﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuanLyBaiThueXeEntities : DbContext
    {
        public QuanLyBaiThueXeEntities()
            : base("name=QuanLyBaiThueXeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DoanhThu> DoanhThus { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiXe> LoaiXes { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuNopPhat> PhieuNopPhats { get; set; }
        public virtual DbSet<PhieuThue> PhieuThues { get; set; }
        public virtual DbSet<Xe> Xes { get; set; }
    }
}
