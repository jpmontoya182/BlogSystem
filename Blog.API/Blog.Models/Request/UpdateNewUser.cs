using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Models.Request
{
    public class UpdateNewUser : InsertNewUser
    {
        public int UserId { get; set; }
    }
}
