using Blog.Models.DataBase;
using Blog.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repos
{
    public class UnitofWork : IUnitOfWork
    {
        private readonly BlogBDContext _DbContext;
        public CommentsRepository CommentsRepository { get; private set; }
        public PostsRepository PostsRepository { get; private set; }
        public ProfilesRepository ProfilesRepository { get; private set; }
        public UsersRepository UsersRepository { get; private set; }
        public UnitofWork(BlogBDContext context)
        {
            _DbContext = context;
            this.CommentsRepository = new CommentsRepository(this._DbContext);
            this.PostsRepository = new PostsRepository(this._DbContext);
            this.ProfilesRepository = new ProfilesRepository(this._DbContext);
            this.UsersRepository = new UsersRepository(this._DbContext);
        }
        public async Task Commit()
        {
            await this._DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._DbContext.Dispose();
        }
    }
}
