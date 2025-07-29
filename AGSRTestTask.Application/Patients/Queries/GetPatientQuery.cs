using AGSRTestTask.Application.Abstractions.CQRS;
using AGSRTestTask.Application.Patients.Models.Responses;

namespace AGSRTestTask.Application.Patients.Queries;

public record GetPatientQuery(Guid PatientId) : IQuery<GetPatientResponse>;