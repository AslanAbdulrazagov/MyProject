using FluentValidation;

namespace Business.Validations.AddressValidations
{
    public class AddressPutDtoValidator : AbstractValidator<AddressPutDto>
    {
        public AddressPutDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required.");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Street is required.");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
            RuleFor(x => x.State).NotEmpty().WithMessage("State is required.");
        }
    }
}
