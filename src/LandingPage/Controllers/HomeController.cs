using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LandingPage.Models;
using LandingPage.Repo;

namespace LandingPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // public IActionResult Index()
        // {
        //     return View();
        // }

        // public IActionResult Privacy()
        // {
        //     return View();
        // }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Articles()
        {
            var model = new ArticlesViewModel();
            model.Articles = new ArticleRepository().GetLatest();

            return View(model);
        }
    }
}
