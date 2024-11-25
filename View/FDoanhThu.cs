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
        public FDoanhThu()
        {
            InitializeComponent();
        }
        private QuanLyBaiThueXeEntities context = new QuanLyBaiThueXeEntities();

        private void FDoanhThu_Load(object sender, EventArgs e)
        {
            // Cài đặt định dạng ngày tháng cho DateTimePicker
            dateTimePickerMonth.Format = DateTimePickerFormat.Custom;
            dateTimePickerMonth.CustomFormat = "dd/MM/yyyy"; // Định dạng ngày/tháng/năm
            // Tải dữ liệu tổng doanh thu hàng tháng khi load form
            LoadTongDoanhThu(DateTime.Now.Month, DateTime.Now.Year); // Mặc định là tháng hiện tại

        }
        private void LoadTongDoanhThu(int month, int year)
        {
            try
            {
                // Truy vấn doanh thu theo tháng và năm
                var doanhThuThang = context.LichSuThues
                    .Where(ls => ls.NgayThue.Month == month && ls.NgayThue.Year == year)
                    .GroupBy(ls => new
                    {
                        Thang = ls.NgayThue.Month,
                        Nam = ls.NgayThue.Year,
                        ls.MaKhachHang,
                        TenKhachHang = ls.KhachHang.HoTen // Giả sử có quan hệ giữa LichSuThues và KhachHang
                    })
                    .Select(group => new
                    {
                        group.Key.Thang,
                        group.Key.Nam,
                        group.Key.MaKhachHang,
                        group.Key.TenKhachHang,
                        TongTien = group.Sum(ls => ls.TongTien) // Tính tổng tiền trong tháng
                    })
                    .OrderBy(dt => dt.Nam).ThenBy(dt => dt.Thang) // Sắp xếp theo năm, tháng
                    .ToList();

                // Hiển thị trên DataGridView
                dtGridViewDoanhThu.DataSource = doanhThuThang;

                // Tùy chỉnh tên cột
                dtGridViewDoanhThu.Columns["Thang"].HeaderText = "Tháng";
                dtGridViewDoanhThu.Columns["Nam"].HeaderText = "Năm";
                dtGridViewDoanhThu.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
                dtGridViewDoanhThu.Columns["TenKhachHang"].HeaderText = "Tên Khách Hàng";
                dtGridViewDoanhThu.Columns["TongTien"].HeaderText = "Tổng Tiền (VND)";

                // Định dạng cột tổng tiền
                dtGridViewDoanhThu.Columns["TongTien"].DefaultCellStyle.Format = "N0"; // Định dạng số nguyên

                // Tính tổng doanh thu của tháng và hiển thị trong TextBox
                decimal tongDoanhThu = doanhThuThang.Sum(dt => dt.TongTien);
                txtTongDoanhThu.Text = tongDoanhThu.ToString("N0"); // Hiển thị tổng doanh thu cho tháng và năm đã chọn
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu doanh thu hàng tháng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            int selectedMonth = dateTimePickerMonth.Value.Month;
            int selectedYear = dateTimePickerMonth.Value.Year;

            // Tải lại dữ liệu doanh thu cho tháng và năm đã chọn
            LoadTongDoanhThu(selectedMonth, selectedYear);
        }
    }
}
