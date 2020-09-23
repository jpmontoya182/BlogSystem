using System;
using System.Collections.Generic;

namespace Blog.Models.DataBase
{
    public partial class Users
    {
        public Users()
        {
            Posts = new HashSet<Posts>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int ProfileId { get; set; }

        public virtual Profiles Profile { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
    }
}
