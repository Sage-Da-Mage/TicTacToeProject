using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities;

namespace TicTacToe.Models.VMs.GameVMs
{
    // The VM that is used to create a GameVM
    public class GameCreateVM : BasicEntity
    {
       
        

        // The list of players associated with this game (2 max/min)
        [Required]
        public List<Guid> PlayersIds { get; set; }

        // The player assigned to go first
        public Guid PlayerStarting { get; set; }

        
        // The boolean to indicate if a draw was reached
        [Required]
        public bool Draw { get; set; }

        // The boolean to indicate if the game has been completed yet.
        [Required]
        public bool Completed { get; set; }

        // The Player that won the game, null if the game isn't completed yet.
        public Guid? Victor { get; set; }

        // The board that this game is set on.
        [Required]
        public List<int> BoardList { get; set; }

    }
}
