using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Web.Miratech.Models;

namespace Web.Miratech.Controllers
{
    public class ViewController : Controller
    {
        DataContext db = new DataContext();
        //
        // GET: /View/

        public ActionResult Index(int? Page, int CategoriesID = -1)
        {
            int ArticleOnPage = 5;
            if (CategoriesID != -1)
            {
                IQueryable<ArticleModels> Article = (from a in db.Article
                                               where a.CategoryID == CategoriesID
                                               orderby a.ID
                                               select a).AsQueryable();
                var pageNumber = Page ?? 1;
                var onePageOfProducts = Article.ToPagedList(pageNumber, ArticleOnPage);
                ViewBag.OnePageOfProducts = onePageOfProducts;
                return View();
            }
            else
            {
                IQueryable<ArticleModels> Article = (from a in db.Article
                                               orderby a.ID
                                               select a).AsQueryable();
                var pageNumber = Page ?? 1;
                var onePageOfProducts = Article.ToPagedList(pageNumber, ArticleOnPage);
                ViewBag.OnePageOfProducts = onePageOfProducts;

                return View();
            }
        }


        public ActionResult Post(int ID = 0)
        {
            var model = from p in db.Article
                        where p.ID == ID
                        select p;

            return View(model.ToList());
        }

        public ActionResult ViewTab()
        {
            return View();
        }

        public PartialViewResult LatestPost() 
        {
            var model = (from l in db.Article
                         where l.CategoryID == 3
                         orderby l.ID descending
                         select l).Take(5);

            return PartialView(model.ToList());

        }
    }
}
