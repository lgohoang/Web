using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Miratech.Models;

namespace Web.Miratech.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        private DataContext db = new DataContext();
        //
        // GET: /Admin/Menu/

        public ActionResult Index()
        {
            return View(db.Menu.ToList());
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult Create()
        {
            using (var db = new DataContext())
            {
                List<SelectListItem> item_parent_id = new List<SelectListItem>();
                var items = (from c in db.Menu
                             orderby c.Order
                             select c).ToList().Select(u => new SelectListItem
                             {
                                 Text = u.Name,
                                 Value = u.ID.ToString()
                             });

                item_parent_id.Add(new SelectListItem { Text = "isParent", Value = "0", Selected = true });
                item_parent_id.AddRange(items);

                ViewBag.List = item_parent_id;

                List<SelectListItem> item = new List<SelectListItem>();

                item.Add(new SelectListItem { Text = "False", Value = "False", Selected = true });
                item.Add(new SelectListItem { Text = "True", Value = "True" });

                ViewBag.isEnable = item;

                return View();
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuModels model)
        {
            model.CreateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Menu.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);

        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            using (var db = new DataContext())
            {
                List<SelectListItem> item_parent_id = new List<SelectListItem>();
                var items = (from c in db.Menu
                             orderby c.Order
                             select c).ToList().Select(u => new SelectListItem
                             {
                                 Text = u.Name,
                                 Value = u.ID.ToString()
                             });
                item_parent_id.Add(new SelectListItem { Text = "isParent", Value = "0", Selected = true });
                item_parent_id.AddRange(items);
                ViewBag.List = item_parent_id;

                List<SelectListItem> item = new List<SelectListItem>();

                item.Add(new SelectListItem { Text = "True", Value = "True", Selected = true });
                item.Add(new SelectListItem { Text = "False", Value = "False" });

                ViewBag.isEnable = item;

                MenuModels menu = db.Menu.Find(ID);
                if (menu == null)
                {
                    return HttpNotFound();
                }
                return View(menu);
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Edit(MenuModels model)
        {
            model.CreateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);

        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int ID = 0)
        {
            MenuModels menu = db.Menu.Find(ID);
            if (menu == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Menu.Remove(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public ActionResult GetParentName(int? ParentID)
        {
            string ParentName = "";

            try
            {
                ParentName = (from m in db.Menu
                              where m.ID == ParentID
                              select (m.Title != "") ? m.Title : m.Name).FirstOrDefault().ToString();
            }
            catch
            {
                ParentName = "Null";
            }

            return PartialView((object)ParentName);
        }

    }
}
