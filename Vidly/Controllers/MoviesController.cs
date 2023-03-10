using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        /*[Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        */

        public ActionResult Index()
        {
            var movies = new List<Movie>()
            {
                new Movie{ Id = 1, Name = "Shrek"},
                new Movie{ Id = 2, Name = "Wall-E"}
            };

            var movie = new MovieViewModel()
            {
                Movies = movies
            };

            return View(movie);
        }
    }
}