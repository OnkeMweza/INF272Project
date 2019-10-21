using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using Deliverable2.Models;
using System.Text;

namespace INF272Project.Controllers
{
    public class ProjectController : Controller
    {
        private Project_DBEntities db = new Project_DBEntities();

        public string Password { get; private set; }
        public string Email { get; private set; }

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

        [HttpPost]
        public ActionResult Login()
        {
            var hashedPassword = ComputeSha256Hash(Password);
            Deliverable2.Models.SysUser user = db.SysUsers.Where(zz => zz.EmailAddress == Email
                                              && zz.Upassword == hashedPassword).FirstOrDefault();
            if (user != null)
            {
                UserVM userVME = new UserVM();
                userVME.user = user;
                userVME.RefreshGUID(db);
                TempData["userVM"] = userVME;
                return RedirectToAction("WelcomePage", "Project");
            }

            return RedirectToAction("Index", "Project");
        }

        string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
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