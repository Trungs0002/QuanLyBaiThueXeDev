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
            CUtils.db.SaveChanges();
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
    }
}
