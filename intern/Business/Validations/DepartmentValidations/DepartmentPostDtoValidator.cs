using FluentValidation;

namespace Business.Validations.DepartmentValidations
{
    public class DepartmentPostDtoValidator : AbstractValidator<DepartmentPostDto>
    {
        public DepartmentPostDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        }
    }
}
