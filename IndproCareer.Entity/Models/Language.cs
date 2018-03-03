using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndproCareer.Entity.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }    
       
    }
}