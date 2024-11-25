using QuanLyBaiThueXeDev.Ctrl_QLBTX;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


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

            // Cấu hình cơ bản cho Chart
            ConfigureChart();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Lấy tháng và năm từ DateTimePicker
            int month = dateTimePickerMonth.Value.Month;
            int year = dateTimePickerMonth.Value.Year;

            // Hiển thị lịch sử thuê và tổng doanh thu
            LoadLichSuThue(month, year);


            // Lấy dữ liệu doanh thu từ controller
            var doanhThuData = ctrlDoanhThu.GetDoanhThuTheoThang(month, year);
            // Hiển thị dữ liệu lên Chart
            UpdateChart(doanhThuData);

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
                //MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}\n{ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

        }

        private void dateTimePickerMonth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void timkiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy từ khóa từ TextBox tìm kiếm
                string keyword = txtTimKiem.Text.Trim();

                // Lấy tháng và năm từ DateTimePicker
                int month = dateTimePickerMonth.Value.Month;
                int year = dateTimePickerMonth.Value.Year;

                // Gọi phương thức tìm kiếm từ Controller
                var ketQuaTimKiem = ctrlDoanhThu.TimKiemDoanhThu(keyword, month, year);

                // Hiển thị kết quả tìm kiếm lên DataGridView
                dtGridViewDoanhThu.DataSource = ketQuaTimKiem.Select(ls => new
                {
                    MaKhachHang = ls.MaKhachHang,
                    BienSoXe = ls.BienSoXe,
                    SoNgayMuon = ls.SoNgayMuon,
                    DonGia = ls.DonGia,
                    TongTien = ls.TongTien,
                    NgayThue = ls.NgayThue.ToString("dd/MM/yyyy")
                }).ToList();

                // Cập nhật tổng tiền sau tìm kiếm
                decimal tongDoanhThu = ketQuaTimKiem.Sum(ls => ls.TongTien);
                txtTongDoanhThu.Text = tongDoanhThu.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtGridViewDoanhThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Gọi phương thức hiển thị dữ liệu lên TextBox
            HienThiChiTietDoanhThu();
        }

        private void HienThiChiTietDoanhThu()
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (dtGridViewDoanhThu.CurrentRow != null)
                {
                    // Lấy dòng được chọn
                    var selectedRow = dtGridViewDoanhThu.CurrentRow;

                    // Gán giá trị từ các ô của dòng được chọn vào TextBox
                    txtMaKH.Text = selectedRow.Cells["MaKhachHang"].Value?.ToString();
                    txtBienSoXe.Text = selectedRow.Cells["BienSoXe"].Value?.ToString();
                    txtSoNgayMuon.Text = selectedRow.Cells["SoNgayMuon"].Value?.ToString();
                    txtDonGia.Text = selectedRow.Cells["DonGia"].Value?.ToString();
                    txtTongTien.Text = selectedRow.Cells["TongTien"].Value?.ToString();
                    txtNgayThue.Text = selectedRow.Cells["NgayThue"].Value?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị chi tiết doanh thu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }



        private void panelChart_Paint(object sender, PaintEventArgs e)
        {

        }

        //
        private void ConfigureChart()
        {
            // Cấu hình chung cho biểu đồ
            chartDoanhThu.ChartAreas.Clear();
            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();

            // Tạo vùng vẽ
            ChartArea chartArea = new ChartArea("DoanhThuArea");
            chartArea.AxisX.Title = "Ngày";
            chartArea.AxisY.Title = "Doanh Thu (VND)";
            chartDoanhThu.ChartAreas.Add(chartArea);

            // Thêm Series
            Series series = new Series("DoanhThu")
            {
                ChartType = SeriesChartType.Column,
                BorderWidth = 2,
                IsValueShownAsLabel = true
            };
            chartDoanhThu.Series.Add(series);

            // Tiêu đề
            chartDoanhThu.Titles.Add("Biểu Đồ Doanh Thu Theo Ngày");
        }

        private void UpdateChart(List<dynamic> doanhThuData)
        {
            // Xóa dữ liệu cũ
            chartDoanhThu.Series["DoanhThu"].Points.Clear();

            // Thêm dữ liệu mới
            foreach (var data in doanhThuData)
            {
                chartDoanhThu.Series["DoanhThu"].Points.AddXY($"Ngày {data.Ngay}", data.TongTien);
            }
        }

    }
}
