using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBet.Models
{
    public abstract class BaseModel
    {
        [Key] // pas obligatoire si la clé se nomme ID
        public int Id { get; set; }

        public bool Deleted { get; set; }

        public Guid? IdCrypt { get; set; }
    }
}
