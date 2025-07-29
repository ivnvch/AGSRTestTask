using AGSRTestTask.Application.Abstractions;
using AGSRTestTask.Application.Abstractions.CQRS;
using AGSRTestTask.Application.Patients.Models.Responses;
using AGSRTestTask.Domain.Result;

namespace AGSRTestTask.Application.Patients.Queries;

public class GetPatientQueryHandler : IQueryHandler<GetPatientQuery, GetPatientResponse>
{
    private readonly IWrapperRepository  _repository;

    public GetPatientQueryHandler(IWrapperRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResult<GetPatientResponse>> Handle(GetPatientQuery request, CancellationToken cancellationToken)
    {
        var response = await _repository.PatientRepository.GetAsync(x => x.Id == request.PatientId, cancellationToken);

        return new BaseResult<GetPatientResponse>
        {
            Data = new GetPatientResponse
                   (response.Gender.ToString(),
                    response.BirthDate,
                    response.Active,
                    response.HumanName.LastName,
                    response.HumanName.FirstName,
                    response.HumanName.MiddleName,
                    response.HumanName.Use)
        };
    }
}