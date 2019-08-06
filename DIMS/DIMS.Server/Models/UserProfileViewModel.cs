using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIMS.Server.Models
{
    public class UserProfileViewModel
    {
        public int UserId { get; set; }
        [Required]
        [Display(Name = "Direction")]
        public int DirectionId { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "The maximum length of Name is 15 characters.")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [RegularExpression(@"^(([a-z0-9_-]+\.)*[a-z0-9_-]+){6,}@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Incorrect email address.")]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "The maximum length of Last Name is 15 characters.")]
        public string LastName { get; set; }
        public string Sex { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "The maximum length of Education is 100 characters.")]
        public string Education { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "University Average Score must be in range from 0 to 10")]
        public double UniversityAverageScore { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "Math Score must be in range from 0 to 10")]
        public double MathScore { get; set; }
        public string Address { get; set; }
        [Required]
        [StringLength(13, ErrorMessage = "The maximum length of Mobile Phone is 13 characters (Format: +375xxxxxxxxx).")]
        public string MobilePhone { get; set; }
        public string Skype { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        public string Role { get; set; }
    }
}