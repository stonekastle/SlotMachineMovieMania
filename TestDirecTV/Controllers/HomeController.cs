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
        [Route("newuser")]
        public ActionResult NewUser()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [Route("slots/{userId:int}/{imageNumber:long}")]
        public ActionResult Slots(int userId, long imageNumber)
        {
            ViewBag.Title = "Slots";
            SlotsViewModel model = new SlotsViewModel();
            model.UserId = userId;
            model.ImageNumber = imageNumber;
            return View(model);
        }

        [Route("questions")]
        public ActionResult Questions()
        {
            ViewBag.Title = "Questions";
            return View();
        }

        [Route("Q1/{userId:int}/{questionSet:int}")]
        public ActionResult Q1(int userId, int questionSet)
        {
            ViewBag.Title = "Q1";
            SlotsViewModel model = new SlotsViewModel();
            model.UserId = userId;
            model.QuestionSet = questionSet;
            return View(model);
        }
        [Route("Q2/{userId:int}/{questionSet:int}")]
        public ActionResult Q2(int userId, int questionSet)
        {
            ViewBag.Title = "Q2";
            SlotsViewModel model = new SlotsViewModel();
            model.UserId = userId;
            model.QuestionSet = questionSet;
            return View(model);
        }
        [Route("Q3/{userId:int}/{questionSet:int}")]
        public ActionResult Q3(int userId, int questionSet)
        {
            ViewBag.Title = "Q3";
            SlotsViewModel model = new SlotsViewModel();
            model.UserId = userId;
            model.QuestionSet = questionSet;
            return View(model);
        }

        [Route("Q4/{userId:int}/{questionSet:int}")]
        public ActionResult Q4(int userId, int questionSet)
        {
            ViewBag.Title = "Q4";
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
