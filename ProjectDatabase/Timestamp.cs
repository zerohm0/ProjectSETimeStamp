//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectDatabase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Timestamp
    {
        public int TimestampID { get; set; }
        public Nullable<int> EmpID { get; set; }
        public string TimestampFDay { get; set; }
        public string TimestampLDay { get; set; }
        public string TimestampKDay { get; set; }
        public string TimestampOffcall { get; set; }
        public string TimestampDes { get; set; }
        public Nullable<int> TypeID { get; set; }
        public Nullable<int> StatusID { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual TimestampType TimestampType { get; set; }
        public virtual TimestapStatus TimestapStatus { get; set; }
    }
}
