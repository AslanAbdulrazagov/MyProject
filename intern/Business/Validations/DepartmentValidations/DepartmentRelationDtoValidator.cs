using FluentValidation;

namespace Business.Validations.DepartmentValidations
{
    public class DepartmentRelationDtoValidator : AbstractValidator<DepartmentRelationDto>
    {
        public DepartmentRelationDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        }
    }
}
