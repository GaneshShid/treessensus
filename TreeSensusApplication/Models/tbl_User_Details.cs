//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TreeSensusApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_User_Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_User_Details()
        {
            this.tbl_Tree_Details = new HashSet<tbl_Tree_Details>();
        }
    
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string Email { get; set; }
        public string gender { get; set; }
        public string password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Tree_Details> tbl_Tree_Details { get; set; }
    }
}