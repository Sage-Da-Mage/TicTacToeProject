using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.VMs.GameVMs;

namespace TicTacToe.Models.Entities
{
    /// <summary>
    /// The Game is the class which the playing of Tic Tac Toe is done in. It inheriets an Id, CreatedAT and LastUpdatedAt properties from the BasicEntity
    /// </summary>
    public class Game : BasicEntity 
    {
        /// <summary>
        /// The Empty constructor used for creating an empty Game Entity
        /// </summary>
        public Game()
        {

        }

        /// <summary>
        /// This constructor takes in a GameCreateVM to construct a Game
        /// </summary>
        /// <param name="src"></param>
        public Game(GameCreateVM src )
        {
            GameHubs = src.PlayersIds.Select(Id => new GameHub { PlayerId = Id }).ToList();
            PlayerStarting = src.PlayerStarting;

            Draw = src.Draw;
            Completed = src.Completed;
            Victor = src.Victor;
            BoardList = src.BoardList;

        }

        /// <summary>
        /// This constructor takes in a GameUpdateVM to update a Game
        /// </summary>
        /// <param name="src"></param>
        public Game(GameUpdateVM src)
        {


            Draw = src.Draw;
            Completed = src.Completed;
            Victor = src.Victor;
            BoardList = src.BoardList;

        }


        /// <summary>
        /// Return the completed variable (for once a game is completed)
        /// </summary>
        /// <returns></returns>
        public bool IsCompleted()
        {
            return Completed;
        }


        // Below are the properties of a Game Entity



        /// <summary>
        /// The bool that returns true in the case that the game ends in a draw
        /// </summary>
        [Required]
        public bool Draw { get; set; }

        /// <summary>
        /// The bool that returns true once the game is over,
        /// either in the victory of a Player or in a draw
        /// (This is important for later endpoints where we check for current games played)
        /// </summary>
        [Required]
        public bool Completed { get; set; }

        /// <summary>
        /// The player that wins the game (gotten via Id)
        /// (not necessarily going to exist in all games as some will end in a draw [no winner])
        /// </summary>
        public Guid? Victor { get; set; }

        /// <summary>
        /// The Board that this specific game takes place on
        /// A 3x3 set of tiles represented by numbers in a list of 9 ints
        /// 1= player 1, 2= player 2 and 5 = unused tile
        /// </summary>
        public List<int> BoardList { get; set; }

        /// <summary>
        /// The player (their Id) assigned to start the game of TicTacToe
        /// </summary>        
        public Guid PlayerStarting { get; set; }

        /// <summary>
        /// The collection of Player and Game info (navigation property)
        /// </summary>
        public ICollection<GameHub> GameHubs { get; set; }

    }
}
