using QuanLyBaiThueXeDev.View;
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
        public Dictionary<int, decimal> GetDoanhThuTheoThang(int thang, int nam, int maNhanVien)
        {
            var doanhThu = CUtils.db.PhieuThues
                .Where(p => p.NhanVien.MaNhanVien == maNhanVien &&
                            p.NgayThue.HasValue &&  // Kiểm tra NgayThue có giá trị không
                            p.NgayThue.Value.Month == thang &&
                            p.NgayThue.Value.Year == nam)
                .GroupBy(p => p.NgayThue.Value.Month)  // Sử dụng .Value để lấy tháng của DateTime
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(p => p.DonGia.HasValue ? (decimal)p.DonGia.Value : 0m)  // Chuyển đổi giá trị của DonGia sang decimal
                );

            return doanhThu;
        }









    }
}
