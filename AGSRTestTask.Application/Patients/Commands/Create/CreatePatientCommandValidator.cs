using AGSRTestTask.Domain.Enum;
using FluentValidation;

namespace AGSRTestTask.Application.Patients.Commands.Create;

public class CreatePatientCommandValidator: AbstractValidator<CreatePatientCommand>
{
    public CreatePatientCommandValidator()
    {
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.");

        RuleFor(x => x.DateOfBirth)
            .LessThan(DateTime.UtcNow).WithMessage("Birth date must be in the past.");

        RuleFor(x => x.Gender)
            .Must(g => Enum.GetNames<Gender>()
                .Any(gender => string.Equals(g, gender, StringComparison.OrdinalIgnoreCase)))
            .WithMessage("Gender must be one of: male, female, other, unknown.");

        RuleFor(x => x.Use)
            .NotEmpty().WithMessage("Use field is required.");
    }
}