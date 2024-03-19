using ApiCompras.Application.Mappings;
using ApiCompras.Application.Services;
using ApiCompras.Application.Services.Interface;
using ApiCompras.Domain.Authentication;
using ApiCompras.Domain.Integration;
using ApiCompras.Domain.Repositories;
using ApiCompras.Infra.Data.Authentication;
using ApiCompras.Infra.Data.Context;
using ApiCompras.Infra.Data.Integration;
using ApiCompras.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiCompras.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApiDbContext>(opt =>
        opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IPurchaseRepository, PurchaseRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITokenGenerator, TokenGenerator>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPersonImageRepository, PersonImageRepository>();
        services.AddScoped<ISavePersonImage, SavePersonImage>();

        return services;
    }

    public static IServiceCollection AddServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(DomainToDTOMapping));

        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IPurchaseService, PurchaseService>();
        services.AddScoped<IUserService, UserService>();        
        services.AddScoped<IPersonImageService, PersonImageService>();        

        return services;
    }
}
