using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.VMs.GameVMs;

namespace TicTacToe.Models.Entities
{
    public class Game : BasicEntity 
    {
        // The Empty constructor used for creating an empty Game Entity
        public Game()
        {

        }

        // This constructor takes in a GameCreateVM to construct a Game
        public Game(GameCreateVM src )
        {
            Draw = src.Draw;
            Completed = src.Completed;
            Victor = src.Victor;
            BoardList = src.BoardList;

        }

        // This constructor takes in a GameUpdateVM to update a Game
        public Game(GameUpdateVM src)
        {
            Draw = src.Draw;
            Completed = src.Completed;
            Victor = src.Victor;
            BoardList = src.BoardList;

        }


        // Return the completed variable (for once a game is completed)
        public bool IsCompleted()
        {
            return Completed;
        }


        // Below are the properties of a Game Entity

        // Id for differenciating games (having issues with using BasicEntity)
        //[Key]
        //public Guid Id { get; set; }


        // The bool that returns true in the case that the game ends in a draw
        [Required]
        public bool Draw { get; set; }

        // The bool that returns true once the game is over,
        // either in the victory of a Player or in a draw
        // (This is important for later endpoints where we check for current games played)
        [Required]
        public bool Completed { get; set; }

        // The player that wins the game
        // (not necessarily going to exist in all games as some will end in a draw [no winner])
        public Player? Victor { get; set; }

        // The Board that this specific game takes place on
        public List<int> BoardList { get; set; }
        
        

    }
}
