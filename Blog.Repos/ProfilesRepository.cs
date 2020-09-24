using Blog.Models.DataBase;
using Blog.Models.Request;
using Blog.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Repos
{
    public class ProfilesRepository : GenericRepository<Profiles>, IProfilesRepository
    {
        private readonly BlogBDContext _DbContext;
        public ProfilesRepository(BlogBDContext context) : base(context)
        {
            _DbContext = context;
        }

        public IEnumerable<Profiles> GetAllProfiles()
        {
            return (from p in this._DbContext.Profiles select p);
        }

        public Profiles GetProfileById(int id)
        {
            return (from p in this._DbContext.Profiles where p.ProfileId.Equals(id) select p).FirstOrDefault();
        }

        public void InsertProfile(InsertNewProfile entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateProfile(UpdateProfile entity)
        {
            Profiles profileToUpdate = this._DbContext.Profiles.Find(entity.ProfileId);
            profileToUpdate.Name = entity.Name;
            profileToUpdate.Description = entity.Description;
            profileToUpdate.State = entity.State;
            this._DbContext.SaveChanges();
        }
        public void DeleteProfile(int id)
        {
            Profiles profile = _DbContext.Profiles.Find(id);
            this._DbContext.Profiles.Remove(profile);
            this._DbContext.SaveChanges();
        }

    }
}
