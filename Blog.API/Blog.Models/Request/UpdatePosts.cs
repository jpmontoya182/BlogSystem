using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Models.Request
{
    public class UpdatePosts
    {
        public int PostId { get; set; }
        public string PostContent { get; set; }
    }
}
