using ApiCompras.Domain.Entities;
using ApiCompras.Infra.Data.Maps;
using Microsoft.EntityFrameworkCore;

namespace ApiCompras.Infra.Data.Context;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);

        modelBuilder.ApplyConfiguration(new PersonMap());
        modelBuilder.ApplyConfiguration(new ProductMap());
        modelBuilder.ApplyConfiguration(new PurchaseMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new PersonImageMap());
    }

    public DbSet<Person> People { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<PersonImage> PersonImages { get; set; }
}   
