using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Entities.VMs.MoveVMs
{
    // The View Model for the Move Entity, used for the viewing of Move Entities 

    public class MoveVM
    {
        // The empty Constructor for the generation of empty MoveVMs
        public MoveVM() 
        {
        
        }

        // The constructor for generating a moveVM model
        public MoveVM(bool gameCompleted, bool winningTurn)
        {

            GameCompleted = gameCompleted;
            WinningTurn = winningTurn;
        }

        // Properties of a MoveVM below
        // I MAY NEED TO CHANGE WHERE GAME COMPLETION BOOLS ARE, I THOUGHT THEY'D BE IN GAME
        // BUT IF I DETERMINE IF THE GAME IS OVER AS PART OF A MOVE I MAY WANT THEM IN HERE

        // Determines if the game is over, this is true if there is a victor or if there is a draw
        public bool GameCompleted { get; set; }

        // The winning turn is true if a player wins the game with this turn
        public bool WinningTurn { get; set; }

    }
}
