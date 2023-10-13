using POCWebApp6.Data;
using POCWebApp6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace POCWebApp6.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login", "Home");
            }
            return View(user);
        }
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User u, string ReturnUrl)
        {
            if (IsValid(u) == true)
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);  //false isliye diye karan permanent cookie nhi h
                Session["Username"] = u.Username.ToString();
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Tasks");
                }
            }
            else
            {
                return View();
            }

        }
        public bool IsValid(User u)
        {
            var Credential = db.Users.Where(model => model.Username == u.Username && model.Password == u.Password).FirstOrDefault();

            if (Credential != null)
            {
                return (u.Username == Credential.Username && u.Password == Credential.Password);
            }

            return false;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["Email"] = null;
            return RedirectToAction("Index", "Home");
        }
        #region  inbuilt function
        public ActionResult Index()
        {
            return View();
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
        #endregion
    }
}