using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Models.Entities.VMs.PlayerVMs;
using TicTacToe.Models.VMs.PlayerVMs;
using TicTacToe.Service.Interfaces;

namespace TicTacToe.Api.Controllers
{
    /// <summary>
    /// The controler holding the endpoints related to players.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        //Setting up acess to the service layer (not created for Player yet)
        private readonly IPlayerService _playerService;

        /// <summary>
        /// The constructor that gives us acess to the service layer.
        /// </summary>
        /// <param name="playerService"></param>
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
       
        /// <summary>
        /// This endpoint creates a player from the inputtedSrc, create two Players before trying to make a Game.
        /// </summary>
        /// <param name="inputtedSrc"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult<PlayerVM>> Create([FromBody] PlayerCreateVM inputtedSrc)
        {
            var result = await _playerService.Create(inputtedSrc);
            return Ok(result);
        }


    }
}
