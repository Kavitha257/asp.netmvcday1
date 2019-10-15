using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.netmvcday1.Models;
using asp.netmvcday1.ViewModel;
using System.Data.Entity;
namespace asp.netmvcday1.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext dbContext = null;
        public MoviesController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
        }
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult DisplayMovie()
        //{
        //    CustomerMovieViewModel viewModel = new CustomerMovieViewModel();

        //    Movie mv = new Movie { Name = "Young Sheldon" };

        //    List<Customer> customers = new List<Customer>
        //    {
        //        new Customer{Name="Kavitha"},
        //        new Customer{Name="Kd"},
        //        new Customer{Name="Kavi"}
        //    };
        //    viewModel.Movies = mv;
        //    viewModel.Customers = customers;
        //    return View(viewModel);
        //}
        //public ActionResult DisplayCustomer()
        //{
        //    CustomerMovieViewModel viewModel = new CustomerMovieViewModel();
        //    Customer customer = new Customer { Name = "Young Sheldon" };
        //    List<Movie> mv = new List<Movie>
        //    {
        //        new Movie{Name="Kappaan"},
        //        new Movie{Name="Castle"},
        //        new Movie{Name="Sheldon"}
        //    };
        //    viewModel.Customers = customer;
        //    viewModel.Movies = mv;
        //    return View(viewModel);
        //}
        public ActionResult Details(int id)
        {
            var movies = dbContext.Movies.Include(k => k.Genres).ToList().SingleOrDefault(a => a.Id == id);
            return View(movies);
        }
        public ActionResult About()
        {
            var movie = dbContext.Movies.Include(k => k.Genres).ToList();

            return View(movie);
        }
        //public List<Movie> GetMovies()
        //{
        //    List<Movie> movies = new List<Movie>
        //    {
        //        new Movie{Id=1,Name="Kappan",Genre="Action",ReleaseDate=Convert.ToDateTime("20/10/2020"),DateAdded=Convert.ToDateTime("20/12/2021")},
        //          new Movie{Id=2,Name="Mass",Genre="Action",ReleaseDate=Convert.ToDateTime("10/1/2010"),DateAdded=Convert.ToDateTime("2/12/2021")},
        //          new Movie{Id=3,Name="Sheldon",Genre="Fun",ReleaseDate=Convert.ToDateTime("12/2/2005"),DateAdded=Convert.ToDateTime("13/2/2006")},


        //    };
        //    return movies;
        //}
        [HttpGet]
        public ActionResult Create()
        {
            var movie = new Movie();
            ViewBag.GenreId = ListGenre();
            return View(movie);
        }
        [HttpPost]
        public ActionResult Create(Movie MovieFromview)
        {
            if (!ModelState.IsValid)
            {
                //var movie = new Movie();
                ViewBag.GenreId = ListGenre();
                return View(MovieFromview);

            }
            dbContext.Movies.Add(MovieFromview);
            dbContext.SaveChanges();
            return RedirectToAction("About", "Movies");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movies = dbContext.Movies.SingleOrDefault(c => c.Id == id);
            if (movies != null)
            {
                ViewBag.GenreId = ListGenre();
                return View(movies);
            }
            return HttpNotFound("Movie id not exist");
        }
        [HttpPost]
        public ActionResult Edit(Movie MovieFromView)
        {
            if (ModelState.IsValid)
            {
                var movieindb = dbContext.Movies.FirstOrDefault(c => c.Id == MovieFromView.Id);
                movieindb.Name = MovieFromView.Name;
                movieindb.ReleaseDate = MovieFromView.ReleaseDate;
                movieindb.AvailableStock = MovieFromView.AvailableStock;
                movieindb.DateAdded = MovieFromView.DateAdded;
                dbContext.SaveChanges();
                return RedirectToAction("About", "Movies");
            }
            else
            {
                ViewBag.gender = ListGenre();

                return View(MovieFromView);
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var movies = dbContext.Movies.SingleOrDefault(c => c.Id == id);
            if (movies != null)
            {

                return View(movies);
            }
            return HttpNotFound("Movie id not exist");
        }
        [HttpPost]
        public ActionResult Delete(Movie MovieFromView)
        {
            var movies = dbContext.Movies.SingleOrDefault(c => c.Id == MovieFromView.Id);
            dbContext.Movies.Remove(movies);
            dbContext.SaveChanges();
            return RedirectToAction("About", "Movies");
        }

        [NonAction]
        public IEnumerable<SelectListItem> ListGenre()
        {

            var mship = dbContext.Genres.AsEnumerable().
                Select(m => new SelectListItem()
                {
                    Text = m.Name,
                    Value = m.Id.ToString()
                }).ToList();
            mship.Insert(0, new SelectListItem { Text = "---Select---", Value = "0", Disabled = true, Selected = true });

            return mship;
        }
    }
}