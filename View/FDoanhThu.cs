using QuanLyBaiThueXeDev.Ctrl_QLBTX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBaiThueXeDev.View
{
    public partial class FDoanhThu : Form
    {
        private Ctrl_PhieuThue ctrlPhieuThue = new Ctrl_PhieuThue();
        private Ctrl_LoaiXe ctrlXe = new Ctrl_LoaiXe();
        public FDoanhThu()
        {
            InitializeComponent();
        }

        private void FDoanhThu_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void LoadDoanhThuThang(int thang, int nam)
        {
            var phieuThueTrongThang = ctrlPhieuThue.findAll()
                .Where(pt => pt.NgayThue.HasValue &&
                             pt.NgayThue.Value.Month == thang &&
                             pt.NgayThue.Value.Year == nam)
                .ToList();

            var doanhThu = phieuThueTrongThang.Sum(pt => pt.SoNgayMuon * pt.DonGia);

            // Hiển thị trong DataGridView
            dtGridViewDoanhThu.DataSource = phieuThueTrongThang.Select(pt => new
            {
                pt.SoPhieuThue,
                pt.NgayThue,
                pt.MaKhachHang,
                pt.BienSoXe,
                pt.SoNgayMuon,
                pt.DonGia,
                TongTien = pt.SoNgayMuon * pt.DonGia
            }).ToList();

            // Hiển thị tổng doanh thu
            lblTongDoanhThu.Text = $"Tổng Doanh Thu: {doanhThu:C}";
        }

        

    }
}
