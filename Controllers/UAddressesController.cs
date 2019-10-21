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
    public class UAddressesController : Controller
    {
        private Project_DBEntities db = new Project_DBEntities();

        // GET: UAddresses
        public ActionResult Index()
        {
            var uAddresses = db.UAddresses.Include(u => u.Street);
            return View(uAddresses.ToList());
        }

        // GET: UAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UAddress uAddress = db.UAddresses.Find(id);
            if (uAddress == null)
            {
                return HttpNotFound();
            }
            return View(uAddress);
        }

        // GET: UAddresses/Create
        public ActionResult Create()
        {
            ViewBag.StreetID = new SelectList(db.Streets, "StreetID", "StreetName");
            return View();
        }

        // POST: UAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AID,StreetID")] UAddress uAddress)
        {
            if (ModelState.IsValid)
            {
                db.UAddresses.Add(uAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StreetID = new SelectList(db.Streets, "StreetID", "StreetName", uAddress.StreetID);
            return View(uAddress);
        }

        // GET: UAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UAddress uAddress = db.UAddresses.Find(id);
            if (uAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.StreetID = new SelectList(db.Streets, "StreetID", "StreetName", uAddress.StreetID);
            return View(uAddress);
        }

        // POST: UAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AID,StreetID")] UAddress uAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StreetID = new SelectList(db.Streets, "StreetID", "StreetName", uAddress.StreetID);
            return View(uAddress);
        }

        // GET: UAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UAddress uAddress = db.UAddresses.Find(id);
            if (uAddress == null)
            {
                return HttpNotFound();
            }
            return View(uAddress);
        }

        // POST: UAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UAddress uAddress = db.UAddresses.Find(id);
            db.UAddresses.Remove(uAddress);
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
