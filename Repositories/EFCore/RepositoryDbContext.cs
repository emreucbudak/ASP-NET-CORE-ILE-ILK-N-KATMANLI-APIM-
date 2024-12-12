using Entities.Models;
using Microsoft.EntityFrameworkCore;

public class RepositoryDbContext : DbContext
{
    public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Product { get; set; }

}
