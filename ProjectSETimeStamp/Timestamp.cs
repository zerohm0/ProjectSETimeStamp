//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectSETimeStamp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Timestamp
    {
        public int TimestampID { get; set; }
        public int EmpID { get; set; }
        public Nullable<System.TimeSpan> TimestampIn { get; set; }
        public Nullable<System.TimeSpan> TimestampOut { get; set; }
        public Nullable<System.DateTime> TimestampFDay { get; set; }
        public Nullable<System.DateTime> TimestampLDay { get; set; }
        public Nullable<System.DateTime> TimestampKDay { get; set; }
        public string TimestampDes { get; set; }
        public int TypeID { get; set; }
        public int StatusID { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual TimestampStatus TimestampStatus { get; set; }
        public virtual TimestampType TimestampType { get; set; }
    }
}
