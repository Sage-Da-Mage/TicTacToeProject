using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Entities.VMs.PlayerVMs
{
    /// <summary>
    /// The View Model for the Player Entity, used for the creation and viewing of Player Entities
    /// </summary>
    public class PlayerVM : BasicEntity     // Basic entity grants an entity an Id, CreatedAt & LastUpdatedAt properties
    {

        /// <summary>
        /// The constructor for generating an empty PlayerVM
        /// </summary>
        public PlayerVM()
        {

        }

        /// <summary>
        /// The constructor for generating a PlayerVM model from a Player Entity
        /// </summary>
        /// <param name="src"></param>
        public PlayerVM(Player src)
        {
            Id = src.Id;
            Name = src.Name;

            CreatedAt = src.CreatedAt;
            LastUpdatedAt = src.LastUpdatedAt;

        }

        /// <summary>
        /// This is the name of the Player
        /// </summary>
        public string Name { get; set; }


    }
}
