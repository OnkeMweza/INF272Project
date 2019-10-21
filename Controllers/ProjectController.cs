using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;


namespace INF272Project.Controllers
{
    public class ProjectController : Controller
    {
       
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