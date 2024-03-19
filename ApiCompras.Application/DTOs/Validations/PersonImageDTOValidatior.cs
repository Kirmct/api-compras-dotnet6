using ApiCompras.Application.DTOs.PersonImage;
using FluentValidation;

namespace ApiCompras.Application.DTOs.Validations;

public class PersonImageDTOValidatior : AbstractValidator<PersonImageDTO>
{
    public PersonImageDTOValidatior()
    {
        RuleFor(x => x.PersonId)
            .GreaterThanOrEqualTo(0)
            .WithMessage("PersonId deve maior que 0!");

        RuleFor(x => x.Image)
            .NotNull()
            .NotEmpty()
            .WithMessage("Image deve ser informado!");
    }
}
