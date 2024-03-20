using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PK_EF;

namespace PumpkinPatchApp.Areas.Equipment.Controllers
{
    public class EquipmentHomeController : Controller
    {
        private PKPalsEntities db = new PKPalsEntities();

        // GET: Equipment/EquipmentHome
        public ActionResult Index()
        {
            var eQUIPMENTs = db.EQUIPMENTs.Include(e => e.FARM).Include(e => e.STATUS);
            return View(eQUIPMENTs.ToList());
        }

        // GET: Equipment/EquipmentHome/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUIPMENT eQUIPMENT = db.EQUIPMENTs.Find(id);
            if (eQUIPMENT == null)
            {
                return HttpNotFound();
            }
            return View(eQUIPMENT);
        }

        // GET: Equipment/EquipmentHome/Create
        public ActionResult Create()
        {
            ViewBag.FarmID = new SelectList(db.FARMs, "FarmID", "Name");
            ViewBag.StatusID = new SelectList(db.STATUS, "StatusID", "Name");
            return View();
        }

        // POST: Equipment/EquipmentHome/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipmentID,FarmID,StatusID,Name,Type,Description")] EQUIPMENT eQUIPMENT)
        {
            if (ModelState.IsValid)
            {
                db.EQUIPMENTs.Add(eQUIPMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FarmID = new SelectList(db.FARMs, "FarmID", "Name", eQUIPMENT.FarmID);
            ViewBag.StatusID = new SelectList(db.STATUS, "StatusID", "Name", eQUIPMENT.StatusID);
            return View(eQUIPMENT);
        }

        // GET: Equipment/EquipmentHome/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUIPMENT eQUIPMENT = db.EQUIPMENTs.Find(id);
            if (eQUIPMENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.FarmID = new SelectList(db.FARMs, "FarmID", "Name", eQUIPMENT.FarmID);
            ViewBag.StatusID = new SelectList(db.STATUS, "StatusID", "Name", eQUIPMENT.StatusID);
            return View(eQUIPMENT);
        }

        // POST: Equipment/EquipmentHome/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipmentID,FarmID,StatusID,Name,Type,Description")] EQUIPMENT eQUIPMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eQUIPMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FarmID = new SelectList(db.FARMs, "FarmID", "Name", eQUIPMENT.FarmID);
            ViewBag.StatusID = new SelectList(db.STATUS, "StatusID", "Name", eQUIPMENT.StatusID);
            return View(eQUIPMENT);
        }

        // GET: Equipment/EquipmentHome/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUIPMENT eQUIPMENT = db.EQUIPMENTs.Find(id);
            if (eQUIPMENT == null)
            {
                return HttpNotFound();
            }
            return View(eQUIPMENT);
        }

        // POST: Equipment/EquipmentHome/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EQUIPMENT eQUIPMENT = db.EQUIPMENTs.Find(id);
            db.EQUIPMENTs.Remove(eQUIPMENT);
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
