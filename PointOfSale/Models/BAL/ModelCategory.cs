using System;


namespace PointOfSale.Models.BAL
{
    
    public  class ModelCategory
    {
        public long ID { get; set; }
        public string Category { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
