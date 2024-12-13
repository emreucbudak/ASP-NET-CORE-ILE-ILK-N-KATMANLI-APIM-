using Entities.Models;
using Microsoft.EntityFrameworkCore;

public class RepositoryDbContext : DbContext
{
    public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Product { get; set; }
    public DbSet<Category> Category { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Category ve Product arasındaki bire-çok ilişkiyi tanımlıyoruz
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category) // Bir ürünün bir kategorisi var
            .WithMany(c => c.Products) // Bir kategorinin birden fazla ürünü var
            .HasForeignKey(p => p.CategoryID) // Yabancı anahtar Product tablosunda
            .OnDelete(DeleteBehavior.Cascade); // Kategori silindiğinde ilişkili ürünler de silinir

    }

}
