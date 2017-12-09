using Netkinetix.DataAccessLayer;
using Netkinetix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Netkinetix.Controllers
{

    public class EditController : Controller
    {
        private SiteEventRepository db = new SiteEventRepository();

        // POST: Edit
        [HttpPost]
        public ActionResult Edit()
        {
            db.Update(this.setSiteEvent());
            db.Save();
            return RedirectToAction("Index", "Home");
        }

        private SiteEvent setSiteEvent()
        {
            // Sets values to variables that has come back from the form
            var seId = Request.Form["id"];
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
                SeId = int.Parse(seId),
                SeTitle = seTitle,
                SeStartDate = DateTime.Parse(seStartDate),
                SeEndDate = DateTime.Parse(seEndDate),
                SeLocation = seLocation,
                SeDescription = seDescription,
                SeURL = seURL,
                SeActive = seActive == "on" ? true : false
            };
        }
    }

   
}