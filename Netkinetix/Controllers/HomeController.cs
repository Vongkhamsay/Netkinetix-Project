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

        public ActionResult Index()
        {
            var a = db.SiteEvent.Add(new SiteEvent { SeId = 1, SeTitle = "First Test", SeActive = true, SeDescription = "test", SeEndDate = new DateTime(1999, 09, 01, 21, 34, 00), SeLocation = "Some location", SeStartDate = new DateTime(1999, 09, 01, 21, 34, 00), SeURL = "URL of some sort"  });
            db.SaveChanges();
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