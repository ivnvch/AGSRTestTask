using System.Reflection;
using AGSRTestTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AGSRTestTask.Persistence;

public class DataContext:DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Patient> Patients { get; set; }
    
    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
        /*Database.EnsureDeleted();
        Database.EnsureCreated()*/;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}