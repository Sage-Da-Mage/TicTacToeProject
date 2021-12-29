using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities;
using TicTacToe.Models.Entities.VMs.GameVMs;
using TicTacToe.Models.VMs.GameVMs;

namespace TicTacToe.Service.Services
{

    public class GameService
    {
        // Structure for Game Repository implementation (not included yet).
        /*public class GameService :IGameService
        * {
        *      private readonly IGameRepository _gameRepository;
        * }
        * 
        * public GameService(IGameRepository gameRepository)
        * {
        *       _gameRepository = gameRepository;
        * }
        */


        public async Task<GameVM> Create(GameCreateVM src)
        {
            // Generate a new Entity with the inputted data
            
            
            var newEntity = new Game(src);



            // Use that data to create the new Game
            var result = await _gameRepository.Create(newEntity);

            // Create a GameVM from the result to return/show
            var model = new GameVM(result);

            // Return the result as an GameVM
            return model;
        }

        // Get an Game by its EmployeeId
        public async Task<GameVM> Get(int EmployeeId)
        {

            // Get the Game entitiy from the repository
            var result = await _gameRepository.Get(EmployeeId);

            // Create the EmployeeVm that we will return
            var model = new GameVM(result);

            // Return the Game VM in a 200 response
            return model;

        }

        // Modified GetAll after switching to database implementation
        public async Task<List<GameVM>> GetAll()
        {
            // Get the Game entities from the repository
            var results = await _gameRepository.GetAll();

            // Build the Game view models to return to the client
            var models = results.Select(employee => new GameVM(employee)).ToList();

            // Return the GameVMs
            return models;
        }

        public async Task<GameVM> Update(GameUpdateVM src, int employeeId)
        {

            // Make the repository update the Game
            var updateData = new Game(src);
            var result = await _gameRepository.Update(updateData, employeeId);

            //Create the EmployeeVm model for returning to the client
            var model = new GameVM(result);

            //Finally return the GameVM to show that the change was sucessfull
            return model;
        }

        public async Task Delete(int id)
        {
            // Inform the repository to delete the specified Listing Entity
            await _gameRepository.Delete(id);
        }



    }
}
