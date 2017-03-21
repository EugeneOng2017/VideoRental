using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRental.Models;
using VideoRental.ViewModels;
using System.Data.Entity;

namespace VideoRental.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;

        // Constructor
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // Destructor
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Index
        public ActionResult Index()
        {
            IEnumerable<Movie> movies = _context
                .Movies
                .Include(m => m.Genre)
                .ToList();

            return View(movies);
        }

        // GET: Movies/Details/1
        public ActionResult Details(int Id)
        {
            Movie movie = _context
                .Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == Id);

            return View(movie);
        }

        // GET: Movies/New
        public ActionResult New()
        {
            IEnumerable<Genre> Genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = Genres
            };

            return View("MovieForm", viewModel);
        }

        // GET: Movies/Edit/1
        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.Single(m => m.Id == Id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        // POST: Movies/Save
        [HttpPost]
        public ActionResult Save(Movie movie)
        {


            if(movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var MovieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                MovieInDb.Name = movie.Name;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
                MovieInDb.GenreId = movie.GenreId;
                MovieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            //try
            //{
            //    _context.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{

            //}


            return RedirectToAction("Index", "Movies");
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            //return View(movie);
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            RandomMovieViewModel viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public IEnumerable<Movie> GetMovies()
        {
            IEnumerable<Movie> movies = new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek"},
                new Movie { Id = 2, Name = "Wall-e"}
            };

            return movies;
        }
    }
}