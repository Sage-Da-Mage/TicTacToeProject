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
    /// The difference beteween an UpdateVM and CreateVM is that the UpdateVm does not have unchangable properties. 
    /// </summary>
    public class GameUpdateVM : BasicEntity
    {
        // The properties of a Game

        /// <summary>
        /// The boolean to indicate if a draw was reached
        /// </summary>
        [Required]
        public bool Draw { get; set; }

        /// <summary>
        /// The boolean to indicate if the game has been completed yet
        /// </summary>
        [Required]
        public bool Completed { get; set; }

        /// <summary>
        /// The Player that won the game, null if the game isn't completed yet
        /// </summary>
        [Required]
        public Guid? Victor { get; set; }

        /// <summary>
        /// The board that this game is set on.
        /// </summary>
        [Required]
        public List<int> BoardList { get; set; }



    }
}
