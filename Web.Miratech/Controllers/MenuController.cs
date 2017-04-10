using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Miratech.Models;

namespace Web.Miratech.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Data/

        DataContext db = new DataContext();

        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult Menu() 
        {
            var menu = from m in db.Menu
                       where (m.Visible == true & m.ParentID == 0)
                       select m;
            return PartialView(menu.ToList());
        }

        [ChildActionOnly]
        public PartialViewResult ChildrenMenu(int ParentID)
        {
            var _menu = from menu in db.Menu
                        where menu.ParentID == ParentID
                        select menu;
            return PartialView(_menu.ToList());
        }

        public PartialViewResult Category()
        {
            var menu = from c in db.Category
                       where c.Visible == true
                       orderby c.Order ascending
                       select c;
            return PartialView(menu.ToList());
        }

    }
}
