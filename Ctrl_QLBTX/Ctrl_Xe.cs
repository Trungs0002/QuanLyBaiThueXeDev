using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBaiThueXeDev.Ctrl_QLBTX
{
    internal class Ctrl_Xe
    {
        public List<Xe> findAll()
        {
            return CUtils.db.Xes.ToList();
        }

        public List<Xe> findByCriteria(string searchTerm)
        {
            searchTerm = searchTerm.ToLower(); // Chuyển đổi tìm kiếm thành chữ thường

            return CUtils.db.Xes
                .Where(x => x.BienSoXe.ToLower().Contains(searchTerm) || // Tìm theo biển số xe
                            x.MaLoaiXe.ToString().Contains(searchTerm) || // Tìm theo mã loại xe
                            x.MauSon.ToLower().Contains(searchTerm) || // Tìm theo màu sơn
                            x.TinhTrang.ToLower().Contains(searchTerm) || // Tìm theo tình trạng
                            x.MoTa.ToLower().Contains(searchTerm))  // Tìm theo mô tả
                .ToList();
        }
        public List<Xe> findByLoaiXe(int maLoaiXe)
        {
            return CUtils.db.Xes.Where(x => x.MaLoaiXe == maLoaiXe).ToList();
        }

        public void upDate(Xe xe)
        {
            CUtils.db.SaveChanges();
        }

        public void add(Xe xe)
        {
            CUtils.db.Xes.Add(xe);
            CUtils.db.SaveChanges();
        }

        public void remove(Xe xe)
        {
            CUtils.db.Xes.Remove(xe);
            CUtils.db.SaveChanges();
        }
    }
}
