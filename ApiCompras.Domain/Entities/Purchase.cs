using ApiCompras.Domain.Validation;

namespace ApiCompras.Domain.Entities;

public sealed class Purchase : Entity
{
    public Purchase(int productId, int personId)
    {
        Validation(productId, personId);
    }

    public Purchase(int id, int productId, int personId)
    {
        DomainValidationException
          .When(id < 0, "Id inválido");

        UpdateId(id);
        Validation(productId, personId);
    }

    public int ProductId { get; private set; }
    public Product Product { get; set; }
    public int PersonId { get; private set; }
    public Person Person { get; set; }
    public DateTime Date { get; private set; }

    public void Validation(int productId, int personId)
    {
        DomainValidationException
            .When(productId <= 0, "Produto inválido");
        DomainValidationException
           .When(personId <= 0, "Pessoa inválida");        

        ProductId = productId;
        PersonId = personId;
        Date = DateTime.Now;
    }

    public void UpdateEntity(int id, int productId, int personId)
    {
        DomainValidationException
          .When(id < 0, "Id inválido");

        UpdateId(id);
        Validation(productId, personId);
    }
}
