using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace QuanLyBaiThueXeDev.Ctrl_QLBTX
{
    public class Ctrl_DoanhThu
    {
        private QuanLyBaiThueXeEntities context;

        public Ctrl_DoanhThu()
        {
            // Khởi tạo context hoặc Inject context nếu dùng Unity
            context = new QuanLyBaiThueXeEntities();
        }

        public List<LichSuThue> GetLichSuThueTheoThang(int month, int year)
        {
            return CUtils.db.LichSuThues
                .Where(ls => ls.NgayThue.Month == month && ls.NgayThue.Year == year)
                .ToList();
        }

        public decimal GetTongDoanhThuTheoThang(int month, int year)
        {
            try
            {
                return CUtils.db.LichSuThues
                    .Where(ls => ls.NgayThue.Month == month && ls.NgayThue.Year == year)
                    .Sum(ls => ls.TongTien);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi tính doanh thu", ex);
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

        public List<dynamic> GetDoanhThuTheoThang(int month, int year)
        {
            // Đây chỉ là ví dụ. Bạn cần thay thế bằng logic lấy dữ liệu thật từ cơ sở dữ liệu.
              return new List<dynamic>
            {
            new { Ngay = "01", TongTien = 100000 },
            new { Ngay = "02", TongTien = 150000 },
            new { Ngay = "03", TongTien = 200000 }
            };
        }


    }
}
