//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyBaiThueXeDev
{
    using System;
    using System.Collections.Generic;
    
    public partial class Xe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Xe()
        {
            this.PhieuThues = new HashSet<PhieuThue>();
        }
    
        public string BienSoXe { get; set; }
        public Nullable<int> MaLoaiXe { get; set; }
        public string MauSon { get; set; }
        public string TinhTrang { get; set; }
        public string MoTa { get; set; }
    
        public virtual LoaiXe LoaiXe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThue> PhieuThues { get; set; }
    }
}
