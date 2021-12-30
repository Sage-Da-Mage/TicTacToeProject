using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities;
using TicTacToe.Models.Entities.VMs.PlayerVMs;
using TicTacToe.Models.VMs.PlayerVMs;
using TicTacToe.Repository.Repositories.Interfaces;
using TicTacToe.Service.Interfaces;

namespace TicTacToe.Service.Services
{
    public class PlayerService : IPlayerService
    {

        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<PlayerVM> Create(PlayerCreateVM src)
        {
            // Set the newEntity to be a new Player with the qualities of the passed in data
            var newEntity = new Player(src);

            // Set the CreatedAt and LastUpdatedAt time at time of creation
            newEntity.CreatedAt = DateTime.UtcNow;
            newEntity.LastUpdatedAt = newEntity.CreatedAt;

            var result = await _playerRepository.Create(newEntity);

            var model = new PlayerVM(result);
            return model;

        }
    }
}
