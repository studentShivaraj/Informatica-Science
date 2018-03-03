using IndproCareer.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndproCareer.Entity.Models
{
    public class School
    {
        [Key]
        public int SId { get; set; }

        // Foreign key 
        [Display(Name = "College")]
        public int CId { get; set; }
        [ForeignKey("CId")]
        public virtual College Colleges { get; set; }

        [Display(Name = "School")]
        [Required(ErrorMessage = "Please Enter School Name")]
        public string Name { get; set; }

        [RegularExpression(@"^\d{4}(-\d{4})?$", ErrorMessage = "Please Enter Valid YOE.")]
        public int YOE { get; set; }

        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile No")]
        [Display(Name = "Mobile")]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        public string Contact { get; set; }

        public string City { get; set; }

        [RegularExpression(@"^\d{6}(-\d{4})?$", ErrorMessage = "Please Enter Valid Postal Code.")]
        public int Pincode { get; set; }

        public string Adress { get; set; }
            
    }
    public class SchoolList : PagingViewModel
    {
        public PagedList.StaticPagedList<IndproCareer.Entity.ViewModel.PagingViewModel> Schools;
    }
}