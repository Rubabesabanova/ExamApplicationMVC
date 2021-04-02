using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ExamApplicationMVC.Models;
using ExamApplicationMVC.Security;

namespace ExamApplicationMVC.Controllers
{
    public class AuthController : Controller
    {
        private ExamDbContext db = new ExamDbContext();

        // GET: Auth
        [Route("Auth/Register")]
        [HttpGet]
        public ActionResult Register()
        {
            return View(new User());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Auth/Register")]
        public ActionResult Register([Bind(Include = "Name,Surname,Email,Password")] User user)
        {
                if (ModelState.IsValid)
                {
                    try
                    {
                    var result = EmailIsUnique(user.Email);
                        user.Password = Crypto.HashPassword(user.Password);
                        db.Users.Add(user);
                        db.SaveChanges();
                        Session["Logined"] = true;
                        Session["User"] = user.Name;
                        Session["UserId"] = user.Id;
                        return RedirectToAction("Index", "Home");
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            return View(user);
        }
        [AllowAnonymous]
        [HttpPost]
        public JsonResult EmailIsUnique(string email)
        {
            foreach (var item in db.Users)
            {
                if (item.Email == email)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Logout(User usr)
        {
            Session["Logined"] = null;
            Session["User"] = null;
            Session["UserId"] = null;
            return RedirectToAction("Login");
        }

        [Route("Auth/Login")]
        [HttpGet]
        public ActionResult Login()
        {
            return View(new User());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Email,Password")] User user)
        {
            try
            {
                User usr = db.Users.FirstOrDefault(x => x.Email == user.Email);
                Session["WrongUser"] = true;
                if (usr != null)
                {
                    if (Crypto.VerifyHashedPassword(usr.Password, user.Password))
                    {
                        Session["Logined"] = true;
                        Session["User"] = usr.Name;
                        Session["UserId"] = usr.Id;
                        return RedirectToAction("Index", "Home");
                    }
                }

                Session.Timeout = 1;
                return RedirectToAction("Login");
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
