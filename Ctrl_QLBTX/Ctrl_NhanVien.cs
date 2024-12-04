using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBaiThueXeDev.Ctrl_QLBTX
{
    internal class Ctrl_NhanVien
    {
        public List<NhanVien> findAll()
        {
            return CUtils.db.NhanViens.ToList();
        }

        


        public List<NhanVien> findByCriteria(string searchTerm)
        {
            searchTerm = searchTerm.ToLower(); // Chuyển đổi tìm kiếm thành chữ thường

            return CUtils.db.NhanViens
                .Where(nv => nv.MaNhanVien.ToString().Contains(searchTerm) || // Tìm theo mã nhân viên
                             nv.TenNhanVien.ToLower().Contains(searchTerm) || // Tìm theo tên nhân viên
                             nv.DienThoai.ToLower().Contains(searchTerm) || // Tìm theo điện thoại
                             nv.MoTa.ToLower().Contains(searchTerm)) // Tìm theo mô tả
                .ToList();
        }

        public void add(NhanVien nhanVien)
        {
            CUtils.db.NhanViens.Add(nhanVien);
            CUtils.db.SaveChanges();
        }

        public void upDate(NhanVien nhanVien)
        {
            CUtils.db.SaveChanges();
        }

        public void remove(NhanVien nhanVien)
        {
            CUtils.db.NhanViens.Remove(nhanVien);
            CUtils.db.SaveChanges();
        }

        //
        public Dictionary<int, decimal> GetDoanhThuTheoThang(int thang, int nam)
        {
            var doanhThu = CUtils.db.PhieuThues
                .Where(p => p.NgayThue.HasValue && p.NgayThue.Value.Month == thang && p.NgayThue.Value.Year == nam)
                .GroupBy(p => p.MaNhanVien) // Nhóm theo mã nhân viên
                .AsEnumerable() // Chuyển đổi sang LINQ to Objects
                .Select(group => new
                {
                    MaNhanVien = group.Key,
                    DoanhThu = group.Sum(p => (decimal)(p.DonGia * p.SoLuong)) // Chuyển đổi ở đây sau khi chuyển sang LINQ to Objects
                })
                .ToDictionary(x => x.MaNhanVien.Value, x => x.DoanhThu); // Chuyển MaNhanVien thành int nếu cần thiết

            return doanhThu;
        }



    }
}
