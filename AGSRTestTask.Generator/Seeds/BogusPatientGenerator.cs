using System.Dynamic;
using AGSRTestTask.Application.Patients.Commands.Create;
using AGSRTestTask.Generator.Abstraction;
using Bogus;
using PatientDataGenerator;

namespace AGSRTestTask.Generator.Seeds;

public class BogusPatientGenerator : IPatientGenerator
{
    private readonly Faker<FakerDTO> _faker;

    public BogusPatientGenerator()
    {
        _faker = new Faker<FakerDTO>()
            .RuleFor(p => p.FirstName, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.MiddleName, f => f.Name.FirstName())
            .RuleFor(p => p.Use, f => f.PickRandom("official", "nickname", "maiden")) 
            .RuleFor(p => p.Gender, f => f.PickRandom("Male", "Female", "Unknown", "Other")) 
            .RuleFor(p => p.DateOfBirth, f => f.Date.Past(50, DateTime.Now.AddYears(-18)).ToUniversalTime())
            .RuleFor(p => p.Active, f => f.Random.Bool());
    }
    public CreatePatientCommand Generate()
    {
        var dto = _faker.Generate();

        return new CreatePatientCommand(
            Gender: dto.Gender,
            DateOfBirth: dto.DateOfBirth,
            Active: dto.Active,
            LastName: dto.LastName,
            FirstName: dto.FirstName,
            MiddleName: dto.MiddleName,
            Use: dto.Use);
    }
    
    
}