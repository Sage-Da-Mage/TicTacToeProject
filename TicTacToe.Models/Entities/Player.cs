using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.VMs.PlayerVMs;

namespace TicTacToe.Models.Entities
{
    /// <summary>
    /// This Entity represents a player of TicTacToe
    /// </summary>
    public class Player : BasicEntity
    {

        /// <summary>
        /// An empty constructor for the creation of an empty Player Entity
        /// </summary>
        public Player()
        {

        }

        /// <summary>
        /// A constructor to generate a Player from a PlayerCreateVM Entity
        /// </summary>
        /// <param name="src"></param>
        public Player(PlayerCreateVM src)
        {
            Name = src.Name;
        }


        // Below are the properties of a Player Entity

        /// <summary>
        /// This is the name of the Player
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Games that this player is associated with (through GameHub)
        /// </summary>
        public ICollection<GameHub> GameHubs { get; set; }




    }
}
