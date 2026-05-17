using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cw7.Models;

[Table("ComponentTypes")]
public class ComponentType
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(30)]
    public string Abbreviation { get; set; }
    
    [MaxLength(150)]
    public string Name { get; set; }
    
    public ICollection<Component> Components { get; set; } = new List<Component>();
}