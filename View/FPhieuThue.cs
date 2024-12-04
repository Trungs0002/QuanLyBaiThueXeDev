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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace QuanLyBaiThueXeDev.View
{
    public partial class FPhieuThue : Form
    {
        private Ctrl_KhachHang ctrlKhachHang = new Ctrl_KhachHang();
        private Ctrl_LoaiXe ctrlLoaiXe = new Ctrl_LoaiXe();
        private Ctrl_Xe ctrlXe = new Ctrl_Xe();
        private Ctrl_PhieuThue ctrlPhieuThue = new Ctrl_PhieuThue();
        private Ctrl_PhieuNopPhat ctrlPhieuNopPhat = new Ctrl_PhieuNopPhat();
        private List<KhachHang> dsKhachHang;
        private List<Xe> dsXe;
        private List<NhanVien> dsNhanVien;
        private Ctrl_NhanVien ctrlNhanVien = new Ctrl_NhanVien();
        public FPhieuThue()
        {
            InitializeComponent();
        }
        private void SetupDataGridView()
        {
            dataGridViewKhachHang.AutoGenerateColumns = false; // Tắt tự động tạo cột
            dataGridViewKhachHang.Columns.Clear(); // Xóa các cột cũ nếu có

            // Thêm cột cho thông tin khách hàng
            //dataGridViewKhachHang.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã Khách Hàng", DataPropertyName = "MaKhachHang" });
            //dataGridViewKhachHang.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Họ Tên", DataPropertyName = "HoTen" });
            //dataGridViewKhachHang.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giới Tính", DataPropertyName = "GioiTinh" });
            //dataGridViewKhachHang.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Điện Thoại", DataPropertyName = "DienThoai" });
            //dataGridViewKhachHang.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Địa Chỉ", DataPropertyName = "DiaChi" });
            //dataGridViewKhachHang.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số Chứng Minh", DataPropertyName = "SoChungMinh" });

            var maKhachHangColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Khách Hàng",
                DataPropertyName = "MaKhachHang",
                Width = 100
            };
            dataGridViewKhachHang.Columns.Add(maKhachHangColumn);

            var hoTenColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Họ Tên",
                DataPropertyName = "HoTen",
                Width = 162
            };
            dataGridViewKhachHang.Columns.Add(hoTenColumn);

            var gioiTinhColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Giới Tính",
                DataPropertyName = "GioiTinh",
                Width = 100
            };
            dataGridViewKhachHang.Columns.Add(gioiTinhColumn);

            var dienThoaiColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Điện Thoại",
                DataPropertyName = "DienThoai",
                Width = 120
            };
            dataGridViewKhachHang.Columns.Add(dienThoaiColumn);

            var diaChiColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Địa Chỉ",
                DataPropertyName = "DiaChi",
                Width = 200
            };
            dataGridViewKhachHang.Columns.Add(diaChiColumn);

            var soChungMinhColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Chứng Minh",
                DataPropertyName = "SoChungMinh",
                Width = 120
            };
            dataGridViewKhachHang.Columns.Add(soChungMinhColumn);

            //dataGridViewKhachHang.Columns["MaKhachHang"].Width = 100;
            //dataGridViewKhachHang.Columns["HoTen"].Width = 150;
            //dataGridViewKhachHang.Columns["GioiTinh"].Width = 100;
            //dataGridViewKhachHang.Columns["DienThoai"].Width = 120;
            //dataGridViewKhachHang.Columns["DiaChi"].Width = 200;
            //dataGridViewKhachHang.Columns["SoChungMinh"].Width = 150;

            dataGridViewXe.AutoGenerateColumns = false; // Tắt tự động tạo cột
            dataGridViewXe.Columns.Clear(); // Xóa các cột cũ nếu có

            // Thêm cột cho thông tin xe
            //dataGridViewXe.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Biển Số Xe", DataPropertyName = "BienSoXe" });
            //dataGridViewXe.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã Loại Xe", DataPropertyName = "MaLoaiXe" });
            //dataGridViewXe.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Màu Sơn", DataPropertyName = "MauSon" });
            //dataGridViewXe.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tình Trạng", DataPropertyName = "TinhTrang" });
            //dataGridViewXe.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mô Tả", DataPropertyName = "MoTa" });
            //dataGridViewXe.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giá Thuê", DataPropertyName = "GiaThueXe" });

            var bienSoXeColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Biển Số Xe",
                DataPropertyName = "BienSoXe",
                Width = 120
            };
            dataGridViewXe.Columns.Add(bienSoXeColumn);

            var maLoaiXeColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Loại Xe",
                DataPropertyName = "MaLoaiXe",
                Width = 100
            };
            dataGridViewXe.Columns.Add(maLoaiXeColumn);

            var mauSonColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Màu Sơn",
                DataPropertyName = "MauSon",
                Width = 100
            };
            dataGridViewXe.Columns.Add(mauSonColumn);

            var tinhTrangColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Tình Trạng",
                DataPropertyName = "TinhTrang",
                Width = 150
            };
            dataGridViewXe.Columns.Add(tinhTrangColumn);

            var moTaColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Mô Tả",
                DataPropertyName = "MoTa",
                Width = 212
            };
            dataGridViewXe.Columns.Add(moTaColumn);

            var giaThueXeColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Giá Thuê",
                DataPropertyName = "GiaThueXe",
                Width = 120
            };
            dataGridViewXe.Columns.Add(giaThueXeColumn);

            //dataGridViewXe.Columns["BienSoXe"].Width = 120;
            //dataGridViewXe.Columns["MaLoaiXe"].Width = 100;
            //dataGridViewXe.Columns["MauSon"].Width = 100;
            //dataGridViewXe.Columns["TinhTrang"].Width = 100;
            //dataGridViewXe.Columns["MoTa"].Width = 200;
            //dataGridViewXe.Columns["GiaThuXe"].Width = 100;
        }
        private void FPhieuThue_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            //txtSoPhieuThue.ReadOnly = true;
            ClearFields();
            SetupDataGridView();
            LoadKhachHang();
            LoadXe();
            LoadNhanVien();
            LoadPhieuThue();

            // Định dạng DateTimePicker
            dateTimePickerNgayThue.Format = DateTimePickerFormat.Custom;
            dateTimePickerNgayThue.CustomFormat = "dd/MM/yyyy";
        }
        private void LoadKhachHang()
        {
            dsKhachHang = ctrlKhachHang.findAll();
            comboBoxKhachHang.DataSource = dsKhachHang;
            comboBoxKhachHang.DisplayMember = "HoTen"; // Hiển thị họ tên
            comboBoxKhachHang.ValueMember = "MaKhachHang"; // Giá trị là mã khách hàng
        }

        private void LoadNhanVien()
        {
            dsNhanVien = ctrlNhanVien.findAll();
            comboBoxNhanVien.DataSource = dsNhanVien;
            comboBoxNhanVien.DisplayMember = "TenNhanVien";
            comboBoxNhanVien.ValueMember = "MaNhanVien";
        }
        //private List<string> tempXeList = new List<string>(); // Danh sách tạm thời
        private void LoadXe()
        {
            dsXe = ctrlXe.findAll();

            // Lọc danh sách xe để chỉ lấy xe có trạng thái "Còn sử dụng"
            comboBoxXe.DataSource = dsXe;
            comboBoxXe.DisplayMember = "BienSoXe"; // Hiển thị biển số xe
            comboBoxXe.ValueMember = "BienSoXe"; // Giá trị là biển số xe
            //var availableXe = dsXe.Where(xe => xe.TinhTrang != "Đang được thuê").ToList();

            //comboBoxXe.DataSource = availableXe; // Gán danh sách xe đã lọc cho ComboBox
            //comboBoxXe.DisplayMember = "BienSoXe"; // Hiển thị biển số xe
            //comboBoxXe.ValueMember = "BienSoXe";
        }

        private void LoadPhieuThue()
        {
            //var list = ctrlPhieuThue.findAll();

            //// Kiểm tra nếu không có phiếu thuê nào
            //if (list == null || !list.Any())
            //{
            //    MessageBox.Show("Không có phiếu thuê nào trong hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    dataGridViewPhieuThue.DataSource = null; // Xóa dữ liệu trong DataGridView
            //    return;
            //}

            //dataGridViewPhieuThue.DataSource = list.Select(pt => new
            //{
            //    pt.SoPhieuThue,
            //    pt.MaKhachHang,
            //    pt.BienSoXe,
            //    pt.SoNgayMuon,
            //    pt.DonGia,
            //    TongTien = pt.SoNgayMuon * pt.DonGia, // Tính tổng tiền thuê
            //    pt.MaNhanVien,
            //    pt.TrangThai// Thêm mã nhân viên vào danh sách
            //}).ToList();

            var list = ctrlPhieuThue.findAll();

            // Xóa dữ liệu cũ trong DataGridView
            dataGridViewPhieuThue.DataSource = null;
            dataGridViewLichSuPhieuThue.DataSource = null;

            // Tạo danh sách cho từng trạng thái
            var phieuThueDaGiao = new List<PhieuThue>();
            var phieuThueDaTra = new List<PhieuThue>();

            foreach (var phieuThue in list)
            {
                // Phân loại phiếu thuê theo trạng thái
                if (phieuThue.TrangThai == "Đã giao xe")
                {
                    phieuThueDaGiao.Add(phieuThue);
                }
                else if (phieuThue.TrangThai == "Đã trả xe")
                {
                    phieuThueDaTra.Add(phieuThue);
                }
            }

            // Cập nhật DataGridView với danh sách tương ứng
            dataGridViewPhieuThue.DataSource = phieuThueDaGiao.Select(pt => new
            {
                pt.SoPhieuThue,
                pt.MaKhachHang,
                pt.BienSoXe,
                pt.SoNgayMuon,
                pt.DonGia,
                TongTien = pt.SoNgayMuon * pt.DonGia, // Tính tổng tiền
                pt.MaNhanVien
            }).ToList();

            dataGridViewLichSuPhieuThue.DataSource = phieuThueDaTra.Select(pt => new
            {
                pt.SoPhieuThue,
                pt.MaKhachHang,
                pt.BienSoXe,
                pt.SoNgayMuon,
                pt.DonGia,
                TongTien = pt.SoNgayMuon * pt.DonGia, // Tính tổng tiền
                pt.MaNhanVien
            }).ToList();

            // Ẩn BienSoXe
            dataGridViewPhieuThue.Columns["BienSoXe"].Visible = false;

            // Ẩn cột mã nhân viên nếu không cần hiển thị
            dataGridViewPhieuThue.Columns["MaNhanVien"].Visible = true;
        }


        private void txtSoPhieuThue_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Ràng buộc dữ liệu trước khi thêm
                if (string.IsNullOrWhiteSpace(txtSoPhieuThue.Text) ||
                    string.IsNullOrWhiteSpace(txtSoNgayMuon.Text) ||
                    comboBoxKhachHang.SelectedIndex == -1 ||
                    comboBoxXe.SelectedIndex == -1 ||
                    comboBoxNhanVien.SelectedIndex == -1) // Kiểm tra nhân viên
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtSoPhieuThue.Text, out int soPhieuThue))
                {
                    MessageBox.Show("Số phiếu thuê phải là số nguyên hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtSoNgayMuon.Text, out int soNgayMuon) || soNgayMuon <= 0)
                {
                    MessageBox.Show("Số ngày mượn phải là số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra trùng Số Phiếu Thuê
                var existingPhieuThue = ctrlPhieuThue.findAll().FirstOrDefault(pt => pt.SoPhieuThue == soPhieuThue);
                if (existingPhieuThue != null)
                {
                    MessageBox.Show("Số phiếu thuê đã tồn tại. Vui lòng nhập số khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra trạng thái xe
                string bienSoXe = comboBoxXe.SelectedValue.ToString();
                var xe = ctrlXe.findByBienSo(bienSoXe);
                if (xe != null && xe.TinhTrang == "Đang được thuê")
                {
                    MessageBox.Show("Xe này đã có người thuê. Vui lòng chọn xe khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo phiếu thuê và lưu dữ liệu
                var phieuThue = new PhieuThue
                {
                    SoPhieuThue = soPhieuThue,
                    NgayThue = dateTimePickerNgayThue.Value,
                    MaKhachHang = (int)comboBoxKhachHang.SelectedValue,
                    BienSoXe = bienSoXe,
                    SoNgayMuon = soNgayMuon,
                    DonGia = xe?.GiaThueXe ?? 0, // Lấy giá thuê từ xe
                    TrangThai = "Đã giao xe", // Mặc định trạng thái
                    MaNhanVien = (int)comboBoxNhanVien.SelectedValue // Lưu mã nhân viên
                };

                ctrlPhieuThue.add(phieuThue);

                // Cập nhật trạng thái xe
                if (xe != null)
                {
                    xe.TinhTrang = "Đang được thuê";
                    ctrlXe.upDate(xe);
                }

                LoadXe();
                LoadPhieuThue();
                ClearFields();

                MessageBox.Show("Thêm phiếu thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewPhieuThue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu hàng được click là hợp lệ
            {
                //LoadXe();
                isEditingPhieuThue = true;
                // Lấy thông tin phiếu thuê từ dòng đã chọn
                var selectedRow = dataGridViewPhieuThue.Rows[e.RowIndex];
                int soPhieuThue = (int)selectedRow.Cells["SoPhieuThue"].Value;

                // Lấy thông tin phiếu thuê từ cơ sở dữ liệu
                var phieuThue = ctrlPhieuThue.findAll().FirstOrDefault(pt => pt.SoPhieuThue == soPhieuThue);
                if (phieuThue != null)
                {
                    // Lấy mã khách hàng, biển số xe và mã nhân viên từ phiếu thuê
                    int maKhachHang = phieuThue.MaKhachHang ?? 0; // Sử dụng ?? để xử lý giá trị null
                    string bienSoXe = phieuThue.BienSoXe;
                    int maNhanVien = phieuThue.MaNhanVien ?? 0; // Lấy mã nhân viên

                    // Hiển thị thông tin vào các điều khiển
                    txtSoPhieuThue.Text = phieuThue.SoPhieuThue.ToString();
                    comboBoxKhachHang.SelectedValue = maKhachHang; // Cập nhật comboBoxKhachHang
                    //comboBoxXe.SelectedValue = bienSoXe; // Cập nhật comboBoxXe
                    //if (!tempXeList.Contains(bienSoXe)) // Kiểm tra xem đã có trong danh sách tạm thời chưa
                    //{
                    //    tempXeList.Add(bienSoXe); // Thêm biển số xe vào danh sách tạm thời
                    //}
                    //comboBoxXe.DataSource = null; // Xóa DataSource hiện tại
                    //comboBoxXe.DataSource = tempXeList; // Gán lại DataSource với danh sách tạm thời
                    comboBoxXe.SelectedValue = bienSoXe;
                    dateTimePickerNgayThue.Value = (DateTime)phieuThue.NgayThue; // Cập nhật ngày thuê
                    txtSoNgayMuon.Text = phieuThue.SoNgayMuon.ToString(); // Cập nhật số ngày thuê

                    // Cập nhật comboBoxNhanVien với mã nhân viên
                    comboBoxNhanVien.SelectedValue = maNhanVien; // Cập nhật comboBoxNhanVien

                    // Lấy thông tin khách hàng từ cơ sở dữ liệu
                    var khachHang = ctrlKhachHang.findById(maKhachHang);
                    if (khachHang != null)
                    {
                        // Hiển thị thông tin khách hàng
                        dataGridViewKhachHang.DataSource = new List<KhachHang> { khachHang };
                    }

                    // Lấy thông tin xe từ cơ sở dữ liệu
                    var xe = ctrlXe.findByBienSo(bienSoXe);
                    if (xe != null)
                    {
                        // Hiển thị thông tin xe
                        dataGridViewXe.DataSource = new List<Xe> { xe };
                    }
                }
            }
        }
        private void ClearFields()
        {
            txtSoPhieuThue.Text = GenerateNewPhieuThueId().ToString();
            txtSoNgayMuon.Clear();
            comboBoxKhachHang.SelectedIndex = -1;
            LoadXe();
            comboBoxXe.SelectedIndex = -1;
            comboBoxNhanVien.SelectedIndex = -1;
            dateTimePickerNgayThue.Value = DateTime.Now;
        }

        private bool isEditingPhieuThue = false; // Biến để xác định 
        private void btnSua_Click(object sender, EventArgs e)
        {
             try
    {
        if (!isEditingPhieuThue) // Kiểm tra nếu không phải là phiếu thuê
        {
            MessageBox.Show("Lịch sử không thể sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtSoPhieuThue.Text))
        {
            MessageBox.Show("Vui lòng chọn phiếu thuê cần sửa từ danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!int.TryParse(txtSoNgayMuon.Text, out int soNgayMuon) || soNgayMuon <= 0)
        {
            MessageBox.Show("Số ngày mượn phải là số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int soPhieuThue = int.Parse(txtSoPhieuThue.Text);
        var phieuThue = ctrlPhieuThue.findAll().FirstOrDefault(pt => pt.SoPhieuThue == soPhieuThue);
        if (phieuThue == null)
        {
            MessageBox.Show("Không tìm thấy phiếu thuê cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Lưu biển số xe cũ
        string bienSoXeCu = phieuThue.BienSoXe;

        // Kiểm tra xem dữ liệu có thay đổi không
        if (phieuThue.SoNgayMuon == soNgayMuon &&
            phieuThue.BienSoXe == comboBoxXe.SelectedValue.ToString() &&
            phieuThue.MaNhanVien == (int)comboBoxNhanVien.SelectedValue) // Kiểm tra mã nhân viên từ comboBox
        {
            MessageBox.Show("Thông tin không có thay đổi. Vui lòng nhập thông tin cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Cập nhật thông tin phiếu thuê
        phieuThue.SoNgayMuon = soNgayMuon;
        phieuThue.BienSoXe = comboBoxXe.SelectedValue.ToString(); // Biển số xe mới
        phieuThue.MaNhanVien = (int)comboBoxNhanVien.SelectedValue; // Cập nhật mã nhân viên từ comboBox
        ctrlPhieuThue.update(phieuThue); // Cập nhật phiếu thuê

        // Cập nhật trạng thái xe cũ
        var xeCu = ctrlXe.findByBienSo(bienSoXeCu);
        if (xeCu != null)
        {
            xeCu.TinhTrang = "Còn sử dụng"; // Cập nhật trạng thái xe cũ
            ctrlXe.upDate(xeCu); // Lưu thay đổi vào cơ sở dữ liệu
        }

        // Cập nhật trạng thái xe mới
        var xeMoi = ctrlXe.findByBienSo(phieuThue.BienSoXe);
        if (xeMoi != null)
        {
            xeMoi.TinhTrang = "Đang được thuê"; // Cập nhật trạng thái xe mới
            ctrlXe.upDate(xeMoi); // Lưu thay đổi vào cơ sở dữ liệu
        }

        LoadXe(); // Cập nhật danh sách xe
        LoadPhieuThue(); // Cập nhật danh sách phiếu thuê
        MessageBox.Show("Sửa phiếu thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    catch (Exception ex)
    {
        MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có phiếu thuê nào được chọn không
                if (string.IsNullOrWhiteSpace(txtSoPhieuThue.Text))
                {
                    MessageBox.Show("Vui lòng chọn phiếu thuê để xóa.");
                    return;
                }

                // Lấy số phiếu thuê cần xóa
                int soPhieuThue = int.Parse(txtSoPhieuThue.Text);

                // Lấy thông tin phiếu thuê từ cơ sở dữ liệu
                var phieuThue = ctrlPhieuThue.findAll().FirstOrDefault(pt => pt.SoPhieuThue == soPhieuThue);
                if (phieuThue != null)
                {
                    // Cập nhật trạng thái phiếu thuê thành "Đã trả xe"
                    phieuThue.TrangThai = "Đã trả xe"; // Cập nhật trạng thái
                    ctrlPhieuThue.upDate(phieuThue); // Lưu thay đổi vào cơ sở dữ liệu

                    // Lưu thông tin vào bảng lịch sử thuê
                    var lichSuThue = new LichSuThue
                    {
                        MaKhachHang = phieuThue.MaKhachHang ?? 0, // Lấy mã khách hàng 
                        BienSoXe = phieuThue.BienSoXe,
                        SoNgayMuon = phieuThue.SoNgayMuon ?? 0, // Lấy số ngày thuê
                        DonGia = (int)(phieuThue.DonGia ?? 0), // Lấy đơn giá
                        TongTien = (int)(phieuThue.SoNgayMuon * phieuThue.DonGia), // Tính tổng tiền
                        NgayThue = phieuThue.NgayThue ?? DateTime.Now // Ngày thuê
                    };

                    // Thêm lịch sử thuê vào cơ sở dữ liệu
                    CUtils.db.LichSuThues.Add(lichSuThue);
                    CUtils.db.SaveChanges();

                    // Khai báo biến để tính ngày trễ trả xe
                    DateTime ngayTraXe = DateTime.Now; // Ngày trả xe
                    DateTime ngayThueXe = phieuThue.NgayThue ?? DateTime.Now; // Ngày thuê từ phiếu thuê

                    // Tính toán số ngày chậm trả
                    int soNgayChamTra = -1 + (ngayTraXe - ngayThueXe).Days;

                    // Nếu số ngày chậm trả > số ngày mượn
                    if (soNgayChamTra > phieuThue.SoNgayMuon)
                    {
                        // Tính số tiền nộp phạt
                        int soTienNopPhat = (int)(500000 * (soNgayChamTra - phieuThue.SoNgayMuon));

                        // Tạo phiếu nộp phạt
                        PhieuNopPhat phieuNopPhat = new PhieuNopPhat
                        {
                            SoPhieuPhat = GenerateNewPhieuPhatId(), // Hàm tạo id
                            HoTenKhachHang = dsKhachHang.FirstOrDefault(kh => kh.MaKhachHang == phieuThue.MaKhachHang)?.HoTen,
                            SoChungMinh = phieuThue.SoChungMinh,
                            // Cập nhật lý do nộp phạt với số ngày trễ
                            LyDoNopPhat = $"Trễ hạn trả xe ({soNgayChamTra} Ngày)",
                            SoTienNopPhat = soTienNopPhat,
                            NgayThueXe = ngayThueXe,
                            NgayTraXe = ngayTraXe
                        };

                        // Thêm phiếu nộp phạt vào cơ sở dữ liệu
                        ctrlPhieuNopPhat.add(phieuNopPhat);
                    }

                    string bienSoXe = phieuThue.BienSoXe;
                    var xe = ctrlXe.findByBienSo(bienSoXe);
                    if (xe != null)
                    {
                        xe.TinhTrang = "Còn sử dụng"; // Cập nhật trạng thái
                        ctrlXe.upDate(xe); // Cập nhật xe trong cơ sở dữ liệu
                    }

                    // Cập nhật lại danh sách phiếu thuê
                    LoadPhieuThue(); // Cập nhật danh sách phiếu thuê
                    LoadXe(); // Cập nhật danh sách xe

                    // Cập nhật lịch sử thuê trong FKhachHang
                    var khachHangForm = Application.OpenForms.OfType<FKhachHang>().FirstOrDefault();
                    if (khachHangForm != null)
                    {
                        // Gọi phương thức LoadLichSuThue với mã khách hàng từ phiếu thuê
                        khachHangForm.LoadLichSuThue(phieuThue.MaKhachHang ?? 0);
                    }

                    MessageBox.Show("Cập nhật trạng thái phiếu thuê thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phiếu thuê để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        public int GenerateNewPhieuThueId()
        {
            // Lấy ID lớn nhất từ bảng PhieuNopPhat
            var maxId = CUtils.db.PhieuThues.Max(pnp => (int?)pnp.SoPhieuThue) ?? 0;
            return maxId + 1; // Tăng thêm 1 để tạo ID mới
        }
        public int GenerateNewPhieuPhatId()
        {
            // Lấy ID lớn nhất từ bảng PhieuNopPhat
            var maxId = CUtils.db.PhieuNopPhats.Max(pnp => (int?)pnp.SoPhieuPhat) ?? 0;
            return maxId + 1; // Tăng thêm 1 để tạo ID mới
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy từ khóa tìm kiếm từ TextBox 
                string searchTerm = txtTimKiem.Text.Trim();

                // Kiểm tra nếu từ khóa tìm kiếm trống 
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    LoadPhieuThue();
                    return;
                }

                // Tìm kiếm phiếu thuê dựa trên từ khóa và trạng thái "Đã giao xe"
                var filteredPhieuThue = ctrlPhieuThue.findByCriteria(searchTerm)
                    .Where(pt => pt.TrangThai == "Đã giao xe") // Chỉ lấy phiếu đã giao xe
                    .ToList();

                // Hiển thị danh sách phiếu thuê đã lọc 
                dataGridViewPhieuThue.DataSource = filteredPhieuThue.Select(pt => new
                {
                    pt.SoPhieuThue,
                    pt.MaKhachHang,
                    pt.BienSoXe,
                    pt.SoNgayMuon,
                    pt.DonGia,
                    TongTien = pt.SoNgayMuon * pt.DonGia,
                    pt.MaNhanVien
                }).ToList();

                // Ẩn cột BienSoXe 
                dataGridViewPhieuThue.Columns["BienSoXe"].Visible = false;

                // Thông báo nếu không tìm thấy kết quả 
                if (filteredPhieuThue.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy phiếu thuê phù hợp với từ khóa. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewPhieuThue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewXe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewLichSuPhieuThue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu hàng được click là hợp lệ
            {
                //LoadXe();
                isEditingPhieuThue = false;
                // Lấy thông tin phiếu thuê từ dòng đã chọn
                var selectedRow = dataGridViewLichSuPhieuThue.Rows[e.RowIndex];
                int soPhieuThue = (int)selectedRow.Cells["SoPhieuThue"].Value;

                // Lấy thông tin phiếu thuê từ cơ sở dữ liệu
                var phieuThue = ctrlPhieuThue.findAll().FirstOrDefault(pt => pt.SoPhieuThue == soPhieuThue);
                if (phieuThue != null)
                {
                    // Lấy mã khách hàng, biển số xe và mã nhân viên từ phiếu thuê
                    int maKhachHang = phieuThue.MaKhachHang ?? 0; // Sử dụng ?? để xử lý giá trị null
                    string bienSoXe = phieuThue.BienSoXe;
                    int maNhanVien = phieuThue.MaNhanVien ?? 0; // Lấy mã nhân viên

                    // Hiển thị thông tin vào các điều khiển
                    txtSoPhieuThue.Text = phieuThue.SoPhieuThue.ToString();
                    comboBoxKhachHang.SelectedValue = maKhachHang; // Cập nhật comboBoxKhachHang
                    //comboBoxXe.SelectedValue = bienSoXe; // Cập nhật comboBoxXe
                    //if (!tempXeList.Contains(bienSoXe)) // Kiểm tra xem đã có trong danh sách tạm thời chưa
                    //{
                    //    tempXeList.Add(bienSoXe); // Thêm biển số xe vào danh sách tạm thời
                    //}
                    //comboBoxXe.DataSource = null; // Xóa DataSource hiện tại
                    //comboBoxXe.DataSource = tempXeList; // Gán lại DataSource với danh sách tạm thời
                    comboBoxXe.SelectedValue = bienSoXe;
                    dateTimePickerNgayThue.Value = (DateTime)phieuThue.NgayThue; // Cập nhật ngày thuê
                    txtSoNgayMuon.Text = phieuThue.SoNgayMuon.ToString(); // Cập nhật số ngày thuê

                    // Cập nhật comboBoxNhanVien với mã nhân viên
                    comboBoxNhanVien.SelectedValue = maNhanVien; // Cập nhật comboBoxNhanVien

                    // Lấy thông tin khách hàng từ cơ sở dữ liệu
                    var khachHang = ctrlKhachHang.findById(maKhachHang);
                    if (khachHang != null)
                    {
                        // Hiển thị thông tin khách hàng
                        dataGridViewKhachHang.DataSource = new List<KhachHang> { khachHang };
                    }

                    // Lấy thông tin xe từ cơ sở dữ liệu
                    var xe = ctrlXe.findByBienSo(bienSoXe);
                    if (xe != null)
                    {
                        // Hiển thị thông tin xe
                        dataGridViewXe.DataSource = new List<Xe> { xe };
                    }
                }
            }
        }

        private void btnTimKiemLS_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy từ khóa tìm kiếm từ TextBox 
                string searchTerm = txtTimKiemLS.Text.Trim();

                // Kiểm tra nếu từ khóa tìm kiếm trống 
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    LoadPhieuThue();
                    return;
                }

                // Tìm kiếm phiếu thuê lịch sử dựa trên từ khóa và trạng thái "Đã trả xe"
                var filteredLichSuPhieuThue = ctrlPhieuThue.findByCriteria(searchTerm)
                    .Where(pt => pt.TrangThai == "Đã trả xe") // Chỉ lấy phiếu đã trả xe
                    .ToList();

                // Hiển thị danh sách lịch sử phiếu thuê đã lọc 
                dataGridViewLichSuPhieuThue.DataSource = filteredLichSuPhieuThue.Select(pt => new
                {
                    pt.SoPhieuThue,
                    pt.MaKhachHang,
                    pt.BienSoXe,
                    pt.SoNgayMuon,
                    pt.DonGia,
                    TongTien = pt.SoNgayMuon * pt.DonGia // Tính tổng tiền thuê 
                }).ToList();

                // Ẩn cột BienSoXe 
                dataGridViewLichSuPhieuThue.Columns["BienSoXe"].Visible = false;

                // Thông báo nếu không tìm thấy kết quả 
                if (filteredLichSuPhieuThue.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy lịch sử phiếu thuê phù hợp với từ khóa. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSoPhieuThue_Enter(object sender, EventArgs e)
        {
            
            //this.ActiveControl = null;
        }

        private void txtSoPhieuThue_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trường này không thể chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void comboBoxXe_DropDown(object sender, EventArgs e)
        {
            //var availableXe = dsXe.Where(xe => xe.TinhTrang != "Đang được thuê").ToList(); // Lọc xe còn sử dụng
            //comboBoxXe.DataSource = availableXe; // Cập nhật DataSource
        }

        private void comboBoxXe_DropDownClosed(object sender, EventArgs e)
        {
            //var availableXe = dsXe.Where(xe => xe.TinhTrang != "Đang được thuê").ToList(); // Lọc xe còn sử dụng
            //comboBoxXe.DataSource = availableXe; // Cập nhật DataSource
        }
        //private bool isUpdating = false;
        private void comboBoxKhachHang_TextChanged(object sender, EventArgs e)
        {
            //if (isUpdating) return; // Nếu đang cập nhật thì không xử lý

            //string searchTerm = comboBoxKhachHang.Text.ToLower(); // Lấy từ khóa tìm kiếm và chuyển thành chữ thường

            //// Lọc danh sách khách hàng dựa trên từ khóa tìm kiếm
            //var filteredList = dsKhachHang
            //    .Where(kh => kh.HoTen.ToLower().Contains(searchTerm)) // Kiểm tra xem họ tên có chứa từ khóa không
            //    .ToList();

            //// Tạm thời tắt sự kiện
            //isUpdating = true;

            //// Cập nhật DataSource cho ComboBox
            //comboBoxKhachHang.DataSource = filteredList;

            //// Nếu không có kết quả nào, có thể chọn giá trị mặc định
            //if (filteredList.Count == 0)
            //{
            //    comboBoxKhachHang.SelectedIndex = -1; // Không chọn gì
            //}
            //else
            //{
            //    comboBoxKhachHang.SelectedIndex = 0; // Chọn giá trị đầu tiên
            //}

            //// Bật lại sự kiện
            //isUpdating = false;
        }

        private void txtTimKiemKH_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
