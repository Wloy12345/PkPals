using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PK_EF;

namespace PumpkinPatchApp.Areas.Supplies.Controllers
{
    public class SupplyHomeController : Controller
    {
        private PKPalsEntities db = new PKPalsEntities();

        // GET: Supplies/SupplyHome
        public ActionResult Index()
        {
            var sUPPLIES = db.SUPPLIES.Include(s => s.CATEGORY);
            return View(sUPPLIES.ToList());
        }

        // GET: Supplies/SupplyHome/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLy sUPPLy = db.SUPPLIES.Find(id);
            if (sUPPLy == null)
            {
                return HttpNotFound();
            }
            return View(sUPPLy);
        }

        // GET: Supplies/SupplyHome/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.CATEGORies, "CategoryID", "Name");
            return View();
        }

        // POST: Supplies/SupplyHome/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuppliesID,CategoryID,Name,Type,Description,Unit")] SUPPLy sUPPLy)
        {
            if (ModelState.IsValid)
            {
                db.SUPPLIES.Add(sUPPLy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.CATEGORies, "CategoryID", "Name", sUPPLy.CategoryID);
            return View(sUPPLy);
        }

        // GET: Supplies/SupplyHome/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLy sUPPLy = db.SUPPLIES.Find(id);
            if (sUPPLy == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.CATEGORies, "CategoryID", "Name", sUPPLy.CategoryID);
            return View(sUPPLy);
        }

        // POST: Supplies/SupplyHome/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SuppliesID,CategoryID,Name,Type,Description,Unit")] SUPPLy sUPPLy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUPPLy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.CATEGORies, "CategoryID", "Name", sUPPLy.CategoryID);
            return View(sUPPLy);
        }

        // GET: Supplies/SupplyHome/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLy sUPPLy = db.SUPPLIES.Find(id);
            if (sUPPLy == null)
            {
                return HttpNotFound();
            }
            return View(sUPPLy);
        }

        // POST: Supplies/SupplyHome/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SUPPLy sUPPLy = db.SUPPLIES.Find(id);
            db.SUPPLIES.Remove(sUPPLy);
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
