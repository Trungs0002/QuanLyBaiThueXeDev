using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBaiThueXeDev.Ctrl_QLBTX
{
    internal class Ctrl_PhieuNopPhat
    {
        public List<PhieuNopPhat> findAll()
        {
            return CUtils.db.PhieuNopPhats.ToList();
        }

        public void upDate(PhieuNopPhat phieuNopPhat)
        {
            CUtils.db.SaveChanges();
        }

        public void add(PhieuNopPhat phieuNopPhat)
        {
            CUtils.db.PhieuNopPhats.Add(phieuNopPhat);
            CUtils.db.SaveChanges();
        }

        public void remove(PhieuNopPhat phieuNopPhat)
        {
            CUtils.db.PhieuNopPhats.Remove(phieuNopPhat);
            CUtils.db.SaveChanges();
        }
        public List<PhieuNopPhat> findByCriteria(string searchTerm)
        {
            searchTerm = searchTerm.ToLower(); // Chuyển đổi tìm kiếm thành chữ thường

            return CUtils.db.PhieuNopPhats
                .Where(pnp => pnp.SoPhieuPhat.ToString().Contains(searchTerm) || // Tìm theo số phiếu phạt
                              pnp.HoTenKhachHang.ToLower().Contains(searchTerm) || // Tìm theo họ tên khách hàng
                              pnp.SoChungMinh.ToLower().Contains(searchTerm) || // Tìm theo số chứng minh
                              pnp.LyDoNopPhat.ToLower().Contains(searchTerm) || // Tìm theo lý do nộp phạt
                              pnp.SoTienNopPhat.ToString().Contains(searchTerm) || // Tìm theo số tiền nộp phạt
                              pnp.TongSoTien.ToString().Contains(searchTerm)) // Tìm theo tổng số tiền
                .ToList();
        }
    }
}
