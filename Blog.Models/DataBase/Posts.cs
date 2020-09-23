using System;
using System.Collections.Generic;

namespace Blog.Models.DataBase
{
    public partial class Posts
    {
        public Posts()
        {
            Comments = new HashSet<Comments>();
        }

        public int PostId { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public DateTime CreateDate { get; set; }
        public bool State { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
