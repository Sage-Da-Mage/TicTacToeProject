using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities;

namespace TicTacToe.Models.VMs.GameVMs
{
    /// <summary>
    /// The VM that is used to create a GameVM
    /// </summary>
    public class GameCreateVM : BasicEntity
    {



        /// <summary>
        /// The list of players associated with this game (2 max/min)
        /// </summary>
        [Required]
        public List<Guid> PlayersIds { get; set; }

        /// <summary>
        /// The player assigned to go first
        /// </summary>
        public Guid PlayerStarting { get; set; }


        /// <summary>
        /// The boolean to indicate if a draw was reached
        /// </summary>
        [Required]
        public bool Draw { get; set; }

        /// <summary>
        /// The boolean to indicate if the game has been completed yet.
        /// </summary>
        [Required]
        public bool Completed { get; set; }

        /// <summary>
        /// The Player that won the game, null if the game isn't completed yet.
        /// </summary>
        public Guid? Victor { get; set; }

        /// <summary>
        /// The board that this game is set on.
        /// </summary>
        [Required]
        public List<int> BoardList { get; set; }

    }
}
