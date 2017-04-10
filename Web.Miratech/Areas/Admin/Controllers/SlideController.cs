using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Miratech.Models;

namespace Web.Miratech.Areas.Admin.Controllers
{
    public class SlideController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Admin/Slide/

        public ActionResult Index()
        {
            return View(db.Slide.ToList());
        }

        //
        // GET: /Article/Create
        //[Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> TrueFalse = new List<SelectListItem>();

            TrueFalse.Add(new SelectListItem { Text = "True", Value = "True", Selected = true });
            TrueFalse.Add(new SelectListItem { Text = "False", Value = "False" });

            ViewBag.TrueFalse = TrueFalse;

            return View();
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SlideModels model)
        {
            string UserName = System.Web.HttpContext.Current.User.Identity.Name;

            int UserID = (from u in db.User
                          where u.Name == UserName
                          select u.ID).FirstOrDefault();

            model.UserID = UserID;
            model.CreateTime = DateTime.Now;
            //var Article = new ArticleModels();
            //Article.CategoryID = model.CategoryID;
            //Article.UserID = UserID;
            //Article.CreateTime = DateTime.Now;
            //Article.Title = model.Title;
            //Article.Describe = model.Describe;
            //Article.Image = model.Image;
            //Article.Content = model.Content;

            if (ModelState.IsValid)
            {
                db.Slide.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }


        //
        // GET: /Article/Edit/5
        //[Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id = 0)
        {
            SlideModels Slide = db.Slide.Find(id);
            if (Slide == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> TrueFalse = new List<SelectListItem>();

            TrueFalse.Add(new SelectListItem { Text = "True", Value = "True", Selected = true });
            TrueFalse.Add(new SelectListItem { Text = "False", Value = "False" });

            ViewBag.TrueFalse = TrueFalse;

            return View(Slide);
        }

        //
        // POST: /Article/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator")]
        public ActionResult Edit(SlideModels model)
        {
            string UserName = System.Web.HttpContext.Current.User.Identity.Name;
            int UserID = (from u in db.User
                          where u.Name == UserName
                          select u.ID).FirstOrDefault();

            model.UserID = UserID;
            model.CreateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //[Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id = 0)
        {
            SlideModels Slide = db.Slide.Find(id);
            if (Slide == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Slide.Remove(Slide);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
