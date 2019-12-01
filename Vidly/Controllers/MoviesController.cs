using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movie = GetMovie();
            return View(movie);
        }

        public IEnumerable<Movie> GetMovie()
        {
            return new List<Movie>
            {
                new Movie{ID=1,Name="Sye Ra NarashimaReddy"},
                new Movie{ID=2,Name="Kaithi"}
            };
        }
    }
}