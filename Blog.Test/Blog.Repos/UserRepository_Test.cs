﻿using Blog.Models.DataBase;
using Blog.Repos;
using Blog.Test.Blog.Repos.Data;
using Blog.Test.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace Blog.Test.Blog.Repos
{
    [TestClass]
    public class UserRepository_Test
    {

        [TestMethod]
        public void GetAllUser()
        {
            var demoDataContext = new Mock<BlogBDContext>();
            // get data simulate on UsersTestData.GetUsersData()
            demoDataContext.Setup(x => x.Users).Returns(UnitTestHelpers.GetQueryableMockDbSet<Users>(UsersTestData.GetUsersData().ToList()));
            demoDataContext.Setup(x => x.Profiles).Returns(UnitTestHelpers.GetQueryableMockDbSet<Profiles>(ProfileTestData.GetProfilesData().ToList()));


            UsersRepository usersRepository = new UsersRepository(demoDataContext.Object);
            var result = usersRepository.GetAllUser();

            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void GetUserById()
        {
            var demoDataContext = new Mock<BlogBDContext>();
            // get data simulate on UsersTestData.GetUsersData()
            demoDataContext.Setup(x => x.Users).Returns(UnitTestHelpers.GetQueryableMockDbSet<Users>(UsersTestData.GetUsersData().ToList()));
            demoDataContext.Setup(x => x.Profiles).Returns(UnitTestHelpers.GetQueryableMockDbSet<Profiles>(ProfileTestData.GetProfilesData().ToList()));

            UsersRepository usersRepository = new UsersRepository(demoDataContext.Object);
            var result = usersRepository.GetUserById(2);

            Assert.AreEqual("Naruto", result.Username);
        }



    }
}
