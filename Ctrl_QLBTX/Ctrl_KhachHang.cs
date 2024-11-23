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

        public List<KhachHang> findByName(string name)
        {
            return CUtils.db.KhachHangs.Where(t => t.HoTen.Contains(name)).ToList();
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
    }
}
