using Blog.Models.DataBase;
using System.Collections.Generic;

namespace Blog.Test.Blog.Repos.Data
{
    public class UsersTestData
    {
        public static IEnumerable<Users> GetUsersData()
        {
            List<Users> lst = new List<Users>();
            lst.Add(new Users()
            {
                UserId = 1,
                Email = "@uno.com",
                Password = "1232220",
                Username = "pepito",
                ProfileId = 1
            });

            lst.Add(new Users()
            {
                UserId = 2,
                Email = "@dos.com",
                Password = "123tytyty2220",
                Username = "Naruto",
                ProfileId = 1
            });


            lst.Add(new Users()
            {
                UserId = 3,
                Email = "@tres.com",
                Password = "12rtrt32220",
                Username = "Pedro",
                ProfileId = 1
            });


            lst.Add(new Users()
            {
                UserId = 4,
                Email = "@cuatro.com",
                Password = "sdsds",
                Username = "Juan182",
                ProfileId = 2
            });



            return lst;

        }

    }
}
