using ApiCompras.Domain.Validation;

namespace ApiCompras.Domain.Entities;

public sealed class Product : Entity
{
    public Product(string name, string codeErp, decimal price)
    {
        Validation(name, codeErp, price);
        Purchases = new List<Purchase>();
    }

    public Product(int id, string name, string codeErp, decimal price)
    {
        DomainValidationException
            .When(id < 0, "Id inválido");
        UpdateId(id);
        Validation(name, codeErp, price);
        Purchases = new List<Purchase>();
    }

    public string Name { get; private set; }
    public string CodeErp { get; private set; }
    public decimal Price { get; private set; }
    public ICollection<Purchase> Purchases { get; set; }


    public void Validation(string name, string codeErp, decimal price)
    {
        DomainValidationException
            .When(string.IsNullOrEmpty(name), "Nome inválido");
        DomainValidationException
           .When(string.IsNullOrEmpty(codeErp), "Código inválido");
        DomainValidationException
           .When(price < 0, "Preço inválido");

        Name = name;
        CodeErp = codeErp;
        Price = price;
    }
}
