using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PK_EF;

namespace PumpkinPatchApp.Areas.Schedules.Controllers
{
    public class ScheduleHomeController : Controller
    {
        private PKPalsEntities db = new PKPalsEntities();

        // GET: Schedules/ScheduleHome
        public ActionResult Index()
        {
            var sCHEDULEs = db.SCHEDULEs.Include(s => s.EMPLOYEE).Include(s => s.EQUIPMENT);
            return View(sCHEDULEs.ToList());
        }

        // GET: Schedules/ScheduleHome/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCHEDULE sCHEDULE = db.SCHEDULEs.Find(id);
            if (sCHEDULE == null)
            {
                return HttpNotFound();
            }
            return View(sCHEDULE);
        }

        // GET: Schedules/ScheduleHome/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.EMPLOYEEs, "EmployeeID", "FirstName");
            ViewBag.EquipmentID = new SelectList(db.EQUIPMENTs, "EquipmentID", "Name");
            return View();
        }

        // POST: Schedules/ScheduleHome/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScheduleID,EmployeeID,EquipmentID,Time,IsApproved,EndTime")] SCHEDULE sCHEDULE)
        {
            if (ModelState.IsValid)
            {
                db.SCHEDULEs.Add(sCHEDULE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.EMPLOYEEs, "EmployeeID", "FirstName", sCHEDULE.EmployeeID);
            ViewBag.EquipmentID = new SelectList(db.EQUIPMENTs, "EquipmentID", "Name", sCHEDULE.EquipmentID);
            return View(sCHEDULE);
        }

        // GET: Schedules/ScheduleHome/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCHEDULE sCHEDULE = db.SCHEDULEs.Find(id);
            if (sCHEDULE == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.EMPLOYEEs, "EmployeeID", "FirstName", sCHEDULE.EmployeeID);
            ViewBag.EquipmentID = new SelectList(db.EQUIPMENTs, "EquipmentID", "Name", sCHEDULE.EquipmentID);
            return View(sCHEDULE);
        }

        // POST: Schedules/ScheduleHome/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScheduleID,EmployeeID,EquipmentID,Time,IsApproved,EndTime")] SCHEDULE sCHEDULE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sCHEDULE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.EMPLOYEEs, "EmployeeID", "FirstName", sCHEDULE.EmployeeID);
            ViewBag.EquipmentID = new SelectList(db.EQUIPMENTs, "EquipmentID", "Name", sCHEDULE.EquipmentID);
            return View(sCHEDULE);
        }

        // GET: Schedules/ScheduleHome/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCHEDULE sCHEDULE = db.SCHEDULEs.Find(id);
            if (sCHEDULE == null)
            {
                return HttpNotFound();
            }
            return View(sCHEDULE);
        }

        // POST: Schedules/ScheduleHome/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SCHEDULE sCHEDULE = db.SCHEDULEs.Find(id);
            db.SCHEDULEs.Remove(sCHEDULE);
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
