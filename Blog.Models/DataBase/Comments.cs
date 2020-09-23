using System;
using System.Collections.Generic;

namespace Blog.Models.DataBase
{
    public partial class Comments
    {
        public int CommentId { get; set; }
        public string ContentComment { get; set; }
        public DateTime CreateDate { get; set; }
        public int PostId { get; set; }

        public virtual Posts Post { get; set; }
    }
}
