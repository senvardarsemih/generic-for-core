using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatternForCore.Models;
using PatternForCore.Models.Common;
using PatternForCore.Services.Base.Contracts;

namespace PatternForCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieServices _movieServices;

        public HomeController(IMovieServices movieServices)
        {
            _movieServices = movieServices;
        }


        [Authorize]
        public IActionResult Index()
        {
            return View(_movieServices.GetMovies());
        }

        public IActionResult SaveMovie(Movie movieItem)
        {
            _movieServices.AddMovie(movieItem);
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
