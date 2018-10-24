using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lab11_MVCApplication.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Making an HTTP Get request for action
        /// </summary>
        /// <returns>View for get request to Index</returns>
        [HttpGet]
        public IActionResult Index()
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

        public IActionResult Result(int startYear, int endYear)
        {
            //Creates a list of TimePerson file that match criteria
            //List<TimePerson> list -TimePerson.GetPersons(begYear, endYear);
            return View();
        }

    }
}
