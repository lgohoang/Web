using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Miratech.Models;

namespace Web.Miratech.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {

        DataContext db = new DataContext();
        //
        // GET: /Admin/Article/

        public ActionResult Index()
        {
            return View(db.Article.ToList());
        }

        //
        // GET: /Article/Create
        //[Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult Create()
        {
            var List = new List<CategoryModels>();
            List = (from c in db.Category
                    orderby c.Order
                    select c).ToList();
            ViewBag.List = List;

            return View();
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleModels model)
        {
            string UserName = System.Web.HttpContext.Current.User.Identity.Name;

            int UserID = (from u in db.User
                          where u.Name == UserName
                          select u.ID).FirstOrDefault();

            var Article = new ArticleModels();
            Article.CategoryID = model.CategoryID;
            Article.UserID = UserID;
            Article.CreateTime = DateTime.Now;
            Article.Title = model.Title;
            Article.Describe = model.Describe;
            Article.Image = model.Image;
            Article.Content = model.Content;

            if (ModelState.IsValid)
            {
                db.Article.Add(Article);
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


            ArticleModels article = db.Article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }

            var List = new List<CategoryModels>();
            List = (from c in db.Category
                    orderby c.Order
                    select c).ToList();
            ViewBag.List = List;

            return View(article);
        }

        //
        // POST: /Article/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator")]
        public ActionResult Edit(ArticleModels article)
        {
            string UserName = System.Web.HttpContext.Current.User.Identity.Name;
            int UserID = (from u in db.User
                          where u.Name == UserName
                          select u.ID).FirstOrDefault();

            article.UserID = UserID;
            article.CreateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        //[Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id = 0)
        {
            ArticleModels Article = db.Article.Find(id);
            if (Article == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Article.Remove(Article);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
