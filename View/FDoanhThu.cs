using QuanLyBaiThueXeDev.Ctrl_QLBTX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBaiThueXeDev.View
{
    public partial class FDoanhThu : Form
    {
        private Ctrl_DoanhThu ctrlDoanhThu = new Ctrl_DoanhThu();
        private Ctrl_PhieuThue ctrlPhieuThue = new Ctrl_PhieuThue();
        public FDoanhThu()
        {
            InitializeComponent();
        }
        private QuanLyBaiThueXeEntities context = new QuanLyBaiThueXeEntities();

        private void FDoanhThu_Load(object sender, EventArgs e)
        {
            dateTimePickerMonth.Format = DateTimePickerFormat.Custom;
            dateTimePickerMonth.CustomFormat = "MM/yyyy"; // Định dạng ngày/tháng/năm
            // Tải dữ liệu tổng doanh thu hàng tháng khi load form
            LoadDoanhThuThang(DateTime.Now.Month, DateTime.Now.Year); // Mặc định là tháng hiện tại

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
