using AGSRTestTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AGSRTestTask.Persistence.Patients.Configuration;

public class PatientConfiguration: IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(p => p.BirthDate).IsRequired();
        builder.Property(p => p.Gender).HasConversion<string>().IsRequired();
        builder.Property(p => p.Active).IsRequired();
        
        builder.OwnsOne(p => p.HumanName, humanName =>
        {
            humanName.Property(h => h.FirstName).IsRequired();
            humanName.Property(h => h.LastName).IsRequired();
            humanName.Property(h => h.MiddleName);
            humanName.Property(h => h.Use);
        });
    }
}