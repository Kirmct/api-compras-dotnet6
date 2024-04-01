using ApiCompras.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCompras.Infra.Data.Maps;

public class UserPermissionMap : IEntityTypeConfiguration<UserPermission>
{
    public void Configure(EntityTypeBuilder<UserPermission> builder)
    {
        builder.ToTable("permissaousuario");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("idpermissaousuario")
            .UseIdentityColumn();

        builder.Property(x => x.UserId)
            .HasColumnName("idusuario");

        builder.Property(x => x.PermissionId)
            .HasColumnName("idpermissao");

        builder.HasOne(x => x.Permission)
            .WithMany(y => y.UserPermissions);

        builder.HasOne(x => x.User)
            .WithMany(y => y.UserPermissions);
    }
}
