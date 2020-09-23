using System.Linq;
using System.Collections.Generic;
using Blog.Repos.Contracts;
using Blog.Models.DataBase;
using Blog.Models.Request;

namespace Blog.Repos
{
    public class UsersRepository : GenericRepository<Users>, IUsersRepository
    {
        private readonly BlogBDContext _DbContext;
        public UsersRepository(BlogBDContext context) : base(context)
        {
            _DbContext = context;
        }
        public IEnumerable<Users> GetAllUser()
        {
            return (from u in this._DbContext.Users select u);
        }
        public Users GetUserById(int id)
        {
            return (from u in this._DbContext.Users where u.UserId.Equals(id) select u).FirstOrDefault();
        }
        public void DeleteUser(int id)
        {
            Users user = this._DbContext.Users.Find(id);
            this._DbContext.Remove(user);
            this._DbContext.SaveChanges();
        }
        public void InsertUser(InsertNewUser entity)
        {
            Users userToSave = new Users()
            {
                Username = entity.Username,
                Password = entity.Password,
                Email = entity.Email,
                ProfileId = entity.ProfileId
            };
            this._DbContext.Users.Add(userToSave);
            this._DbContext.SaveChanges();
        }
        public void UpdateUser(UpdateNewUser entity)
        {
            Users userToUpdate = this._DbContext.Users.Find(entity.UserId);
            userToUpdate.Username = entity.Username;
            userToUpdate.Password = entity.Password;
            userToUpdate.Email = entity.Email;
            userToUpdate.ProfileId = entity.ProfileId;
            this._DbContext.SaveChanges();
        }
    }
}
