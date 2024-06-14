using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models_DTOs;
[Table("characters")]
[PrimaryKey(nameof(id))]
public class Character
{
    [Key]
    public int id { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    [Required]
    public int CurrentWeight { get; set; }
    [Required]
    public int MaxWeight { get; set; }

    public List<Backpack> Backpacks { get; set; } = new List<Backpack>();
    public List<Character_title> CharacterTitles { get; set; } = new List<Character_title>();

}