using AGSRTestTask.Application.Abstractions;
using AGSRTestTask.Application.Patient.Repositories;
using AGSRTestTask.Persistence.Patient.Repositories;

namespace AGSRTestTask.Persistence.Data;

public class WrapperRepository:IWrapperRepository
{
    private readonly DataContext _context;
    private IPatientRepository _patientRepository;

    public WrapperRepository(DataContext context)
    {
        _context = context;
    }

    public IPatientRepository PatientRepository
    {
        get
        {
            if (_patientRepository == null)
                _patientRepository = new PatientRepository(_context);
            return _patientRepository;
        }
    }
}