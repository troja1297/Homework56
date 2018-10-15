using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Data;
using WebApplication6.Models;
using WebApplication6.Models.ManageViewModels;
using WebApplication6.Models.PostViewModels;
using WebApplication6.Services;

namespace WebApplication6.Controllers
{
    public class PostController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private static ApplicationDbContext _context;
        private IHostingEnvironment _environment;
        private FileUploadService _fileUploadService;
        private UserManager<ApplicationUser> _userManager;

        public PostController (
            UserManager<ApplicationUser> userManager,
            FileUploadService fileUploadService,
            IHostingEnvironment environment,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _fileUploadService = fileUploadService;
            _environment = environment;
            _context = context;
        }
//
//        // GET: Post
//        public ActionResult Index()
//        {
//            return View();
//        }
//
//        // GET: Post/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult CreatePost(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(PostViewModel model, string returnUrl = null)
        {
            var user = await _userManager.GetUserAsync(User);
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                string mpath = Path.Combine(
                    _environment.WebRootPath,
                    $"images\\{model.Name}\\{model.Title}");
                var postPhoto = $"/images/{model.Name}/{model.PostPhoto.FileName}";
                _fileUploadService.Upload(mpath, model.PostPhoto.FileName, model.PostPhoto);
                var postModel = new PostModel()
                {
                    Time = DateTime.Now,
                    Likes = 0,
                    Description = model.Description,
                    Title = model.Title,
                    PostPhoto =
                        postPhoto,
                    OwnerId = user.Id,
                    Owner = user
                };
                
                _context.AddAsync(postModel);
                await _context.SaveChangesAsync();
                return RedirectToLocal(returnUrl);
            }
            return View(model);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

//        // GET: Post/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }
//
//        // POST: Post/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, IFormCollection collection)
//        {
//            try
//            {
//                // TODO: Add update logic here
//
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
//
//        // GET: Post/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }
//
//        // POST: Post/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here
//
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
    }
}