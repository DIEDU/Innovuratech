using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using POCWebApp6.Data;
using POCWebApp6.Models;

namespace POCWebApp6.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        #region  old code of login
        // [HttpGet]
        // public ActionResult Registr()
        // {
        //     return View();
        // }
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Registr(User user)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         db.Users.Add(user);
        //         db.SaveChanges();
        //         return RedirectToAction("Login", "Account");
        //     }
        //     return View(user);
        // }
        // [HttpGet]
        // public ActionResult Register()
        // {
        //     return View();
        // }
        // [HttpPost]
        //// [ValidateAntiForgeryToken]
        // public ActionResult Register(User user)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         db.Users.Add(user);
        //         db.SaveChanges();
        //         return RedirectToAction("Login", "Account");
        //     }
        //     return View(user);
        // }
        // [AllowAnonymous]
        // [HttpPost]
        // public ActionResult Login(User u, string ReturnUrl)
        // {
        //     if (IsValid(u) == true)
        //     {
        //         FormsAuthentication.SetAuthCookie(u.Username, false);  //false isliye diye karan permanent cookie nhi h
        //         Session["Username"] = u.Username.ToString();
        //         if (ReturnUrl != null)
        //         {
        //             return Redirect(ReturnUrl);
        //         }
        //         else
        //         {
        //             return RedirectToAction("Index", "Home");
        //         }
        //     }
        //     else
        //     {
        //         return View();
        //     }

        // }
        // public bool IsValid(User u)
        // {
        //     var Credential = db.Users.Where(model => model.Username == u.Username && model.Password == u.Password).FirstOrDefault();

        //     // Check if Credential is not null before accessing its properties
        //     if (Credential != null)
        //     {
        //         return (u.Username == Credential.Username && u.Password == Credential.Password);
        //     }

        //     // If Credential is null, return false (credentials are not valid)
        //     return false;
        // }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult LogOut()
        // {
        //     FormsAuthentication.SignOut();
        //     Session["Email"] = null;
        //     return RedirectToAction("Index", "Home");
        // }
        #endregion

        
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }
       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
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
