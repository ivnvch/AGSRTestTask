namespace AGSRTestTask.Application.Patients.Models.Requests;

public record CreatePatientRequest
    (string Gender, DateTime DateOfBirth, bool Active,
        string LastName, string FirstName, string MiddleName,
        string Use);