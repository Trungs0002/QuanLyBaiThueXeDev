using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBaiThueXeDev.Ctrl_QLBTX
{
    internal class Ctrl_KhachHang
    {
        public List<KhachHang> findAll()
        {
            return CUtils.db.KhachHangs.ToList();
        }
        public List<KhachHang> findByCriteria(string searchTerm)
        {
            searchTerm = searchTerm.ToLower(); // Chuyển đổi tìm kiếm thành chữ thường

            return CUtils.db.KhachHangs
                .Where(kh => kh.MaKhachHang.ToString().Contains(searchTerm) || // Tìm theo mã khách hàng
                             kh.HoTen.ToLower().Contains(searchTerm) || // Tìm theo họ tên
                             kh.GioiTinh.ToLower().Contains(searchTerm) || // Tìm theo giới tính
                             kh.DienThoai.ToLower().Contains(searchTerm) || // Tìm theo điện thoại
                             kh.DiaChi.ToLower().Contains(searchTerm) || // Tìm theo địa chỉ
                             kh.SoChungMinh.ToLower().Contains(searchTerm)) // Tìm theo số chứng minh
                .ToList();
        }

        public void upDate(KhachHang khachHang)
        {
            CUtils.db.SaveChanges();
        }

        public void add(KhachHang khachHang)
        {
            CUtils.db.KhachHangs.Add(khachHang);
            CUtils.db.SaveChanges();
        }

        public void remove(KhachHang khachHang)
        {
            CUtils.db.KhachHangs.Remove(khachHang);
            CUtils.db.SaveChanges();
        }
        public KhachHang findById(int maKhachHang)
        {
            return CUtils.db.KhachHangs.FirstOrDefault(kh => kh.MaKhachHang == maKhachHang);
        }
    }
}
