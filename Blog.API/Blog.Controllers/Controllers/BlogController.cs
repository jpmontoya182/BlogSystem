using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Business;
using Blog.Models;
using Blog.Models.DataBase;
using Blog.Models.Request;
using Blog.Repos;
using Blog.Repos.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Blog.Controllers.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        #region variables
        private readonly IOptions<SetUpModel> _setup;
        private readonly UnitofWork _unitOfWork;
        private UserBusiness _userBusiness = null;
        #endregion

        #region constructor
        public BlogController(IOptions<SetUpModel> setup, IUnitOfWork uow)
        {
            _setup = setup;
            _unitOfWork = uow as UnitofWork;
            _userBusiness = new UserBusiness(_setup.Value);
        }

        #endregion

        #region Comments 

        [HttpGet]
        [Route("GetAllComments")]
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





        #region Posts
        [HttpGet]
        [Route("GetAllPosts")]
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
        [Route("InsertPost")]
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
        [Route("UpdatePost")]
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

        #region Profiles

        //void UpdateProfile(UpdateProfile entity);
        //void DeleteProfile(int id);

        [HttpGet]
        [Route("GetAllProfiles")]
        [AllowAnonymous]
        public IEnumerable<Profiles> GetAllProfiles()
        {
            return _unitOfWork.ProfilesRepository.GetAllProfiles();
        }

        [HttpGet]
        [Route("GetProfileById/{ProfileId}")]
        [AllowAnonymous]
        public Profiles GetProfileById(string ProfileId)
        {
            Profiles result = new Profiles();
            try
            {
                int id;
                bool success = Int32.TryParse(ProfileId, out id);
                result = _unitOfWork.ProfilesRepository.GetProfileById(id);
            }
            catch (Exception)
            {
                throw;
            }
            return result;

        }

        [HttpPost]
        [Route("InsertPost")]
        [AllowAnonymous]
        public void InsertProfile(InsertNewProfile entity)
        {
            try
            {
                _unitOfWork.ProfilesRepository.InsertProfile(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("UpdateProfile")]
        [AllowAnonymous]
        public void UpdateProfile(UpdateProfile entity)
        {
            try
            {
                _unitOfWork.ProfilesRepository.UpdateProfile(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpDelete]
        [Route("DeleteProfile/{ProfileId}")]
        [AllowAnonymous]
        public void DeleteProfile(string ProfileId)
        {
            try
            {
                int id;
                bool success = Int32.TryParse(ProfileId, out id);
                if (success)
                {
                    _unitOfWork.ProfilesRepository.DeleteProfile(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Users

        [HttpGet]
        [Route("GetAllUser")]
        [AllowAnonymous]
        public IEnumerable<Users> GetAllUser()
        {
            return _unitOfWork.UsersRepository.GetAllUser();
        }

        [HttpGet]
        [Route("GetUserById/{UserId}")]
        [AllowAnonymous]
        public Users GetUserById(string UserId)
        {
            Users result = new Users();
            try
            {
                int id;
                bool success = Int32.TryParse(UserId, out id);
                result = _unitOfWork.UsersRepository.GetUserById(id);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        [HttpPost]
        [Route("InsertUser")]
        [AllowAnonymous]
        public void InsertUser(InsertNewUser entity)
        {
            try
            {
                _unitOfWork.UsersRepository.InsertUser(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        [AllowAnonymous]
        public void UpdateUser(UpdateNewUser entity)
        {
            try
            {
                _unitOfWork.UsersRepository.UpdateUser(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("DeleteUser/{UserId}")]
        [AllowAnonymous]
        public void DeleteUser(string UserId)
        {
            try
            {
                int id;
                bool success = Int32.TryParse(UserId, out id);
                if (success)
                {
                    _unitOfWork.UsersRepository.DeleteUser(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        #region security

        [HttpPost]
        [Route("login/")]
        [AllowAnonymous]
        public Dictionary<string, string> Login([FromBody] UserModel login)
        {

            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("token", _userBusiness.Login(login));
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}