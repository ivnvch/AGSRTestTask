using AGSRTestTask.Application.Abstractions;
using AGSRTestTask.Application.Patient.Repositories;
using AGSRTestTask.Persistence.Data;
using AGSRTestTask.Persistence.Patient.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AGSRTestTask.Persistence;

public static class DependencyInjection
{
    public static void AddPersistenceExtensions(this IServiceCollection services)
    {
        services.AddDbContext<DataContext>();
        services.RegisterRepository();
    }


    private static void RegisterRepository(this IServiceCollection services)
    {
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IWrapperRepository, WrapperRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}