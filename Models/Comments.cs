using System;
using System.Collections.Generic;
using System.Linq;

namespace blog_crud1.Models
{
        public class Comment
        {
                public int CommentId { get; set; }
                public int PostId { get; set; }
                public string Text { get; set; } = "";
                public DateTime CreatedAt { get; set; }

                public virtual Post? Post { get; set; }
        }
}

