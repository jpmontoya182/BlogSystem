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
    public class PostsController : Controller
    {

        private readonly UnitofWork _unitOfWork;

        public PostsController(IUnitOfWork uow)
        {
            _unitOfWork = uow as UnitofWork;
        }

        // GET: Posts
        public IActionResult Index()
        {
            var result = _unitOfWork.PostsRepository.GetAllPosts();
            return View(result);
        }

        // GET: Posts/Details/5
        public IActionResult Details(int id)
        {
            var posts = _unitOfWork.PostsRepository.GetPostById(id);
            if (posts == null)
            {
                return NotFound();
            }

            return View(posts);
        }

        //// GET: Posts/Create
        //public IActionResult Create()
        //{
        //    ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
        //    return View();
        //}

        //// POST: Posts/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PostId,Title,PostContent,CreateDate,State,UserId")] Posts posts)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(posts);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", posts.UserId);
        //    return View(posts);
        //}

        //// GET: Posts/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var posts = await _context.Posts.FindAsync(id);
        //    if (posts == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", posts.UserId);
        //    return View(posts);
        //}

        //// POST: Posts/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("PostId,Title,PostContent,CreateDate,State,UserId")] Posts posts)
        //{
        //    if (id != posts.PostId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(posts);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PostsExists(posts.PostId))
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
        //    ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", posts.UserId);
        //    return View(posts);
        //}

        //// GET: Posts/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var posts = await _context.Posts
        //        .Include(p => p.User)
        //        .FirstOrDefaultAsync(m => m.PostId == id);
        //    if (posts == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(posts);
        //}

        //// POST: Posts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var posts = await _context.Posts.FindAsync(id);
        //    _context.Posts.Remove(posts);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PostsExists(int id)
        //{
        //    return _context.Posts.Any(e => e.PostId == id);
        //}
    }
}
