using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication6.Models.PostViewModels;

namespace WebApplication6.Models { 

    public class PostModel : Entity
    {
        public string Title { get; set; }

        [ForeignKey("ApplicationUser")] public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }

        public string PostPhoto { get; set; }

        public DateTime Time { get; set; }

        public string Description { get; set; }

        public IEnumerable<FeedbackPostModel> FeedbacksPost { get; set; }

        public int Likes { get; set; }
    }
}