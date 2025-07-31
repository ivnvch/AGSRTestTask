using AGSRTestTask.Application.Patients.Repositories;
using AGSRTestTask.Domain.Entities;
using AGSRTestTask.Persistence.Data;

namespace AGSRTestTask.Persistence.Patients.Repositories;

public class PatientRepository:BaseRepository<Patient>, IPatientRepository
{
    public PatientRepository(DataContext context) : base(context)
    {
    }
    
}