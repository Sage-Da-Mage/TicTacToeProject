using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities;
using TicTacToe.Repository.Repositories.Interfaces;
using TicTacToe.Shared.Exceptions;

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

        // This method is used to confirm that both players are within the database
        public async Task CheckPlayersInSystem(List<Guid> playerIds)
        {

            var playerCount = await _context.Players
                .Where(p => p.Id == playerIds[0] || p.Id == playerIds[1]).CountAsync();

            // If both players are not within the database (playercound is not exactly 2) then throw the NotFoundException
            if (playerCount != 2) throw new NotFoundException("A requested player could not be found");

        }


    }
}
