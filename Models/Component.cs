using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cw7.Models;

[Table("Components")]
public class Component
{
    [Key]
    [Column(TypeName = "char(10)")]
    public string Code { get; set; }
    
    [MaxLength(300)]
    public string Name { get; set; }
    
    [Column(TypeName = "nvarchar(max)")]
    public string Description { get; set; }
    
    public int ComponentManufacturersId { get; set; }

    [ForeignKey(nameof(ComponentManufacturersId))]
    public ComponentManufacturer ComponentManufacturer { get; set; } = null!;
    
    public int ComponentTypesId { get; set; }

    [ForeignKey(nameof(ComponentTypesId))] 
    public ComponentType ComponentType { get; set; } = null!;

}