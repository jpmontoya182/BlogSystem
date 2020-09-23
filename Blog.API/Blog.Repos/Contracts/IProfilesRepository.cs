using Blog.Models.DataBase;
using Blog.Models.Request;
using System.Collections.Generic;

namespace Blog.Repos.Contracts
{
    public interface IProfilesRepository
    {
        IEnumerable<Profiles> GetAllProfiles();
        Profiles GetProfileById(int id);
        void InsertProfile(InsertNewProfile entity);
        void UpdateProfile(UpdateProfile entity);
        void DeleteProfile(int id);
    }
}
