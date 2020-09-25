using Blog.Models.DataBase;
using System.Collections.Generic;

namespace Blog.Test.Data
{
    public class ProfileTestData
    {
        public static IEnumerable<Profiles> GetProfilesData()
        {
            List<Profiles> lst = new List<Profiles>();
            lst.Add(new Profiles()
            {
                ProfileId = 1,
                Name = "admin",
                Description = "Administrator",
                State = true

            });
            lst.Add(new Profiles()
            {
                ProfileId = 2,
                Name = "user",
                Description = "Usuario",
                State = true
            });

            return lst;

        }
    }
}
