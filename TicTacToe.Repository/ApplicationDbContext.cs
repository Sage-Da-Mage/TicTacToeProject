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

        public DbSet<Game> Games { get; set; }

    }
}
