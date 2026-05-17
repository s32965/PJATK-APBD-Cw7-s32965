using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Cw7.Models;

[Table("PCComponents"), PrimaryKey(nameof(PCId), nameof(ComponentCode))]
public class PCComponent
{
    public int PCId { get; set; }

    [ForeignKey(nameof(PCId))] public PC PC { get; set; } = null!;
    
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; }

    [ForeignKey(nameof(ComponentCode))] public Component Component { get; set; } = null!;
    
    public int Amount { get; set; }
}