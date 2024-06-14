using Kolokwium2.Models_DTOs;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Data;

public class EntityFrameworkContext : DbContext
{
    protected EntityFrameworkContext()
    {
    }

    protected EntityFrameworkContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Item> Items{ get; set; }
    public virtual DbSet<Backpack> Backpacks{ get; set; }
    public virtual DbSet<Character> Characters{ get; set; }
    public virtual DbSet<Character_title>CharacterTitles{ get; set; }
    public virtual DbSet<Title> Titles{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(
            new Item(){id = 1,Name = "nóż",Weight = 10},
            new Item(){id = 2,Name = "Duży miecz",Weight = 100},
            new Item(){id = 3,Name = "zbroja",Weight = 100}
        );
        modelBuilder.Entity<Character>().HasData(
            new Character(){id = 1,FirstName = "Character",LastName = "Charakterowski",CurrentWeight = 50,MaxWeight = 500},
            new Character(){id = 2,FirstName = "Jan",LastName = "Kowalski",CurrentWeight = 60,MaxWeight = 150}
        );
        modelBuilder.Entity<Backpack>().HasData(
            new Backpack(){CharacterId = 1,ItemId = 1,Amount = 1},
            new Backpack(){CharacterId = 1,ItemId =2,Amount = 1},
            new Backpack(){CharacterId = 2,ItemId = 3,Amount = 1}
        );
        modelBuilder.Entity<Title>().HasData(
            new Title(){id = 1,Name = "Mag"},
            new Title(){id = 2,Name = "Wojownik"},
            new Title(){id = 3,Name = "Morderca Goblinów"}
        );
        modelBuilder.Entity<Title>().HasData(
            new Character_title(){CharacterID = 1,TitleId = 1,AcquiredAt = new DateTime(2024,6,14)},
            new Character_title(){CharacterID = 2,TitleId = 3,AcquiredAt = new DateTime(2024,1,1)}
        );
        base.OnModelCreating(modelBuilder);
    }
}