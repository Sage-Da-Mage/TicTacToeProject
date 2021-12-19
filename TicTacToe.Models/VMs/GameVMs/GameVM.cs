using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Entities.VMs.GameVMs
{

    // The View Model for the Game Entity, used for the creation and viewing of Game Entities

    public class GameVM
    {
        // The bool that returns true in the case that the game ends in a draw
        public bool Draw { get; set; }

        // The bool that returns true once the game is over,
        // either in the victory of a Player or in a draw
        public bool Completed { get; set; }

        // The player that wins the game
        // (not necessarily going to exist in all games as some will end in a draw [no winner])
        public Player? Victor { get; set; }

        // The Board that this specific game takes place on
        public Board? InitializedBoard { get; set; }


    }
}
