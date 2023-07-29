using APIContas.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIContas.Data.Mappings;

public class ContaMap : IEntityTypeConfiguration<Conta>
{
    public void Configure(EntityTypeBuilder<Conta> builder)
    {
        builder.ToTable(nameof(Conta));

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Descricao)
            .HasColumnType("varchar(30)")
            .IsRequired();

        builder.Property(p => p.Ativo)
            .HasColumnType("bit")
            .IsRequired();

        builder.Property(p => p.Valor)
             .HasColumnType("decimal(10,2)")
             .IsRequired();

        builder.Property(p => p.DataInclusao)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(p => p.Mes)
           .HasColumnType("int")
           .IsRequired();


        builder.HasQueryFilter(p => p.Ativo);
    }
}
