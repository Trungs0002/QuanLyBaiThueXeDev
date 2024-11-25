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
    public partial class FNhanVien : Form
    {
        private Ctrl_NhanVien ctrlNhanVien = new Ctrl_NhanVien();
        private List<NhanVien> dsNhanVien = null;
        private NhanVien nhanVien;
        private int index;
        public FNhanVien()
        {
            InitializeComponent();
        }

        private void FNhanVien_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            dsNhanVien = ctrlNhanVien.findAll();
            load_NhanVien();
        }
        private void load_NhanVien()
        {
            var list = from nv in dsNhanVien
                       select new { nv.MaNhanVien, nv.TenNhanVien, nv.DienThoai, nv.MoTa };
            dtGridViewKhachHang.DataSource = list.ToList();
            dtGridViewKhachHang.Columns["MaNhanVien"].Width = 100; 
            dtGridViewKhachHang.Columns["TenNhanVien"].Width = 200; 
            dtGridViewKhachHang.Columns["DienThoai"].Width = 150; 
            dtGridViewKhachHang.Columns["MoTa"].Width = 557;
        }
        private void dtGridViewKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtGridViewKhachHang.CurrentRow;
            index = row.Index;
            if (index >= 0)
            {
                nhanVien = dsNhanVien[index];
                txtMaNhanVien.Text = nhanVien.MaNhanVien.ToString();
                txtTenNhanVien.Text = nhanVien.TenNhanVien;
                txtDienThoai.Text = nhanVien.DienThoai;
                txtMoTa.Text = nhanVien.MoTa;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường bắt buộc
                if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text) ||
                    string.IsNullOrWhiteSpace(txtTenNhanVien.Text) ||
                    string.IsNullOrWhiteSpace(txtDienThoai.Text))
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin bắt buộc.");
                }

                // Kiểm tra độ dài và định dạng
                if (txtTenNhanVien.Text.Length > 100)
                {
                    throw new Exception("Tên nhân viên không được vượt quá 100 ký tự.");
                }

                if (txtDienThoai.Text.Length != 10 || !txtDienThoai.Text.All(char.IsDigit))
                {
                    throw new Exception("Số điện thoại phải là 10 chữ số.");
                }

                if (txtMoTa.Text.Length > 255)
                {
                    throw new Exception("Mô tả không được vượt quá 255 ký tự.");
                }

                // Kiểm tra mã nhân viên là số
                if (!int.TryParse(txtMaNhanVien.Text, out int maNhanVien))
                {
                    throw new Exception("Mã nhân viên phải là số.");
                }

                // Kiểm tra mã nhân viên trùng lặp
                var nhanVienTrung = dsNhanVien.Find(nv => nv.MaNhanVien == maNhanVien);
                if (nhanVienTrung != null)
                {
                    throw new Exception("Mã nhân viên đã tồn tại. Vui lòng nhập mã khác.");
                }

                // Tạo đối tượng NhanVien
                nhanVien = new NhanVien
                {
                    MaNhanVien = maNhanVien,
                    TenNhanVien = txtTenNhanVien.Text.Trim(),
                    DienThoai = txtDienThoai.Text.Trim(),
                    MoTa = txtMoTa.Text.Trim()
                };

                // Thêm vào cơ sở dữ liệu và danh sách
                ctrlNhanVien.add(nhanVien);
                dsNhanVien.Add(nhanVien);
                load_NhanVien();
                ClearFields();

                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Thêm nhân viên thất bại! Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (nhanVien != null)
                {
                    // Kiểm tra độ dài và định dạng
                    if (txtTenNhanVien.Text.Length > 100)
                    {
                        throw new Exception("Tên nhân viên không được vượt quá 100 ký tự.");
                    }

                    if (txtDienThoai.Text.Length != 10 || !txtDienThoai.Text.All(char.IsDigit))
                    {
                        throw new Exception("Số điện thoại phải là 10 chữ số.");
                    }

                    if (txtMoTa.Text.Length > 255)
                    {
                        throw new Exception("Mô tả không được vượt quá 255 ký tự.");
                    }

                    // Cập nhật thông tin
                    nhanVien.TenNhanVien = txtTenNhanVien.Text.Trim();
                    nhanVien.DienThoai = txtDienThoai.Text.Trim();
                    nhanVien.MoTa = txtMoTa.Text.Trim();

                    ctrlNhanVien.upDate(nhanVien);
                    load_NhanVien();
                    ClearFields();

                    MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chưa chọn nhân viên để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cập nhật nhân viên thất bại! Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (nhanVien != null)
                {
                    // Xác nhận trước khi xóa
                    var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?",
                                                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        ctrlNhanVien.remove(nhanVien);
                        dsNhanVien.RemoveAt(index);
                        load_NhanVien();
                        ClearFields();

                        MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa chọn nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xóa nhân viên thất bại! Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtTimKiem.Text.Trim();
                dsNhanVien = ctrlNhanVien.findByCriteria(searchTerm);

                if (dsNhanVien.Count > 0)
                {
                    load_NhanVien();
                    MessageBox.Show($"Tìm thấy {dsNhanVien.Count} kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tìm kiếm thất bại! Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearFields()
        {
            txtMaNhanVien.Clear();
            txtTenNhanVien.Clear();
            txtDienThoai.Clear();
            txtMoTa.Clear();
            nhanVien = null;
        }

        private void txtMaNhanVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDienThoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaNhanVien_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtTenNhanVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtGridViewKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
