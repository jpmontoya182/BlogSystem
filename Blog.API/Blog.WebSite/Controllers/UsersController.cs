using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog.Models.DataBase;
using Blog.Repos;
using Blog.Repos.Contracts;

namespace Blog.WebSite.Controllers
{
    public class UsersController : Controller
    {
        private readonly UnitofWork _unitOfWork;

        public UsersController(IUnitOfWork uow)
        {
            _unitOfWork = uow as UnitofWork;
        }

        // GET: Users
        public IActionResult Index()
        {
            var result = _unitOfWork.UsersRepository.GetAllUser();
            return View(result);
        }

        // GET: Users/Details/5
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

        //// POST: Users/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("UserId,Username,Password,Email,ProfileId")] Users users)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(users);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ProfileId"] = new SelectList(_context.Profiles, "ProfileId", "Name", users.ProfileId);
        //    return View(users);
        //}

        //// GET: Users/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var users = await _context.Users.FindAsync(id);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ProfileId"] = new SelectList(_context.Profiles, "ProfileId", "Name", users.ProfileId);
        //    return View(users);
        //}

        //// POST: Users/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("UserId,Username,Password,Email,ProfileId")] Users users)
        //{
        //    if (id != users.UserId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(users);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UsersExists(users.UserId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ProfileId"] = new SelectList(_context.Profiles, "ProfileId", "Name", users.ProfileId);
        //    return View(users);
        //}

        //// GET: Users/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var users = await _context.Users
        //        .Include(u => u.Profile)
        //        .FirstOrDefaultAsync(m => m.UserId == id);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(users);
        //}

        //// POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var users = await _context.Users.FindAsync(id);
        //    _context.Users.Remove(users);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UsersExists(int id)
        //{
        //    return _context.Users.Any(e => e.UserId == id);
        //}
    }
}
