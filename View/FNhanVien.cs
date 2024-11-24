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
                // 1. Kiểm tra các trường bắt buộc có bị bỏ trống không
                if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text) ||
                    string.IsNullOrWhiteSpace(txtTenNhanVien.Text) ||
                    string.IsNullOrWhiteSpace(txtDienThoai.Text))
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin bắt buộc.");
                }

                // 2. Kiểm tra độ dài chuỗi nhập liệu
                if (txtTenNhanVien.Text.Length > 100)
                {
                    throw new Exception("Tên nhân viên không được vượt quá 100 ký tự.");
                }

                if (txtDienThoai.Text.Length != 10)
                {
                    throw new Exception("Số điện thoại không hợp lệ.");
                }

                if (txtMoTa.Text.Length > 255)
                {
                    throw new Exception("Mô tả không được vượt quá 255 ký tự.");
                }

                // 3. Kiểm tra mã nhân viên có phải là số không
                if (!int.TryParse(txtMaNhanVien.Text, out int maNhanVien))
                {
                    throw new Exception("Mã nhân viên phải là số.");
                }

                // 4. Kiểm tra mã nhân viên có bị trùng không
                var nhanVienTrung = dsNhanVien.Find(nv => nv.MaNhanVien == maNhanVien);
                if (nhanVienTrung != null)
                {
                    throw new Exception("Mã nhân viên đã tồn tại. Vui lòng nhập mã khác.");
                }

                // 5. Tạo đối tượng NhanVien nếu không có lỗi
                nhanVien = new NhanVien
                {
                    MaNhanVien = maNhanVien,
                    TenNhanVien = txtTenNhanVien.Text.Trim(),
                    DienThoai = txtDienThoai.Text.Trim(),
                    MoTa = txtMoTa.Text.Trim()
                };

                // 6. Thêm vào cơ sở dữ liệu và danh sách hiển thị
                ctrlNhanVien.add(nhanVien);  // Thêm vào cơ sở dữ liệu
                dsNhanVien.Add(nhanVien);   // Thêm vào danh sách tạm
                load_NhanVien();            // Cập nhật DataGridView
                ClearFields();              // Xóa các trường nhập liệu
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (nhanVien != null)
            {
                nhanVien.TenNhanVien = txtTenNhanVien.Text.Trim();
                nhanVien.DienThoai = txtDienThoai.Text.Trim();
                nhanVien.MoTa = txtMoTa.Text.Trim();

                ctrlNhanVien.upDate(nhanVien);
                load_NhanVien();
                ClearFields();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (nhanVien != null)
            {
                ctrlNhanVien.remove(nhanVien);
                dsNhanVien.RemoveAt(index);
                load_NhanVien();
                ClearFields();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text; 
            dsNhanVien = ctrlNhanVien.findByCriteria(searchTerm); 
            load_NhanVien(); 
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
    }
}
