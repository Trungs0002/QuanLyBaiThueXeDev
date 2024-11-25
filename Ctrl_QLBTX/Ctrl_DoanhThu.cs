using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyBaiThueXeDev.Ctrl_QLBTX
{
    internal class Ctrl_DoanhThu
    {


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

    }
}
