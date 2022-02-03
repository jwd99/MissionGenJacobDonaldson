using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MissionGenJacobDonaldson.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MissionGenJacobDonaldson.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieFormContext daContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieFormContext saveValue)
        {
            _logger = logger;
            //contexter is used to help in saving to the database
            daContext = saveValue;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult My_Podcasts()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Category = daContext.Categories.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult MovieForm(FormResponse Response)
        {
            //If the form model data is valid then add and save changes to the database
            if (ModelState.IsValid)
            {
                daContext.Add(Response);
                //adds response and then saves it
                daContext.SaveChanges();
                return View("Confirmation", Response);
            }
            //If the form model data is not valid then return the view and show validation information.
            else
            {
                ViewBag.Category = daContext.Categories.ToList();
                return View(Response);
            }

        }
        //Display Movies in table controls
        public IActionResult MovieList()
        {

            var applications = daContext.Responses
                .Include(item => item.Category)
                .OrderBy(item => item.Title)
                .ToList();
            //.Where(item => item.Eligible == false)
            return View(applications);
        }

        //Edit Controls
        [HttpGet]
        public IActionResult Edit(int MovieId)
        {//grabs the movie id from the route to bring the right records data over
            ViewBag.Category = daContext.Categories.ToList();

            var moviechange = daContext.Responses.Single(item => item.MovieId == MovieId);
            return View("MovieForm", moviechange);

        }
        [HttpPost]
        public IActionResult Edit(FormResponse fr)
        {//updates the specifc fr response in the database
            daContext.Update(fr);
            daContext.SaveChanges();
            return RedirectToAction("MovieList");

        }

        //Delete Controls
        [HttpGet]
        public IActionResult Delete(int MovieId)
        {//Grabs specific MovieId to delete
            var moviechange = daContext.Responses.Single(item => item.MovieId == MovieId);
            return View(moviechange);
        }
        [HttpPost]
        public IActionResult Delete(FormResponse fr)
        {//Removes the movie record and saves the changes
            daContext.Remove(fr);
            daContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
