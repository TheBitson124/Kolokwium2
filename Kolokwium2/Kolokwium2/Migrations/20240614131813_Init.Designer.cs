﻿// <auto-generated />
using System;
using Kolokwium2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kolokwium2.Migrations
{
    [DbContext(typeof(CharacterContext))]
    [Migration("20240614131813_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kolokwium2.Models_DTOs.Backpack", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("backpacks");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            ItemId = 1,
                            Amount = 1
                        },
                        new
                        {
                            CharacterId = 1,
                            ItemId = 2,
                            Amount = 1
                        },
                        new
                        {
                            CharacterId = 2,
                            ItemId = 3,
                            Amount = 1
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models_DTOs.Character", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("CurrentWeight")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("MaxWeight")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("characters");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CurrentWeight = 50,
                            FirstName = "Character",
                            LastName = "Charakterowski",
                            MaxWeight = 500
                        },
                        new
                        {
                            id = 2,
                            CurrentWeight = 60,
                            FirstName = "Jan",
                            LastName = "Kowalski",
                            MaxWeight = 150
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models_DTOs.Character_title", b =>
                {
                    b.Property<int>("CharacterID")
                        .HasColumnType("int");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AcquiredAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CharacterID", "TitleId");

                    b.HasIndex("TitleId");

                    b.ToTable("character_titles");

                    b.HasData(
                        new
                        {
                            CharacterID = 1,
                            TitleId = 1,
                            AcquiredAt = new DateTime(2024, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CharacterID = 2,
                            TitleId = 3,
                            AcquiredAt = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models_DTOs.Item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("items");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Name = "nóż",
                            Weight = 10
                        },
                        new
                        {
                            id = 2,
                            Name = "Duży miecz",
                            Weight = 100
                        },
                        new
                        {
                            id = 3,
                            Name = "zbroja",
                            Weight = 100
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models_DTOs.Title", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.ToTable("titles");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Name = "Mag"
                        },
                        new
                        {
                            id = 2,
                            Name = "Wojownik"
                        },
                        new
                        {
                            id = 3,
                            Name = "Morderca Goblinów"
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models_DTOs.Backpack", b =>
                {
                    b.HasOne("Kolokwium2.Models_DTOs.Character", "CharacterNavigation")
                        .WithMany("Backpacks")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium2.Models_DTOs.Item", "ItemNavigation")
                        .WithMany("Backpacks")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharacterNavigation");

                    b.Navigation("ItemNavigation");
                });

            modelBuilder.Entity("Kolokwium2.Models_DTOs.Character_title", b =>
                {
                    b.HasOne("Kolokwium2.Models_DTOs.Character", "CharacterNavigation")
                        .WithMany("CharacterTitles")
                        .HasForeignKey("CharacterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium2.Models_DTOs.Title", "TitleNavigation")
                        .WithMany("CharacterTitles")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharacterNavigation");

                    b.Navigation("TitleNavigation");
                });

            modelBuilder.Entity("Kolokwium2.Models_DTOs.Character", b =>
                {
                    b.Navigation("Backpacks");

                    b.Navigation("CharacterTitles");
                });

            modelBuilder.Entity("Kolokwium2.Models_DTOs.Item", b =>
                {
                    b.Navigation("Backpacks");
                });

            modelBuilder.Entity("Kolokwium2.Models_DTOs.Title", b =>
                {
                    b.Navigation("CharacterTitles");
                });
#pragma warning restore 612, 618
        }
    }
}