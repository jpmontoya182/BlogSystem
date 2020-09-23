using System;
using System.Collections.Generic;

namespace Blog.Models.DataBase
{
    public partial class Profiles
    {
        public Profiles()
        {
            Users = new HashSet<Users>();
        }

        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
