using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Entity.Models
{
   public class Log
    {
       [Key]
       public int Id { get; set; }

       public string UserName { get; set; }

       public string Password { get; set; }

       public bool isEnable { get; set; }
    }
}
