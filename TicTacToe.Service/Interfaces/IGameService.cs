using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities.VMs.GameVMs;
using TicTacToe.Models.VMs.GameVMs;

namespace TicTacToe.Service.Interfaces
{
    interface IGameService
    {

        // Create a new Game
        Task<GameVM> Create(GameCreateVM src);

        //Get a single existing Game by its Id
        Task<GameVM> Get(int id);

        //Update a currently existing Game
        Task<GameVM> Update(GameUpdateVM src, int EmployeeId);

        // Delete a Game
        Task Delete(int id);



        // Get all of the Games currently existing (CC required)
        public Task<List<GameVM>> GetAll();

        // List all of the Games currently existing (CC required)
        public Task<List<GameVM>> ListAll();

    }
}
