using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Entity.Models
{
    public class SendMail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string To { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime DateTime { get; set; }
    }

}
