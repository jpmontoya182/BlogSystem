using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Blog.Models.DataBase;
using Blog.Models.Request;
using Blog.Repos;
using Blog.Repos.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace Blog.Controllers.Controllers
{
    [Route("api/Posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IOptions<SetUpModel> _setup;
        private readonly UnitofWork _unitOfWork;
        protected readonly ILogger<PostsController> _logger;

        public PostsController(IOptions<SetUpModel> setup, IUnitOfWork uow, ILogger<PostsController> logger)
        {
            _setup = setup;
            _unitOfWork = uow as UnitofWork;
            _logger = logger;
        }


        #region Posts

        [HttpGet]
        [Route("GetAllPosts/")]
        [AllowAnonymous]
        public IEnumerable<Posts> GetAllPosts()
        {
            List<Posts> result = new List<Posts>();
            try
            {
                result = _unitOfWork.PostsRepository.GetAllPosts().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        [HttpGet]
        [Route("GetPostById/{PostId}")]
        [AllowAnonymous]
        public Posts GetPostById(string PostId)
        {
            Posts result = new Posts();
            try
            {
                int id;
                bool success = Int32.TryParse(PostId, out id);
                result = _unitOfWork.PostsRepository.GetPostById(id);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        [HttpPost]
        [Route("InsertPost/")]
        [AllowAnonymous]
        public void InsertPost([FromBody] InsertNewPosts data)
        {
            try
            {
                _unitOfWork.PostsRepository.InsertPost(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("UpdatePost/")]
        [AllowAnonymous]
        public void UpdatePost([FromBody] UpdatePosts data)
        {
            try
            {
                _unitOfWork.PostsRepository.UpdatePost(data);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete]
        [Route("DeletePostById/{PostId}")]
        [AllowAnonymous]
        public void DeletePostById(string PostId)
        {
            try
            {
                int id;
                bool success = Int32.TryParse(PostId, out id);
                if (success)
                {
                    _unitOfWork.PostsRepository.DeletePostById(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}
