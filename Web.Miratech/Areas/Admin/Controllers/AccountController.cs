using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Miratech.Models;

namespace Web.Miratech.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        DataContext db = new DataContext();
        //
        // GET: /Admin/Account/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (System.Web.HttpContext.Current.User.Identity.Name == "")
            {
                ViewBag.ReturnUrl = returnUrl;
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                if (IsValid(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = ""});
        }


        private bool IsValid(string username, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;

            using (var db = new DataContext())
            {
                var user = db.User.FirstOrDefault(u => u.Name == username);
                if (user != null)
                {
                    if (user.Password == crypto.Compute(password, user.PasswordSalt))
                    {
                        IsValid = true;
                    }
                }
            }
            return IsValid;
        }

        [HttpGet]
        [Authorize]
        public ActionResult ChangePassword()
        {
            //var db = new DataContext();

            //var user = from u in db.UserProfiles
            //           where u.ID == Id
            //           select u;

            return View(/*user*/);
        }

        [HttpPost]
        [Authorize]
        public ActionResult ChangePassword(ChangePasswordModels user)
        {
            var db = new DataContext();

            string UserName = System.Web.HttpContext.Current.User.Identity.Name;

            int UserID = (from u in db.User
                          where u.Name == UserName
                          select u.ID).FirstOrDefault();
            if (IsValid(UserName, user.OldPassword))
            {
                if (user.NewPassword.Equals(user.ReNewPassword))
                {
                    UserModels user_profile = db.User.Find(UserID);
                    if (user_profile == null)
                    {
                        return HttpNotFound();
                    }
                    var crypto = new SimpleCrypto.PBKDF2();
                    var encrypPass = crypto.Compute(user.NewPassword);
                    user_profile.Password = encrypPass;
                    user_profile.PasswordSalt = crypto.Salt;

                    if (ModelState.IsValid)
                    {
                        db.Entry(user_profile).State = System.Data.EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }

                }
                else
                {
                    return RedirectToAction("ChangePassword");
                }
            }
            else
            {
                return RedirectToAction("ChangePassword");
            }
            return RedirectToAction("LogOff");
        }


        public ActionResult GetFullName(int? id)
        {
            if (id == null)
            {
                string temp = "";
                return PartialView((object)temp);
            }
            string FullName = "";
            try
            {
                FullName = (from m in db.User
                            where m.ID == id
                            select (m.FullName != "") ? m.FullName : m.Name).FirstOrDefault().ToString();
            }
            catch
            {
                FullName = "Null";
            }

            return PartialView((object)FullName);

        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
