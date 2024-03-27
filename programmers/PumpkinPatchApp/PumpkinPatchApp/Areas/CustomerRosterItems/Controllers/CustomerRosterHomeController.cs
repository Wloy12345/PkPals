using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PK_EF;

namespace PumpkinPatchApp.Areas.CustomerRosterItems.Controllers
{
    public class CustomerRosterHomeController : Controller
    {
        private PKPalsEntities db = new PKPalsEntities();

        // GET: CustomerRosterItems/CustomerRosterHome
        public ActionResult Index()
        {
            var cUSTOMERROSTERs = db.CUSTOMERROSTERs.Include(c => c.CUSTOMER).Include(c => c.FARM);
            return View(cUSTOMERROSTERs.ToList());
        }

        // GET: CustomerRosterItems/CustomerRosterHome/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMERROSTER cUSTOMERROSTER = db.CUSTOMERROSTERs.Find(id);
            if (cUSTOMERROSTER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMERROSTER);
        }

        // GET: CustomerRosterItems/CustomerRosterHome/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.CUSTOMERs, "CustomerID", "FirstName");
            ViewBag.FarmID = new SelectList(db.FARMs, "FarmID", "Name");
            return View();
        }

        // POST: CustomerRosterItems/CustomerRosterHome/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerRosterID,CustomerID,FarmID")] CUSTOMERROSTER cUSTOMERROSTER)
        {
            if (ModelState.IsValid)
            {
                db.CUSTOMERROSTERs.Add(cUSTOMERROSTER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.CUSTOMERs, "CustomerID", "FirstName", cUSTOMERROSTER.CustomerID);
            ViewBag.FarmID = new SelectList(db.FARMs, "FarmID", "Name", cUSTOMERROSTER.FarmID);
            return View(cUSTOMERROSTER);
        }

        // GET: CustomerRosterItems/CustomerRosterHome/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMERROSTER cUSTOMERROSTER = db.CUSTOMERROSTERs.Find(id);
            if (cUSTOMERROSTER == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.CUSTOMERs, "CustomerID", "FirstName", cUSTOMERROSTER.CustomerID);
            ViewBag.FarmID = new SelectList(db.FARMs, "FarmID", "Name", cUSTOMERROSTER.FarmID);
            return View(cUSTOMERROSTER);
        }

        // POST: CustomerRosterItems/CustomerRosterHome/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerRosterID,CustomerID,FarmID")] CUSTOMERROSTER cUSTOMERROSTER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUSTOMERROSTER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.CUSTOMERs, "CustomerID", "FirstName", cUSTOMERROSTER.CustomerID);
            ViewBag.FarmID = new SelectList(db.FARMs, "FarmID", "Name", cUSTOMERROSTER.FarmID);
            return View(cUSTOMERROSTER);
        }

        // GET: CustomerRosterItems/CustomerRosterHome/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMERROSTER cUSTOMERROSTER = db.CUSTOMERROSTERs.Find(id);
            if (cUSTOMERROSTER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMERROSTER);
        }

        // POST: CustomerRosterItems/CustomerRosterHome/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUSTOMERROSTER cUSTOMERROSTER = db.CUSTOMERROSTERs.Find(id);
            db.CUSTOMERROSTERs.Remove(cUSTOMERROSTER);
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
