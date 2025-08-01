using AGSRTestTask.Application.Patients.Commands.Create;

namespace AGSRTestTask.Generator.Abstraction;

public interface IPatientBatchSender
{
    Task<bool> SendBatchAsync(List<CreatePatientCommand> patients);
}