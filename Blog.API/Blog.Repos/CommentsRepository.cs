using Blog.Models.DataBase;
using Blog.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Blog.Repos
{
    public class CommentsRepository : GenericRepository<Comments>, ICommentsRepository
    {
        private readonly BlogBDContext _DbContext;
        public CommentsRepository(BlogBDContext context) : base(context)
        {
            _DbContext = context;
        }

        public IEnumerable<Comments> GetAllComments()
        {
            return (from c in _DbContext.Comments select c);
        }
    }
}
