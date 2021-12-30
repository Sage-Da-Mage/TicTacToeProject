using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.VMs.PlayerVMs
{
    /// <summary>
    /// The VM that creates a player.
    /// </summary>
    public class PlayerCreateVM
    {
        /// <summary>
        /// A players Name, the remaining properties will be filled in outside a PlayerCreateVM
        /// </summary>
        public string Name { get; set; }

    }
}
