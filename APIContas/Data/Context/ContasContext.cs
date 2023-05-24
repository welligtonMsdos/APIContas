using APIContas.Model;
using Microsoft.EntityFrameworkCore;

namespace APIContas.Data.Context;

public class ContasContext : DbContext
{
    public ContasContext(DbContextOptions<ContasContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categoria { get; set; }
}
