using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestDirecTV.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [Route("Index")]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [Route("Slots/{userId:int}")]
        public ActionResult Index2()
        {
            ViewBag.Title = "Slots";

            return View();
        }

        [Route("Q1/{userId:int}/{questionSet:int}")]
        public ActionResult Index3()
        {
            ViewBag.Title = "Q1";

            return View();
        }
        [Route("Q2/{userId:int}/{questionSet:int}")]
        public ActionResult Index4()
        {
            ViewBag.Title = "Q2";

            return View();
        }
        [Route("Q3/{userId:int}/{questionSet:int}")]
        public ActionResult Index5()
        {
            ViewBag.Title = "Q3";

            return View();
        }
        
        [Route("Scoreboard")]
        public ActionResult Scoreboard()
        {
            ViewBag.Title = "Scoreboard";

            return View();
        }

    }
}
