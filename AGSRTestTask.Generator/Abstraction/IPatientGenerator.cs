using AGSRTestTask.Application.Patients.Commands.Create;

namespace AGSRTestTask.Generator.Abstraction;

public interface IPatientGenerator
{
    CreatePatientCommand Generate();
}