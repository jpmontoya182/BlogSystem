using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Blog.Repos;
using Blog.Repos.Contracts;
using Blog.Models.Request;

namespace Blog.WebSite.Controllers
{
    public class UsersController : Controller
    {
        private readonly UnitofWork _unitOfWork;

        public UsersController(IUnitOfWork uow)
        {
            _unitOfWork = uow as UnitofWork;
        }

        public IActionResult Index()
        {
            var result = _unitOfWork.UsersRepository.GetAllUser();
            return View(result);
        }

        public IActionResult Details(int id)
        {
            var user = _unitOfWork.UsersRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public IActionResult Create()
        {
            ViewData["ProfileId"] = new SelectList(_unitOfWork.ProfilesRepository.GetAllProfiles(), "ProfileId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("UserId,Username,Password,Email,ProfileId")] InsertNewUser user)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.UsersRepository.InsertUser(user);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfileId"] = new SelectList(_unitOfWork.ProfilesRepository.GetAllProfiles(), "ProfileId", "Name", user.ProfileId);
            return View(user);
        }

        public IActionResult Edit(int id)
        {

            var users = _unitOfWork.UsersRepository.GetUserById(id);
            if (users == null)
            {
                return NotFound();
            }
            ViewData["ProfileId"] = new SelectList(_unitOfWork.ProfilesRepository.GetAllProfiles(), "ProfileId", "Name", users.ProfileId);
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("UserId,Username,Password,Email,ProfileId")] UpdateUser users)
        {
            if (id != users.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.UsersRepository.UpdateUser(users);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfileId"] = new SelectList(_unitOfWork.ProfilesRepository.GetAllProfiles(), "ProfileId", "Name", users.ProfileId);
            return View(users);
        }

        public IActionResult Delete(int id)
        {
            var user = _unitOfWork.UsersRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.UsersRepository.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
