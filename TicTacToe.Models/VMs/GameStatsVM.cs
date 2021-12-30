using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.VMs
{

    /// <summary>
    /// This class holds stats regarding a game (specifically the number of moves players have made)
    /// </summary>
    public class GameStatsVM
    {
        /// <summary>
        /// The standard empty constructor for generating empty GameStatsVM entities
        /// </summary>
        public GameStatsVM()
        {

        }

        /// <summary>
        /// The Id belonging to the game which this entitiy is associated with
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// The name of the starting player (Player1)
        /// </summary>
        public string StartingPlayer { get; set; }

        /// <summary>
        /// The name of the second player (Player2)
        /// </summary>
        public string Player2 { get; set; }

        /// <summary>
        /// The number of moves completed by Player1
        /// </summary>
        public int Player1MoveCount { get; set; }

        /// <summary>
        /// The number of moves completed by Player2
        /// </summary>
        public int Player2MoveCount { get; set; }



    }
}
