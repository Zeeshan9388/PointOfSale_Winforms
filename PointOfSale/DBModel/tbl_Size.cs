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
    
    public partial class tbl_Size
    {
        public long ID { get; set; }
        public long CatID { get; set; }
        public long ItemID { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public decimal Qty { get; set; }
        public Nullable<decimal> PurchaseTotal { get; set; }
        public Nullable<decimal> RetailPrice { get; set; }
        public Nullable<decimal> RetailTotal { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
