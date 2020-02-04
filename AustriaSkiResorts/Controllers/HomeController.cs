using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AustriaSkiResorts.Models;

namespace AustriaSkiResorts.Controllers
{
    public class HomeController : Controller
    {
        private readonly resortContext _context;

        public HomeController(resortContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            ViewData["avg"] = getAvgPrice();
            ViewData["total"] = getTotalResorts();

            return View();
        }
        public int getTotalResorts()
        {
            var total = (from item in _context.resort
                         select item.id).Count();
            return total;
        }
        public double getAvgPrice()
        {
            var s = (from item in _context.resort
                     select item.price).Sum();
            return s / getTotalResorts();
        }


        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
