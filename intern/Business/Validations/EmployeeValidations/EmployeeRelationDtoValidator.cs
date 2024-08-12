using FluentValidation;

namespace Business.Validations.EmployeeValidations
{
    public class EmployeeRelationDtoValidator : AbstractValidator<EmployeeRelationDto>
    {
        public EmployeeRelationDtoValidator()
        {
            RuleFor(x => x.Fullname).NotEmpty().WithMessage("Fullname is required.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
                                 .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required.")
                                       .Matches(@"^\+?\d{10,15}$").WithMessage("Invalid phone number format.");
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("Department ID is required.");
        }
    }
}
