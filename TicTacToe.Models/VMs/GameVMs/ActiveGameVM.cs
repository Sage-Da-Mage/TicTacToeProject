using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.VMs.GameVMs
{
    // This class is used for showing the games that are currently active as well as for
    // counting the nubmer of moves each player has used in that game.
    public class ActiveGameVM
    {
        // The default constructor for generating an empty ActiveGameVm entity
        public ActiveGameVM()
        {

        }

        // The constructor for generating an ActiveGameVM from a gameId
        public ActiveGameVM(Guid gameId)
        {
            Id = gameId;
        }

        // Below are the properties of an activeGameVM

        // The Id is what allows us to differenciate and identify specific ActiveGameVMs
        public Guid Id { get; set; }


        // The name for the Player that starts the game off
        public string StartingPlayerName { get; set; }

        // The number of moves completed by the starting player (P1)
        public int Player1MoveCount { get; set; }


        // The name for the player that goes second
        public string Player2 { get; set; }

        // The number of moves that the second player has taken
        public int Player2MoveCount { get; set; }


    }
}
