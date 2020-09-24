using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Models.Request
{
    public class InsertNewPosts
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string PostContent { get; set; }
        public int UserId { get; set; }
        public bool State { get { return true; } }
        public DateTime CreateDate { get { return DateTime.Now; } }
    }
}
