using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using WebApplication6.Models;

namespace WebApplication6.Models { 
    public class PostViewModel : Entity
    {
        public string OwnerId { get; set; }

        [Required]
        [Display(Name = "Text")]
        [StringLength(120, ErrorMessage = "Description Max Length is 120")]
        public string Title { get; set; }

        [Required]
        public IFormFile PostPhoto { get; set; }


        public string Name { get; set; }

        [Display(Name = "Text")]
        [StringLength(2000, ErrorMessage = "Description Max Length is 2000")]
        public string Description { get; set; }
    }
}