using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Entities.VMs.PlayerVMs
{
    // The View Model for the Player Entity, used for the creation and viewing of Player Entities
    public class PlayerVM
    {

        // This is the name of the Player
        public string Name { get; set; }

        // This is the bool which shows whether a player is a human or
        // a computer playing the game
        public bool ComputerPlayer { get; set; }


    }
}
