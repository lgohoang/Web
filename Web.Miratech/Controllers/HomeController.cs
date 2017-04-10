using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Miratech.Models;

namespace Web.Miratech.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();

        public ActionResult Index()
        {
            var Slide = (from sl in db.Slide
                         where (sl.Enable == true && sl.Visible == true)
                         orderby sl.ID
                         select sl).Take(5);

            ViewBag.Slide = Slide.ToList();

            var Solution_Areas = (from sa in db.Article
                                  join ca in db.Category
                                  on sa.CategoryID equals ca.ID
                                  where ca.ID == 4
                                  orderby sa.ID
                                  select sa).Take(8);

            var NumberOfRow = 4;
            var Count = Solution_Areas.Count();
            var NumberRow = Count / NumberOfRow + ((Count % NumberOfRow == 0 ? 0 : 1));

            ViewBag.NumberOfRow = NumberOfRow;
            ViewBag.Count = Count;
            ViewBag.NumberRow = NumberRow;

            ViewBag.Solution_Areas = Solution_Areas.ToList();

            ///Lasted Posts
            ///
            var lasted_post = (from lp in db.Article
                               orderby lp.ID ascending
                               select lp).Take(5);
            ViewBag.LastedPost = lasted_post.ToList();


            ///Our Clients
            ///
            var our_client = from o in db.Client
                             where o.Visible == true
                             orderby o.Order ascending
                             select o;

            ViewBag.OurClients = our_client.ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
