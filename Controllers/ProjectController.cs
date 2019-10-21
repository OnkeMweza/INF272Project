using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Deliverable2.Models;


namespace INF272Project.Controllers
{
    public class ProjectController : Controller
    {
        private Project_DBEntities db = new Project_DBEntities();
        // GET: Project
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult WelcomePage()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            ViewBag.SurbubID = new SelectList(db.Surbubs, "SurbubID", "SurbubName");
            ViewBag.StreetName = new SelectList(db.Streets, "StreetID", "StreetName");
            ViewBag.IllnessName = new SelectList(db.Illnesses, "IID", "IllnessName");
            ViewBag.MedicalAidName = new SelectList(db.MedicalAids, "MID", "MedicalAidName");
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult MedicalInfo()
        {
            return View();
        }

        public ActionResult PatientDetails()
        {
            return View();
        }

        public ActionResult UpdatePatientDetails()
        {
            return View();
        }

        public ActionResult CreatePatientDetails()
        {
            return View();
        }

        public ActionResult CreateMedicalInfo()
        {
            return View();
        }

        public ActionResult UpdateMedicalInfo()
        {
            return View();
        }
        public ActionResult Hospitals()
        {
            return View();
        }
    }
}