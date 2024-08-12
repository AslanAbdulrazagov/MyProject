using FluentValidation;

namespace Business.Validations.DepartmentValidations
{
    public class DepartmentGetDtoValidator : AbstractValidator<DepartmentGetDto>
    {
        public DepartmentGetDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        }
    }
}
