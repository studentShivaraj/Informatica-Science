using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Entity.Models
{
    public class Citi
    {
        [Key]
        public int Id { get; set; }
       
        public virtual State States { get; set; }
        [Required]
        public string CitiName { get; set; }
    }
}
