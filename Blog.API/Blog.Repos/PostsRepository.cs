using Blog.Models.DataBase;
using Blog.Models.Request;
using Blog.Repos.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Repos
{
    public class PostsRepository : GenericRepository<Posts>, IPostsRepository
    {
        private readonly BlogBDContext _DbContext;

        public PostsRepository(BlogBDContext context) : base(context)
        {
            _DbContext = context;
        }

        public IEnumerable<Posts> GetAllPosts()
        {
            return (from p in this._DbContext.Posts
                    join u in this._DbContext.Users on p.UserId equals u.UserId
                    select new Posts
                    {
                        PostId = p.PostId,
                        Title = p.Title,
                        PostContent = p.PostContent,
                        CreateDate = p.CreateDate,
                        State = p.State,
                        UserId = p.UserId,
                        User = u
                    });


        }

        public Posts GetPostById(int id)
        {
            return (from p in this._DbContext.Posts
                    join u in this._DbContext.Users on p.UserId equals u.UserId
                    // join c in this._DbContext.Comments on p.PostId equals c.PostId
                    where p.PostId.Equals(id)
                    select new Posts
                    {
                        PostId = p.PostId,
                        Title = p.Title,
                        PostContent = p.PostContent,
                        CreateDate = p.CreateDate,
                        State = p.State,
                        UserId = p.UserId,
                        User = u
                        //,
                        //Comments = new List<Comments>
                        //{
                        //    PostId = c.PostId
                        //}
                    }).FirstOrDefault();
        }

        public void InsertPost(InsertNewPosts entity)
        {
            Posts postToSave = new Posts()
            {
                Title = entity.Title,
                PostContent = entity.PostContent,
                CreateDate = entity.CreateDate,
                State = entity.State,
                UserId = entity.UserId
            };

            this._DbContext.Posts.Add(postToSave);
            this._DbContext.SaveChanges();
        }

        public void UpdatePost(UpdatePosts entity)
        {
            Posts postToUpdate = this._DbContext.Posts.Find(entity.PostId);
            postToUpdate.PostContent = entity.PostContent;
            postToUpdate.Title = entity.Title;
            this._DbContext.SaveChanges();
        }

        public void DeletePostById(int id)
        {
            Posts postDelete = this._DbContext.Posts.Find(id);
            this._DbContext.Posts.Remove(postDelete);
            this._DbContext.SaveChanges();
        }
    }
}
