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
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Direction { get; set; }
        public string Sex { get; set; }
        public string Education { get; set; }
        public int Age { get; set; }
        public double UniversityAverageScore { get; set; }
        public double MathScore { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string Skype { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime StartDate { get; set; }
    }
}