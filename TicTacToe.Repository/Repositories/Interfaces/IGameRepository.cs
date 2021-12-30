using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities;
using TicTacToe.Models.VMs.GameVMs;

namespace TicTacToe.Repository.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<Game> Create(Game src);                        // Create a new Game

        Task<Game> Get(Guid gameid);                        // Get a single Game by its Id

        Task<List<Game>> GetAll();                          // Get all Games stored in the Database

        Task<Game> Update(Game src, Guid gameId);           // Update an existing Game

        Task Delete(Guid inputId);                          // Delete a specific Game

    }
}
