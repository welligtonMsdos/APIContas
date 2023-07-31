using APIContas.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIContas.Data.Mappings;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable(nameof(Usuario));

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Nome)
            .HasColumnType("varchar(30)")
            .IsRequired();

        builder.Property(p => p.Senha)
            .HasColumnType("varchar(max)")
            .IsRequired();

        builder.Property(p => p.Ativo)
            .HasColumnType("bit")
            .IsRequired();

        builder.HasQueryFilter(p => p.Ativo);

        builder.HasOne(p => p.Perfil)
               .WithMany(p => p.Usuarios)
               .HasForeignKey(p => p.PerfilId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
