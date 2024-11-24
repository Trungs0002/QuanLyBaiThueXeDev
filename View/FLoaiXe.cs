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
        public FLoaiXe()
        {
            InitializeComponent();
        }

        private void FLoaiXe_Load(object sender, EventArgs e)
        {
            dsLoaiXe = ctrlLoaiXe.findAll();
            load_LoaiXe();
        }
        private void load_LoaiXe()
        {
            var list = from a in dsLoaiXe
                       select new { a.MaLoaiXe, a.TenLoai, a.HangSanXuat, a.NamSanXuat, a.MoTa };
            dtGridViewLoaiXe.DataSource = list.ToList();
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
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            loaiXe = new LoaiXe
            {
                MaLoaiXe = int.Parse(txtMaLoaiXe.Text),
                TenLoai = txtTenLoai.Text.Trim(),
                HangSanXuat = txtHangSanXuat.Text.Trim(),
                NamSanXuat = int.Parse(txtNamSanXuat.Text),
                MoTa = txtMoTa.Text.Trim()
            };

            ctrlLoaiXe.add(loaiXe);
            dsLoaiXe.Add(loaiXe);
            load_LoaiXe();
            ClearFields();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (loaiXe != null)
            {
                loaiXe.TenLoai = txtTenLoai.Text.Trim();
                loaiXe.HangSanXuat = txtHangSanXuat.Text.Trim();
                loaiXe.NamSanXuat = int.Parse(txtNamSanXuat.Text);
                loaiXe.MoTa = txtMoTa.Text.Trim();

                ctrlLoaiXe.upDate(loaiXe);
                load_LoaiXe();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Chưa chọn loại xe để cập nhật!!!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (loaiXe != null)
            {
                ctrlLoaiXe.remove(loaiXe);
                dsLoaiXe.Remove(loaiXe);
                load_LoaiXe();
                ClearFields();
                loaiXe = null;
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
