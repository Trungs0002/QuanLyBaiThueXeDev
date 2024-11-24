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
            khachHang = new KhachHang
            {
                MaKhachHang = int.Parse(txtMaKhachHang.Text),
                HoTen = txtHoTen.Text.Trim(),
                GioiTinh = txtGioiTinh.Text.Trim(),
                DienThoai = txtDienThoai.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                SoChungMinh = txtSoChungMinh.Text.Trim()
            };

            ctrlKhachHang.add(khachHang);
            dsKhachHang.Add(khachHang);
            load_KhachHang();
            ClearFields();
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
    }
}
