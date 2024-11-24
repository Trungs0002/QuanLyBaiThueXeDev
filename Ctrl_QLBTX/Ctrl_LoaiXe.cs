using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBaiThueXeDev.Ctrl_QLBTX
{
    internal class Ctrl_LoaiXe
    {
        public List<LoaiXe> findAll()
        {
            return CUtils.db.LoaiXes.ToList();
        }

        public List<LoaiXe> findByName(string searchTerm)
        {
            searchTerm = searchTerm.ToLower();

            return CUtils.db.LoaiXes
                .Where(t => t.MaLoaiXe.ToString().Contains(searchTerm) || 
                            t.TenLoai.ToLower().Contains(searchTerm) || 
                            t.HangSanXuat.ToLower().Contains(searchTerm) || 
                            t.NamSanXuat.ToString().Contains(searchTerm) || 
                            t.MoTa.ToLower().Contains(searchTerm)) 
                .ToList();
        }

        public void upDate(LoaiXe loaiXe)
        {
            CUtils.db.SaveChanges();
        }

        public void add(LoaiXe loaiXe)
        {
            CUtils.db.LoaiXes.Add(loaiXe);
            CUtils.db.SaveChanges();
        }

        public void remove(LoaiXe loaiXe)
        {
            CUtils.db.LoaiXes.Remove(loaiXe);
            CUtils.db.SaveChanges();
        }
    }
}
