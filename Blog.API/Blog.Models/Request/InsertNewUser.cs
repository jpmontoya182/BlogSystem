using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Models.Request
{
    public class InsertNewUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int ProfileId { get; set; }
    }
}
