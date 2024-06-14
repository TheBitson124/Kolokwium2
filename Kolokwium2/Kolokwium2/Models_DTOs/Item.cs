using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models_DTOs;
[Table("items")]
[PrimaryKey(nameof(id))]

public class Item
{
    [Key]
    public int id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    public int Weight { get; set; }
    public List<Backpack> Backpacks { get; set; } = new List<Backpack>();

}