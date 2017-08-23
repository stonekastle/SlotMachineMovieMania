using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDirecTV.Models;

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
        public ActionResult Index2(int userId)
        {
            ViewBag.Title = "Slots";
            SlotsViewModel model = new SlotsViewModel();
            model.UserId = userId;
            return View(model);
        }

        [Route("Q1/{userId:int}/{questionSet:int}")]
        public ActionResult Index3(int userId, int questionSet)
        {
            ViewBag.Title = "Q1";
            SlotsViewModel model = new SlotsViewModel();
            model.UserId = userId;
            model.QuestionSet = questionSet;
            return View(model);
        }
        [Route("Q2/{userId:int}/{questionSet:int}")]
        public ActionResult Index4(int userId, int questionSet)
        {
            ViewBag.Title = "Q2";
            SlotsViewModel model = new SlotsViewModel();
            model.UserId = userId;
            model.QuestionSet = questionSet;
            return View(model);
        }
        [Route("Q3/{userId:int}/{questionSet:int}")]
        public ActionResult Index5(int userId, int questionSet)
        {
            ViewBag.Title = "Q3";
            SlotsViewModel model = new SlotsViewModel();
            model.UserId = userId;
            model.QuestionSet = questionSet;
            return View(model);
        }
        
        [Route("Scoreboard")]
        public ActionResult Scoreboard()
        {
            ViewBag.Title = "Scoreboard";

            return View();
        }

    }
}
