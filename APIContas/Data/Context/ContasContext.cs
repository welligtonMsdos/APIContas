﻿using APIContas.Data.Mappings;
using APIContas.Model;
using Microsoft.EntityFrameworkCore;

namespace APIContas.Data.Context;

public class ContasContext : DbContext
{
    public ContasContext(DbContextOptions<ContasContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<Conta> Conta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoriaMap());
        modelBuilder.ApplyConfiguration(new ContaMap());
    }
}
