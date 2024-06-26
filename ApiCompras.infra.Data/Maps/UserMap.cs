﻿using ApiCompras.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCompras.Infra.Data.Maps;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("usuario");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("idusuario")
            .UseIdentityColumn();

        builder.Property(x => x.Email)
            .HasColumnName("email");
        builder.Property(x => x.Password)
            .HasColumnName("senha");

        builder.HasMany(x => x.UserPermissions)
            .WithOne(y => y.User)
            .HasForeignKey(z => z.UserId);
    }
}
