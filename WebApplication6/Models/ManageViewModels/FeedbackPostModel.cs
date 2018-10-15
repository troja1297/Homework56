using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace WebApplication6.Models.PostViewModels
{
    public class FeedbackPostModel : Entity
    {
        public string OwnerId { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
    }
}
