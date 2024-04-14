using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PK_EF;

namespace PumpkinPatchApp.Areas.Plots.Controllers
{
    public class PlotsHomeController : Controller
    {
        private PKPalsEntities db = new PKPalsEntities();

        // GET: Plots/PlotsHome
        public ActionResult Index()
        {
            var pLOTs = db.PLOTs.Include(p => p.CROP).Include(p => p.CROP_WATER_STATUS).Include(p => p.FARM);
            return View(pLOTs.ToList());
        }

        // GET: Plots/PlotsHome/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLOT pLOT = db.PLOTs.Find(id);
            if (pLOT == null)
            {
                return HttpNotFound();
            }
            return View(pLOT);
        }

        // GET: Plots/PlotsHome/Create
        public ActionResult Create()
        {
            ViewBag.CropID = new SelectList(db.CROPs, "CropID", "Name");
            ViewBag.CropWaterStatusID = new SelectList(db.CROP_WATER_STATUS, "CropWaterStatusID", "Name");
            ViewBag.FarmID = new SelectList(db.FARMs, "FarmID", "Name");
            return View();
        }

        // POST: Plots/PlotsHome/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlotID,FarmID,CropID,CropWaterStatusID,Name,Description,Size,History,DatePlantec")] PLOT pLOT)
        {
            if (ModelState.IsValid)
            {
                db.PLOTs.Add(pLOT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CropID = new SelectList(db.CROPs, "CropID", "Name", pLOT.CropID);
            ViewBag.CropWaterStatusID = new SelectList(db.CROP_WATER_STATUS, "CropWaterStatusID", "Name", pLOT.CropWaterStatusID);
            ViewBag.FarmID = new SelectList(db.FARMs, "FarmID", "Name", pLOT.FarmID);
            return View(pLOT);
        }

        // GET: Plots/PlotsHome/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLOT pLOT = db.PLOTs.Find(id);
            if (pLOT == null)
            {
                return HttpNotFound();
            }
            ViewBag.CropID = new SelectList(db.CROPs, "CropID", "Name", pLOT.CropID);
            ViewBag.CropWaterStatusID = new SelectList(db.CROP_WATER_STATUS, "CropWaterStatusID", "Name", pLOT.CropWaterStatusID);
            ViewBag.FarmID = new SelectList(db.FARMs, "FarmID", "Name", pLOT.FarmID);
            return View(pLOT);
        }

        // POST: Plots/PlotsHome/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlotID,FarmID,CropID,CropWaterStatusID,Name,Description,Size,History,DatePlantec")] PLOT pLOT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pLOT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CropID = new SelectList(db.CROPs, "CropID", "Name", pLOT.CropID);
            ViewBag.CropWaterStatusID = new SelectList(db.CROP_WATER_STATUS, "CropWaterStatusID", "Name", pLOT.CropWaterStatusID);
            ViewBag.FarmID = new SelectList(db.FARMs, "FarmID", "Name", pLOT.FarmID);
            return View(pLOT);
        }

        // GET: Plots/PlotsHome/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLOT pLOT = db.PLOTs.Find(id);
            if (pLOT == null)
            {
                return HttpNotFound();
            }
            return View(pLOT);
        }

        // POST: Plots/PlotsHome/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PLOT pLOT = db.PLOTs.Find(id);
            db.PLOTs.Remove(pLOT);
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
