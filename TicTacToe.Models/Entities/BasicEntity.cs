using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Entities
{
    /// <summary>
    /// This is the basic entity class which shows the properties all Entities posses
    /// </summary>
    public abstract class BasicEntity
    {
        /// <summary>
        /// The Id of the Entity, used to differenciate entities/pick out specific entities in endpoints
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The DateTime which the entity was created at
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The DateTime which the entity was updated
        /// </summary>
        public DateTime LastUpdatedAt { get; set; }


    }
}
