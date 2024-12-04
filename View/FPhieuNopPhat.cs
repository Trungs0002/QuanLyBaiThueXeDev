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
            dsKhachHang = ctrlKhachHang.findAll(); 
            comboBoxHoTen.DataSource = dsKhachHang; 
            comboBoxHoTen.DisplayMember = "HoTen"; 
            comboBoxHoTen.ValueMember = "MaKhachHang"; 
        }
        private void FPhieuNopPhat_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            dsPhieuNopPhat = ctrlPhieuNopPhat.findAll();
            load_PhieuNopPhat();
            LoadKhachHang();
            ClearFields();
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
                           NgayThueXe = p.NgayThueXe.HasValue ? p.NgayThueXe.Value.ToString("dd/MM/yyyy") : "Chưa có", // Nếu có gtri thì trả về ToString không thì "Chưa có"
                           NgayTraXe = p.NgayTraXe.HasValue ? p.NgayTraXe.Value.ToString("dd/MM/yyyy") : "Chưa có"  
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
            try
            {
                // Ràng buộc dữ liệu
                if (string.IsNullOrWhiteSpace(txtSoPhieuPhat.Text) ||
                    string.IsNullOrWhiteSpace(txtSoTienPhat.Text) ||
                    string.IsNullOrWhiteSpace(txtLyDo.Text) ||
                    comboBoxHoTen.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtSoPhieuPhat.Text, out int soPhieuPhat))
                {
                    MessageBox.Show("Số phiếu phạt phải là số nguyên hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(txtSoTienPhat.Text, out double soTienPhat) || soTienPhat <= 0)
                {
                    MessageBox.Show("Số tiền phạt phải là số hợp lệ và lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng phiếu phạt mới
                phieuNopPhat = new PhieuNopPhat
                {
                    SoPhieuPhat = soPhieuPhat,
                    HoTenKhachHang = comboBoxHoTen.Text,
                    SoChungMinh = txtSoChungMinh.Text,
                    LyDoNopPhat = txtLyDo.Text,
                    SoTienNopPhat = soTienPhat,
                    TongSoTien = soTienPhat
                };

                // Thêm phiếu phạt vào cơ sở dữ liệu
                ctrlPhieuNopPhat.add(phieuNopPhat);
                dsPhieuNopPhat = ctrlPhieuNopPhat.findAll();
                load_PhieuNopPhat();

                MessageBox.Show("Thêm phiếu nộp phạt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text; 
            dsPhieuNopPhat = ctrlPhieuNopPhat.findByCriteria(searchTerm); 
            load_PhieuNopPhat(); 
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (phieuNopPhat == null)
                {
                    MessageBox.Show("Vui lòng chọn phiếu phạt để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu phạt này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    ctrlPhieuNopPhat.remove(phieuNopPhat);
                    dsPhieuNopPhat = ctrlPhieuNopPhat.findAll();
                    load_PhieuNopPhat();

                    MessageBox.Show("Xóa phiếu nộp phạt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (phieuNopPhat == null)
                {
                    MessageBox.Show("Vui lòng chọn phiếu phạt để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSoTienPhat.Text) || string.IsNullOrWhiteSpace(txtLyDo.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(txtSoTienPhat.Text, out double soTienPhat) || soTienPhat <= 0)
                {
                    MessageBox.Show("Số tiền phạt phải là số hợp lệ và lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật thông tin phiếu phạt
                phieuNopPhat.HoTenKhachHang = comboBoxHoTen.Text;
                phieuNopPhat.SoChungMinh = txtSoChungMinh.Text;
                phieuNopPhat.LyDoNopPhat = txtLyDo.Text;
                phieuNopPhat.SoTienNopPhat = soTienPhat;
                phieuNopPhat.TongSoTien = soTienPhat;

                // Lưu vào cơ sở dữ liệu
                ctrlPhieuNopPhat.upDate(phieuNopPhat);
                dsPhieuNopPhat = ctrlPhieuNopPhat.findAll();
                load_PhieuNopPhat();

                MessageBox.Show("Cập nhật phiếu nộp phạt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void comboBoxHoTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHoTen.SelectedValue != null)
            {
                try
                {
                    int maKhachHang = Convert.ToInt32(comboBoxHoTen.SelectedValue); 
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
        public int GenerateNewPhieuThueId()
        {
            // Lấy ID lớn nhất từ bảng PhieuNopPhat
            var maxId = CUtils.db.PhieuNopPhats.Max(pnp => (int?)pnp.SoPhieuPhat) ?? 0;
            return maxId + 1; // Tăng thêm 1 để tạo ID mới
        }
        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            txtSoPhieuPhat.Text = GenerateNewPhieuThueId().ToString();
            txtLyDo.Clear();
            txtMaKhachHang.Clear();
            txtSoChungMinh.Clear();
            txtSoTienPhat.Clear();
        }

        private void txtSoPhieuPhat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trường này không thể chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
