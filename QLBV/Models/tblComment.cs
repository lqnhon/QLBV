//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBV.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblComment
    {
        public int iD { get; set; }
        public string cTopic { get; set; }
        public string cContent { get; set; }
        public Nullable<int> iContent { get; set; }
        public Nullable<int> iCreateBy { get; set; }
        public Nullable<System.DateTime> dCreateDate { get; set; }
    }
}