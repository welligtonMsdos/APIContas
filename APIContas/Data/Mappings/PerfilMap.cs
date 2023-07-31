using APIContas.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIContas.Data.Mappings;

public class PerfilMap : IEntityTypeConfiguration<Perfil>
{
    public void Configure(EntityTypeBuilder<Perfil> builder)
    {
        builder.ToTable(nameof(Perfil));

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Descricao)
            .HasColumnType("varchar(30)")
            .IsRequired();

        builder.Property(p => p.Ativo)
            .HasColumnType("bit")
            .IsRequired();

        builder.HasQueryFilter(p => p.Ativo);
    }
}
