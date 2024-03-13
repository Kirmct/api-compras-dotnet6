using ApiCompras.Application.DTOs;
using ApiCompras.Domain.Entities;
using AutoMapper;

namespace ApiCompras.Application.Mappings;

public class DTOToDomainMapping : Profile
{
    public DTOToDomainMapping()
    {
        CreateMap<PersonDTO, Person>();
        CreateMap<ProductDTO, Product>();
        CreateMap<PurchaseDTO, Purchase>();
    }
}
