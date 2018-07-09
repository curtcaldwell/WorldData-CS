using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldData.Models;

namespace WorldData.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cities()
        {
            ViewData["Message"] = "Your application description page.";

            return View(City.GetAll());
            // string input = Request.Form["contain"];
            // return View(City.GetByName(input);
            // public List<City> GetByName(string input);
        }

        public IActionResult Countries()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Input()
        {
          return View();
        }

        public IActionResult PopCities(int minpop, int maxpop)
        {
          return View("Cities", City.GetByPopulation(minpop,maxpop));
        }

        public IActionResult StartsWith(string start)
        {
          return View("Cities", City.GetStart(start));
        }

        // public IActionResult Error()
        // {
        //     return View();
        // }
    }
}
