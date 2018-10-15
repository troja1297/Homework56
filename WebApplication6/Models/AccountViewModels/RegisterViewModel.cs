using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication6.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Login")]
        [StringLength(20, ErrorMessage = "Login max length is 20")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(40, ErrorMessage = "Name max length is 40")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Select gender")]
        public int Gender { get; set; }

        [Phone]
        [Display(Name = "Enter phone number")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Insert Photo")]
        public IFormFile UserPhoto { get; set; }

        [Display(Name = "About yourself")]
        [StringLength(300, ErrorMessage = "Description Max Length is 300")]
        public string Information { get; set; }
    }
}
