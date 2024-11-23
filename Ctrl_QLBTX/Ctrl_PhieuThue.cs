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
