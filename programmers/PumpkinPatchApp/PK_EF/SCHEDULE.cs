//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PK_EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class SCHEDULE
    {
        public int ScheduleID { get; set; }
        public int EmployeeID { get; set; }
        public int EquipmentID { get; set; }
        public System.DateTime Time { get; set; }
        public string IsApproved { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
    
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual EQUIPMENT EQUIPMENT { get; set; }
    }
}
