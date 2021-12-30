﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TicTacToe.Repository;

namespace TicTacToe.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<Guid?>("VictorId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VictorId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TicTacToe.Models.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("ComputerPlayer")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("TicTacToe.Models.Entities.Game", b =>
                {
                    b.HasOne("TicTacToe.Models.Entities.Player", "Victor")
                        .WithMany()
                        .HasForeignKey("VictorId");

                    b.Navigation("Victor");
                });
#pragma warning restore 612, 618
        }
    }
}
