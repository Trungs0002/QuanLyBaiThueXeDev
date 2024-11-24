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
        private List<PhieuNopPhat> dsPhieuNopPhat = null;
        private PhieuNopPhat phieuNopPhat;
        private int index;
        public FPhieuNopPhat()
        {
            InitializeComponent();
        }

        private void FPhieuNopPhat_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            dsPhieuNopPhat = ctrlPhieuNopPhat.findAll();
            load_PhieuNopPhat();
        }
        private void load_PhieuNopPhat()
        {
            var list = from p in dsPhieuNopPhat
                       select new { p.SoPhieuPhat, p.HoTenKhachHang, p.SoChungMinh, p.LyDoNopPhat, p.SoTienNopPhat, p.TongSoTien };
            dtGridViewPhieuPhat.DataSource = list.ToList();
        }
        private void dtGridViewPhieuPhat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtGridViewPhieuPhat.CurrentRow;
            index = row.Index;
            if (index >= 0)
            {
                phieuNopPhat = dsPhieuNopPhat[index];
                txtSoPhieuPhat.Text = phieuNopPhat.SoPhieuPhat.ToString();
                txtHoTen.Text = phieuNopPhat.HoTenKhachHang;
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
                HoTenKhachHang = txtHoTen.Text,
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
                phieuNopPhat.HoTenKhachHang = txtHoTen.Text;
                phieuNopPhat.SoChungMinh = txtSoChungMinh.Text;
                phieuNopPhat.LyDoNopPhat = txtLyDo.Text;
                phieuNopPhat.SoTienNopPhat = double.Parse(txtSoTienPhat.Text);
                phieuNopPhat.TongSoTien = double.Parse(txtSoTienPhat.Text); // Cập nhật tổng số tiền
                ctrlPhieuNopPhat.upDate(phieuNopPhat);
                dsPhieuNopPhat = ctrlPhieuNopPhat.findAll();
                load_PhieuNopPhat();
            }
        }
    }
}
