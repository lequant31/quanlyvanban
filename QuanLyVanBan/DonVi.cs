//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyVanBan
{
    using System;
    using System.Collections.Generic;
    
    public partial class DonVi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonVi()
        {
            this.CanBo = new HashSet<CanBo>();
            this.LanhDaoDonVi = new HashSet<LanhDaoDonVi>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<bool> InOrOut { get; set; }
        public string MaDonVi { get; set; }
        public string TenDonVi { get; set; }
        public string PrintName { get; set; }
        public System.DateTime Createdate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CanBo> CanBo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LanhDaoDonVi> LanhDaoDonVi { get; set; }
    }
}