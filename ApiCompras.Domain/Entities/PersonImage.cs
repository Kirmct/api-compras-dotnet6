using ApiCompras.Domain.Validation;

namespace ApiCompras.Domain.Entities;

public class PersonImage : Entity
{
    public PersonImage(
        int personId,
        string? imageUri, 
        string imageBase)
    {
        Validation(personId);
        ImageUri = imageUri;
        ImageBase = imageBase;
    }

    public int PersonId { get; private set; }
    public Person Person { get; set; }
    public string? ImageUri { get; private set; }
    public string? ImageBase { get; private set; }
    
    private void Validation(
        int personId)
    {
        DomainValidationException
            .When(personId == 0, "Id pessoa deve ser informado");

        PersonId = personId;
    }
}
