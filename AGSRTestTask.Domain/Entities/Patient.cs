using AGSRTestTask.Domain.Enum;

namespace AGSRTestTask.Domain.Entities;

public class Patient:Entity
{
    public Guid Id { get; set; } =  Guid.NewGuid();
    
    public HumanName HumanName { get; set; }
    public Gender  Gender { get; private set; }
    
    public DateTime BirthDate { get; private set; }
    public bool Active { get; set; }
    
    private Patient(){}
    public Patient(HumanName humanName, Gender gender, DateTime birthDate, bool active)
    {
        if (string.IsNullOrWhiteSpace(humanName.LastName))
            throw new ArgumentException("LastName is required");

        HumanName = humanName;
        Gender = gender;
        BirthDate = birthDate;
        Active = active;
    }
    
}