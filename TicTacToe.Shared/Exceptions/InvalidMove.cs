using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Shared.Exceptions
{
    public class InvalidMove : Exception
    {
        // The default, empty constructor for generating an empty InvalidMove 
        public InvalidMove()
        {

        }

        // This constructor allows us to generate InvalidMoveExceptions with messages.
        public InvalidMove(string message) 
            : base(message)
        {

        }


    }
}
