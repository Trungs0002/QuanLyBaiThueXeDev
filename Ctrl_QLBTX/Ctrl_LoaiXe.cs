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

        public List<LoaiXe> findByName(string name)
        {
            return CUtils.db.LoaiXes.Where(t => t.TenLoai.Contains(name)).ToList();
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
