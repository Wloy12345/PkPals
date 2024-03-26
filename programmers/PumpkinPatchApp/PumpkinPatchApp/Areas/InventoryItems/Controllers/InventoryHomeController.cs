using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PK_EF;

namespace PumpkinPatchApp.Areas.InventoryItems.Controllers
{
    public class InventoryHomeController : Controller
    {
        private PKPalsEntities db = new PKPalsEntities();

        // GET: InventoryItems/InventoryHome
        public ActionResult Index()
        {
            var iNVENTORies = db.INVENTORies.Include(i => i.FARM).Include(i => i.SUPPLy);
            return View(iNVENTORies.ToList());
        }

        // GET: InventoryItems/InventoryHome/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTORY iNVENTORY = db.INVENTORies.Find(id);
            if (iNVENTORY == null)
            {
                return HttpNotFound();
            }
            return View(iNVENTORY);
        }

        // GET: InventoryItems/InventoryHome/Create
        public ActionResult Create()
        {
            ViewBag.FarmID = new SelectList(db.FARMs, "FarmID", "Name");
            ViewBag.SuppliesID = new SelectList(db.SUPPLIES, "SuppliesID", "Name");
            return View();
        }

        // POST: InventoryItems/InventoryHome/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InventoryID,FarmID,SuppliesID,Quantity")] INVENTORY iNVENTORY)
        {
            if (ModelState.IsValid)
            {
                db.INVENTORies.Add(iNVENTORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FarmID = new SelectList(db.FARMs, "FarmID", "Name", iNVENTORY.FarmID);
            ViewBag.SuppliesID = new SelectList(db.SUPPLIES, "SuppliesID", "Name", iNVENTORY.SuppliesID);
            return View(iNVENTORY);
        }

        // GET: InventoryItems/InventoryHome/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTORY iNVENTORY = db.INVENTORies.Find(id);
            if (iNVENTORY == null)
            {
                return HttpNotFound();
            }
            ViewBag.FarmID = new SelectList(db.FARMs, "FarmID", "Name", iNVENTORY.FarmID);
            ViewBag.SuppliesID = new SelectList(db.SUPPLIES, "SuppliesID", "Name", iNVENTORY.SuppliesID);
            return View(iNVENTORY);
        }

        // POST: InventoryItems/InventoryHome/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InventoryID,FarmID,SuppliesID,Quantity")] INVENTORY iNVENTORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNVENTORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FarmID = new SelectList(db.FARMs, "FarmID", "Name", iNVENTORY.FarmID);
            ViewBag.SuppliesID = new SelectList(db.SUPPLIES, "SuppliesID", "Name", iNVENTORY.SuppliesID);
            return View(iNVENTORY);
        }

        // GET: InventoryItems/InventoryHome/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTORY iNVENTORY = db.INVENTORies.Find(id);
            if (iNVENTORY == null)
            {
                return HttpNotFound();
            }
            return View(iNVENTORY);
        }

        // POST: InventoryItems/InventoryHome/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INVENTORY iNVENTORY = db.INVENTORies.Find(id);
            db.INVENTORies.Remove(iNVENTORY);
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
