using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.EmployeeValidations
{
    public class EmployeePostDtoValidator : AbstractValidator<EmployeePostDto>
    {
        public EmployeePostDtoValidator()
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
