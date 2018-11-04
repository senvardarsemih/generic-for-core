using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatternForCore.Model.Common;
using PatternForCore.Models;
using PatternForCore.Service.Interfaces;

namespace PatternForCore.Controllers
{
    public class HomeController : Controller
    {
        public readonly IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [Authorize]
        public IActionResult Index()
        {
            return View(_movieService.GetMovies());
        }

        public IActionResult SaveMovie(Movie movieItem)
        {
            _movieService.AddMovie(movieItem);
            return RedirectToAction("Index");
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
