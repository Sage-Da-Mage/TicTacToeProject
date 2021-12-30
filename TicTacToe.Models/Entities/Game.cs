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
            GameHubs = src.PlayersIds.Select(Id => new GameHub { PlayerId = Id }).ToList();
            PlayerStarting = src.PlayerStarting;

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
        public Guid? Victor { get; set; }

        // The Board that this specific game takes place on
        // A 3x3 set of tiles represented by numbers in a list of 9 ints
        // 1= player 1, 2= player 2 & 3 = unused tile
        public List<int> BoardList { get; set; }

        // The player (their Id) assigned to start the game of TicTacToe 
        public Guid PlayerStarting { get; set; }
        
        // The collection of Player and Game info (navigation property)
        public ICollection<GameHub> GameHubs { get; set; }

    }
}
