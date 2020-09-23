using Blog.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Repos.Contracts
{
    public interface ICommentsRepository
    {
        IEnumerable<Comments> GetAllComments();
    }
}
