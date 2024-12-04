using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBaiThueXeDev.Ctrl_QLBTX
{
    internal class Ctrl_PhieuThue
    {
        public List<PhieuThue> findAll()
        {
            return CUtils.db.PhieuThues.ToList();
        }
        //public List<PhieuThue> findByCriteria(string searchTerm)
        //{
        //    searchTerm = searchTerm.ToLower(); // Chuyển đổi tìm kiếm thành chữ thường

        //    return CUtils.db.PhieuThues
        //        .Where(pt => pt.SoPhieuThue.ToString().Contains(searchTerm) || // Tìm theo số phiếu thuê
        //                     pt.BienSoXe.ToLower().Contains(searchTerm) || // Tìm theo biển số xe
        //                     pt.SoChungMinh.ToLower().Contains(searchTerm) || // Tìm theo số chứng minh
        //                     pt.KhachHang.ToLower().Contains(searchTerm) || // Tìm theo họ tên khách hàng
        //                     pt.DonGia.ToString().Contains(searchTerm) || // Tìm theo tổng tiền
        //                     pt.NgayThue.ToString().Contains(searchTerm)) // Tìm theo ngày thuê
        //        .ToList();
        //}
        public void upDate(PhieuThue phieuThue)
        {
            // Tìm phiếu thuê trong cơ sở dữ liệu dựa vào khóa chính (SoPhieuThue)
            var existingPhieuThue = CUtils.db.PhieuThues.Find(phieuThue.SoPhieuThue);

            if (existingPhieuThue != null) // Nếu tìm thấy phiếu thuê
            {
                // Cập nhật các thuộc tính
                existingPhieuThue.NgayThue = phieuThue.NgayThue;
                existingPhieuThue.MaKhachHang = phieuThue.MaKhachHang;
                existingPhieuThue.SoChungMinh = phieuThue.SoChungMinh;
                existingPhieuThue.BienSoXe = phieuThue.BienSoXe;
                existingPhieuThue.MaLoaiXe = phieuThue.MaLoaiXe;
                existingPhieuThue.HangSanXuat = phieuThue.HangSanXuat;
                existingPhieuThue.NamSanXuat = phieuThue.NamSanXuat;
                existingPhieuThue.TinhTrang = phieuThue.TinhTrang;
                existingPhieuThue.SoLuong = phieuThue.SoLuong;
                existingPhieuThue.SoNgayMuon = phieuThue.SoNgayMuon;
                existingPhieuThue.DonGia = phieuThue.DonGia;

                // Lưu các thay đổi vào cơ sở dữ liệu
                CUtils.db.SaveChanges();
            }
            else
            {
                throw new Exception("Không tìm thấy phiếu thuê với mã số: " + phieuThue.SoPhieuThue);
            }
        }
        public List<PhieuThue> findByCriteria(string searchTerm)
        {
            searchTerm = searchTerm.ToLower(); // Chuyển từ khóa thành chữ thường để không phân biệt hoa thường

            return CUtils.db.PhieuThues
                .Where(pt =>
                    pt.KhachHang.HoTen.ToLower().Contains(searchTerm) ||  // Tìm theo tên khách hàng
                    pt.BienSoXe.ToLower().Contains(searchTerm) ||         // Tìm theo biển số xe
                    pt.KhachHang.SoChungMinh.ToLower().Contains(searchTerm)         // Tìm theo số chứng minh
                ).ToList();
        }


        public void add(PhieuThue phieuThue)
        {
            CUtils.db.PhieuThues.Add(phieuThue);
            CUtils.db.SaveChanges();
        }

        public void remove(PhieuThue phieuThue)
        {
            CUtils.db.PhieuThues.Remove(phieuThue);
            CUtils.db.SaveChanges();
        }
        public void update(PhieuThue phieuThue)
        {

        }
        public void AddLichSuThue(int maKhachHang, string bienSoXe, int soNgayMuon, int donGia)
        {
            var lichSuThue = new LichSuThue
            {
                MaKhachHang = maKhachHang,
                BienSoXe = bienSoXe,
                SoNgayMuon = soNgayMuon,
                DonGia = donGia,
                TongTien = soNgayMuon * donGia, // Tính tổng tiền
                NgayThue = DateTime.Now // Ngày thuê hiện tại
            };

            CUtils.db.LichSuThues.Add(lichSuThue);
            CUtils.db.SaveChanges();
        }
    }
}
