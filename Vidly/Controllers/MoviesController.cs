using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movie = _context.Movies.Include(c=>c.Genre).ToList();
            return View(movie);
        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.ID == id);
            movies = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.ID == id);
            if (movies == null)
                return HttpNotFound();
            return View(movies);
        }
    }
}