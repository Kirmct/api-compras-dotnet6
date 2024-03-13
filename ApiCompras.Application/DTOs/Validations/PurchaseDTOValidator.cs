using FluentValidation;

namespace ApiCompras.Application.DTOs.Validations;

public class PurchaseDTOValidator : AbstractValidator<PurchaseDTO>
{
    public PurchaseDTOValidator()
    {
        RuleFor(x => x.CodeErp)
            .NotNull()
            .NotEmpty()
            .WithMessage("Produto deve ser informado!");

        RuleFor(x => x.Document)
           .NotNull()
           .NotEmpty()
           .WithMessage("Comprador deve ser informado!");
    }
}
