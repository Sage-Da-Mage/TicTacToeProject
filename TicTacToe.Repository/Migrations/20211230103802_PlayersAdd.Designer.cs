﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TicTacToe.Repository;

namespace TicTacToe.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211230103802_PlayersAdd")]
    partial class PlayersAdd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("TicTacToe.Models.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<List<int>>("BoardList")
                        .HasColumnType("integer[]");

                    b.Property<bool>("Completed")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Draw")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("PlayerStarting")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("VictorId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VictorId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TicTacToe.Models.Entities.GameHub", b =>
                {
                    b.Property<Guid>("GameId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uuid");

                    b.HasKey("GameId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GameHubs");
                });

            modelBuilder.Entity("TicTacToe.Models.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TicTacToe.Models.Entities.Game", b =>
                {
                    b.HasOne("TicTacToe.Models.Entities.Player", "Victor")
                        .WithMany()
                        .HasForeignKey("VictorId");

                    b.Navigation("Victor");
                });

            modelBuilder.Entity("TicTacToe.Models.Entities.GameHub", b =>
                {
                    b.HasOne("TicTacToe.Models.Entities.Game", "Game")
                        .WithMany("GameHubs")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicTacToe.Models.Entities.Player", "Player")
                        .WithMany("GameHubs")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("TicTacToe.Models.Entities.Game", b =>
                {
                    b.Navigation("GameHubs");
                });

            modelBuilder.Entity("TicTacToe.Models.Entities.Player", b =>
                {
                    b.Navigation("GameHubs");
                });
#pragma warning restore 612, 618
        }
    }
}