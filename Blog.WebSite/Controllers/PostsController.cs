using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Blog.Repos;
using Blog.Repos.Contracts;
using Blog.Models.Request;

namespace Blog.WebSite.Controllers
{
    public class PostsController : Controller
    {

        private readonly UnitofWork _unitOfWork;

        public PostsController(IUnitOfWork uow)
        {
            _unitOfWork = uow as UnitofWork;
        }

        public IActionResult Index()
        {
            var result = _unitOfWork.PostsRepository.GetAllPosts();
            return View(result);
        }

        public IActionResult Details(int id)
        {
            var posts = _unitOfWork.PostsRepository.GetPostById(id);
            if (posts == null)
            {
                return NotFound();
            }

            return View(posts);
        }

        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_unitOfWork.UsersRepository.GetAllUser(), "UserId", "Username");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PostId,Title,PostContent,UserId")] InsertNewPosts post)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PostsRepository.InsertPost(post);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_unitOfWork.UsersRepository.GetAllUser(), "UserId", "Username", post.UserId);
            return View(post);
        }

        public IActionResult Edit(int id)
        {

            var post = _unitOfWork.PostsRepository.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_unitOfWork.UsersRepository.GetAllUser(), "UserId", "Username", post.UserId);
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("PostId,Title,PostContent")] UpdatePosts post)
        {
            if (id != post.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.PostsRepository.UpdatePost(post);
                return RedirectToAction(nameof(Index));
            }

            return View(post);
        }
        public IActionResult Delete(int id)
        {
            var posts = _unitOfWork.PostsRepository.GetPostById(id);
            if (posts == null)
            {
                return NotFound();
            }

            return View(posts);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.PostsRepository.DeletePostById(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
