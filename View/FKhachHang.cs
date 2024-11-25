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
            SetupListView();

        }
        private void SetupListView()
        {
            listViewLichSuThue.View = System.Windows.Forms.View.Details;
            listViewLichSuThue.FullRowSelect = true;

            // Thêm các cột vào ListView
            listViewLichSuThue.Columns.Add("Mã Khách Hàng", 100);
            listViewLichSuThue.Columns.Add("Biển Số Xe", 100);
            listViewLichSuThue.Columns.Add("Số Ngày Mượn", 100);
            listViewLichSuThue.Columns.Add("Đơn Giá", 100);
            listViewLichSuThue.Columns.Add("Tổng Tiền", 100);
            listViewLichSuThue.Columns.Add("Ngày Thuê", 100);
        }
        public void LoadLichSuThue(int maKhachHang)
        {
            listViewLichSuThue.Items.Clear(); // Xóa tất cả mục hiện tại trong ListView
            var lichSuThueList = CUtils.db.LichSuThues.Where(ls => ls.MaKhachHang == maKhachHang).ToList();

            foreach (var lichSu in lichSuThueList)
            {
                var item = new ListViewItem(lichSu.MaKhachHang.ToString());
                item.SubItems.Add(lichSu.BienSoXe);
                item.SubItems.Add(lichSu.SoNgayMuon.ToString());
                item.SubItems.Add(lichSu.DonGia.ToString());
                item.SubItems.Add(lichSu.TongTien.ToString());
                item.SubItems.Add(lichSu.NgayThue.ToString("dd/MM/yyyy")); // Thêm ngày thuê
                listViewLichSuThue.Items.Add(item);
            }

            if (lichSuThueList.Count == 0)
            {
                MessageBox.Show("Không có lịch sử thuê nào cho khách hàng này.");
            }
        }
        private void load_KhachHang()
        {
            var list = from kh in dsKhachHang
                       select new { kh.MaKhachHang, kh.HoTen, kh.GioiTinh, kh.DienThoai, kh.DiaChi, kh.SoChungMinh };
            dtGridViewKhachHang.DataSource = list.ToList();
            dtGridViewKhachHang.Columns["MaKhachHang"].Width = 90;
            dtGridViewKhachHang.Columns["HoTen"].Width = 142; 
            dtGridViewKhachHang.Columns["GioiTinh"].Width = 101; 
            dtGridViewKhachHang.Columns["DienThoai"].Width = 120; 
            dtGridViewKhachHang.Columns["DiaChi"].Width = 142; 
            dtGridViewKhachHang.Columns["SoChungMinh"].Width = 120;
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
                    txtDienThoai.Text.Length > 10 ||
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

        private void btnLoadLichSu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xem lịch sử.");
                return;
            }

            // Lấy mã khách hàng từ textbox
            int maKhachHang;
            if (int.TryParse(txtMaKhachHang.Text, out maKhachHang))
            {
                LoadLichSuThue(maKhachHang); // Gọi phương thức để tải lịch sử thuê
            }
            else
            {
                MessageBox.Show("Mã khách hàng không hợp lệ.");
            }
        }

        private void listViewLichSuThue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
