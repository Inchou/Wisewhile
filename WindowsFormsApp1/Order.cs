//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int OrderID { get; set; }
        public int MemberID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public Nullable<System.DateTime> ArrivedDate { get; set; }
        public int StatusID { get; set; }
        public int ShippingID { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Member Member { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual OrderStatu OrderStatu { get; set; }
        public virtual Shipping Shipping { get; set; }
    }
}