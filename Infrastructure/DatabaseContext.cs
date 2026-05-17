using Microsoft.EntityFrameworkCore;
using Cw7.Models;

namespace Cw7.Infrastructure;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<PC> PCs { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    
    
}