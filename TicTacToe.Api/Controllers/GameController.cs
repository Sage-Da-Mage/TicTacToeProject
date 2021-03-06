using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Models.Entities.VMs.GameVMs;
using TicTacToe.Models.Entities.VMs.MoveVMs;
using TicTacToe.Models.VMs.GameVMs;
using TicTacToe.Models.VMs.MoveVMs;
using TicTacToe.Service.Interfaces;
using TicTacToe.Shared.Exceptions;

namespace TicTacToe.Api.Controllers
{
    /// <summary>
    /// This contoller has all of the endpoints directly related to/interacting with the Game Entity
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        private readonly IGameService _gameService;
        
        /// <summary>
        /// The Constructor which gives the GameController access to the service layer 
        /// </summary>
        /// <param name="gameService"></param>
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }


        /// <summary>
        /// Create a new game 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ActionResult<GameVM>> Create([FromBody] GameCreateVM data)
        {

            // Verify that only 2 players are passed in
            if(data.PlayersIds.Count != 2)
            {
                return BadRequest(new { message = "You have to have exactly 2 players to play. No more, no less." });
            }

            // Make sure that one of the two players passed in is the player that starts the game
            if(data.PlayerStarting != data.PlayersIds[0] && data.PlayerStarting != data.PlayersIds[1])
            {
                return BadRequest(new { message = "One of the two players joining must be the assigned 'Starting Player' otherwise, the game won't start." });
            }


            // The guts of the Create endpoint, make a call to the service layer to do the 
            // mechanics of creating the new game

            var result = await _gameService.Create(data);

            return Ok(result);

        }


        /// <summary>
        ///  Get a specific game by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<GameVM>> Get([FromRoute] Guid id)
        {



            // The guts of the Get endpoint, make a call to the service layer to do the
            // mechanics of getting the requsted game

            var result = await _gameService.Get(id);

            // In the case that a game can't be found matching the provided inputId throw an Exception indicating so
            if (result == null) throw new NotFoundException("The requested game could not be found");
            
            return Ok(result);

        }


        /// <summary>
        /// This endpoint takes in a MoveCreateVm (GameID + PlayerWhosTurnItIsId + Tile to select)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>        
        [HttpPost]
        [Route("move")]
        public async Task<ActionResult<MoveVM>> Move([FromBody] MoveCreateVM data)
        {
            var result = await _gameService.Move(data);
            return Ok(result);
        }




        /// <summary>
        /// Get the number of games currently active (not completed)
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="setsPerPage"></param>
        /// <returns></returns>
        [HttpGet("getCurrentlyActiveGames")]
        public async Task<List<ActiveGameVM>> GetActiveGames([FromQuery] int pageNumber, int setsPerPage)
        {
            // The guts of the GetAll endpoint, make a call to the service layer to do the 
            // mechanics of getting every game in the database and then sorting out any non-active
            // game from that list

            var results = await _gameService.GetActiveGames(pageNumber, setsPerPage);

            return results;

        }
        

    }
}
