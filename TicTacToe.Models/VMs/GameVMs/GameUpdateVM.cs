using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities;

namespace TicTacToe.Models.VMs.GameVMs
{
    // The difference beteween an UpdateVM and CreateVM is that 
    // the UpdateVm does not have unchangable properties. 
    public class GameUpdateVM
    {
        // The properties of a Game

        // The boolean to indicate if a draw was reached
        [Required]
        public bool Draw { get; set; }

        // The boolean to indicate if the game has been completed yet.
        [Required]
        public bool Completed { get; set; }

        // The Player that won the game, null if the game isn't completed yet.
        [Required]
        public Player? Victor { get; set; }

        // The board that this game is set on.
        [Required]
        public List<int> BoardList { get; set; }



    }
}
