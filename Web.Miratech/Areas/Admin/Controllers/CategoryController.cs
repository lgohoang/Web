using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Miratech.Models;

namespace Web.Miratech.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private DataContext db = new DataContext();
        //
        // GET: /Admin/Category/

        public ActionResult Index()
        {
            return View(db.Category.ToList());
        }

        public ActionResult Create()
        {
            //using (var db = new DataContext())
            //{
            //    List<SelectListItem> parent_id = new List<SelectListItem>();



            //    var item_parent_id = (from c in db.Category
            //                          orderby c.Order
            //                          select c).ToList().Select(u => new SelectListItem
            //                          {
            //                              Text = u.Name,
            //                              Value = u.ID.ToString()
            //                          });

            //    parent_id.Add(new SelectListItem { Text = "isParent", Value = "0", Selected = true });
            //    parent_id.AddRange(item_parent_id);
            //    ViewBag.Parent_Id = parent_id;

            //    List<SelectListItem> menu_id = new List<SelectListItem>();
            //    var item_menu_id = (from c in db.Menu
            //                        orderby c.Order
            //                        select c).ToList().Select(u => new SelectListItem
            //                        {
            //                            Text = u.Name,
            //                            Value = u.ID.ToString()
            //                        });

            //    menu_id.Add(new SelectListItem { Text = "Select Menu", Value = "0", Selected = true });
            //    menu_id.AddRange(item_menu_id);
            //    ViewBag.Menu_Id = menu_id;

            //    List<SelectListItem> Menu_ID = new List<SelectListItem>();

            //    Menu_ID.Add(new SelectListItem { Text = "False", Value = "False", Selected = true });
            //    Menu_ID.Add(new SelectListItem { Text = "True", Value = "True" });

            //    ViewBag.isEnable = Menu_ID;

            //    return View();
            //}
            List<SelectListItem> TrueFalse = new List<SelectListItem>();

            TrueFalse.Add(new SelectListItem { Text = "True", Value = "True", Selected = true });
            TrueFalse.Add(new SelectListItem { Text = "False", Value = "False" });

            ViewBag.TrueFalse = TrueFalse;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryModels categories)
        {
            if (ModelState.IsValid)
            {
                db.Category.Add(categories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categories);
        }

        //
        // GET: /Categories/Edit/5

        //[Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id = 0)
        {
            CategoryModels categories = db.Category.Find(id);
            if (categories == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> TrueFalse = new List<SelectListItem>();

            TrueFalse.Add(new SelectListItem { Text = "True", Value = "True", Selected = true });
            TrueFalse.Add(new SelectListItem { Text = "False", Value = "False" });

            ViewBag.TrueFalse = TrueFalse;

            return View(categories);
        }

        //
        // POST: /Categories/Edit/5
        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryModels categories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categories);
        }

        //
        // GET: /Categories/Delete/5

        //[Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id = 0)
        {
            CategoryModels categories = db.Category.Find(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            else 
            {
                db.Category.Remove(categories);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        //
        // POST: /Categories/Delete/5


        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CategoryModels categories = db.Category.Find(id);
        //    db.Category.Remove(categories);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult GetCategoryName(int id)
        {
            string CategoryTitle = "";

            try
            {
                CategoryTitle = (from m in db.Category
                                 where m.ID == id
                                 select (m.Title != "") ? m.Title : m.Name).FirstOrDefault().ToString();
            }
            catch
            {
                CategoryTitle = "Null";
            }

            return PartialView((object)CategoryTitle);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
