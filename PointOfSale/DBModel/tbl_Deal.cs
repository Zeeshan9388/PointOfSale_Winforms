//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PointOfSale.DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Deal
    {
        public long ID { get; set; }
        public string DealType { get; set; }
        public string DealName { get; set; }
        public string DealSize { get; set; }
        public Nullable<decimal> DealPrice { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}