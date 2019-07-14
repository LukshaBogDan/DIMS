using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  
using System.Linq;
using System.Web;

namespace HIMS.Server.Models
{
    public class vUserProfileViewModel
    {
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string FullName { get; set; }
        [EmailAddress]
        [Required]
        [Display(Name="Mail")]
        public string Email { get; set; }
        public string Direction { get; set; }
        public string Sex { get; set; }
        public string Education { get; set; }
        public int Age { get; set; }
        [Range(1,10)]
        public double UniversityAverageScore { get; set; }
        [Range(1, 10)]
        public double MathScore { get; set; }
        public string Address { get; set; }
        [Phone]
        public string MobilePhone { get; set; }
        public string Skype { get; set; }
        public DateTime StartDate { get; set; }
    }
}