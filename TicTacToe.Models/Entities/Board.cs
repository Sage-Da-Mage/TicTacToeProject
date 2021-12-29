using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Entities
{
    // This Class represents the board TicTacToe is played on as well as all the associated properties
    public class Board : BasicEntity
    {

        // An empty constructor for the creation of an empty Board Entity
        public Board()
        {

        }


        // Below are the properties of a Board Entity

        // A TicTacToe board is a 3x3 set of tiles all initially empty
        // An empty tile is represented by a 3
        // A tile used by Player 1 is represented by a 1
        // A tile used by Player 2 is represented by a 2
        public List<int> BoardList { get; set; }

    }
}
