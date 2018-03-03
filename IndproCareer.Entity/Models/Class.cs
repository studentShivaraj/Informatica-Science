using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndproCareer.Entity.Models
{
    public class Class
    {

        [Key]
        public int ClassNo { get; set; }

        // Foreign key 
        [Display(Name = "School")]
        public int SId { get; set; }
        [ForeignKey("SId")]
        public virtual School Schools { get; set; }

        [Display(Name = "Class")]
        [Required(ErrorMessage = " Branch Name Is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Class Madium is Required")]
        public string Madium { get; set; }


    }
}