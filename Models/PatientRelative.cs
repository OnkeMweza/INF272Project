//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Deliverable2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PatientRelative
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PatientRelative()
        {
            this.Patients = new HashSet<Patient>();
        }
    
        public int RID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string ContactDetailsP { get; set; }
        public string ContactDetailsH { get; set; }
        public string ContactDetailsW { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient> Patients { get; set; }
    }
}