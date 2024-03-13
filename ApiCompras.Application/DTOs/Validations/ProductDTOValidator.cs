using FluentValidation;

namespace ApiCompras.Application.DTOs.Validations;

public class ProductDTOValidator : AbstractValidator<ProductDTO>
{
    public ProductDTOValidator()
    {
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .NotEmpty()
            .NotNull()
            .WithMessage("Preço deve ser informado e maior que zero!");

        RuleFor(x => x.CodeErp)
            .NotEmpty()
            .NotNull()
            .WithMessage("Código ERP deve ser informado!");

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Nome deve ser informado!");
    }
}
