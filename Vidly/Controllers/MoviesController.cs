using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Inception" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

            /* ViewData["Movie"] = movie; */

            // return Content("Hello World!");
            // return HttpNotFound();
            // return new EmptyResult();
            // return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name"});
        }

        // GET: Movies/Released/{Year}/{Month}
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)")] 
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        // GET: Movies/Edit/{ID}
        public ActionResult Edit(int id)
        {
            return Content("Movie ID = " + id);
        }

        // GET: Movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}", pageIndex, sortBy));
        }
    }
}