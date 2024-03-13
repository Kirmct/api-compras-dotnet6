using ApiCompras.Application.DTOs;
using ApiCompras.Domain.Entities;
using AutoMapper;

namespace ApiCompras.Application.Mappings;

public class DomainToDTOMapping : Profile
{
    public DomainToDTOMapping()
    {
        CreateMap<Person, PersonDTO>();

        CreateMap<Product, ProductDTO>();

        CreateMap<Purchase, PurchaseDTO>()
            .ForMember(d => d.CodeErp, opt => opt.MapFrom(src => src.Product.CodeErp))
            .ForMember(d => d.Document, opt => opt.MapFrom(src => src.Person.Document));
        CreateMap<Purchase, PurchaseDetailDTO>()
            .ForMember(d => d.Person, opt => opt.Ignore())
            .ForMember(d => d.Product, opt => opt.Ignore())
            .ConstructUsing((model, context) =>
            {
                var dto = new PurchaseDetailDTO
                {
                    Product = model.Product.Name,
                    Id = model.Id,
                    Date = model.Date,
                    Person = model.Person.Name
                };
                return dto;
            });
    }
}
