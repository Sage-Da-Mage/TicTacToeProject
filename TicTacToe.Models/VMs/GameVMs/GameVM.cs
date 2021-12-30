using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Entities.VMs.GameVMs
{

    // The View Model for the Game Entity, used for the creation and viewing of Game Entities
    public class GameVM : BasicEntity
    {
        // This is the default constructor for generating empty GameVMs
        public GameVM ()
        {

        }

        // This is the constructor for creating a GameVM from a Game Entity
        public GameVM(Entities.Game src)
        {
            
            Draw = src.Draw;
            Completed = src.Completed;
            Victor = src.Victor;
            BoardList = src.BoardList;
        }

        // The bool that returns true in the case that the game ends in a draw
        public bool Draw { get; set; }

        // The bool that returns true once the game is over,
        // either in the victory of a Player or in a draw
        public bool Completed { get; set; }

        // The player that wins the game
        // (not necessarily going to exist in all games as some will end in a draw [no winner])
        public Player? Victor { get; set; }

        // The Board that this specific game takes place on
        public List<int> BoardList { get; set; }


    }
}
