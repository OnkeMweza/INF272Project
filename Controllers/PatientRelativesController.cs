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
    public class PatientRelativesController : Controller
    {
        private Project_DBEntities db = new Project_DBEntities();

        // GET: PatientRelatives
        public ActionResult Index()
        {
            return View(db.PatientRelatives.ToList());
        }

        // GET: PatientRelatives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientRelative patientRelative = db.PatientRelatives.Find(id);
            if (patientRelative == null)
            {
                return HttpNotFound();
            }
            return View(patientRelative);
        }

        // GET: PatientRelatives/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientRelatives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RID,FirstName,Surname,ContactDetailsP,ContactDetailsH,ContactDetailsW")] PatientRelative patientRelative)
        {
            if (ModelState.IsValid)
            {
                db.PatientRelatives.Add(patientRelative);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patientRelative);
        }

        // GET: PatientRelatives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientRelative patientRelative = db.PatientRelatives.Find(id);
            if (patientRelative == null)
            {
                return HttpNotFound();
            }
            return View(patientRelative);
        }

        // POST: PatientRelatives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RID,FirstName,Surname,ContactDetailsP,ContactDetailsH,ContactDetailsW")] PatientRelative patientRelative)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientRelative).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patientRelative);
        }

        // GET: PatientRelatives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientRelative patientRelative = db.PatientRelatives.Find(id);
            if (patientRelative == null)
            {
                return HttpNotFound();
            }
            return View(patientRelative);
        }

        // POST: PatientRelatives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientRelative patientRelative = db.PatientRelatives.Find(id);
            db.PatientRelatives.Remove(patientRelative);
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
