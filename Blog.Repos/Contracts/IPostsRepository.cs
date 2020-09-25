using Blog.Models.DataBase;
using Blog.Models.Request;
using System.Collections.Generic;


namespace Blog.Repos.Contracts
{
    public interface IPostsRepository
    {
        IEnumerable<Posts> GetAllPosts();
        Posts GetPostById(int id);
        void InsertPost(InsertNewPosts entity);
        void UpdatePost(UpdatePosts entity);
        void DeletePostById(int id);
    }
}
