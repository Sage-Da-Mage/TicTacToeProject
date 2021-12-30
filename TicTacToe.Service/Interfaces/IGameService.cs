using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities.VMs.GameVMs;
using TicTacToe.Models.Entities.VMs.MoveVMs;
using TicTacToe.Models.VMs.GameVMs;
using TicTacToe.Models.VMs.MoveVMs;

namespace TicTacToe.Service.Interfaces
{
    public interface IGameService
    {

        // Create a new Game
        Task<GameVM> Create(GameCreateVM src);

        //Get a single existing Game by its Id
        Task<GameVM> Get(Guid id);

        //Update a currently existing Game
        Task<GameVM> Update(GameUpdateVM src, Guid inputId);

        // Delete a Game
        Task Delete(Guid gameId);


        // This method lets a user play a move in the game
        public Task<MoveVM> Move(MoveCreateVM inputtedSrc);

        // This method Gets all the active (non-complete) games as well as gather information about the players.
        public Task<List<ActiveGameVM>> GetActiveGames(int pageNumber, int setsPerPage);

    }
}
