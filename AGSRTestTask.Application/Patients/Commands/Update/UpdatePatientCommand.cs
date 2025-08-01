using AGSRTestTask.Application.Abstractions.CQRS;
using AGSRTestTask.Application.Patients.Models.Requests;
using AGSRTestTask.Application.Patients.Models.Responses;

namespace AGSRTestTask.Application.Patients.Commands.Update;

public record UpdatePatientCommand
       (Guid PatientId, 
        string Gender, 
        DateTime DateOfBirth, 
        bool Active,
        string LastName, 
        string FirstName, 
        string MiddleName,
        string Use)
    : ICommand<UpdatePatientResponse>;