using IndproCareer.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndproCareer.Entity.Models
{
    public class University
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [RegularExpression(@"^\d{4}(-\d{4})?$", ErrorMessage = "Please Enter Valid YOE.")]
        public int YOE { get; set; }

        public string Slogan { get; set; }

        public List<College> Colleges { get; set; }
    }
    public class UniversityList : PagingViewModel
    {
        public PagedList.StaticPagedList<IndproCareer.Entity.ViewModel.PagingViewModel> Universitys;
    }
}