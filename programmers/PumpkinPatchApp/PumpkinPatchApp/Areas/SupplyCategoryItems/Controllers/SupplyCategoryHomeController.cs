using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PK_EF;

namespace PumpkinPatchApp.Areas.SupplyCategoryItems.Controllers
{
    public class SupplyCategoryHomeController : Controller
    {
        private PKPalsEntities db = new PKPalsEntities();

        // GET: SupplyCategoryItems/SupplyCategoryHome
        public ActionResult Index()
        {
            return View(db.CATEGORies.ToList());
        }

        // GET: SupplyCategoryItems/SupplyCategoryHome/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY cATEGORY = db.CATEGORies.Find(id);
            if (cATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORY);
        }

        // GET: SupplyCategoryItems/SupplyCategoryHome/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplyCategoryItems/SupplyCategoryHome/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,Name")] CATEGORY cATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.CATEGORies.Add(cATEGORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cATEGORY);
        }

        // GET: SupplyCategoryItems/SupplyCategoryHome/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY cATEGORY = db.CATEGORies.Find(id);
            if (cATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORY);
        }

        // POST: SupplyCategoryItems/SupplyCategoryHome/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,Name")] CATEGORY cATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATEGORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cATEGORY);
        }

        // GET: SupplyCategoryItems/SupplyCategoryHome/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY cATEGORY = db.CATEGORies.Find(id);
            if (cATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORY);
        }

        // POST: SupplyCategoryItems/SupplyCategoryHome/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CATEGORY cATEGORY = db.CATEGORies.Find(id);
            db.CATEGORies.Remove(cATEGORY);
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
