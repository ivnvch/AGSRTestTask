namespace AGSRTestTask.Application.Patients.Models.Responses;

public record GetPatientResponse
           (string Gender, 
            DateTime DateOfBirth, 
            bool Active,
            string LastName, 
            string FirstName, 
            string MiddleName,
            string Use);