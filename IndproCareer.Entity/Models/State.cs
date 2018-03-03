using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Entity.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }

        public virtual Country Countrys { get; set; }

        [Required]
        public string StateName { get; set; }
    }
}
