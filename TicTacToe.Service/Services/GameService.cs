using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities;
using TicTacToe.Models.Entities.VMs.GameVMs;
using TicTacToe.Models.Entities.VMs.MoveVMs;
using TicTacToe.Models.VMs.GameVMs;
using TicTacToe.Models.VMs.MoveVMs;
using TicTacToe.Repository.Repositories.Interfaces;
using TicTacToe.Service.Interfaces;
using TicTacToe.Shared.Exceptions;

namespace TicTacToe.Service.Services
{

    public class GameService : IGameService
    {

        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        // Create a new game
        public async Task<GameVM> Create(GameCreateVM src)
        {
            // Generate a new Entity with the inputted data            
            var newEntity = new Game(src);


            // Set the BoardList of the newEntity to be the default TicTacToeBoard
            List<int> initializeBoard = new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5 };

            newEntity.BoardList = initializeBoard;

            // Set the Completed booleans to false (Game is just started there is no winner, tie or victor)
            newEntity.Completed = false;
            newEntity.Draw = false;
            newEntity.Victor = null;

            // Set the creationDate for this game to be the current time
            newEntity.CreatedAt = DateTime.UtcNow;
            // Set the lastUpdateTime as the same as the current time as it hasn't been updated yet
            newEntity.LastUpdatedAt = newEntity.CreatedAt;


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
        

        // The call for getting all games within the database
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

        // Delete a Game from the Database
        public async Task Delete(Guid inputId)
        {
            // Inform the repository to delete the specified Listing Entity
            await _gameRepository.Delete(inputId);
        }

        // The Move Endpoint for Endpoint 2 of the project
        // Has the current player choose a tile to mark (including exceptions should they choose either their player or Tile incorrectly)
        public async Task<MoveVM> Move(MoveCreateVM inputtedSrc)
        {
            // If the tile that the move is for is non-valid ( # < 0 || # > 8) retern an exception
            if(inputtedSrc.TileSelected < 0 || inputtedSrc.TileSelected > 8)
            {
                // Throw an exception, the TileSelected needs to be within acceptable ranges
                throw new InvalidMove("The selected tile is invalid, select a tile placement between 0 (top-left) and 8 (bottom-right)");
            }

            // Get the Game the move is for from the Database
            var result = await _gameRepository.Get(inputtedSrc.GameId);

            // Determine whether the game has been won already (error/exception catching)
            if(result.Completed == true)
            {
                // Throw an exception, you can't make a move if the game is already over
                throw new InvalidMove("This game has already been completed, you can't take another move.");
            }

            // Determine which player gets to go: true = p1s turn, false = p2s turn
            bool doesStartingPlayerGo = P1Go(result.BoardList);

            // The line below determines if the player determined above is valid and assigns the int
            // to place in the boardList based on which player it is (1 = P1, 2 = P2)
            int whichPlayerMark = PlayerValidCheckPlusIntAssignment(result, inputtedSrc.PlayerId, doesStartingPlayerGo);

            // Determine if the desired tile of the boardList is empty (check for invalid move)
            // If the tile chosen is not 5 it isn't a valid move
            if (result.BoardList[inputtedSrc.TileSelected] != 5)
            {
                // Throw an exception, you can't select a tile that has already been used
                throw new InvalidMove("The selected Tile is not available for a move");
            }

            // Add a mark to the boardList (Getting here means it was a valid move)
            result.BoardList[inputtedSrc.TileSelected] = whichPlayerMark;

            // Determine whether there is a winner of the game as a result of this move
            result.Completed = DoesThisMoveWin(result.BoardList, whichPlayerMark);


            // Now determine if the move won the game
            if (result.Completed == true)
            {
                //set winner's id
                if (doesStartingPlayerGo)
                {
                    result.Victor = result.PlayerStarting;
                }
                else
                {
                    var GameWinner = result.GameHubs.Where(GameWinner => GameWinner.PlayerId != result.PlayerStarting).First();
                    result.Victor = GameWinner.PlayerId;
                }
            }

            // Determine whether this move (that did not win) was also the last available Tile to use
            // If there is no tile in the list which is the integer 5, then there are no available tiles left to use and the game is a draw
            if (!result.BoardList.Contains(5))
            {
                result.Completed = true;
                result.Draw = true; 
            }

            // Save the Move done on the Game (if reached this point it has succeeded and was valid)
            var moveResult = await _gameRepository.Update(result, result.Id);


            // Determine the results of the turn for returning the MoveVM 
            bool gameDone = false;
            bool gameWon = false;
            if(result.Completed == true) { gameDone = true; }
            if (result.Draw == false && gameDone == true) { gameWon = true; }

            // Return a MoveVM which displays whether the game is completed and whether there was a victor
            var model = new MoveVM(gameDone, gameWon);

            // Return the model with the results dependant on what the move accomplished (Draw, Victor, Game Continues)
            return model;

        }

