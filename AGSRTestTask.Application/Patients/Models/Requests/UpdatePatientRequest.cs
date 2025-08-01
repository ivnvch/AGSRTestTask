namespace AGSRTestTask.Application.Patients.Models.Requests;

public record UpdatePatientRequest
       (string Gender, 
        DateTime DateOfBirth, 
        bool Active,
        string LastName, 
        string FirstName, 
        string MiddleName,
        string Use);