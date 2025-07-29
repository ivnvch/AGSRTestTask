namespace AGSRTestTask.Application.Patients.Models.Responses;

public record CreatePatientResponse
    (string Gender, DateTime DateOfBirth, bool Active,
    string LastName, string FirstName, string MiddleName,
    string Use);