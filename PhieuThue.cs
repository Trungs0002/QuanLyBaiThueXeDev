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
    
    public partial class PhieuThue
    {
        public int SoPhieuThue { get; set; }
        public Nullable<System.DateTime> NgayThue { get; set; }
        public Nullable<int> MaKhachHang { get; set; }
        public string SoChungMinh { get; set; }
        public string BienSoXe { get; set; }
        public Nullable<int> MaLoaiXe { get; set; }
        public string HangSanXuat { get; set; }
        public Nullable<int> NamSanXuat { get; set; }
        public string TinhTrang { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<int> SoNgayMuon { get; set; }
        public Nullable<double> DonGia { get; set; }
        public string TrangThai { get; set; }
        public Nullable<int> MaNhanVien { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
        public virtual LoaiXe LoaiXe { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual Xe Xe { get; set; }
    }
}
