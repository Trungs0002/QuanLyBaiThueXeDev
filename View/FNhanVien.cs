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

            // Khởi tạo giá trị cho dtpThangNam (Chỉ chọn tháng và năm)
            dtpThangNam.Format = DateTimePickerFormat.Custom;
            dtpThangNam.CustomFormat = "MM/yyyy"; // Định dạng tháng/năm

            // Set giá trị mặc định là tháng hiện tại
            dtpThangNam.Value = DateTime.Now;

            // Tải danh sách nhân viên
            dsNhanVien = ctrlNhanVien.findAll();

            // Kiểm tra xem dsNhanVien có dữ liệu không
            if (dsNhanVien != null && dsNhanVien.Count > 0)
            {
                load_NhanVien(); // Gọi để hiển thị dữ liệu lên DataGridView
            }
            else
            {
                MessageBox.Show("Không có dữ liệu nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ClearFields();
        }
        private void InitializeDataGridView()
        {
            // Thêm cột MaNhanVien nếu chưa có
            if (!dtGridViewNhanVien.Columns.Contains("MaNhanVien"))
            {
                DataGridViewTextBoxColumn maNVColumn = new DataGridViewTextBoxColumn();
                maNVColumn.Name = "MaNhanVien";
                maNVColumn.HeaderText = "Mã Nhân Viên";
                dtGridViewNhanVien.Columns.Add(maNVColumn);
            }

            // Thêm cột DoanhThu nếu chưa có
            if (!dtGridViewNhanVien.Columns.Contains("DoanhThu"))
            {
                DataGridViewTextBoxColumn doanhThuColumn = new DataGridViewTextBoxColumn();
                doanhThuColumn.Name = "DoanhThu";
                doanhThuColumn.HeaderText = "Doanh Thu";
                dtGridViewNhanVien.Columns.Add(doanhThuColumn);
            }
        }

        private void load_NhanVien()
        {
            var list = from nv in dsNhanVien
                       select new { nv.MaNhanVien, nv.TenNhanVien, nv.DienThoai, nv.MoTa };
            dtGridViewNhanVien.DataSource = list.ToList();
            dtGridViewNhanVien.Columns["MaNhanVien"].Width = 100;
            dtGridViewNhanVien.Columns["TenNhanVien"].Width = 200;
            dtGridViewNhanVien.Columns["DienThoai"].Width = 150;
            dtGridViewNhanVien.Columns["MoTa"].Width = 557;


        }
        private void dtGridViewKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtGridViewNhanVien.CurrentRow;
            index = row.Index;
            if (index >= 0)
            {
                nhanVien = dsNhanVien[index];
                txtMaNhanVien.Text = nhanVien.MaNhanVien.ToString();
                txtTenNhanVien.Text = nhanVien.TenNhanVien;
                txtDienThoai.Text = nhanVien.DienThoai;
                txtMoTa.Text = nhanVien.MoTa;

                txtDoanhThu.Clear();
                // Sau khi chọn nhân viên, tải doanh thu cho nhân viên này theo tháng và năm hiện tại
                LoadDoanhThuForNhanVien();
            }
        }

        private void LoadDoanhThuForNhanVien()
        {
            try
            {
                // Kiểm tra xem người dùng đã chọn tháng và năm chưa
                if (dtpThangNam.Value == null)
                {
                    MessageBox.Show("Vui lòng chọn tháng và năm trước khi lấy doanh thu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy giá trị tháng và năm từ DateTimePicker
                int thang = dtpThangNam.Value.Month;
                int nam = dtpThangNam.Value.Year;

                // Gọi phương thức từ Ctrl_NhanVien để lấy doanh thu
                var doanhThu = ctrlNhanVien.GetDoanhThuTheoThang(thang, nam, nhanVien.MaNhanVien);

                // Kiểm tra dữ liệu doanh thu
                if (doanhThu != null && doanhThu.Count > 0)
                {
                    // Hiển thị tổng doanh thu vào TextBox (ví dụ: txtDoanhThu)
                    decimal tongDoanhThu = doanhThu.Values.Sum();
                    txtDoanhThu.Text = tongDoanhThu.ToString("N0");  // Định dạng số cho dễ đọc
                    MessageBox.Show("Dữ liệu doanh thu của tháng đã được tải thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu doanh thu trong tháng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi tải dữ liệu doanh thu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public int GenerateNewPhieuThueId()
        {
            // Lấy ID lớn nhất từ bảng PhieuNopPhat
            var maxId = CUtils.db.NhanViens.Max(pnp => (int?)pnp.MaNhanVien) ?? 0;
            return maxId + 1; // Tăng thêm 1 để tạo ID mới
        }

        private void ClearFields()
        {
            txtMaNhanVien.Text = GenerateNewPhieuThueId().ToString();
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

        private void dtGridViewDoanhThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpThangNam_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtMaNhanVien_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trường này không thể chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
