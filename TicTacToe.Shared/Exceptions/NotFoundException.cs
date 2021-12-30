using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Shared.Exceptions
{
    public class NotFoundException : Exception
    {
        // The standard empty constructor for generating an empty NotFoundException
        public NotFoundException() 
        { 
        
        }

        // This constructor generates a NotFoundException with a message
        public NotFoundException(string message) 
            : base(message)
        {

        }




    }
}
