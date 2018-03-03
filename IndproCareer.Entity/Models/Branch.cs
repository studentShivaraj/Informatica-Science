using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IndproCareer.Entity.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }

        // Foreign key 
        [Display(Name = "College")]
        public int CId { get; set; }
        [ForeignKey("CId")]
        public virtual College Colleges { get; set; }

        [Display(Name = "Branch")]
        [Required(ErrorMessage = "Branch Name Required")]
        public string Name { get; set; }

    }
}