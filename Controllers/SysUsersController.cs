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
    public class SysUsersController : Controller
    {
        private Project_DBEntities db = new Project_DBEntities();

        // GET: SysUsers
        public ActionResult Index()
        {
            var sysUsers = db.SysUsers.Include(s => s.UserType);
            return View(sysUsers.ToList());
        }

        // GET: SysUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysUser sysUser = db.SysUsers.Find(id);
            if (sysUser == null)
            {
                return HttpNotFound();
            }
            return View(sysUser);
        }

        // GET: SysUsers/Create
        public ActionResult Create()
        {
            ViewBag.UTID = new SelectList(db.UserTypes, "UTID", "UTDescription");
            return View();
        }

        // POST: SysUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,EmailAddress,Upassword,UTID")] SysUser sysUser)
        {
            if (ModelState.IsValid)
            {
                db.SysUsers.Add(sysUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UTID = new SelectList(db.UserTypes, "UTID", "UTDescription", sysUser.UTID);
            return View(sysUser);
        }

        // GET: SysUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysUser sysUser = db.SysUsers.Find(id);
            if (sysUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.UTID = new SelectList(db.UserTypes, "UTID", "UTDescription", sysUser.UTID);
            return View(sysUser);
        }

        // POST: SysUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,EmailAddress,Upassword,UTID")] SysUser sysUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sysUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UTID = new SelectList(db.UserTypes, "UTID", "UTDescription", sysUser.UTID);
            return View(sysUser);
        }

        // GET: SysUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysUser sysUser = db.SysUsers.Find(id);
            if (sysUser == null)
            {
                return HttpNotFound();
            }
            return View(sysUser);
        }

        // POST: SysUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SysUser sysUser = db.SysUsers.Find(id);
            db.SysUsers.Remove(sysUser);
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
