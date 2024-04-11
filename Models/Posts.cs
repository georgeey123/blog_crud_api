using System;
using System.Collections.Generic;
using System.Linq;

namespace blog_crud1.Models
{
    public class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }
        public int PostId { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}


