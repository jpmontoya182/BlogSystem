using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Models.Request
{
    public class InsertNewComment
    {
        public string ContentComment { get; set; }
        public int PostId { get; set; }
        public DateTime CreateDate { get { return DateTime.Now; } }
    }
}
