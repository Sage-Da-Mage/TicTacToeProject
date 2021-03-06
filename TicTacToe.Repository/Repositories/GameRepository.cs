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
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;

        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        // Create a new Game
        public async Task<Game> Create(Game src)
        {

            _context.Games.Add(src);                    // Preform the add in the memory
            await _context.SaveChangesAsync();          // Save the changes to the database

            // Return the new Game, a new Id for the Game will by added by Entity Framework automatically
            return src;
        }

        // Get a single Game by Id
        public async Task<Game> Get(Guid inputId)
        {
            // Get the game desired from the inputtedId
            var result = await _context.Games
                .Include(g => g.GameHubs).FirstOrDefaultAsync(i => i.Id == inputId);

            // If it isn't present, throw a NotFoundException
            if (result == null) throw new NotFoundException("The requested game could not be found");
            
            // return the results
            return result;

        }


        // Update a currently existing Game
        public async Task<Game> Update(Game src, Guid inputId)
        {

            // Add the inputted employeeId to the src
            src.Id = inputId;

            // Get the entity to update
            var result = await _context.Games
                .FirstOrDefaultAsync(i => i.Id == src.Id);

            // In the case that a game can't be found matching the provided inputId throw an Exception indicating so
            if (result == null) throw new NotFoundException("The requested game could not be found");


            // Preform the update on the Game entity
            result.Draw = src.Draw;
            result.Completed = src.Completed;
            result.Victor = src.Victor;
            result.BoardList = src.BoardList;
            result.LastUpdatedAt = DateTime.UtcNow;

            // Save the updates to the database
            await _context.SaveChangesAsync();

            // Return the Actual entity class and not the src class so that we are sure that the database Game is correct
            return result;
        }

        // Delete a specific Game
        public async Task Delete(Guid inputId)
        {
            // Get the specific Game Entity you wish to delete
            var result = await _context.Games.FirstAsync(i => i.Id == inputId);

            //Remove the entity from the collection in your memory
            _context.Remove(result);

            // Remove the entity from the database
            await _context.SaveChangesAsync();
        }

        // This functions to organize the games pulled from the database so that they are comprehensible when acessed at the service layer.
        public async Task<List<Game>> GetActiveGames(int pageNumber, int setsPerPage)
        {
            // Get the list of games from the database:
            var result = await _context.Games
                // Where the game has an empty Tile (ie there is no victor or draw yet)
                .Where(game => game.BoardList.Contains(5) && game.Victor == null && game.Draw != true)

                // Get the players associated with the game as well via the GameHubs
                .Include(game => game.GameHubs).ThenInclude(gp => gp.Player)

                // Order the games by the time they were created at (why not/helps with organization)
                .OrderBy(game => game.CreatedAt)
                
                // And take the ones matching the block of data associated with the inputted pageNumber/# of sets per page
                .Skip((pageNumber - 1) * setsPerPage).Take(setsPerPage)
                .ToListAsync();

            // Return the results to the service layer.
            return result;

        }

    }
}
