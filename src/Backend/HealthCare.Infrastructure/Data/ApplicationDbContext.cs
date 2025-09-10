using HealthCare.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
    {
        
    }


    public DbSet<Product> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(product =>
        {
            product.HasKey(p => p.Id);
            product.Property(p => p.Name).IsRequired();
            product.Property(p => p.QuantityInStock).IsRequired();
        });
    }
}