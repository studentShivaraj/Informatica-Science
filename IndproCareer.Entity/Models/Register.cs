using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Entity.Models
{
    public class Register
    {
        [Key]
        public int Id { get; set; }

        public Roles Role { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile No")]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        public string Mobile { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }

        [RegularExpression(@"^\d{6}(-\d{4})?$", ErrorMessage = "Please Enter Valid Postal Code.")]
        public int Pincode { get; set; }

        [Display(Name = "CDate")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "MDate")]
        public DateTime ModifiedDate { get; set; }

        public Register()
        {
            this.CreationDate = DateTime.Now;   //DateTime.UtcNow;   universal time 5:30 difference to local time GMT-5:30
            this.ModifiedDate = DateTime.Now; //this.ModifiedDate = DateTime.UtcNow;            
        }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }       
        
    }

    public enum Roles
    {
        SuperAdmin = 1,
        CollegeAdmin = 2,
        SchoolAdmin = 3
    }

    public class Login
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }

}
