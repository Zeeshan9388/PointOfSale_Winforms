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
    
    public partial class Vu_Sales
    {
        public string Customer { get; set; }
        public string Category { get; set; }
        public string Items { get; set; }
        public string Size { get; set; }
        public Nullable<decimal> GrossTotal { get; set; }
        public Nullable<decimal> GST { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> PayAmount { get; set; }
        public Nullable<decimal> ReturnAmount { get; set; }
    }
}