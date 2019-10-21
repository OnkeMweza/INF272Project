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
    public class PatientsController : Controller
    {
        private Project_DBEntities db = new Project_DBEntities();

        // GET: Patients
        public ActionResult Index()
        {
            var patients = db.Patients.Include(p => p.Illness).Include(p => p.MedicalAid).Include(p => p.UAddress).Include(p => p.PatientRelative).Include(p => p.SysUser).Include(p => p.Vital);
            return View(patients.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            UserVM userVM = new UserVM();
            if (userVM.IsLogedIn(db, userGUID))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Patient patient = db.Patients.Find(id);
                PatientVM patiVM = new PatientVM();
                patiVM.userVM = userVM;
                patiVM.patients.Add(patient);
                if (patient == null)
                {
                    return HttpNotFound();
                }
                return View(patient);
            }
            return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            ViewBag.IID = new SelectList(db.Illnesses, "IID", "IllnessName");
            ViewBag.MID = new SelectList(db.MedicalAids, "MID", "MedicalAidName");
            ViewBag.AID = new SelectList(db.UAddresses, "AID", "AID");
            ViewBag.RID = new SelectList(db.PatientRelatives, "RID", "FirstName");
            ViewBag.userID = new SelectList(db.SysUsers, "userID", "EmailAddress");
            ViewBag.VitalID = new SelectList(db.Vitals, "VitalID", "VitalID");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientID,FirstName,Surname,EmailAddress,Age,ContactDetails,ChipID,MID,VitalID,RID,IID,AID,userID")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IID = new SelectList(db.Illnesses, "IID", "IllnessName", patient.IID);
            ViewBag.MID = new SelectList(db.MedicalAids, "MID", "MedicalAidName", patient.MID);
            ViewBag.AID = new SelectList(db.UAddresses, "AID", "AID", patient.AID);
            ViewBag.RID = new SelectList(db.PatientRelatives, "RID", "FirstName", patient.RID);
            ViewBag.userID = new SelectList(db.SysUsers, "userID", "EmailAddress", patient.userID);
            ViewBag.VitalID = new SelectList(db.Vitals, "VitalID", "VitalID", patient.VitalID);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.IID = new SelectList(db.Illnesses, "IID", "IllnessName", patient.IID);
            ViewBag.MID = new SelectList(db.MedicalAids, "MID", "MedicalAidName", patient.MID);
            ViewBag.AID = new SelectList(db.UAddresses, "AID", "AID", patient.AID);
            ViewBag.RID = new SelectList(db.PatientRelatives, "RID", "FirstName", patient.RID);
            ViewBag.userID = new SelectList(db.SysUsers, "userID", "EmailAddress", patient.userID);
            ViewBag.VitalID = new SelectList(db.Vitals, "VitalID", "VitalID", patient.VitalID);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientID,FirstName,Surname,EmailAddress,Age,ContactDetails,ChipID,MID,VitalID,RID,IID,AID,userID")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IID = new SelectList(db.Illnesses, "IID", "IllnessName", patient.IID);
            ViewBag.MID = new SelectList(db.MedicalAids, "MID", "MedicalAidName", patient.MID);
            ViewBag.AID = new SelectList(db.UAddresses, "AID", "AID", patient.AID);
            ViewBag.RID = new SelectList(db.PatientRelatives, "RID", "FirstName", patient.RID);
            ViewBag.userID = new SelectList(db.SysUsers, "userID", "EmailAddress", patient.userID);
            ViewBag.VitalID = new SelectList(db.Vitals, "VitalID", "VitalID", patient.VitalID);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
