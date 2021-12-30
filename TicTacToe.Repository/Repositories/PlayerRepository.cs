using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities;
using TicTacToe.Repository.Repositories.Interfaces;

namespace TicTacToe.Repository.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        // Get the context from the ApplicationDbContext
        private readonly ApplicationDbContext _context;

        // Make the context from ApplicationDbContext the context for this
        public PlayerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Player> Create(Player src)
        {
            _context.Players.Add(src);
            await _context.SaveChangesAsync();

            // return the source (what was created as a player)
            return src;

        }

        public async Task CheckPlayersInSystem(List<Guid> playerIds)
        {
            var playerCount = await _context.Players
                .Where(p => p.Id == playerIds[0] || p.Id == playerIds[1]).CountAsync();
        }


    }
}
