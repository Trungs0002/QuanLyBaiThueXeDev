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
    
    public partial class LichSuThue
    {
        public int Id { get; set; }
        public int MaKhachHang { get; set; }
        public string BienSoXe { get; set; }
        public int SoNgayMuon { get; set; }
        public int DonGia { get; set; }
        public int TongTien { get; set; }
        public System.DateTime NgayThue { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
    }
}
