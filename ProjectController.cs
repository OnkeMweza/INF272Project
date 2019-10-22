using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Deliverable2.Models;
using System.Text;
using System.Security.Cryptography;


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

        public ActionResult WelcomePage(string Name, string Surname, string Email, string password, int Age, string Contact, int HouseNo, [Bind(Include = "StreetID,StreetName,HouseNO,SurbubID")] Street street, [Bind(Include = "SurbubID,SurbubName")] Surbub surbub, [Bind(Include = "IID,IllnessName")] Illness illness, [Bind(Include = "MID,MedicalAidName")] MedicalAid medicalAid, string ChipID, string RelName, string RelSurname, string RelPersNo, string txtRelHomeNo, string txtRelWorkNo)
        {
            //creating patients
            if (Name == null) return View();
            Patient p = new Patient();
            p.FirstName = Name;
            p.Surname = Surname;
            p.EmailAddress = Email;
            p.Age = Age;
            p.ContactDetails = Contact;
            p.ChipID = ChipID;

            PatientRelative rel = new PatientRelative();
            rel.ContactDetailsH = txtRelHomeNo;
            rel.ContactDetailsP = RelPersNo;
            rel.ContactDetailsW = txtRelWorkNo;
            rel.FirstName = RelName;
            rel.Surname = RelSurname;
            db.PatientRelatives.Add(rel);
            db.SaveChanges();

            p.RID = db.PatientRelatives.Where(rr => rr.FirstName == RelName && rr.Surname == RelSurname && rr.ContactDetailsP == RelPersNo).FirstOrDefault().RID;



            SysUser user = new SysUser();
            user.UTID = 1;
            user.Upassword = computeSha256(password);
            user.EmailAddress = Email;
            db.SysUsers.Add(user);
            db.SaveChanges();

            db.Streets.Add(street);
            db.Surbubs.Add(surbub);
            db.SaveChanges();

            Street str = db.Streets.Where(ss => ss.StreetName == street.StreetName).FirstOrDefault();
            str.SurbubID = db.Surbubs.Where(ss => ss.SurbubName == surbub.SurbubName).FirstOrDefault().SurbubID;

            UAddress a = new UAddress();
            a.HouseNO = HouseNo;
            a.StreetID = str.StreetID;
            db.UAddresses.Add(a);
            db.SaveChanges();

            p.AID = db.UAddresses.Where(aa => aa.StreetID == str.StreetID).FirstOrDefault().AID;
            //db.Illnesses.Add(illness);
            //db.MedicalAids.Add(medicalAid);
           

            p.IID = db.Illnesses.Where(zz => zz.IllnessName == illness.IllnessName).FirstOrDefault().IID;
            p.MID = db.MedicalAids.Where(zz => zz.MedicalAidName == medicalAid.MedicalAidName).FirstOrDefault().MID;


            SysUser refU = db.SysUsers.Where(zz => zz.EmailAddress == Email && zz.Upassword == computeSha256(password)).FirstOrDefault();
            p.userID = refU.userID;



            db.Patients.Add(p);
            return View("PatientDetails");
        }

        string computeSha256(string s)
        {
            using (SHA256 hash = SHA256.Create())
            {
                byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(s));

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < sb.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
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