//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vote
    {
        public Vote()
        {
            this.Holder_Vote = new HashSet<Holder_Vote>();
        }
    
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> Order { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreateUser { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UpdateUser { get; set; }
    
        public virtual ICollection<Holder_Vote> Holder_Vote { get; set; }
    }
}
