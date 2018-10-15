using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebApplication6.Models.PostViewModels;

namespace WebApplication6.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(20, ErrorMessage = "Description Max Length is 20")]
        public string Login { get; set; }
        [Required]
        public string Path { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }
        public string Information { get; set; }

        public int PostsColl { get; set; }
        public int SubscriptionColl { get; set; }
        public int SubscriberColl { get; set; }

        // public IEnumerable<PostModel> Posts { get; set; }

    }
}
