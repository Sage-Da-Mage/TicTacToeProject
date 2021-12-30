using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.VMs.GameVMs
{
    /// <summary>
    /// This class is used for showing the games that are currently active as well as for counting the number
    /// of moves each player has used in that game
    /// </summary>
    public class ActiveGameVM
    {
        /// <summary>
        /// The default constructor for generating an empty ActiveGameVm entity
        /// </summary>
        public ActiveGameVM()
        {

        }

        /// <summary>
        /// The constructor for generating an ActiveGameVM from a gameId
        /// </summary>
        /// <param name="gameId"></param>
        public ActiveGameVM(Guid gameId)
        {
            Id = gameId;
        }

        // Below are the properties of an activeGameVM

        /// <summary>
        /// The Id is what allows us to differenciate and identify specific ActiveGameVMs
        /// </summary>
        public Guid Id { get; set; }


        /// <summary>
        /// The name for the Player that starts the game off
        /// </summary>
        public string StartingPlayerName { get; set; }

        /// <summary>
        /// The number of moves completed by the starting player (P1)
        /// </summary>
        public int Player1MoveCount { get; set; }


        /// <summary>
        /// The name for the player that goes second
        /// </summary>
        public string Player2 { get; set; }

        /// <summary>
        /// The number of moves that the second player has taken
        /// </summary>
        public int Player2MoveCount { get; set; }


    }
}
