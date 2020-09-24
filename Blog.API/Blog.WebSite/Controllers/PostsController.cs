using Blog.Models;
using Blog.Models.Request;
using Blog.Repos;
using Blog.Repos.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebSite.Controllers
{
    public class PostsController : Controller
    {
        private readonly UnitofWork _unitOfWork;
        public PostsController(IUnitOfWork uow)
        {
            _unitOfWork = uow as UnitofWork;
        }

        public ActionResult Index()
        {
            var result = _unitOfWork.PostsRepository.GetAllPosts().ToList();
            return View(result);
        }

        public ActionResult GetPostById(int id)
        {
            var result = _unitOfWork.PostsRepository.GetPostById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult InsertPost([FromBody] InsertNewPosts data)
        {
            try
            {
                _unitOfWork.PostsRepository.InsertPost(data);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public ActionResult UpdatePost([FromBody] UpdatePosts data)
        {
            try
            {
                _unitOfWork.PostsRepository.UpdatePost(data);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete]
        public IActionResult DeletePostById(int PostId)
        {
            try
            {
                _unitOfWork.PostsRepository.DeletePostById(PostId);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
