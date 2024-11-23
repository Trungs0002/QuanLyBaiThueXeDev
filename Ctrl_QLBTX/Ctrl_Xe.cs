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

        public List<Xe> findByLicensePlate(string licensePlate)
        {
            return CUtils.db.Xes.Where(t => t.BienSoXe.Contains(licensePlate)).ToList();
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
