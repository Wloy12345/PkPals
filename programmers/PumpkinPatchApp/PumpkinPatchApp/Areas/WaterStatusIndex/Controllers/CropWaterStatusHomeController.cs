﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PK_EF;

namespace PumpkinPatchApp.Areas.WaterStatusIndex.Controllers
{
    public class CropWaterStatusHomeController : Controller
    {
        private PKPalsEntities db = new PKPalsEntities();

        // GET: WaterStatusIndex/CropWaterStatusHome
        public ActionResult Index()
        {
            return View(db.CROP_WATER_STATUS.ToList());
        }

        // GET: WaterStatusIndex/CropWaterStatusHome/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CROP_WATER_STATUS cROP_WATER_STATUS = db.CROP_WATER_STATUS.Find(id);
            if (cROP_WATER_STATUS == null)
            {
                return HttpNotFound();
            }
            return View(cROP_WATER_STATUS);
        }

        // GET: WaterStatusIndex/CropWaterStatusHome/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WaterStatusIndex/CropWaterStatusHome/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CropWaterStatusID,Name")] CROP_WATER_STATUS cROP_WATER_STATUS)
        {
            if (ModelState.IsValid)
            {
                db.CROP_WATER_STATUS.Add(cROP_WATER_STATUS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cROP_WATER_STATUS);
        }

        // GET: WaterStatusIndex/CropWaterStatusHome/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CROP_WATER_STATUS cROP_WATER_STATUS = db.CROP_WATER_STATUS.Find(id);
            if (cROP_WATER_STATUS == null)
            {
                return HttpNotFound();
            }
            return View(cROP_WATER_STATUS);
        }

        // POST: WaterStatusIndex/CropWaterStatusHome/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CropWaterStatusID,Name")] CROP_WATER_STATUS cROP_WATER_STATUS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cROP_WATER_STATUS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cROP_WATER_STATUS);
        }

        // GET: WaterStatusIndex/CropWaterStatusHome/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CROP_WATER_STATUS cROP_WATER_STATUS = db.CROP_WATER_STATUS.Find(id);
            if (cROP_WATER_STATUS == null)
            {
                return HttpNotFound();
            }
            return View(cROP_WATER_STATUS);
        }

        // POST: WaterStatusIndex/CropWaterStatusHome/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CROP_WATER_STATUS cROP_WATER_STATUS = db.CROP_WATER_STATUS.Find(id);
            db.CROP_WATER_STATUS.Remove(cROP_WATER_STATUS);
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
