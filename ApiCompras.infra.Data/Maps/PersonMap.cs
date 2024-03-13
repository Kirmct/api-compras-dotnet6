using ApiCompras.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCompras.Infra.Data.Maps;

public class PersonMap : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("pessoa");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("idpessoa")
            .UseIdentityColumn();

        builder.Property(x => x.CreateDate).HasColumnName("createdate");
        builder.Property(x => x.UpdateDate).HasColumnName("updatedate");

        builder.Property(x => x.Document).HasColumnName("documento");
        builder.Property(x => x.Name).HasColumnName("nome");
        builder.Property(x => x.Phone).HasColumnName("celular");

        builder.HasMany(x => x.Purchases)
            .WithOne(y => y.Person)
            .HasForeignKey(f => f.PersonId);
    }
}
