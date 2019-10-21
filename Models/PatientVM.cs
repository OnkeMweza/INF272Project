using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Deliverable2.Models
{
    public class PatientVM
    {
        public int? id;
        public List<Patient> patients;
        public UserVM userVM;
    }
}