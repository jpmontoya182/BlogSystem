using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Models.Request
{
    public class UpdateProfile : InsertNewProfile
    {
        public int ProfileId { get; set; }
    }
}
