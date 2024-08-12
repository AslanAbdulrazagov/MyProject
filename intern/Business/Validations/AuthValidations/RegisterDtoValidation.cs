using FluentValidation;

namespace Business.Validations.AuthValidations;

public class RegisterDtoValidation:AbstractValidator<RegisterDto>
{
    public RegisterDtoValidation()
    {
        RuleFor(x => x.Fullname).NotNull().MaximumLength(256).MinimumLength(5);
        RuleFor(x => x.Email).NotNull().MaximumLength(256).MinimumLength(5);
        RuleFor(x => x.Password).NotNull().MaximumLength(64).MinimumLength(6);
        RuleFor(x => x.ConfirmPassword).NotNull().MaximumLength(64).MinimumLength(6);
        RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("The password and confirmation password do not match.");
    }
}
