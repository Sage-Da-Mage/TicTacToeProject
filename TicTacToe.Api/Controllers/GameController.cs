﻿using Microsoft.AspNetCore.Http;
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

namespace TicTacToe.Api.Controllers
{
    // This contoller has all of the endpoints directly related to/interacting with the Game Entity
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }


        // Create a new game 
        [HttpPost("create")]
        public async Task<ActionResult<GameVM>> Create([FromBody] GameCreateVM data)
        {
            // The guts of the Create endpoint, make a call to the service layer to do the 
            // mechanics of creating the new game

            var result = await _gameService.Create(data);

            return Ok(result);

        }


        // Get a specific game by its Id
        [HttpGet]
        public async Task<ActionResult<GameVM>> Get([FromRoute] Guid id)
        {
            // The guts of the Get endpoint, make a call to the service layer to do the
            // mechanics of getting the requsted game

            var result = await _gameService.Get(id);

            return Ok(result);

        }

        // Get all games
        [HttpGet("GetAll")]
        public async Task<List<GameVM>> GetAll()
        {
            // The guts of the GetAll endpoint, make a call to the service layer to do the 
            // mechanics of getting every game in the database

            var results = await _gameService.GetAll();

            return results;
        }



        // This endpoint takes in a MoveCreateVm (GameID + PlayerWhosTurnItIsId + Tile to select) 
        [HttpPost]
        [Route("move")]
        public async Task<ActionResult<MoveVM>> Move([FromBody] MoveCreateVM data)
        {
            var result = await _gameService.Move(data);
            return Ok(result);
        }



        /*
        // Get the number of games currently active (not completed)
        [HttpGet]
        public async Task<List<GameVM>> GetAllActiveGames()
        {
            // The guts of the GetAll endpoint, make a call to the service layer to do the 
            // mechanics of getting every game in the database and then sorting out any non-active
            // game from that list

            var results = await _gameService.GetAllActiveGames();

            return results;

        }
        */

    }
}
