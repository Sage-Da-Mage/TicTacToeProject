using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Entities
{
    // This class exists to put Player and Game Entities associated with each other into
    // a single location for ease of acess.
    public class GameHub
    {
        // The Id of the game itself
        public Guid GameId { get; set; }


        // The Id of a specific Player
        public Guid PlayerId { get; set; }

        // The navigation property for a player
        public Player Player { get; set; }

        // The navigation property for a Game
        public Game Game { get; set; }


    }
}
