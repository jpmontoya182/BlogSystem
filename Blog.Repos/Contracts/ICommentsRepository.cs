
using System.Collections.Generic;
using Blog.Models.DataBase;
using Blog.Models.Request;

namespace Blog.Repos.Contracts
{
    public interface ICommentsRepository
    {
        IEnumerable<Comments> GetAllComments();
        Comments GetCommentById(int id);
        void InsertComment(InsertNewComment entity);
        void DeleteComment(int id);
    }
}
