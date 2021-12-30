using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Entities
{
    /// <summary>
    /// This class exists to put Player and Game Entities associated with each other into a single location for ease of acess.
    /// </summary>
    public class GameHub
    {
        /// <summary>
        /// The Id of the game itself
        /// </summary>
        public Guid GameId { get; set; }


        /// <summary>
        /// The Id of a specific Player
        /// </summary>
        public Guid PlayerId { get; set; }

        /// <summary>
        /// The navigation property for a player
        /// </summary>
        public Player Player { get; set; }

        /// <summary>
        /// The navigation property for a Game
        /// </summary>
        public Game Game { get; set; }


    }
}
