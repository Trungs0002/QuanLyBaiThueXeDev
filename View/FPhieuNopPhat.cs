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
    public partial class FPhieuNopPhat : Form
    {
        private Ctrl_PhieuNopPhat ctrlPhieuNopPhat = new Ctrl_PhieuNopPhat();
        private Ctrl_KhachHang ctrlKhachHang = new Ctrl_KhachHang();
        private List<PhieuNopPhat> dsPhieuNopPhat = null;
        private List<KhachHang> dsKhachHang;
        private PhieuNopPhat phieuNopPhat;
        private int index;
        public FPhieuNopPhat()
        {
            InitializeComponent();
        }
        private void LoadKhachHang()
        {
            dsKhachHang = ctrlKhachHang.findAll(); // Lấy danh sách khách hàng
            comboBoxHoTen.DataSource = dsKhachHang; // Gán danh sách khách hàng cho ComboBox
            comboBoxHoTen.DisplayMember = "HoTen"; // Hiển thị tên khách hàng
            comboBoxHoTen.ValueMember = "MaKhachHang"; // Giá trị là mã khách hàng
        }
        private void FPhieuNopPhat_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            dsPhieuNopPhat = ctrlPhieuNopPhat.findAll();
            load_PhieuNopPhat();
            LoadKhachHang();
        }
        private void load_PhieuNopPhat()
        {
            var list = from p in dsPhieuNopPhat
                       select new
                       {
                           p.SoPhieuPhat,
                           p.HoTenKhachHang,
                           p.SoChungMinh,
                           p.LyDoNopPhat,
                           p.SoTienNopPhat,
                           NgayThueXe = p.NgayThueXe.HasValue ? p.NgayThueXe.Value.ToString("dd/MM/yyyy") : "Chưa có", // Định dạng ngày
                           NgayTraXe = p.NgayTraXe.HasValue ? p.NgayTraXe.Value.ToString("dd/MM/yyyy") : "Chưa có"  // Định dạng ngày
                       };
            dtGridViewPhieuPhat.DataSource = list.ToList();

            dtGridViewPhieuPhat.Columns["SoPhieuPhat"].Width = 100;
            dtGridViewPhieuPhat.Columns["HoTenKhachHang"].Width = 165;
            dtGridViewPhieuPhat.Columns["SoChungMinh"].Width = 120;
            dtGridViewPhieuPhat.Columns["LyDoNopPhat"].Width = 230;
            dtGridViewPhieuPhat.Columns["SoTienNopPhat"].Width = 150;
            dtGridViewPhieuPhat.Columns["NgayThueXe"].Width = 120;
            dtGridViewPhieuPhat.Columns["NgayTraXe"].Width = 120;
        }
        private void dtGridViewPhieuPhat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtGridViewPhieuPhat.CurrentRow;
            index = row.Index;
            if (index >= 0)
            {
                phieuNopPhat = dsPhieuNopPhat[index];
                txtSoPhieuPhat.Text = phieuNopPhat.SoPhieuPhat.ToString();
                comboBoxHoTen.Text = phieuNopPhat.HoTenKhachHang;
                txtSoChungMinh.Text = phieuNopPhat.SoChungMinh;
                txtLyDo.Text = phieuNopPhat.LyDoNopPhat;
                txtSoTienPhat.Text = phieuNopPhat.SoTienNopPhat.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            phieuNopPhat = new PhieuNopPhat
            {
                SoPhieuPhat = int.Parse(txtSoPhieuPhat.Text),
                HoTenKhachHang = comboBoxHoTen.Text,
                SoChungMinh = txtSoChungMinh.Text,
                LyDoNopPhat = txtLyDo.Text,
                SoTienNopPhat = double.Parse(txtSoTienPhat.Text),
                TongSoTien = double.Parse(txtSoTienPhat.Text) // Giả sử tổng số tiền bằng số tiền nộp phạt
            };
            ctrlPhieuNopPhat.add(phieuNopPhat);
            dsPhieuNopPhat = ctrlPhieuNopPhat.findAll();
            load_PhieuNopPhat();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text; // Lấy từ ô tìm kiếm
            dsPhieuNopPhat = ctrlPhieuNopPhat.findByCriteria(searchTerm); // Gọi phương thức tìm kiếm
            load_PhieuNopPhat(); // Tải lại danh sách phiếu nộp phạt
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (phieuNopPhat != null)
            {
                ctrlPhieuNopPhat.remove(phieuNopPhat);
                dsPhieuNopPhat = ctrlPhieuNopPhat.findAll();
                load_PhieuNopPhat();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (phieuNopPhat != null)
            {
                phieuNopPhat.HoTenKhachHang = comboBoxHoTen.Text;
                phieuNopPhat.SoChungMinh = txtSoChungMinh.Text;
                phieuNopPhat.LyDoNopPhat = txtLyDo.Text;
                phieuNopPhat.SoTienNopPhat = double.Parse(txtSoTienPhat.Text);
                phieuNopPhat.TongSoTien = double.Parse(txtSoTienPhat.Text); // Cập nhật tổng số tiền
                ctrlPhieuNopPhat.upDate(phieuNopPhat);
                dsPhieuNopPhat = ctrlPhieuNopPhat.findAll();
                load_PhieuNopPhat();
            }
        }

        private void comboBoxHoTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHoTen.SelectedValue != null)
            {
                try
                {
                    int maKhachHang = Convert.ToInt32(comboBoxHoTen.SelectedValue); // Sử dụng Convert.ToInt32
                    var khachHang = dsKhachHang.FirstOrDefault(kh => kh.MaKhachHang == maKhachHang); // Tìm khách hàng tương ứng

                    if (khachHang != null)
                    {
                        txtMaKhachHang.Text = khachHang.MaKhachHang.ToString(); // Cập nhật mã khách hàng
                        txtSoChungMinh.Text = khachHang.SoChungMinh; // Cập nhật số chứng minh nhân dân
                    }
                }
                catch (FormatException)
                {
                    
                }
                catch (InvalidCastException)
                {
                    
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
