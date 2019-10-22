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
        //public string Password { get; private set; }

        //public string Email { get; private set; }
        // GET: Project
        public ActionResult Home()
        {
            return View();
        }
        //[HttpPost]

        //[ValidateAntiForgeryToken]
        public ActionResult WelcomePage(/*string Name, string Surname, string Email, string password, int Age, string Contact, int HouseNo, string streetName, string surbubName, string illnessN, string MedAid, string ChipID, string RelName, string RelSurname, string RelPersNo, string txtRelHomeNo, string txtRelWorkNo*/)
        {
            //creating patients

            //if (Name == null) return View();

            //Patient p = new Patient();

            //p.FirstName = Name;

            //p.Surname = Surname;

            //p.EmailAddress = Email;

            //p.Age = Age;

            //p.ContactDetails = Contact;

            //p.ChipID = ChipID;



            //PatientRelative rel = new PatientRelative();

            //rel.ContactDetailsH = txtRelHomeNo;

            //rel.ContactDetailsP = RelPersNo;

            //rel.ContactDetailsW = txtRelWorkNo;

            //rel.FirstName = RelName;

            //rel.Surname = RelSurname;

            //db.PatientRelatives.Add(rel);

            //db.SaveChangesAsync();

            //PatientRelative refp = new PatientRelative();

            //refp = db.PatientRelatives.Where(rr => rr.FirstName == RelName && rr.Surname == RelSurname && rr.ContactDetailsP == RelPersNo).FirstOrDefault();

            //p.RID = refp.RID;

            //SysUser user = new SysUser();

            //user.UTID = 1;

            //user.Upassword = computeSha256(password);

            //user.EmailAddress = Email;

            //db.SysUsers.Add(user);

            //db.SaveChanges();

            //Street street = new Street();

            //street.StreetName = streetName;

            //db.Streets.Add(street);

            //Surbub surbub = new Surbub();

            //surbub.SurbubName = surbubName.ToUpper();

            //db.Surbubs.Add(surbub);

            //db.SaveChanges();

            //Street str = db.Streets.Where(ss => ss.StreetName == street.StreetName).FirstOrDefault();

            //Surbub refSur = db.Surbubs.Where(ss => ss.SurbubName == surbub.SurbubName).FirstOrDefault();

            //str.SurbubID = refSur.SurbubID;

            //UAddress a = new UAddress();

            //a.HouseNO = HouseNo;

            //a.StreetID = str.StreetID;

            //db.UAddresses.Add(a);

            //db.SaveChanges();

            //UAddress ua = db.UAddresses.Where(aa => aa.StreetID == str.StreetID).FirstOrDefault();

            //p.AID = ua.AID;

            ////db.Illnesses.Add(illness);

            ////db.MedicalAids.Add(medicalAid);

            //Illness illness = new Illness();

            //illness.IllnessName = illnessN;

            //db.Illnesses.Add(illness);

            //MedicalAid medicalAid = new MedicalAid();

            //medicalAid.MedicalAidName = MedAid;

            //db.MedicalAids.Add(medicalAid);

            //Illness ill = db.Illnesses.Where(zz => zz.IllnessName == illness.IllnessName).FirstOrDefault();

            //p.IID = ill.IID;

            //p.MID = db.MedicalAids.Where(zz => zz.MedicalAidName == medicalAid.MedicalAidName).FirstOrDefault().MID;
            //SysUser refU = db.SysUsers.Where(zz => zz.EmailAddress == Email && zz.Upassword == computeSha256(password)).FirstOrDefault();
            //p.userID = refU.userID;
            //db.Patients.Add(p);
            //return View("PatientDetails");
            return View();
        }

        //string computeSha256(string s)

        //{

        //    using (SHA256 hash = SHA256.Create())

        //    {

        //        byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(s));



        //        StringBuilder sb = new StringBuilder();



        //        for (int i = 0; i < sb.Length; i++)

        //        {

        //            sb.Append(bytes[i].ToString("x2"));

        //        }



        //        return sb.ToString();

        //    }

        //}

        public ActionResult SignUp()
        {
            ViewBag.SurbubID = new SelectList(db.Surbubs, "SurbubID", "SurbubName");
            ViewBag.StreetName = new SelectList(db.Streets, "StreetID", "StreetName");
            ViewBag.IllnessName = new SelectList(db.Illnesses, "IID", "IllnessName");
            ViewBag.MedicalAidName = new SelectList(db.MedicalAids, "MID", "MedicalAidName");
            return View();
        }
        //[HttpPost]
        public ActionResult Login(/*string Email, string Password*/)
        {
            //var hashedPassword = ComputeSha256Hash(Password);

            //Deliverable2.Models.SysUser user = db.SysUsers.Where(zz => zz.EmailAddress == Email

            //                                  && zz.Upassword == hashedPassword).FirstOrDefault();

            //if (user != null)

            //{

            //    UserVM userVME = new UserVM();

            //    userVME.user = user;

            //    userVME.RefreshGUID(db);

            //    TempData["userVM"] = userVME;

            //    return RedirectToAction("WelcomePage", "Project");

            //}



            //return RedirectToAction("Index", "Project");
            return View();
        }

        //string ComputeSha256Hash(string rawData)

        //{

        //    using (SHA256 sha256Hash = SHA256.Create())

        //    {

        //        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));



        //        StringBuilder builder = new StringBuilder();

        //        for (int i = 0; i < bytes.Length; i++)

        //        {

        //            builder.Append(bytes[i].ToString("x2"));

        //        }

        //        return builder.ToString();

        //    }

        //}

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