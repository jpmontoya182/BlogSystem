using Blog.Models;
using Blog.Models.DataBase;
using Blog.Models.Request;
using Blog.Repos;
using Blog.Repos.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Blog.Controllers.Controllers
{
    [Route("api/Comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        private readonly IOptions<SetUpModel> _setup;
        private readonly UnitofWork _unitOfWork;

        public CommentsController(IOptions<SetUpModel> setup, IUnitOfWork uow)
        {
            _setup = setup;
            _unitOfWork = uow as UnitofWork;
        }


        #region Comments 

        [HttpGet]
        [Route("GetAllComments/")]
        [AllowAnonymous]
        public IEnumerable<Comments> GetAllComments()
        {
            List<Comments> result = new List<Comments>();
            try
            {
                result = _unitOfWork.CommentsRepository.GetAllComments().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        [HttpGet]
        [Route("GetCommentById/{CommentId}")]
        [AllowAnonymous]
        public Comments GetCommentById(string CommentId)
        {
            try
            {
                int id;
                bool success = Int32.TryParse(CommentId, out id);
                Comments result = new Comments();

                if (success)
                {
                    result = _unitOfWork.CommentsRepository.GetCommentById(id);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("InsertComment/")]
        public void InsertComment([FromBody] InsertNewComment data)
        {
            _unitOfWork.CommentsRepository.InsertComment(data);
        }


        [HttpDelete]
        [Route("DeleteComment/{CommentId}")]
        public void DeleteComment(string CommentId)
        {
            int id;
            bool success = Int32.TryParse(CommentId, out id);
            _unitOfWork.CommentsRepository.DeleteComment(id);
        }

        #endregion
    }
}
