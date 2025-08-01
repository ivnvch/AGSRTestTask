using AGSRTestTask.Application.Abstractions.CQRS;

namespace AGSRTestTask.Application.Patients.Commands.Delete;

public record DeletePatientCommand(Guid PatientId): ICommand<bool>;