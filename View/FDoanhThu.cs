using QuanLyBaiThueXeDev.Ctrl_QLBTX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyBaiThueXeDev.View
{
    public partial class FDoanhThu : Form
    {
        private Ctrl_DoanhThu ctrlDoanhThu = new Ctrl_DoanhThu();

        public FDoanhThu()
        {
            InitializeComponent();
        }

        private void FDoanhThu_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            // Định dạng DateTimePicker
            dateTimePickerMonth.Format = DateTimePickerFormat.Custom;
            dateTimePickerMonth.CustomFormat = "MM/yyyy"; // Hiển thị tháng/năm
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Lấy tháng và năm từ DateTimePicker
            int month = dateTimePickerMonth.Value.Month;
            int year = dateTimePickerMonth.Value.Year;

            // Hiển thị lịch sử thuê và tổng doanh thu
            LoadLichSuThue(month, year);
        }

        private void LoadLichSuThue(int month, int year)
        {
            try
            {
                // Gọi phương thức lấy lịch sử thuê
                var lichSuThueList = ctrlDoanhThu.GetLichSuThueTheoThang(month, year);

                // Hiển thị lên DataGridView
                dtGridViewDoanhThu.DataSource = lichSuThueList.Select(ls => new
                {
                    ls.MaKhachHang,
                    ls.BienSoXe,
                    ls.SoNgayMuon,
                    ls.DonGia,
                    ls.TongTien,
                    NgayThue = ls.NgayThue.ToString("dd/MM/yyyy")
                }).ToList();

                // Tính tổng doanh thu
                decimal tongDoanhThu = ctrlDoanhThu.GetTongDoanhThuTheoThang(month, year);
                txtTongDoanhThu.Text = tongDoanhThu.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}\n{ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
