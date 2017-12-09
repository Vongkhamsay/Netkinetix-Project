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
        private SiteEventRepository db = new SiteEventRepository();

        // This is a GET action (Grabs all the data)
        public ActionResult Index(string search,string searchTitle, string searchDateAfter,string searchDateBefore)
        {
            var dateAfter= searchDateAfter !=null&& searchDateAfter != "" ? DateTime.Parse(searchDateAfter) : DateTime.MinValue;
            var dateBefore = searchDateBefore != null&&searchDateBefore != "" ? DateTime.Parse(searchDateBefore) : DateTime.MaxValue;
            var result = db.GetAll();
            if (search == null && search != "search")
            {
                return View(result);
            }
            if (searchTitle != null && searchTitle != "")
            {
                result = result.Where(f => f.SeTitle.Contains(searchTitle));
            }
            result= result.Where(f=>f.SeStartDate > dateAfter && f.SeStartDate < dateBefore);
            //DB calls the GetAll method thats in SiteEventRepository
            return View(result);

        }

        //Get specific data by ID
        public ActionResult GetEvent(int id)
        {
            var siteEvent = db.GetOne(id);

            return View(siteEvent);
        }

        // This is a POST action
        [HttpPost]
        public ActionResult Index()
        {
            if (HttpContext.Request.RequestType == "POST")
            {
                var siteEvent = this.setSiteEvent();
                // Creates new data
                db.Create(siteEvent);
                //Save
                db.Save();
            }
            // Return all data
            return View(db.GetAll());

        }

        private SiteEvent setSiteEvent ()
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
            return new SiteEvent
            {
                SeTitle = seTitle,
                SeStartDate = DateTime.Parse(seStartDate),
                SeEndDate = DateTime.Parse(seEndDate),
                SeLocation = seLocation,
                SeDescription = seDescription,
                SeURL = seURL,
                SeActive = seActive == "on" ? true : false
            };
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Message = "Your application description page.";

            return View(db.GetOne(id));
        }

        [HttpPost]
        public ActionResult Search()
        {
            var searchTitle = Request.Form["searchTitle"];
            var searchDateAfter = Request.Form["searchDateAfter"] != null ? DateTime.Parse(Request.Form["searchDateAfter"]) : DateTime.MinValue;
            var searchDateBefore = Request.Form["searchDateBefore"] != null ? DateTime.Parse(Request.Form["searchDateBefore"]) : DateTime.MaxValue;

            var x = db.GetAll().Where(f=> f.SeTitle.Contains(searchTitle) && f.SeStartDate > searchDateAfter && f.SeStartDate < searchDateBefore);
           
            return View(x);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}