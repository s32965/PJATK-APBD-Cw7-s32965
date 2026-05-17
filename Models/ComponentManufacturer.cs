using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cw7.Models;

[Table("ComponentManufacturers")]
public class ComponentManufacturer
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(30)]
    public string Abbreviation { get; set; }
    
    [MaxLength(300)]
    public string FullName { get; set; }
    
    [Column(TypeName = "date")]
    public DateOnly FoundationDate { get; set; }
    
    public ICollection<Component> Components { get; set; } = new List<Component>();
}