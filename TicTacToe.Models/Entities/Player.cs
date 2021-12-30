using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.VMs.PlayerVMs;

namespace TicTacToe.Models.Entities
{
    // This Entity represents a player of TicTacToe
    public class Player : BasicEntity
    {

        // An empty constructor for the creation of an empty Player Entity
        public Player()
        {

        }

        // A constructor to generate a Player from a PlayerCreateVM Entity
        public Player(PlayerCreateVM src)
        {
            Name = src.Name;
        }


        // Below are the properties of a Player Entity

        // This is the name of the Player
        public string Name { get; set; }

        // The Games that this player is associated with (through GmaeHub)
        public ICollection<GameHub> GameHubs { get; set; }




    }
}
