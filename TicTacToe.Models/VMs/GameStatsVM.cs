using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.VMs
{

    // This class holds stats regarding a game (specifically the number of moves players have made)
    public class GameStatsVM
    {
        // The standard empty constructor for generating empty GameStatsVM entities
        public GameStatsVM()
        {

        }

        // The Id belonging to the game which this entitiy is associated with
        public Guid GameId { get; set; }

        // The name of the starting player (Player1)
        public string StartingPlayer { get; set; }

        // The name of the second player (Player2)
        public string Player2 { get; set; }

        // The number of moves completed by Player1
        public int Player1MoveCount { get; set; }

        // The number of moves completed by Player2
        public int Player2MoveCount { get; set; }



    }
}
