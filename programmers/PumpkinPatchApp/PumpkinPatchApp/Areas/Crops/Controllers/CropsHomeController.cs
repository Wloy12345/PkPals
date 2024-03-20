using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PK_EF;

namespace PumpkinPatchApp.Areas.Crops.Controllers
{
    public class CropsHomeController : Controller
    {
        private PKPalsEntities db = new PKPalsEntities();

        // GET: Crops/CropsHome
        public ActionResult Index()
        {
            return View(db.CROPs.ToList());
        }

        // GET: Crops/CropsHome/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CROP cROP = db.CROPs.Find(id);
            if (cROP == null)
            {
                return HttpNotFound();
            }
            return View(cROP);
        }

        // GET: Crops/CropsHome/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crops/CropsHome/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CropID,Name,Description,Type,DaysTillHarvest,Season,SelfLife,MarketValue,WaterAmount,CropRotationRecom,HarvestTechniques")] CROP cROP)
        {
            if (ModelState.IsValid)
            {
                db.CROPs.Add(cROP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cROP);
        }

        // GET: Crops/CropsHome/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CROP cROP = db.CROPs.Find(id);
            if (cROP == null)
            {
                return HttpNotFound();
            }
            return View(cROP);
        }

        // POST: Crops/CropsHome/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CropID,Name,Description,Type,DaysTillHarvest,Season,SelfLife,MarketValue,WaterAmount,CropRotationRecom,HarvestTechniques")] CROP cROP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cROP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cROP);
        }

        // GET: Crops/CropsHome/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CROP cROP = db.CROPs.Find(id);
            if (cROP == null)
            {
                return HttpNotFound();
            }
            return View(cROP);
        }

        // POST: Crops/CropsHome/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CROP cROP = db.CROPs.Find(id);
            db.CROPs.Remove(cROP);
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
