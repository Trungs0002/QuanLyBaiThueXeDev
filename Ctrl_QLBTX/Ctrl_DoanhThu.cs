using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyBaiThueXeDev.Ctrl_QLBTX
{
    public class Ctrl_DoanhThu
    {
        private QuanLyBaiThueXeEntities context;

        public Ctrl_DoanhThu()
        {
            // Khởi tạo context
            context = new QuanLyBaiThueXeEntities();
        }

        public List<LichSuThue> GetLichSuThueTheoThang(int month, int year)
        {
            if (context?.LichSuThues == null) return new List<LichSuThue>();
            return context.LichSuThues
                .Where(ls => ls.NgayThue.Month == month && ls.NgayThue.Year == year)
                .ToList();

        }

        public decimal GetTongDoanhThuTheoThang(int month, int year)
        {
            try
            {
                return context.LichSuThues
                    .Where(ls => ls.NgayThue.Month == month && ls.NgayThue.Year == year)
                    .Sum(ls => ls.TongTien);
            }
            catch
            {
                return 0;
            }
        }

        public List<LichSuThue> TimKiemDoanhThu(string keyword, int month, int year)
        {
            // Tìm kiếm doanh thu dựa trên từ khóa, tháng và năm
            return context.LichSuThues
                .Where(ls =>
                    (string.IsNullOrEmpty(keyword) ||
                     ls.KhachHang.HoTen.Contains(keyword) ||
                     ls.BienSoXe.Contains(keyword)) && // Điều kiện tìm kiếm theo từ khóa
                    ls.NgayThue.Month == month &&
                    ls.NgayThue.Year == year // Điều kiện tháng và năm
                )
                .ToList();
        }

        public decimal GetTongDoanhThuTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            try
            {
                return context.LichSuThues
                    .Where(ls => ls.NgayThue >= ngayBatDau && ls.NgayThue <= ngayKetThuc)
                    .Sum(ls => ls.TongTien);
            }
            catch
            {
                return 0;
            }
        }

        public List<LichSuThue> GetLichSuThueTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            return context.LichSuThues
                .Where(ls => ls.NgayThue >= ngayBatDau && ls.NgayThue <= ngayKetThuc)
                .ToList();
        }

        public List<LichSuThue> GetLichSuThueTheoNam(int year)
        {
            return context.LichSuThues
                .Where(ls => ls.NgayThue.Year == year)
                .ToList();
        }

        public decimal GetTongDoanhThuTheoNam(int year)
        {
            try
            {
                return context.LichSuThues
                    .Where(ls => ls.NgayThue.Year == year)
                    .Sum(ls => ls.TongTien);
            }
            catch
            {
                return 0;
            }
        }



    }

}
