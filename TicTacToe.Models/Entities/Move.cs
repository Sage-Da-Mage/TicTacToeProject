using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Entities
{
    // A move done on a board for a game of TicTacToe 
    // (Usually seen as placing an X or an O on one of the free positions)
    public class Move : BasicEntity
    {

        // An empty constructor for the creation of an empty Move Entity
        public Move()
        {

        }

        // Below are the properties belonging to the Move Entity

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
