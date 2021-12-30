using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Entities.VMs.PlayerVMs
{
    // The View Model for the Player Entity, used for the creation and viewing of Player Entities
    public class PlayerVM : BasicEntity     // Basic entity grants an entity an Id, CreatedAt & LastUpdatedAt properties
    {

        // The constructor for generating an empty PlayerVM
        public PlayerVM()
        {

        }

        // The constructor for generating a PlayerVM model from a Player Entity
        public PlayerVM(Player src)
        {
            Id = src.Id;
            Name = src.Name;

            CreatedAt = src.CreatedAt;
            LastUpdatedAt = src.LastUpdatedAt;

        }


        // This is the name of the Player
        public string Name { get; set; }


    }
}
