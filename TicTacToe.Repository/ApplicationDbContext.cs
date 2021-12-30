using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities;

namespace TicTacToe.Repository
{
    // This class creates a context for Database acess/management.
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            // This is where if I decided to, I could use Fluent API to use finer control over Db setup.
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<GameHub>()
               .HasKey(u => new { u.GameId, u.PlayerId });

            /* Ported over from a previous project as part of the above (modified) code, it may have potential use (after modification)
             * in future for making sure something builds properly so I'm leaving it in for now
             * 
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Cars & Vehicles" },
                new Category { Id = 2, Name = "Furniture" },
                new Category { Id = 3, Name = "Electronics" },
                new Category { Id = 4, Name = "Real Estate" }

            ); */
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<GameHub> GameHubs { get; set; }

    }
}
