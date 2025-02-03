using FluentValidation;

namespace ClenaArch.Application.Members.Commands.Validations;

public class CreateMemberCommandValidation : AbstractValidator<CreateMemberCommand>
{
    public CreateMemberCommandValidation()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty().WithMessage("Please ensure you have entered the FirstName")
            .Length(4, 100).WithMessage("The FirstName must have between 4 and 100 charcters");

        RuleFor(c => c.LastName)
            .NotEmpty().WithMessage("Please ensure you have entered the LastName")
            .Length(4, 100).WithMessage("The LastName must have between 4 ad 100 characters");

        RuleFor(c => c.Gender)
            .NotNull()
            .MinimumLength(4).WithMessage("The Gernder must be a valid information");

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Please ensure you have entered the Email")
            .EmailAddress().WithMessage("The Email must be a valid email address");

        RuleFor(c => c.IsActive)
            .NotNull().WithMessage("Please ensure you have entered the IsActive");
    }
}