        // This is the buisiness logic which is called to return a list of currently running games as well as the number of moves each player has taken in those games
        // Passed in numbers are for handling blocks of the list at a time, there could theoretically be thousands of games and they would havbe to be brocken up somehow.
        public async Task<List<ActiveGameVM>> GetActiveGames(int pageNumber, int setsPerPage)
        {
            // Get the list of all active games from the repository layer (allocated by page)
            var results = await _gameRepository.GetActiveGames(pageNumber, setsPerPage);

            // Generate a list to hold all the VMs gathered
            var models = new List<ActiveGameVM>();

            // For every Game gotten from the repository layer: convert it into an ActiveGameVM and add it to the models list for returning later 
            foreach(Game game in results)
            {
                // get the first players Name

                // Set a single Game into the model Variable
                var model = new ActiveGameVM(game.Id);

                // Find the name of the starting Player
                Guid P1 = game.PlayerStarting;
                
                // Set xMark to be the game matching the passed in PlayerId from results
                var xMark = game.GameHubs.Where(ps => ps.PlayerId == P1).FirstOrDefault();

                // Set the name of the startingPlayer to be the name of the firstPlayer associated with the game focused on in this loop
                model.StartingPlayerName = xMark.Player.Name;


                // Find the second Players Name

                // Set oMark to be the player that is associated with the game of this loop that isn't the first player
                var oMark = game.GameHubs.Where(pt => pt.PlayerId != P1).FirstOrDefault();

                // Set the name of the second Player to be the name of the secondPlayer associated with the game focused on in this iteration of the loop
                model.Player2 = oMark.Player.Name;

                // Count the moves done by both players
                model.Player1MoveCount = game.BoardList.Count(x => x == 1);
                model.Player2MoveCount = game.BoardList.Count(o => o == 2);

                // Add the model generated in this iteration of the loop to the List of ActivGameVMs
                models.Add(model);
            }
            // Now that the looping is over, return the list of ActiveGameVMs to the controller.
            return models;

        }

        // -------------------------------------------------------------------------------------------------------------------
        // Below are supplemental methods used in the above methods that are called from endpoints. 


        // This method is used in the move endpoint to determine which player gets to go:
        private bool P1Go(List<int> boardList)
        {
            // Count the number of times each player has gone (x=p1, o=p2)
            int x = boardList.Count(x => x == 1);
            int o = boardList.Count(o => o == 2);

            // If x==o then it is player 1s turn again (both players have gone the same amount)
            if (x == o) return true;

            // If x != o then player 1 has gone more times than player 2 and it is player 2s turn
            return false;
        }

        // This method is used in the move endpoint to determine if the player whose turn is determined in p1Go is valid to play
        private int PlayerValidCheckPlusIntAssignment(Game game, Guid playerId, bool playerGoing)
        {
            // Is the player we pass in from the inputtedSrc a valid player in this game?
            if (game.GameHubs.FirstOrDefault(i => i.PlayerId == playerId) == null)
            {
                // Add Exception here, if the requested player is not related to this game they can't participate (no randoms joining in)
                throw new NotFoundException("The requested player has not been found related to this game");
            }
            // Determine if the passed in player is P1 
            if (game.PlayerStarting == playerId)
            {
                // If they are P1, determine if it is their turn
                if (playerGoing == false)
                {
                    // If the player passed in is P1 but isn't the playerGoing then this isn't thier turn and they can't go, return exception
                    throw new InvalidMove("It is not the requested players turn");
                }
                // If the passed in player is P1 and the playerGoing indicates it is P1s turn, then return 1 (P1s mark)
                else return 1;
            }
            // If we reach this part of the method then the Player is P2
            if (playerGoing == true)
            {
                // If the playerGoing is true then it is P1s turn,  however, we shouldn't have reached this if it was P1s turn,
                // therefore it isn't the passed in players turn. Return an exception.
                throw new InvalidMove("It is not the requested players turn");
            }
            // If the passed in player is P2 and the playerGoing indicates it is P2s turn, then retunr 2 (P2s mark)
            return 2;
        }

        // This method is used in the move endpoint to determine whether the move which just completed wins the game or not
        private bool DoesThisMoveWin(List<int> boardList, int playerMakingMove)
        {
            // We check if there is a win by determining if there is 3 of the playerMakingMove in a row vertically, horizontally or diagonally
            // The board is 3 tiles in any of the 3 ways so if the sum of a row/collumn/diagonal is EXACTLY = (playerMakingMove * 3) then it is a winning move.
            int winningValue = playerMakingMove * 3;


            // Determine if the move wins via a Horizontal line
            if (boardList[0] + boardList[1] + boardList[2] == winningValue) return true;
            if (boardList[3] + boardList[4] + boardList[5] == winningValue) return true;
            if (boardList[6] + boardList[7] + boardList[8] == winningValue) return true;


            // Determine if the move wins via a Vertical line
            if (boardList[0] + boardList[3] + boardList[6] == winningValue) return true;
            if (boardList[1] + boardList[4] + boardList[7] == winningValue) return true;
            if (boardList[2] + boardList[5] + boardList[8] == winningValue) return true;


            // Determine if the move wins via a Diagonal line
            if (boardList[6] + boardList[4] + boardList[2] == winningValue) return true;
            if (boardList[8] + boardList[4] + boardList[0] == winningValue) return true;

            // If none of the above has triggered(returned true) then the move didn't win the game and we return false
            return false;
        }

    }
}
