using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Entities
{
    // This Entity represents a player of TicTacToe
    public class Player : BasicEntity
    {

        // An empty constructor for the creation of an empty Player Entity
        public Player()
        {

        }

        // Below are the properties of a Player Entity

        // This is the name of the Player
        public string Name { get; set; }

        // This is the bool which shows whether a player is a human or
        // a computer playing the game
        public bool ComputerPlayer { get; set; }




    }
}
