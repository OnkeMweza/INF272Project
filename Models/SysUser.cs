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
    
    public partial class SysUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SysUser()
        {
            this.Patients = new HashSet<Patient>();
            this.SysAdmins = new HashSet<SysAdmin>();
        }
    
        public int userID { get; set; }
        public string EmailAddress { get; set; }
        public string Upassword { get; set; }
        public Nullable<int> UTID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient> Patients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysAdmin> SysAdmins { get; set; }
        public virtual UserType UserType { get; set; }
        public string GUID { get; internal set; }
        public DateTime GUIDExpiry { get; internal set; }
    }
}