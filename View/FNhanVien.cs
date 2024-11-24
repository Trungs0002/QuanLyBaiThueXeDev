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
            nhanVien = new NhanVien
            {
                MaNhanVien = int.Parse(txtMaNhanVien.Text),
                TenNhanVien = txtTenNhanVien.Text.Trim(),
                DienThoai = txtDienThoai.Text.Trim(),
                MoTa = txtMoTa.Text.Trim()
            };

            ctrlNhanVien.add(nhanVien);
            dsNhanVien.Add(nhanVien);
            load_NhanVien();
            ClearFields();
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
    }
}
