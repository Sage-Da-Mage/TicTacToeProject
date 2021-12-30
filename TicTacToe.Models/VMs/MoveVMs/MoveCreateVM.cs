using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.VMs.MoveVMs
{
    /// <summary>
    /// The VM for creating a MoveVM
    /// </summary>
    public class MoveCreateVM
    {

        /// <summary>
        /// The Id of the Game the move is set for
        /// </summary>
        [Required]
        public Guid GameId { get; set; }

        /// <summary>
        /// The player who is making the move
        /// </summary>
        [Required]
        public Guid PlayerId { get; set; }

        /// <summary>
        /// The tile which the move is done upon (arranged as 3 rows of integers 0-2, 3-5, 6-8) [INVALID IF NUMBERPASSEDIN greater than 8 || NUMBERPASSEDIN less than 0]
        /// </summary>
        [Required]
        public int TileSelected { get; set; }

    }
}
