using System;
using System.Collections.Generic;
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

        // The number of collums the game is played within
        public int NumberOfColumns { get; set; }

        // The number of rows the game is played within
        public int NumberOfRows { get; set; }

        // The free spaces within the board (unused spaces)
        [NotMapped]
        public IList<int> FreeSpaces { get; set; }

    }
}
