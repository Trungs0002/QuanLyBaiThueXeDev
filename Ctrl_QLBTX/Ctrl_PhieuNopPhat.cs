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
    }
}
