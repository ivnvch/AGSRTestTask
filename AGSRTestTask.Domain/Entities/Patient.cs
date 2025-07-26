using AGSRTestTask.Domain.Common.Interfaces;
using AGSRTestTask.Domain.Enum;

namespace AGSRTestTask.Domain.Entities;

public class Patient:IEntityId<Guid>
{
    public Guid Id { get; set; } =  Guid.NewGuid();
    
    HumanName Name { get; set; }
    public Gender  Gender { get; private set; }
    
    public DateTime BirthDate { get; private set; }
    private bool Active { get; set; }
    
    public Patient(HumanName name, Gender gender, DateTime birthDate, bool active)
    {
        if (string.IsNullOrWhiteSpace(name.LastName))
            throw new ArgumentException("LastName is required");

        Name = name;
        Gender = gender;
        BirthDate = birthDate;
        Active = active;
    }
    
}