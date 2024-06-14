using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models_DTOs;
[Table("titles")]
[PrimaryKey(nameof(id))]

public class Title
{
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public List<Character_title> CharacterTitles { get; set; } = new List<Character_title>();

}