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
    public partial class FLoaiXe : Form
    {
        private Ctrl_LoaiXe ctrlLoaiXe = new Ctrl_LoaiXe();
        private List<LoaiXe> dsLoaiXe = null;
        private LoaiXe loaiXe;
        private int index;

        private Ctrl_Xe ctrlXe = new Ctrl_Xe();
        private List<Xe> dsXe = null;

        public FLoaiXe()
        {
            InitializeComponent();
        }

        private void FLoaiXe_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            dsLoaiXe = ctrlLoaiXe.findAll();
            load_LoaiXe();
        }
        private void LoadXeByLoaiXe(int maLoaiXe)
        {
            dsXe = ctrlXe.findByLoaiXe(maLoaiXe); 
            var list = from x in dsXe
                       select new { x.BienSoXe, x.MauSon, x.TinhTrang, x.MoTa };
            dtGridViewXe.DataSource = list.ToList();
            dtGridViewXe.Columns["BienSoXe"].Width = 100;
            dtGridViewXe.Columns["MauSon"].Width = 100;
            dtGridViewXe.Columns["TinhTrang"].Width = 200;
            dtGridViewXe.Columns["MoTa"].Width = 333;
        }
        private void load_LoaiXe()
        {
            var list = from a in dsLoaiXe
                       select new { a.MaLoaiXe, a.TenLoai, a.HangSanXuat, a.NamSanXuat, a.MoTa };
            dtGridViewLoaiXe.DataSource = list.ToList();
            dtGridViewLoaiXe.Columns["MaLoaiXe"].Width = 80;
            dtGridViewLoaiXe.Columns["TenLoai"].Width = 100;
            dtGridViewLoaiXe.Columns["HangSanXuat"].Width = 100;
            dtGridViewLoaiXe.Columns["NamSanXuat"].Width = 100;
            dtGridViewLoaiXe.Columns["MoTa"].Width = 352;
        }
        private void dtGridViewLoaiXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtGridViewLoaiXe.CurrentRow;
            index = row.Index;
            if (index >= 0)
            {
                loaiXe = dsLoaiXe[index];
                txtMaLoaiXe.Text = loaiXe.MaLoaiXe.ToString();
                txtTenLoai.Text = loaiXe.TenLoai;
                txtHangSanXuat.Text = loaiXe.HangSanXuat;
                txtNamSanXuat.Text = loaiXe.NamSanXuat.ToString();
                txtMoTa.Text = loaiXe.MoTa;

                LoadXeByLoaiXe(loaiXe.MaLoaiXe); 
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem mã loại xe đã tồn tại hay chưa
                int maLoaiXeMoi;
                if (!int.TryParse(txtMaLoaiXe.Text, out maLoaiXeMoi))
                {
                    MessageBox.Show("Mã loại xe phải là số. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var loaiXeTrung = dsLoaiXe.FirstOrDefault(lx => lx.MaLoaiXe == maLoaiXeMoi);
                if (loaiXeTrung != null)
                {
                    MessageBox.Show("Mã loại xe đã tồn tại. Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Nếu không trùng, tạo đối tượng mới
                loaiXe = new LoaiXe
                {
                    MaLoaiXe = maLoaiXeMoi,
                    TenLoai = txtTenLoai.Text.Trim(),
                    HangSanXuat = txtHangSanXuat.Text.Trim(),
                    NamSanXuat = int.Parse(txtNamSanXuat.Text),
                    MoTa = txtMoTa.Text.Trim()
                };

                // Thêm loại xe vào danh sách và cơ sở dữ liệu
                ctrlLoaiXe.add(loaiXe); // Thêm vào cơ sở dữ liệu
                dsLoaiXe.Add(loaiXe);   // Thêm vào danh sách hiển thị
                load_LoaiXe();          // Cập nhật danh sách hiển thị
                ClearFields();          // Xóa các trường nhập liệu

                MessageBox.Show("Thêm loại xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Thêm loại xe thất bại! Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (loaiXe != null)
                {
                    loaiXe.TenLoai = txtTenLoai.Text.Trim();
                    loaiXe.HangSanXuat = txtHangSanXuat.Text.Trim();
                    loaiXe.NamSanXuat = int.Parse(txtNamSanXuat.Text);
                    loaiXe.MoTa = txtMoTa.Text.Trim();

                    ctrlLoaiXe.upDate(loaiXe); // Cập nhật cơ sở dữ liệu
                    load_LoaiXe();             // Tải lại danh sách
                    ClearFields();             // Xóa các trường nhập liệu

                    MessageBox.Show("Cập nhật loại xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chưa chọn loại xe để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cập nhật loại xe thất bại! Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (loaiXe != null)
                {
                    // Kiểm tra xem có xe thuộc loại xe đang được thuê hay không
                    var dsXeDangDuocThue = dsXe.Where(x => x.MaLoaiXe == loaiXe.MaLoaiXe && x.TinhTrang.Equals("Đang được thuê", StringComparison.OrdinalIgnoreCase)).ToList();

                    if (dsXeDangDuocThue.Count > 0)
                    {
                        MessageBox.Show("Loại xe đang có xe được thuê, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Hỏi xác nhận trước khi xóa
                    var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa loại xe này không?",
                                                        "Xác nhận",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        ctrlLoaiXe.remove(loaiXe); // Xóa khỏi cơ sở dữ liệu
                        dsLoaiXe.Remove(loaiXe);   // Xóa khỏi danh sách hiển thị
                        load_LoaiXe();             // Tải lại danh sách
                        ClearFields();             // Xóa các trường nhập liệu
                        loaiXe = null;

                        MessageBox.Show("Xóa loại xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa chọn loại xe để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xóa loại xe thất bại! Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            /*string searchTerm = txtTimKiem.Text;
            var results = dsLoaiXe
                .Where(x => x.TenLoai.Contains(searchTerm) || x.HangSanXuat.Contains(searchTerm))
                .Select(x => new { x.MaLoaiXe, x.TenLoai, x.HangSanXuat, x.NamSanXuat, x.MoTa })
                .ToList();
            dtGridViewLoaiXe.DataSource = results;*/
            string searchTerm = txtTimKiem.Text; 
            dsLoaiXe = ctrlLoaiXe.findByName(searchTerm); 
            load_LoaiXe();
        }

        private void ClearFields()
        {
            txtMaLoaiXe.Clear();
            txtTenLoai.Clear();
            txtHangSanXuat.Clear();
            txtNamSanXuat.Clear();
            txtMoTa.Clear();
            txtTimKiem.Clear();
        }
    }
}
