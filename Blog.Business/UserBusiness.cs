using Blog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Business
{
    public class UserBusiness
    {
        private readonly SetUpModel _setUp;
        private AuthenticateUserBusiness _authenticationUser = null;
        public UserBusiness(SetUpModel setup)
        {
            _setUp = setup;
            _authenticationUser = new AuthenticateUserBusiness(_setUp);
        }


        public string Login(UserModel user)
        {
            return _authenticationUser.Login(user);
        }


    }
}
