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

            // Định dạng DateTimePickers
            //label1.Text = "Chọn từ Ngày - Ngày";
            datePickerStart.Format = DateTimePickerFormat.Custom;
            datePickerStart.CustomFormat = "dd/MM/yyyy";

            datePickerEnd.Format = DateTimePickerFormat.Custom;
            datePickerEnd.CustomFormat = "dd/MM/yyyy";

            // Đặt các tùy chọn cho ComboBox
            cbThoiGian.Items.AddRange(new string[] { "Theo Ngày", "Theo Tháng", "Theo Năm" });
            cbThoiGian.SelectedIndex = 0; // Mặc định là "Theo Ngày"

            // Định dạng DateTimePicker
            dateTimePickerMonth.Format = DateTimePickerFormat.Custom;
            dateTimePickerMonth.CustomFormat = "MM/yyyy";
            //label1.Text = "Chọn Tháng/Năm";

            dateTimePickerYear.Format = DateTimePickerFormat.Custom;
            dateTimePickerYear.CustomFormat = "yyyy";
            dateTimePickerYear.ShowUpDown = true; // Hiển thị dạng cuộn chọn năm
            dateTimePickerYear.Visible = false; // Ẩn mặc định, chỉ hiện khi chọn "Theo Năm"
            //label1.Text = "Chọn Năm";

            // Cấu hình biểu đồ
            ConfigureChart();
            CustomizeChartFont();
        }
        private void CustomizeChartFont()
        {
            chartDoanhThu.Titles[0].Font = new Font("Cambria", 8.25f, FontStyle.Bold);

            chartDoanhThu.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Cambria", 8.25f, FontStyle.Bold);

            chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Cambria", 8.25f, FontStyle.Bold);

            chartDoanhThu.ChartAreas[0].AxisX.TitleFont = new Font("Cambria", 8.25f, FontStyle.Bold);

            chartDoanhThu.ChartAreas[0].AxisY.TitleFont = new Font("Cambria", 8.25f, FontStyle.Bold);

            chartDoanhThu.Legends[0].Font = new Font("Cambria", 8.25f, FontStyle.Bold);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                string loaiThongKe = cbThoiGian.SelectedItem.ToString();
                decimal tongDoanhThu = 0;

                if (loaiThongKe == "Theo Ngày")
                {
                    DateTime ngayBatDau = datePickerStart.Value.Date;
                    DateTime ngayKetThuc = datePickerEnd.Value.Date;
                    //label1.Text = "Chọn từ Ngày - Ngày";
                    if (ngayBatDau > ngayKetThuc)
                    {
                        MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;  // Dừng việc thực hiện nếu ngày không hợp lệ
                    }
                    // Lấy dữ liệu và hiển thị
                    LoadLichSuThueTheoNgay(ngayBatDau, ngayKetThuc);
                    tongDoanhThu = ctrlDoanhThu.GetTongDoanhThuTheoNgay(ngayBatDau, ngayKetThuc);
                }
                
                else if (loaiThongKe == "Theo Tháng")
                {
                    int month = dateTimePickerMonth.Value.Month;
                    int year = dateTimePickerMonth.Value.Year;

                    LoadLichSuThue(month, year);
                    tongDoanhThu = ctrlDoanhThu.GetTongDoanhThuTheoThang(month, year);
                    //label1.Text = "Chọn Tháng/Năm";
                }
                else if (loaiThongKe == "Theo Năm")
                {
                    int year = dateTimePickerYear.Value.Year;

                    var lichSuThueList = ctrlDoanhThu.GetLichSuThueTheoNam(year);
                    LoadLichSuThueTheoNam(lichSuThueList);

                    tongDoanhThu = ctrlDoanhThu.GetTongDoanhThuTheoNam(year);
                    //label1.Text = "Chọn Năm";
                }

                // Hiển thị tổng doanh thu
                txtTongDoanhThu.Text = tongDoanhThu.ToString("N0");

                // Cập nhật biểu đồ
                UpdateChart(tongDoanhThu);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thống kê doanh thu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLichSuThueTheoNam(List<LichSuThue> lichSuThueList)
        {
            try
            {
                dtGridViewDoanhThu.DataSource = lichSuThueList.Select(ls => new
                {
                    ls.MaKhachHang,
                    ls.BienSoXe,
                    ls.SoNgayMuon,
                    ls.DonGia,
                    ls.TongTien,
                    NgayThue = ls.NgayThue.ToString("dd/MM/yyyy")
                }).ToList();

                txtTongDoanhThu.Text = lichSuThueList.Sum(ls => ls.TongTien).ToString("N0");
                label4.Text = $"DANH SÁCH LỊCH SỬ PHIẾU THUÊ | NĂM {dateTimePickerYear.Value.Year}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLichSuThueTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            var lichSuThueList = ctrlDoanhThu.GetLichSuThueTheoNgay(ngayBatDau, ngayKetThuc);

            dtGridViewDoanhThu.DataSource = lichSuThueList.Select(ls => new
            {
                ls.MaKhachHang,
                ls.BienSoXe,
                ls.SoNgayMuon,
                ls.DonGia,
                ls.TongTien,
                NgayThue = ls.NgayThue.ToString("dd/MM/yyyy")
            }).ToList();

            decimal tongDoanhThu = lichSuThueList.Sum(ls => ls.TongTien);
            txtTongDoanhThu.Text = tongDoanhThu.ToString("N0");

            label4.Text = $"DANH SÁCH LỊCH SỬ PHIẾU THUÊ | TỪ {ngayBatDau:dd/MM/yyyy} ĐẾN {ngayKetThuc:dd/MM/yyyy}";
        }


        private void LoadLichSuThue(int month, int year)
        {
            try
            {
                // Lấy dữ liệu lịch sử thuê
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

                dtGridViewDoanhThu.Columns["MaKhachHang"].Width = 100; 
                dtGridViewDoanhThu.Columns["BienSoXe"].Width = 100; 
                dtGridViewDoanhThu.Columns["SoNgayMuon"].Width = 105;
                dtGridViewDoanhThu.Columns["DonGia"].Width = 150; 
                dtGridViewDoanhThu.Columns["TongTien"].Width = 150; 
                dtGridViewDoanhThu.Columns["NgayThue"].Width = 100;

                // Cập nhật tổng doanh thu
                decimal tongDoanhThu = ctrlDoanhThu.GetTongDoanhThuTheoThang(month, year);
                txtTongDoanhThu.Text = tongDoanhThu.ToString("N0"); // "N0" Đổi số thành chuỗi 
                label4.Text = "DANH SÁCH LỊCH SỬ PHIẾU THUÊ | THEO THÁNG " + month;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                int month = dateTimePickerMonth.Value.Month;
                int year = dateTimePickerMonth.Value.Year;

                var ketQuaTimKiem = ctrlDoanhThu.TimKiemDoanhThu(keyword, month, year);

                dtGridViewDoanhThu.DataSource = ketQuaTimKiem.Select(ls => new
                {
                    ls.MaKhachHang,
                    ls.BienSoXe,
                    ls.SoNgayMuon,
                    ls.DonGia,
                    ls.TongTien,
                    NgayThue = ls.NgayThue.ToString("dd/MM/yyyy")
                }).ToList();

                decimal tongDoanhThu = ketQuaTimKiem.Sum(ls => ls.TongTien);
                txtTongDoanhThu.Text = tongDoanhThu.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureChart()
        {
            chartDoanhThu.ChartAreas.Clear();
            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();

            var chartArea = new ChartArea("DoanhThuArea")
            {
                AxisX = { Title = "Tháng/Năm" },
                AxisY = { Title = "Tổng Doanh Thu (VND)" }
            };

            chartDoanhThu.ChartAreas.Add(chartArea);

            chartDoanhThu.Titles.Add("Biểu Đồ Tổng Doanh Thu");
        }

        private void UpdateChart(decimal tongDoanhThu)
        {
            chartDoanhThu.Series.Clear();
            var series = new Series("Tổng Doanh Thu")
            {
                ChartType = SeriesChartType.Column,
                BorderWidth = 2,
                Color = Color.FromArgb(56, 56, 56)
            };

            string loaiThongKe = cbThoiGian.SelectedItem.ToString();

            if (loaiThongKe == "Theo Tháng")
            {
                // Cập nhật biểu đồ theo tháng
                series.Points.AddXY($"{dateTimePickerMonth.Value.Month}/{dateTimePickerMonth.Value.Year}", tongDoanhThu);
            }
            else if (loaiThongKe == "Theo Năm")
            {
                // Cập nhật biểu đồ theo năm
                series.Points.AddXY($"{dateTimePickerYear.Value.Year}", tongDoanhThu);
            }
            else if (loaiThongKe == "Theo Ngày")
            {
                // Cập nhật biểu đồ theo ngày
                DateTime ngayBatDau = datePickerStart.Value.Date;
                DateTime ngayKetThuc = datePickerEnd.Value.Date;
                var doanhThuTheoNgay = ctrlDoanhThu.GetLichSuThueTheoNgay(ngayBatDau, ngayKetThuc);

                // Thêm dữ liệu từng ngày vào biểu đồ
                foreach (var item in doanhThuTheoNgay)
                {
                    series.Points.AddXY(item.NgayThue.ToString("dd/MM/yyyy"), item.TongTien);
                }
            }

            chartDoanhThu.Series.Add(series);
            chartDoanhThu.ChartAreas[0].RecalculateAxesScale();
        }

        private void dateTimePickerMonth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loaiThongKe = cbThoiGian.SelectedItem.ToString();

            // Ẩn tất cả các DateTimePicker trước khi hiển thị cái cần thiết
            datePickerStart.Visible = false;
            datePickerEnd.Visible = false;
            dateTimePickerMonth.Visible = false;
            dateTimePickerYear.Visible = false;

            // Kiểm tra loại thống kê và hiển thị các DateTimePicker tương ứng
            if (loaiThongKe == "Theo Ngày")
            {
                datePickerStart.Visible = true;
                datePickerEnd.Visible = true;
                label1.Text = "Chọn Từ Ngày - Ngày";
            }
            else if (loaiThongKe == "Theo Tháng")
            {
                dateTimePickerMonth.Visible = true;
                label1.Text = "Chọn Tháng/Năm";
            }
            else if (loaiThongKe == "Theo Năm")
            {
                dateTimePickerYear.Visible = true;
                label1.Text = "Chọn Năm";
            }
        }
    }
}
