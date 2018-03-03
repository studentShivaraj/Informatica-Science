using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndproCareer.Entity.Models
{
    public class BasicDetail
    {
        [Key]
        public int Id { get; set; }
        public string FName { get; set; }

        public string LName { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public bool Gender { get; set; }

        public string Email { get; set; }

        public DateTime DOB { get; set; }

        public string MobileNo { get; set; }

        public string AdharNo { get; set; }
    }
}