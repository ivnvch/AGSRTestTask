using AGSRTestTask.Application.Patients.Repositories;

namespace AGSRTestTask.Application.Abstractions;

public interface IWrapperRepository
{
    IPatientRepository PatientRepository { get; }
}