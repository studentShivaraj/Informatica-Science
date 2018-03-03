using IndproCareer.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IndproCareer.Entity.Models
{
    public class College
    {
        [Key]
        public int CId { get; set; }

        // Foreign key 
        [Display(Name = "University")]
        public int Id { get; set; }
        [ForeignKey("Id")]
        public virtual University Universitys { get; set; }

        [Display(Name = "College")]
        [Required]
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

        public List<School> Schoolss { get; set; }

    }
    public class CollegeyList : PagingViewModel
    {
        public PagedList.StaticPagedList<IndproCareer.Entity.ViewModel.PagingViewModel> Colleges;
    }
}