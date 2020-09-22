using System;
using System.Collections.Generic;
using Blog.Business;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Blog.Controllers.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IOptions<SetUpModel> _setup;
        private UserBusiness _userBusiness = null;

        public BlogController(IOptions<SetUpModel> setup)
        {
            _setup = setup;
            _userBusiness = new UserBusiness(_setup.Value);
        }
        // select -> get
        // insert -> post
        // update -> put
        // delete -> DELETE

        [HttpGet]
        [Route("getAllComments")]
        [AllowAnonymous]
        public void getAllComments()
        {

        }

        [HttpGet]
        [Route("getCommentById/{CommentId}")]
        [AllowAnonymous]
        public void getCommentById(string CommentId)
        {
        }


        [HttpPost]
        [Route("getCommentsByUser/")]
        public void getCommentsByUser(string User)
        {

        }

        [HttpPost]
        [Route("insert/")]
        public void insertComment()
        {
        }

        [HttpPut]
        [Route("update/")]
        public void updateComment()
        {
        }


        [HttpDelete]
        [Route("delete/")]
        public void deleteComment()
        { }



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



    }
}