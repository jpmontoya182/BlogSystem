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

        public UnitofWork(BlogBDContext context)
        {
            _DbContext = context;
            this.CommentsRepository = new CommentsRepository(this._DbContext);
        }
        public async Task Commit()
        {
            await _DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _DbContext.Dispose();
        }
    }
}
