using Blog.Models.DataBase;
using Blog.Models.Request;
using Blog.Repos.Contracts;
using System.Collections.Generic;
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
            return (from c in _DbContext.Comments
                    join p in this._DbContext.Posts on c.PostId equals p.PostId
                    select new Comments
                    {
                        CommentId = c.CommentId,
                        ContentComment = c.ContentComment,
                        CreateDate = c.CreateDate,
                        Post = p
                    });
        }
        public Comments GetCommentById(int id)
        {
            return (from c in _DbContext.Comments
                    join p in _DbContext.Posts on c.PostId equals p.PostId
                    where c.CommentId.Equals(id)
                    select new Comments
                    {
                        CommentId = c.CommentId,
                        ContentComment = c.ContentComment,
                        CreateDate = c.CreateDate,
                        Post = p
                    }).FirstOrDefault();
        }
        public void InsertComment(InsertNewComment entity)
        {

            Comments Comment = new Comments()
            {
                ContentComment = entity.ContentComment,
                PostId = entity.PostId,
                CreateDate = entity.CreateDate
            };

            this._DbContext.Comments.Add(Comment);
            this._DbContext.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            Comments comment = this._DbContext.Comments.Find(id);
            this._DbContext.Comments.Remove(comment);
            this._DbContext.SaveChanges();
        }
    }
}
