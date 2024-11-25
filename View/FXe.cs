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

namespace QuanLyBaiThueXeDev
{
    public partial class FXe : Form
    {
        private Ctrl_Xe ctrlXe = new Ctrl_Xe();
        private List<Xe> dsXe = null;
        private Xe xe;
        private int index;
        public FXe()
        {
            InitializeComponent();

        }

        private void FXe_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            dsXe = ctrlXe.findAll();
            load_Xe();
        }
        private void load_Xe()
        {
            var list = from a in dsXe
                       select new { a.BienSoXe, a.MaLoaiXe, a.MauSon, a.TinhTrang, a.MoTa, a.GiaThueXe };
            dtGridViewXe.DataSource = list.ToList();
            dtGridViewXe.Columns["BienSoXe"].Width = 150;
            dtGridViewXe.Columns["MaLoaiXe"].Width = 80;
            dtGridViewXe.Columns["MauSon"].Width = 150;
            dtGridViewXe.Columns["TinhTrang"].Width = 200;
            dtGridViewXe.Columns["MoTa"].Width = 378;
            dtGridViewXe.Columns["GiaThueXe"].Width = 100;
        }
        private void dtGridViewXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtGridViewXe.CurrentRow;
            index = row.Index;
            if (index >= 0)
            {
                xe = dsXe[index];
                txtBienSoXe.Text = xe.BienSoXe;
                txtMaLoaiXe.Text = xe.MaLoaiXe.ToString();
                txtMauSon.Text = xe.MauSon;
                txtTinhTrang.Text = xe.TinhTrang;
                txtMoTa.Text = xe.MoTa;
                txtGiaThueXe.Text = xe.GiaThueXe.ToString();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường nhập liệu
                if (string.IsNullOrWhiteSpace(txtBienSoXe.Text) ||
                    string.IsNullOrWhiteSpace(txtMaLoaiXe.Text) ||
                    string.IsNullOrWhiteSpace(txtMauSon.Text) ||
                    string.IsNullOrWhiteSpace(txtTinhTrang.Text) ||
                    string.IsNullOrWhiteSpace(txtGiaThueXe.Text))
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin.");
                }

                // Kiểm tra độ dài của Biển số xe
                if (txtBienSoXe.Text.Length != 9)
                {
                    throw new Exception("Biển số xe phải đúng 9 ký tự.");
                }

                // Kiểm tra dữ liệu hợp lệ
                if (!int.TryParse(txtMaLoaiXe.Text, out int maLoaiXe))
                    throw new Exception("Mã loại xe phải là số.");
                if (!int.TryParse(txtGiaThueXe.Text, out int giaThueXe))
                    throw new Exception("Giá thuê xe phải là số.");
                if (dsXe.Any(x => x.BienSoXe.Equals(txtBienSoXe.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
                    throw new Exception("Biển số xe đã tồn tại.");

                // Thêm mới xe
                xe = new Xe
                {
                    BienSoXe = txtBienSoXe.Text.Trim(),
                    MaLoaiXe = maLoaiXe,
                    MauSon = txtMauSon.Text.Trim(),
                    TinhTrang = txtTinhTrang.Text.Trim(),
                    MoTa = txtMoTa.Text.Trim(),
                    GiaThueXe = giaThueXe
                };

                ctrlXe.add(xe); // Thêm xe vào cơ sở dữ liệu
                dsXe.Add(xe);   // Cập nhật danh sách hiển thị
                load_Xe();      // Tải lại DataGridView
                ClearFields();  // Xóa các trường nhập liệu

                MessageBox.Show("Thêm xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Thêm xe thất bại! Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (xe != null)
                {
                    // Kiểm tra độ dài của Biển số xe
                    if (txtBienSoXe.Text.Length != 9)
                    {
                        throw new Exception("Biển số xe phải đúng 9 ký tự.");
                    }

                    if (!int.TryParse(txtMaLoaiXe.Text, out int maLoaiXe))
                        throw new Exception("Mã loại xe phải là số.");
                    if (!int.TryParse(txtGiaThueXe.Text, out int giaThueXe))
                        throw new Exception("Giá thuê xe phải là số.");

                    // Cập nhật thông tin xe
                    xe.MaLoaiXe = maLoaiXe;
                    xe.MauSon = txtMauSon.Text.Trim();
                    xe.TinhTrang = txtTinhTrang.Text.Trim();
                    xe.MoTa = txtMoTa.Text.Trim();
                    xe.GiaThueXe = giaThueXe;

                    ctrlXe.upDate(xe); // Cập nhật trong cơ sở dữ liệu
                    load_Xe();         // Tải lại DataGridView
                    ClearFields();     // Xóa các trường nhập liệu

                    MessageBox.Show("Cập nhật xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chưa chọn xe để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cập nhật xe thất bại! Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (xe != null)
                {
                    // Kiểm tra tình trạng xe
                    if (xe.TinhTrang.Equals("Đang được thuê", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Xe đang được sử dụng, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Hỏi xác nhận trước khi xóa
                    var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa xe này không?",
                                                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        ctrlXe.remove(xe); // Xóa khỏi cơ sở dữ liệu
                        dsXe.Remove(xe);   // Xóa khỏi danh sách hiển thị
                        load_Xe();         // Tải lại DataGridView
                        ClearFields();     // Xóa các trường nhập liệu
                        xe = null;

                        MessageBox.Show("Xóa xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa chọn xe để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xóa xe thất bại! Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text; 
            dsXe = ctrlXe.findByCriteria(searchTerm); 
            load_Xe();
        }
        private void ClearFields()
        {
            txtBienSoXe.Clear();
            txtMaLoaiXe.Clear();
            txtMauSon.Clear();
            txtMoTa.Clear();
            txtTimKiem.Clear();
            txtGiaThueXe.Clear();
        }

        private void txtBienSoXe_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtGridViewXe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtTinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
