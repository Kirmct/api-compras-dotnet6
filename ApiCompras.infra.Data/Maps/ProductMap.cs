﻿using ApiCompras.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCompras.Infra.Data.Maps;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("produto");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("idproduto")
            .UseIdentityColumn();

        builder.Property(x => x.CreateDate).HasColumnName("createdate");
        builder.Property(x => x.UpdateDate).HasColumnName("updatedate");

        builder.Property(x => x.Name).HasColumnName("nome");
        builder.Property(x => x.CodeErp).HasColumnName("codigoerp");
        builder.Property(x => x.Price) .HasColumnName("preco");

        builder.HasMany(x => x.Purchases)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);
    }
}
