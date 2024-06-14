using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models_DTOs;
[Table("character_titles")]
[PrimaryKey(nameof(CharacterID),nameof(CharacterID))]
public class Character_title
{
    [Required]
    public int CharacterID { get; set; }
    [Required]
    public int TitleId { get; set; }
    [Required]
    public DateTime AcquiredAt { get; set; }
    [ForeignKey(nameof(CharacterID))] public Character CharacterNavigation { get; set; }
    [ForeignKey(nameof(TitleId))] public Title TitleNavigation { get; set; }


}