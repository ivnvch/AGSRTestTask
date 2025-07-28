using AGSRTestTask.Application.Abstractions.CQRS;
using AGSRTestTask.Application.Patients.Models.Responses;

namespace AGSRTestTask.Application.Patients.Commands.Create;

public record CreatePatientCommand
           (string Gender, 
           DateTime DateOfBirth, 
           bool Active,
           string LastName, 
           string FirstName, 
           string MiddleName,
           string Use): ICommand<CreatePationResponse>;