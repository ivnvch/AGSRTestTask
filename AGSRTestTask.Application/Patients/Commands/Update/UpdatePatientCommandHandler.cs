using AGSRTestTask.Application.Abstractions;
using AGSRTestTask.Application.Abstractions.CQRS;
using AGSRTestTask.Application.Extensions;
using AGSRTestTask.Application.Patients.Models.Responses;
using AGSRTestTask.Domain.Enum;
using AGSRTestTask.Domain.Result;

namespace AGSRTestTask.Application.Patients.Commands.Update;

public class UpdatePatientCommandHandler : ICommandHandler<UpdatePatientCommand, UpdatePatientResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWrapperRepository _wrapperRepository;

    public UpdatePatientCommandHandler(IUnitOfWork unitOfWork, IWrapperRepository wrapperRepository)
    {
        _unitOfWork = unitOfWork;
        _wrapperRepository = wrapperRepository;
    }

    public async Task<BaseResult<UpdatePatientResponse>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var response = await _wrapperRepository.PatientRepository
            .GetAsync(x => x.Id == request.PatientId, cancellationToken);

        if (response == null)
        {
            return new BaseResult<UpdatePatientResponse>
            {
                ErrorCode = (int)ErrorCodes.PatientNotFound,
                ErrorMessage = "Patient not found"
            };
        }
        
        response.Gender = request.Gender.ToEnum<Gender>();
        response.HumanName.LastName = request.LastName;
        response.HumanName.FirstName = request.FirstName;
        response.HumanName.MiddleName = request.MiddleName;
        response.HumanName.Use = request.Use;
        response.Active = request.Active;
        
        await _wrapperRepository.PatientRepository
            .UpdateAsync(response, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new BaseResult<UpdatePatientResponse>
        {
            Data = new UpdatePatientResponse
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