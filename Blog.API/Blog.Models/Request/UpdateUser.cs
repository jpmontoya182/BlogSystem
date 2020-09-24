using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Models.Request
{
    public class UpdateUser : InsertNewUser
    {
        public int UserId { get; set; }
    }
}
