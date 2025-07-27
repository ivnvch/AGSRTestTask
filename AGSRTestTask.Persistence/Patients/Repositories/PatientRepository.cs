using AGSRTestTask.Application.Patient.Repositories;
using AGSRTestTask.Persistence.Data;

namespace AGSRTestTask.Persistence.Patient.Repositories;

public class PatientRepository:BaseRepository<Domain.Entities.Patient>, IPatientRepository
{
    public PatientRepository(DataContext context) : base(context)
    {
    }
}