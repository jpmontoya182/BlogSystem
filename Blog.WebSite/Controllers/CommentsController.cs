using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Blog.Repos;
using Blog.Repos.Contracts;
using Blog.Models.Request;

namespace Blog.WebSite.Controllers
{
    public class CommentsController : Controller
    {
        private readonly UnitofWork _unitOfWork;

        public CommentsController(IUnitOfWork uow)
        {
            _unitOfWork = uow as UnitofWork;
        }

        public IActionResult Index()
        {
            var result = _unitOfWork.CommentsRepository.GetAllComments();
            return View(result);
        }

        public IActionResult Details(int id)
        {

            var comment = _unitOfWork.CommentsRepository.GetCommentById(id);

            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        public IActionResult Create()
        {
            ViewData["PostId"] = new SelectList(_unitOfWork.PostsRepository.GetAllPosts(), "PostId", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CommentId,ContentComment,PostId")] InsertNewComment comment)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CommentsRepository.InsertComment(comment);
                return RedirectToAction(nameof(Index));
            }

            ViewData["PostId"] = new SelectList(_unitOfWork.PostsRepository.GetAllPosts(), "PostId", "Title", comment.PostId);
            return View(comment);
        }

        public IActionResult Delete(int id)
        {
            var comment = _unitOfWork.CommentsRepository.GetCommentById(id);

            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.CommentsRepository.DeleteComment(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
