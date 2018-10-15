﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string PhotoPath { get; set; }

        public string Username { get; set; }

        public string Gender { get; set; }

        public string Information { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }


        public string StatusMessage { get; set; }
    }
}
