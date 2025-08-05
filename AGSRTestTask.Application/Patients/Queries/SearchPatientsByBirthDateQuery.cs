using AGSRTestTask.Application.Abstractions.CQRS;
using AGSRTestTask.Application.Patients.Models.Responses;

namespace AGSRTestTask.Application.Patients.Queries;

public record SearchPatientsByBirthDateQuery(List<string> BirthDateFilters) : IQuery<List<GetPatientResponse>>;