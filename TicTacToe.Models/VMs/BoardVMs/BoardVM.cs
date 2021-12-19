using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Entities.VMs.BoardVMs
{
    // The View Model for the Board Entity, used for the creation and viewing of Board Entities

    public class BoardVM
    {
        // The number of collums the game is played within
        public int NumberOfColumns { get; set; }

        // The number of rows the game is played within
        public int NumberOfRows { get; set; }

        // The free spaces within the board (unused spaces)
        public IList<int> FreeSpaces { get; set; }


    }
}
