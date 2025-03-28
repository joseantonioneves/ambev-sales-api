using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM;

public class DefaultContext : DbContext
{
    public DbSet<User> Users { get; set; }
    // Implementação para suporte a Sales
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleItem> SaleItems { get; set; }

    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TODO: Implementar mapeamento das entidades (Fluent API)
        modelBuilder.Entity<Sale>(entity => {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.SaleNumber).IsRequired();
            entity.Property(s => s.SaleDate).IsRequired();
            entity.Property(s => s.TotalAmount).HasColumnType("decimal(18,2)");

            // TODO: Relacionamento com SaleItem (1:N) e delete em cascata
            entity.HasMany(s => s.Products)
                  .WithOne()
                  .HasForeignKey(si => si.SaleId) // propriedade na classe SaleItem
                  .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<SaleItem>(entity =>
        {
            entity.HasKey(si => si.Id);
            entity.Property(si => si.UnitPrice).HasColumnType("decimal(18,2)");
            entity.Property(si => si.Discount).HasColumnType("decimal(4,2)");
        });

        // TODO: Aplica outras configurações a partir de assemblies
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DefaultContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseNpgsql(
               connectionString,
               b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
                     .EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
        );
        return new DefaultContext(builder.Options);
    }
}