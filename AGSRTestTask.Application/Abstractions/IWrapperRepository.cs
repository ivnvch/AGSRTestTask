using AGSRTestTask.Application.Patient.Repositories;

namespace AGSRTestTask.Application.Abstractions;

public interface IWrapperRepository
{
    IPatientRepository PatientRepository { get; }
}