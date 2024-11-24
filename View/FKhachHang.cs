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
    public partial class FKhachHang : Form
    {
        private Ctrl_KhachHang ctrlKhachHang = new Ctrl_KhachHang();
        private List<KhachHang> dsKhachHang = null;
        private KhachHang khachHang;
        private int index;

        public FKhachHang()
        {
            InitializeComponent();
        }

        private void FKhachHang_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            dsKhachHang = ctrlKhachHang.findAll();
            load_KhachHang();
        }
        private void load_KhachHang()
        {
            var list = from kh in dsKhachHang
                       select new { kh.MaKhachHang, kh.HoTen, kh.GioiTinh, kh.DienThoai, kh.DiaChi, kh.SoChungMinh };
            dtGridViewKhachHang.DataSource = list.ToList();
        }
        private void dtGridViewKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtGridViewKhachHang.CurrentRow;
            index = row.Index;
            if (index >= 0)
            {
                khachHang = dsKhachHang[index];
                txtMaKhachHang.Text = khachHang.MaKhachHang.ToString();
                txtHoTen.Text = khachHang.HoTen;
                txtGioiTinh.Text = khachHang.GioiTinh;
                txtDienThoai.Text = khachHang.DienThoai;
                txtDiaChi.Text = khachHang.DiaChi;
                txtSoChungMinh.Text = khachHang.SoChungMinh;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường nhập liệu có bị bỏ trống hay không
                if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text) ||
                    string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                    string.IsNullOrWhiteSpace(txtGioiTinh.Text) ||
                    string.IsNullOrWhiteSpace(txtDienThoai.Text) ||
                    string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                    string.IsNullOrWhiteSpace(txtSoChungMinh.Text))
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin.");
                }

                // Kiểm tra độ dài của các trường nhập liệu
                if (txtHoTen.Text.Length > 50 ||
                    txtGioiTinh.Text.Length > 10 ||
                    txtDienThoai.Text.Length > 15 ||
                    txtDiaChi.Text.Length > 100 ||
                    txtSoChungMinh.Text.Length > 12)
                {
                    throw new Exception("Một số trường nhập liệu quá dài. Vui lòng kiểm tra lại.");
                }

                // Chuyển đổi mã khách hàng
                int maKhachHangMoi;
                if (!int.TryParse(txtMaKhachHang.Text, out maKhachHangMoi))
                {
                    throw new Exception("Mã khách hàng phải là số.");
                }

                // Kiểm tra mã khách hàng trùng lặp bằng Find
                var khachHangTrung = dsKhachHang.Find(kh => kh.MaKhachHang == maKhachHangMoi);
                if (khachHangTrung != null)
                {
                    throw new Exception("Mã khách hàng bị trùng. Vui lòng nhập mã khác.");
                }

                // Nếu không trùng, thực hiện thêm mới
                khachHang = new KhachHang
                {
                    MaKhachHang = maKhachHangMoi,
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = txtGioiTinh.Text.Trim(),
                    DienThoai = txtDienThoai.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    SoChungMinh = txtSoChungMinh.Text.Trim()
                };

                ctrlKhachHang.add(khachHang); // Thêm khách hàng vào cơ sở dữ liệu
                dsKhachHang.Add(khachHang);  // Thêm vào danh sách hiển thị
                load_KhachHang();            // Cập nhật lại DataGridView
                ClearFields();               // Xóa trường nhập liệu
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnSua_Click(object sender, EventArgs e)
        {
            if (khachHang != null)
            {
                khachHang.HoTen = txtHoTen.Text.Trim();
                khachHang.GioiTinh = txtGioiTinh.Text.Trim();
                khachHang.DienThoai = txtDienThoai.Text.Trim();
                khachHang.DiaChi = txtDiaChi.Text.Trim();
                khachHang.SoChungMinh = txtSoChungMinh.Text.Trim();

                ctrlKhachHang.upDate(khachHang);
                load_KhachHang();
                ClearFields();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (khachHang != null)
            {
                ctrlKhachHang.remove(khachHang);
                dsKhachHang.RemoveAt(index);
                load_KhachHang();
                ClearFields();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text; 
            dsKhachHang = ctrlKhachHang.findByCriteria(searchTerm); 
            load_KhachHang();
        }

        private void ClearFields()
        {
            txtMaKhachHang.Clear();
            txtHoTen.Clear();
            txtGioiTinh.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtSoChungMinh.Clear();
            khachHang = null;
        }

        private void txtMaKhachHang_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
