﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Deliverable2.Models;

namespace Deliverable2.Controllers
{
    public class IllnessesController : Controller
    {
        private Project_DBEntities db = new Project_DBEntities();

        // GET: Illnesses
        public ActionResult Index()
        {
            return View(db.Illnesses.ToList());
        }

        // GET: Illnesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Illness illness = db.Illnesses.Find(id);
            if (illness == null)
            {
                return HttpNotFound();
            }
            return View(illness);
        }

        // GET: Illnesses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Illnesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IID,IllnessName")] Illness illness)
        {
            if (ModelState.IsValid)
            {
                db.Illnesses.Add(illness);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(illness);
        }

        // GET: Illnesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Illness illness = db.Illnesses.Find(id);
            if (illness == null)
            {
                return HttpNotFound();
            }
            return View(illness);
        }

        // POST: Illnesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IID,IllnessName")] Illness illness)
        {
            if (ModelState.IsValid)
            {
                db.Entry(illness).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(illness);
        }

        // GET: Illnesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Illness illness = db.Illnesses.Find(id);
            if (illness == null)
            {
                return HttpNotFound();
            }
            return View(illness);
        }

        // POST: Illnesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Illness illness = db.Illnesses.Find(id);
            db.Illnesses.Remove(illness);
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