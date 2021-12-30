using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Entities.VMs.MoveVMs
{
    /// <summary>
    /// The View Model for the Move Entity, used for the viewing of Move Entities 
    /// </summary>
    public class MoveVM
    {
        /// <summary>
        /// The empty Constructor for the generation of empty MoveVMs
        /// </summary>
        public MoveVM() 
        {
        
        }

        /// <summary>
        /// The constructor for generating a moveVM model
        /// </summary>
        /// <param name="gameCompleted"></param>
        /// <param name="winningTurn"></param>
        public MoveVM(bool gameCompleted, bool winningTurn)
        {

            GameCompleted = gameCompleted;
            WinningTurn = winningTurn;
        }

        // Properties of a MoveVM below

        /// <summary>
        /// Determines if the game is over, this is true if there is a victor or if there is a draw
        /// </summary>
        public bool GameCompleted { get; set; }

        /// <summary>
        /// The winning turn is true if a player wins the game with this turn
        /// </summary>
        public bool WinningTurn { get; set; }

    }
}
