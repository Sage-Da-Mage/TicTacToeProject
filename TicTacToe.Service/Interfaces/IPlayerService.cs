using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities.VMs.PlayerVMs;
using TicTacToe.Models.VMs.PlayerVMs;

namespace TicTacToe.Service.Interfaces
{
    public interface IPlayerService
    {
        // The Create method for the PlayerService
        Task<PlayerVM> Create(PlayerCreateVM inputtedSrc);


    }
}
