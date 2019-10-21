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
    public class SysAdminsController : Controller
    {
        private Project_DBEntities db = new Project_DBEntities();

        // GET: SysAdmins
        public ActionResult Index()
        {
            var sysAdmins = db.SysAdmins.Include(s => s.SysUser);
            return View(sysAdmins.ToList());
        }

        // GET: SysAdmins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysAdmin sysAdmin = db.SysAdmins.Find(id);
            if (sysAdmin == null)
            {
                return HttpNotFound();
            }
            return View(sysAdmin);
        }

        // GET: SysAdmins/Create
        public ActionResult Create()
        {
            ViewBag.userID = new SelectList(db.SysUsers, "userID", "EmailAddress");
            return View();
        }

        // POST: SysAdmins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminID,EmailAddress,FirstName,Surname,ContactDetails,userID")] SysAdmin sysAdmin)
        {
            if (ModelState.IsValid)
            {
                db.SysAdmins.Add(sysAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userID = new SelectList(db.SysUsers, "userID", "EmailAddress", sysAdmin.userID);
            return View(sysAdmin);
        }

        // GET: SysAdmins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysAdmin sysAdmin = db.SysAdmins.Find(id);
            if (sysAdmin == null)
            {
                return HttpNotFound();
            }
            ViewBag.userID = new SelectList(db.SysUsers, "userID", "EmailAddress", sysAdmin.userID);
            return View(sysAdmin);
        }

        // POST: SysAdmins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminID,EmailAddress,FirstName,Surname,ContactDetails,userID")] SysAdmin sysAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sysAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userID = new SelectList(db.SysUsers, "userID", "EmailAddress", sysAdmin.userID);
            return View(sysAdmin);
        }

        // GET: SysAdmins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysAdmin sysAdmin = db.SysAdmins.Find(id);
            if (sysAdmin == null)
            {
                return HttpNotFound();
            }
            return View(sysAdmin);
        }

        // POST: SysAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SysAdmin sysAdmin = db.SysAdmins.Find(id);
            db.SysAdmins.Remove(sysAdmin);
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
