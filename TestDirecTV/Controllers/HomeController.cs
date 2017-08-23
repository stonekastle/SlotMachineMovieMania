using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestDirecTV.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [Route("{id:int}/")]
        public ActionResult Index2()
        {
            ViewBag.Title = "Slot";

            return View();
        }

        [Route("{id:int}/")]
        public ActionResult Index3()
        {
            ViewBag.Title = "Q1";

            return View();
        }
        [Route("{id:int}/")]
        public ActionResult Index4()
        {
            ViewBag.Title = "Q2";

            return View();
        }
        [Route("{id:int}/")]
        public ActionResult Index5()
        {
            ViewBag.Title = "Q3";

            return View();
        }
        
        public ActionResult Scoreboard()
        {
            ViewBag.Title = "Scoreboard";

            return View();
        }

    }
}
