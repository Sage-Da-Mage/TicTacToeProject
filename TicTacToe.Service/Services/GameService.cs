using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities;
using TicTacToe.Models.Entities.VMs.GameVMs;
using TicTacToe.Models.VMs.GameVMs;
using TicTacToe.Repository.Repositories.Interfaces;
using TicTacToe.Service.Interfaces;

namespace TicTacToe.Service.Services
{

    public class GameService : IGameService
    {

        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<GameVM> Create(GameCreateVM src)
        {
            // Generate a new Entity with the inputted data            
            var newEntity = new Game(src);


            // Set the BoardList of the newEntity to be the default TicTacToeBoard
            List<int> initializeBoard = new List<int> { 3, 3, 3, 3, 3, 3, 3, 3, 3 };

            newEntity.BoardList = initializeBoard;

            // Set the Completed booleans to false (Game is just started there is no winner, tie or victor)
            newEntity.Completed = false;
            newEntity.Draw = false;
            newEntity.Victor = null;

            // Set the creationDate for this game to be the current time
            newEntity.CreatedAt = DateTime.UtcNow;


            // Use that data to create the new Game
            var result = await _gameRepository.Create(newEntity);

            // Create a GameVM from the result to return/show
            var model = new GameVM(newEntity);

            // Return the result as an GameVM
            return model;
        }

        // Get an Game by its GameId
        public async Task<GameVM> Get(Guid gameId)
        {

            // Get the Game entitiy from the repository
            var result = await _gameRepository.Get(gameId);

            // Create the GameVM that we will return
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
            var models = results.Select(game => new GameVM(game)).ToList();

            // Return the GameVMs
            return models;
        }

        public async Task<GameVM> Update(GameUpdateVM src, Guid inputId)
        {

            // Make the repository update the Game
            var updateData = new Game(src);
            var result = await _gameRepository.Update(updateData, inputId);

            //Create the GameVM model for returning to the client
            var model = new GameVM(result);

            //Finally return the GameVM to show that the change was sucessfull
            return model;
        }

        public async Task Delete(Guid inputId)
        {
            // Inform the repository to delete the specified Listing Entity
            await _gameRepository.Delete(inputId);
        }
    }
}
