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
    
    public partial class Salary
    {
        public int SalaryID { get; set; }
        public int EmployeeID { get; set; }
        public int Seniority { get; set; }
        public decimal Salary1 { get; set; }
        public Nullable<decimal> Allowance { get; set; }
        public string AllowanceDetail { get; set; }
        public string PaidHistory { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
