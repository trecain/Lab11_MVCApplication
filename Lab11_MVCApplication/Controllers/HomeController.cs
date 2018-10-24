using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab11_MVCApplication.Models;

namespace Lab11_MVCApplication.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Making an HTTP Get request for action
        /// </summary>
        /// <returns>View for get request to Index</returns>
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        /// <summary>
        /// Making an HTTP Post request for action
        /// </summary>
        /// <param name="startYear"></param>
        /// <param name="endYear"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {
            // redirects to the results action, given parameters
            return RedirectToAction("Result", new { startYear, endYear });
        }


        /// <summary>
        /// Creates the list of people in the csv file that fit the criteria
        /// </summary>
        /// <param name="startYear"></param>
        /// <param name="endYear"></param>
        /// <returns>The results view</returns>
        public ViewResult Result(int startYear, int endYear)
        {
            //Creates a list of TimePerson file that match criteria
            List<TimePerson> list = TimePerson.GetPersons(startYear, endYear);
            return View(list);
        }

    }
}
