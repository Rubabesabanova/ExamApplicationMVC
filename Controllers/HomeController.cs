using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamApplicationMVC.Enums;
using ExamApplicationMVC.Filters;
using ExamApplicationMVC.Models;
using ExamApplicationMVC.Security;

namespace ExamApplicationMVC.Controllers
{
    public class HomeController : Controller
    {
        private ExamDbContext db = new ExamDbContext();

        [Auth]
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel
            {
                Topics = db.Topics.ToList(),
                Questions = db.Questions.ToList(),
                Subjects = db.Subjects.ToList()
            };
            return View(model);
        }
        [Auth]
        public ActionResult Topic(int id)
        {
            Topic topic = db.Topics.FirstOrDefault(x => x.Id == id);
            if (topic!=null)
            {
                int userid = Convert.ToInt32(Session["UserId"]);
                TopicViewModel model = new TopicViewModel
                {
                    Topic = db.Topics.FirstOrDefault(x => x.Id == id),
                    User = db.Users.FirstOrDefault(x => x.Id == userid)
                };
                return View(model);
            }
            else
            {
                return Content("Not Found");
            }
            
        }
        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Result(FormCollection collection)
        {
            try
            {
                var results = new Dictionary<string, int>(){
                    {"Answered", 0},
                    {"Total", 0},
                    {"Correct", 0},
                        {"Point", 0}
                    };
                int userid = Convert.ToInt32(Session["UserId"]);
                User usr = db.Users.FirstOrDefault(x => x.Id == userid);
                int number = 0;
                while (number++<= db.Questions.OrderByDescending(x => x.Id).FirstOrDefault().Id)
                {
                    if (collection.AllKeys.Contains($"Id {number}"))
                    {
                        
                        results["Total"] += 1;
                        var question = db.Questions.FirstOrDefault(x => x.Id == number);
                        var answer = (VariantEnum)question.TrueAnswer;
                        if (collection.AllKeys.Contains($"A {number}") || collection.AllKeys.Contains($"B {number}") || collection.AllKeys.Contains($"C {number}") || collection.AllKeys.Contains($"D {number}") || collection.AllKeys.Contains($"E {number}")) 
                        {
                            results["Answered"] += 1;
                            if (collection.AllKeys.Contains($"{answer} {number}"))
                            {
                                results["Correct"] += 1;
                                results["Point"] += question.Point;
                                
                            }
                        }
                    }

                }
                usr.TotalQuestion += results["Total"];
                usr.Point += results["Point"];
                usr.TrueAnswer += results["Correct"];
                db.SaveChanges();
                return View(results);
            }
            catch (Exception)
            {
                throw;
            }
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