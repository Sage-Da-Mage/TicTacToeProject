using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Entities
{
    // This is the basic entity class which shows the properties all Entities posses
    public abstract class BasicEntity
    {
        // The Id of the Entity, used to differenciate
        // between entities/pick out specific entities in endpoints
        [Key]
        public Guid Id { get; set; }

        // The DateTime which the entity was created at
        public DateTime CreatedAt { get; set; }

        // The DateTime which the entity was updated
        public DateTime UpdatedAt { get; set; }


    }
}
