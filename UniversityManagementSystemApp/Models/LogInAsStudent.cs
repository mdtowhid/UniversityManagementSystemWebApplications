using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models
{
    public class LogInAsStudent
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide User Name Field")]
        [Display(Name = "User Name")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Please Provide Email Field")]
        
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Provide Password Field")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Provide ConfirmPassword Field")]
        public string ConfirmPassword { get; set; }

        public string StudentRegistrationNumber { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}