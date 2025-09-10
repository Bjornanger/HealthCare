using System.Runtime.InteropServices.Marshalling;
using HealthCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
    {
        
    }


    public DbSet<Product> Products { get; set; }
    public DbSet<UnitType> UnitTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(product =>
        {
            product.HasKey(p => p.Id);
            product.Property(p => p.Name).IsRequired();
            product.Property(p => p.QuantityInStock).IsRequired();
            product.HasOne(p => p.UnitType)
                .WithMany()
                .HasForeignKey(p => p.UnitTypeId)
                .IsRequired();
        });

        modelBuilder.Entity<UnitType>(unit =>
        {
            unit.HasKey(u => u.Id);
            unit.Property(u => u.Name).IsRequired();
        });
    }
}