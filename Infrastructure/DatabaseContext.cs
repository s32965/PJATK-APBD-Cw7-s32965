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
        
        modelBuilder.Entity<ComponentManufacturer>().HasData(
            new ComponentManufacturer { Id = 1, Abbreviation = "AMD", FullName = "Advanced Micro Devices, Inc.", FoundationDate = new DateOnly(1969, 5, 1) },
            new ComponentManufacturer { Id = 2, Abbreviation = "Corsair", FullName = "Corsair Gaming, Inc.", FoundationDate = new DateOnly(1994, 1, 1) },
            new ComponentManufacturer { Id = 3, Abbreviation = "Intel", FullName = "Intel Corporation", FoundationDate = new DateOnly(1968, 7, 18) }
        );
        
        modelBuilder.Entity<ComponentType>().HasData(
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Central Processing Unit" },
            new ComponentType { Id = 2, Abbreviation = "RAM", Name = "Random Access Memory" },
            new ComponentType { Id = 3, Abbreviation = "GPU", Name = "Graphics Processing Unit" }
        );
        
        modelBuilder.Entity<Component>().HasData(
            new Component { 
                Code = "CPU-AMD-01",
                Name = "AMD Ryzen 9 7950X", 
                Description = "High-performance 16-core desktop processor.", 
                ComponentManufacturersId = 1, 
                ComponentTypesId = 1 
            },
            new Component { 
                Code = "RAM-COR-01",
                Name = "Corsair Vengeance 32GB", 
                Description = "DDR5 6000MHz Memory Kit.", 
                ComponentManufacturersId = 2, 
                ComponentTypesId = 2 
            },
            new Component { 
                Code = "GPU-INT-01",
                Name = "Intel Arc A770", 
                Description = "16GB GDDR6 Graphics Card.", 
                ComponentManufacturersId = 3, 
                ComponentTypesId = 3 
            }
        );
        
        modelBuilder.Entity<PC>().HasData(
            new PC { Id = 1, Name = "Office Workstation", Weight = 5.5f, Warranty = 12, CreatedAt = new DateTime(2023, 1, 15, 9, 0, 0), Stock = 15 },
            new PC { Id = 2, Name = "Ultimate Gaming Rig", Weight = 12.0f, Warranty = 36, CreatedAt = new DateTime(2023, 10, 1, 14, 30, 0), Stock = 5 },
            new PC { Id = 3, Name = "Home Media Server", Weight = 8.2f, Warranty = 24, CreatedAt = new DateTime(2024, 2, 20, 11, 15, 0), Stock = 2 }
        );
        
        modelBuilder.Entity<PCComponent>().HasData(
            new PCComponent { PCId = 1, ComponentCode = "GPU-INT-01", Amount = 1 },
            new PCComponent { PCId = 2, ComponentCode = "CPU-AMD-01", Amount = 1 },
            new PCComponent { PCId = 2, ComponentCode = "RAM-COR-01", Amount = 2 },
            new PCComponent { PCId = 3, ComponentCode = "RAM-COR-01", Amount = 4 }
        );
    }
    
    
}