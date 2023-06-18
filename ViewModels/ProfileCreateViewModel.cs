using System;
using System.ComponentModel.DataAnnotations;
using ProfileManagement.Models;

namespace ProfileManagement.ViewModels;

public class ProfileCreateView
    { 
        [Required]
        [MaxLength(30, ErrorMessage = "Name cannot exceed 30 characters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", 
            ErrorMessage = "Invalid Email Format")]
        [Display(Name = "Standard Email")]
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set; }
        public string Skills { get; set; }
        [Required]
        public string Experience { get; set; } 
        [Required]
        public string Projects { get; set; }
        public IFormFile Photo { get; set; }
    }