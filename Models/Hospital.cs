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
    
    public partial class Hospital
    {
        public int HID { get; set; }
        public string HospitalName { get; set; }
        public Nullable<int> AID { get; set; }
    
        public virtual UAddress UAddress { get; set; }
    }
}
