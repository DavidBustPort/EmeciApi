using FluentValidation;

namespace Application.Features.Doctor.Create
{
    public class CreateDoctorValidator : AbstractValidator<CreateDoctorCommand>
    {
        public CreateDoctorValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                    .WithMessage("El correo electrónico es obligatorio.")
                .EmailAddress()
                    .WithMessage("El correo electrónico no es válido.");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password es obligatorio.");
        }
    }
}
