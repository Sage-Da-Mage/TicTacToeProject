using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Entities.VMs.MoveVMs
{
    // The View Model for the Move Entity, used for the creation and viewing of Move Entities

    public class MoveVM
    {
        // This is the position on the board this move was done on
        public int MovePosition { get; set; }

        // This is the Id of the board that the move takes place on
        public Guid BoardId { get; set; }

        // This is a navigational property for the board the move is on
        public Board Board { get; set; }

        // This is a navigational property to identify who made the move
        public Player MoveMadeBy { get; set; }


    }
}
