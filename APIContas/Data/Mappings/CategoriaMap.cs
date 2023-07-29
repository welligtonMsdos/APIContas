using APIContas.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIContas.Data.Mappings;

public class CategoriaMap : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable(nameof(Categoria));

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
