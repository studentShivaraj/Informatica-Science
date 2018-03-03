using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Entity.Models
{
    public class Visiter
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter LastName")]
        public string LastName { get; set; }

        
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile No")]
        [Display(Name = "Mobile")]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Required Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Required State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Required City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter ZipCode ")]
        [RegularExpression(@"\d{6}$", ErrorMessage = "Invalid Zip Code")]
        public int ZipCode { get; set; }

        [Required]
        [StringLength(200)]
        public string Comments { get; set; }

        public DateTime DateTime { get; set; }

    }
}