using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Entity.Models
{
    public class Admission
    {
        [Key]
        public int TicketId { get; set; }

        //basic details
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        [Required]
        public string Category { get; set; }

        [Required]
        public string AdharNo { get; set; }

        [Required]
        public DateTime DoB { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile No")]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        public string Mobile { get; set; }

        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "School/College")]
        public string School { get; set; }

        [Required]
        public Nationality Nationality { get; set; }      

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }

        [RegularExpression(@"^\d{6}(-\d{4})?$", ErrorMessage = "Please Enter Valid Postal Code.")]
        public int Pincode { get; set; }

        [Required]
        public string PassingYear { get; set; }

        [Required]
        public int TotalMarks { get; set; }

        [Required]
        public int SecuredMark { get; set; }

        [Required]
        public float Percentage{get;set;}

        [Display(Name = "CDate")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "MDate")]
        public DateTime ModifiedDate { get; set; }

        [Required]
        public bool Agree { get; set; }


        public Admission()
        {
            this.CreationDate = DateTime.Now;   //DateTime.UtcNow;   universal time 5:30 difference to local time GMT-5:30
            this.ModifiedDate = DateTime.Now; //this.ModifiedDate = DateTime.UtcNow;            
        }
    }
    public enum Category
    {
        SC = 1,
        ST = 2,
        OBC = 3,
        Cat_I = 4,
        Cat_IIA = 5,
        Cat_IIB = 6,
        Cat_IIIA = 7
    }

    public enum Nationality
    {
        India = 1,
        Other = 2
    }







}
