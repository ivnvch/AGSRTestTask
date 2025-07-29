using AGSRTestTask.Application.Abstractions;
using AGSRTestTask.Application.Abstractions.CQRS;
using AGSRTestTask.Application.Patients.Models.Responses;
using AGSRTestTask.Domain.Entities;
using AGSRTestTask.Domain.Enum;
using AGSRTestTask.Domain.Result;

namespace AGSRTestTask.Application.Patients.Commands.Create;

public class CreatePatientCommandHandler: ICommandHandler<CreatePatientCommand, CreatePatientResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWrapperRepository _wrapperRepository;

    public CreatePatientCommandHandler(IUnitOfWork unitOfWork, IWrapperRepository wrapperRepository)
    {
        _unitOfWork = unitOfWork;
        _wrapperRepository = wrapperRepository;
    }

    public async Task<BaseResult<CreatePatientResponse>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var genderParsed = Enum.TryParse<Gender>(request.Gender, true, out var gender)
                ? gender
                : throw new ArgumentException("Invalid gender value");
            
            var humanName = new HumanName
                   (request.Use, 
                    request.LastName, 
                    request.FirstName, 
                    request.MiddleName
                   );
            
            Patient patient = new Patient
                   (humanName: humanName, 
                    gender: genderParsed, 
                    DateTime.UtcNow, 
                    active: request.Active 
                   );

            await _wrapperRepository.PatientRepository.AddAsync(patient, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            
            return new BaseResult<CreatePatientResponse>
            {
                Data = new CreatePatientResponse
                        (request.Gender,
                        request.DateOfBirth,
                        request.Active,
                        request.LastName,
                        request.FirstName,
                        request.MiddleName,
                        request.Use)
            };
        }
        catch (Exception ex)
        {
            return new BaseResult<CreatePatientResponse>
            {
                ErrorCode = (int)ErrorCodes.InternalServerError,
                ErrorMessage = ex.Message
            };
        }
    }
}