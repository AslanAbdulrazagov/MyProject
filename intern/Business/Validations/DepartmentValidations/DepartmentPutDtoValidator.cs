using FluentValidation;

namespace Business.Validations.DepartmentValidations
{
    public class DepartmentPutDtoValidator : AbstractValidator<DepartmentPutDto>
    {
        public DepartmentPutDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        }
    }
}
