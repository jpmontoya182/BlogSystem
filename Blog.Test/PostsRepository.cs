using Blog.Models.DataBase;
using Blog.Models.Request;
using Blog.Repos.Contracts;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
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
            return (from p in this._DbContext.Posts select p);
        }


        public Posts GetPostById(int id)
        {
            return (from p in this._DbContext.Posts select p).FirstOrDefault();
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
