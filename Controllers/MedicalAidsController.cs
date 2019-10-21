using System;
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
    public class MedicalAidsController : Controller
    {
        private Project_DBEntities db = new Project_DBEntities();

        // GET: MedicalAids
        public ActionResult Index()
        {
            return View(db.MedicalAids.ToList());
        }

        // GET: MedicalAids/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalAid medicalAid = db.MedicalAids.Find(id);
            if (medicalAid == null)
            {
                return HttpNotFound();
            }
            return View(medicalAid);
        }

        // GET: MedicalAids/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalAids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MID,MedicalAidName")] MedicalAid medicalAid)
        {
            if (ModelState.IsValid)
            {
                db.MedicalAids.Add(medicalAid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicalAid);
        }

        // GET: MedicalAids/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalAid medicalAid = db.MedicalAids.Find(id);
            if (medicalAid == null)
            {
                return HttpNotFound();
            }
            return View(medicalAid);
        }

        // POST: MedicalAids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MID,MedicalAidName")] MedicalAid medicalAid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicalAid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicalAid);
        }

        // GET: MedicalAids/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalAid medicalAid = db.MedicalAids.Find(id);
            if (medicalAid == null)
            {
                return HttpNotFound();
            }
            return View(medicalAid);
        }

        // POST: MedicalAids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicalAid medicalAid = db.MedicalAids.Find(id);
            db.MedicalAids.Remove(medicalAid);
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
