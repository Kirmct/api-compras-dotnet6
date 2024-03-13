using ApiCompras.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCompras.Infra.Data.Maps;

public class PurchaseMap : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable("compra");
        builder.HasKey(p => p.Id);

        builder.Property(x => x.Id)
            .HasColumnName("idcompra")
            .UseIdentityColumn();

        builder.Property(x => x.ProductId)
            .HasColumnName("idproduto");

        builder.Property(x => x.PersonId)
           .HasColumnName("idpessoa");

        builder.Property(x => x.CreateDate).HasColumnName("createdate");
        builder.Property(x => x.UpdateDate).HasColumnName("updatedate");

        builder.Property(x => x.Date).HasColumnName("datacompra");

        builder.HasOne(x => x.Person)
            .WithMany(y => y.Purchases);

        builder.HasOne(x => x.Product)
           .WithMany(y => y.Purchases);
    }
}
