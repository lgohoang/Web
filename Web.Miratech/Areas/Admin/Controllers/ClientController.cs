using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Miratech.Models;

namespace Web.Miratech.Areas.Admin.Controllers
{
    public class ClientController : Controller
    {
        private DataContext db = new DataContext();
        //
        // GET: /Admin/Config/

        public ActionResult Index()
        {
            return View(db.Client.ToList());
        }

        //
        // GET: /Client/Create

        //[Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            List<SelectListItem> TrueFalse = new List<SelectListItem>();

            TrueFalse.Add(new SelectListItem { Text = "True", Value = "True", Selected = true });
            TrueFalse.Add(new SelectListItem { Text = "False", Value = "False" });

            ViewBag.TrueFalse = TrueFalse;

            return View();
        }

        //
        // POST: /Client/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator")]
        public ActionResult Create(ClientModels ourclients)
        {
            if (ModelState.IsValid)
            {
                db.Client.Add(ourclients);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ourclients);
        }

        //
        // GET: /Client/Edit/5
        //[Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id = 0)
        {
            List<SelectListItem> TrueFalse = new List<SelectListItem>();

            TrueFalse.Add(new SelectListItem { Text = "True", Value = "True", Selected = true });
            TrueFalse.Add(new SelectListItem { Text = "False", Value = "False" });

            ViewBag.TrueFalse = TrueFalse;

            ClientModels ourclients = db.Client.Find(id);
            if (ourclients == null)
            {
                return HttpNotFound();
            }
            return View(ourclients);
        }

        //
        // POST: /Client/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator")]
        public ActionResult Edit(ClientModels ourclients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ourclients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ourclients);
        }

        //
        // GET: /Client/Delete/5

        //[Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id = 0)
        {
            ClientModels ourclients = db.Client.Find(id);
            if (ourclients == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Client.Remove(ourclients);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
