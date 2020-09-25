using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Models
{
    public class UserModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string? email { get; set; }
    }
}
