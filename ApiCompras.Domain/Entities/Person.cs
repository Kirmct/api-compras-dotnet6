using ApiCompras.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCompras.Domain.Entities;

public sealed class Person : Entity
{
    public Person(
        string name,
        string document,
        string phone)
    {
        Validation(name, document, phone);
        Purchases = new List<Purchase>();
        PersonImage = new List<PersonImage>();
    }
    public Person(
        int id, 
        string name,
        string document,
        string phone)
    {
        DomainValidationException
            .When(id < 0, "Id Inválido");
        UpdateId(id);
        Validation(name, document, phone);
        Purchases = new List<Purchase>();
        PersonImage = new List<PersonImage>();
    }
    public string Name { get; private set; }
    public string Document { get; private set; }
    public string Phone { get; private set; }
    public ICollection<Purchase> Purchases { get; set; }
    public ICollection<PersonImage> PersonImage { get; private set; }

    private void Validation(
        string name,
        string document,
        string phone)
    {
        DomainValidationException
            .When(string.IsNullOrEmpty(name), "Nome deve ser informado");
        DomainValidationException
            .When(string.IsNullOrEmpty(document), "Nome deve ser informado");
        DomainValidationException
            .When(string.IsNullOrEmpty(phone), "Nome deve ser informado");

        Name = name;
        Document = document;
        Phone = phone;
    }

}
