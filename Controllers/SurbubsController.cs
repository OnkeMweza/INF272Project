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
    public class SurbubsController : Controller
    {
        private Project_DBEntities db = new Project_DBEntities();

        // GET: Surbubs
        public ActionResult Index()
        {
            return View(db.Surbubs.ToList());
        }

        // GET: Surbubs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Surbub surbub = db.Surbubs.Find(id);
            if (surbub == null)
            {
                return HttpNotFound();
            }
            return View(surbub);
        }

        // GET: Surbubs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Surbubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SurbubID,SurbubName")] Surbub surbub)
        {
            if (ModelState.IsValid)
            {
                db.Surbubs.Add(surbub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(surbub);
        }

        // GET: Surbubs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Surbub surbub = db.Surbubs.Find(id);
            if (surbub == null)
            {
                return HttpNotFound();
            }
            return View(surbub);
        }

        // POST: Surbubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SurbubID,SurbubName")] Surbub surbub)
        {
            if (ModelState.IsValid)
            {
                db.Entry(surbub).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(surbub);
        }

        // GET: Surbubs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Surbub surbub = db.Surbubs.Find(id);
            if (surbub == null)
            {
                return HttpNotFound();
            }
            return View(surbub);
        }

        // POST: Surbubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Surbub surbub = db.Surbubs.Find(id);
            db.Surbubs.Remove(surbub);
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
