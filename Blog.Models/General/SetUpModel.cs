using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Models
{
    public class SetUpModel
    {
        public string JwtKey { get; set; }
        public string JwtIssuer { get; set; }
        public string StringConnectionWriter { get; set; }
        public string StringConnectionReader { get; set; }
    }
}
