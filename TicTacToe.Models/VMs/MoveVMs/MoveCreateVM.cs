﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.VMs.MoveVMs
{
    class MoveCreateVM
    {

        // The Id of the Game the move is set for
        [Required]
        public Guid GameId { get; set; }

        // The player who is making the move
        [Required]
        public Guid PlayerId { get; set; }

        // The tile which the move is done upon (arranged as 3 rows of integers 0-2, 3-5, 6-8)
        [Required]
        public int TileSelected { get; set; }

    }
}
