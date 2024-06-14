using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models_DTOs;
[Table("backpacks")]
[PrimaryKey(nameof(CharacterId),nameof(ItemId))]
public class Backpack

{
    [Required]
    public int  CharacterId { get; set; }
    [Required]
    public int  ItemId { get; set; }
    [Required]
    public int  Amount { get; set; }
    [ForeignKey(nameof(CharacterId))] public Character CharacterNavigation { get; set; }
    [ForeignKey(nameof(ItemId))] public Item ItemNavigation { get; set; }
    

}