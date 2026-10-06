using Desafio1.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio1.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Venda> Vendas { get; set; }

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Venda>(entity =>
        {
            entity.HasKey(v => v.Id);
            entity.Property(v => v.Id).ValueGeneratedOnAdd();
            entity.Property(v => v.vendedor).IsRequired();
            entity.Property(v => v.valor).IsRequired();
        });

    }
}