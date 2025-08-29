using Microsoft.EntityFrameworkCore;
using ECommerceInterno.Models;

namespace ECommerceInterno.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Produto> Produtos => Set<Produto>();
    public DbSet<Compra>  Compras  => Set<Compra>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(e =>
        {
            e.Property(p => p.Nome).IsRequired().HasMaxLength(150);
            e.Property(p => p.CPF).IsRequired().HasMaxLength(14);
            e.HasIndex(p => p.CPF).IsUnique();
            e.Property(p => p.Email).HasMaxLength(150);
            e.Property(p => p.Senha).HasMaxLength(200);
        });

        modelBuilder.Entity<Produto>(e =>
        {
            e.Property(p => p.Descricao).IsRequired().HasMaxLength(150);
            e.Property(p => p.PrecoUnitario).HasColumnType("decimal(18,2)");

            //Isso só faz sentido se Quantidade for do tipo string. Se for int, HasMaxLength não tem efeito
            //  e deve ser removido.
            e.Property(p => p.Quantidade).IsRequired();
        });

        modelBuilder.Entity<Compra>(e =>
        {
            e.HasOne(c => c.Cliente)
             .WithMany(c => c.Compras)
             .HasForeignKey(c => c.ClienteId)
             .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(c => c.Produto)
             .WithMany(p => p.Compras)
             .HasForeignKey(c => c.ProdutoId)
             .OnDelete(DeleteBehavior.Restrict); // impede que o produto seja deletado se houver compras associadas.

        });
    }
}
