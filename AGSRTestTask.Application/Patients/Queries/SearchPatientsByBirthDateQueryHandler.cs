using AGSRTestTask.Application.Abstractions;
using AGSRTestTask.Application.Abstractions.CQRS;
using AGSRTestTask.Application.Extensions;
using AGSRTestTask.Application.Patients.Models.Responses;
using AGSRTestTask.Domain.Entities;
using AGSRTestTask.Domain.Result;
using Microsoft.EntityFrameworkCore;

namespace AGSRTestTask.Application.Patients.Queries;

public class
    SearchPatientsByBirthDateQueryHandler : IQueryHandler<SearchPatientsByBirthDateQuery, List<GetPatientResponse>>
{
    private readonly IWrapperRepository _repository;

    public SearchPatientsByBirthDateQueryHandler(IWrapperRepository repository)
    {
        _repository = repository;
    }
    
    private static readonly Dictionary<string, Func<IQueryable<Patient>, DateTime, IQueryable<Patient>>> Filters =
        new(StringComparer.OrdinalIgnoreCase)
        {
            ["eq"] = (q, d) => q.Where(p => p.BirthDate.Date == d),
            ["ne"] = (q, d) => q.Where(p => p.BirthDate.Date != d),
            ["gt"] = (q, d) => q.Where(p => p.BirthDate.Date > d),
            ["lt"] = (q, d) => q.Where(p => p.BirthDate.Date < d),
            ["ge"] = (q, d) => q.Where(p => p.BirthDate.Date >= d),
            ["le"] = (q, d) => q.Where(p => p.BirthDate.Date <= d),
            ["sa"] = (q, d) => q.Where(p => p.BirthDate.Date > d),
            ["eb"] = (q, d) => q.Where(p => p.BirthDate.Date < d),
            ["ap"] = (q, d) => q.Where(p => Math.Abs((p.BirthDate - d).TotalDays) <= 7)
        };

    public async Task<BaseResult<List<GetPatientResponse>>> Handle(SearchPatientsByBirthDateQuery request,
        CancellationToken cancellationToken)
    {
        if (request.BirthDateFilters == null || !request.BirthDateFilters.Any())
            throw new ArgumentException("At least one birthDate filter is required");

        var parsedFilters = ParseDateFilters(request.BirthDateFilters);

        IQueryable<Patient> query = _repository.PatientRepository.GetAll();

        foreach (var (prefix, date) in parsedFilters)
        {
            if (!Filters.TryGetValue(prefix, out var filterFunc))
                throw new ArgumentException($"Unsupported prefix '{prefix}'");

            query = filterFunc(query, date);
        }

        var patients = await query
            .Select(p => new GetPatientResponse(
                p.Gender.ToString(),
                p.BirthDate,
                p.Active,
                p.HumanName.LastName,
                p.HumanName.FirstName,
                p.HumanName.MiddleName,
                p.HumanName.Use
            ))
            .ToListAsync(cancellationToken);

        return new BaseResult<List<GetPatientResponse>> { Data = patients };
    }


    private static IEnumerable<(string prefix, DateTime date)> ParseDateFilters(IEnumerable<string> rawFilters)
    {
        foreach (var filter in rawFilters)
        {
            if (string.IsNullOrWhiteSpace(filter))
                throw new ArgumentException("BirthDate filter cannot be empty");

            var matchedPrefix = Filters.Keys
                .FirstOrDefault(p => filter.StartsWith(p, StringComparison.OrdinalIgnoreCase));

            var prefix = matchedPrefix ?? "eq";
            var datePart = matchedPrefix is not null 
                ? filter.Substring(matchedPrefix.Length) 
                : filter;

            yield return (prefix, ParseDateTimeExtension.ParseDateTime(datePart));
        }
    }
}