using Blog.Models.DataBase;
using Blog.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Repos.Contracts
{
    public interface IUsersRepository
    {
        IEnumerable<Users> GetAllUser();
        Users GetUserById(int id);
        void InsertUser(InsertNewUser entity);
        void UpdateUser(UpdateNewUser entity);
        void DeleteUser(int id);
    }
}
