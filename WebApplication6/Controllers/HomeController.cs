using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Data;
using WebApplication6.Models;
using WebApplication6.Models.ManageViewModels;
using WebApplication6.Models.PostViewModels;
using WebApplication6.Services;

namespace WebApplication6.Controllers
{
    [Authorize(Policy = "blocked")]
    public class HomeController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private static ApplicationDbContext _context;
        private IHostingEnvironment _environment;
        private FileUploadService _fileUploadService;

        public HomeController(
            UserManager<ApplicationUser> userManager,
            FileUploadService fileUploadService,
            IHostingEnvironment environment,
            ApplicationDbContext context)
        {
            _fileUploadService = fileUploadService;
            _environment = environment;
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var users = from m in _context.Users
                select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.Login.Contains(searchString));
            }

            return View(await users.ToListAsync());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
    }
}
