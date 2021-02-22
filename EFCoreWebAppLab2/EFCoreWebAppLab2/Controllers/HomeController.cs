using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFCoreWebAppLab2.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebAppLab2.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext context { get; set; }

        public HomeController(MovieContext ctx)
        {
            context = ctx;
        }

        [Route("/")]
        public IActionResult Index()
        {
            var movies = context.Movies.Include(m => m.Genre).OrderBy(m => m.Name).ToList();
            return View(movies);
        }

        [Route("About")]
        public IActionResult About()
        {
            return Content("Home controller, About action");
        }
    }
}
