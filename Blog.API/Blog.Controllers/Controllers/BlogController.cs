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
    [Route("api/Users")]
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




        #region Users

        [HttpGet]
        [Route("GetAllUser/")]
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
        [Route("InsertUser/")]
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
        [Route("UpdateUser/")]
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
        [Route("Login/")]
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