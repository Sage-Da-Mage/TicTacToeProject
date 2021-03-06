using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Entities.VMs.GameVMs
{

    /// <summary>
    /// The View Model for the Game Entity, used for the creation and viewing of Game Entities
    /// </summary>
    public class GameVM
    {
        /// <summary>
        /// This is the default constructor for generating empty GameVMs
        /// </summary>
        public GameVM ()
        {

        }

        /// <summary>
        /// This is the constructor for creating a GameVM from a Game Entity
        /// </summary>
        /// <param name="src"></param>
        public GameVM(Game src)
        {
            GameId = src.Id;
            PlayersIds = src.GameHubs.Select(Id => Id.PlayerId).ToList();

            /*
            Draw = src.Draw;
            Completed = src.Completed;
            Victor = src.Victor;
            BoardList = src.BoardList;
            */
        }

        /* Removing this from the VM to match the desired return type of the Endpoint 
         * 
        // The bool that returns true in the case that the game ends in a draw
        public bool Draw { get; set; }

        // The bool that returns true once the game is over,
        // either in the victory of a Player or in a draw
        public bool Completed { get; set; }

        // The player that wins the game
        // (not necessarily going to exist in all games as some will end in a draw [no winner])
        public Guid? Victor { get; set; }

        // The Board that this specific game takes place on
        public List<int> BoardList { get; set; }
        */

        /// <summary>
        /// The List of players (Ids) that are associated with this game (max/min 2)
        /// </summary>
        public List<Guid> PlayersIds { get; set; }

        /// <summary>
        /// A temporary holding for the Id of a game being passed in 
        /// </summary>
        public Guid GameId { get; set; }
    }
}
