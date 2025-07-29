using AGSRTestTask.Application.Abstractions;
using AGSRTestTask.Application.Abstractions.CQRS;
using AGSRTestTask.Domain.Enum;
using AGSRTestTask.Domain.Result;
using Serilog;

namespace AGSRTestTask.Application.Patients.Commands.Delete;

public class DeletePatientCommandHandler: ICommandHandler<DeletePatientCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWrapperRepository _wrapperRepository;
    private readonly ILogger _logger;

    public DeletePatientCommandHandler(IUnitOfWork unitOfWork, IWrapperRepository wrapperRepository, ILogger logger)
    {
        _unitOfWork = unitOfWork;
        _wrapperRepository = wrapperRepository;
        _logger = logger;
    }

    public async Task<BaseResult<bool>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        var response = await _wrapperRepository.PatientRepository.GetAsync(x => x.Id == request.PatientId, cancellationToken);

        if (response is null)
        {
            return new BaseResult<bool>
            {
                ErrorCode = (int)ErrorCodes.PatientNotFound,
                ErrorMessage = "Patient not found"
            };
        }
        
        await _wrapperRepository.PatientRepository.DeleteAsync(response, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return new BaseResult<bool>
        {
            Data = true,
        };;
    }
}