namespace AGSRTestTask.Application.Patients.Models.Requests;

public record UpdatePatientRequest
       (Guid PatientId,
        string Gender, 
        DateTime DateOfBirth, 
        bool Active,
        string LastName, 
        string FirstName, 
        string MiddleName,
        string Use);