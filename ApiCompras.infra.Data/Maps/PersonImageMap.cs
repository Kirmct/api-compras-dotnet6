using ApiCompras.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCompras.Infra.Data.Maps;

public class PersonImageMap : IEntityTypeConfiguration<PersonImage>
{
    public void Configure(EntityTypeBuilder<PersonImage> builder)
    {
        builder.ToTable("pessoaimagem");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("idimagem")
            .UseIdentityColumn();

        builder.Property(x => x.CreateDate).HasColumnName("createdate");
        builder.Property(x => x.UpdateDate).HasColumnName("updatedate");

        builder.Property(x => x.ImageUri)
           .HasColumnName("imagemurl");
        builder.Property(x => x.ImageBase)
            .HasColumnName("pimagembase");

        builder.Property(x => x.PersonId)
            .HasColumnName("idpessoa");

        builder.HasOne(x => x.Person)
            .WithMany(x => x.PersonImage);
    }
}
