using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
