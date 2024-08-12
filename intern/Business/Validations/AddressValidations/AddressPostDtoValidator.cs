using FluentValidation;

namespace Business.Validations.AddressValidations
{
    public class AddressPostDtoValidator : AbstractValidator<AddressPostDto>
    {
        public AddressPostDtoValidator()
        {
            RuleFor(x => x.Street).NotEmpty().WithMessage("Street is required.");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
            RuleFor(x => x.State).NotEmpty().WithMessage("State is required.");
        }
    }
}
