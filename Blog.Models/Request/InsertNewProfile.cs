using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Models.Request
{
    public class InsertNewProfile
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get { return true; } }
    }
}
