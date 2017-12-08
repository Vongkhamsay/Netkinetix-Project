using Netkinetix.DataAccessLayer;
using Netkinetix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Netkinetix.Controllers
{
    public class HomeController : Controller
    {
        private NetkinetixContext db = new NetkinetixContext();

        // This is a GET action (Grabs all the data)
        public ActionResult Index()
        {
            //.ToList just list all the data
            return View(db.SiteEvent.ToList());

        }
        // This is a POST action
        [HttpPost]
        public ActionResult Index(string data)
        {
            if (HttpContext.Request.RequestType == "POST")
            {
                // Sets values to variables that has come back from the form
                var seTitle = Request.Form["title"];
                var seStartDate = Request.Form["startDate"];
                var seEndDate = Request.Form["endDate"];
                var seLocation = Request.Form["location"];
                var seDescription = Request.Form["description"];
                var seURL = Request.Form["url"];
                var seActive = Request.Form["active"];

                // Create new site event and add to db
                var a = db.SiteEvent.Add(new SiteEvent
                {
                    SeTitle = seTitle,
                    SeStartDate = DateTime.Parse(seStartDate),
                    SeEndDate = DateTime.Parse(seEndDate),
                    SeLocation = seLocation,
                    SeDescription = seDescription,
                    SeURL = seURL,
                    SeActive = true
                });
                // Save 
                db.SaveChanges();
            }
            return View(db.SiteEvent.ToList());

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}