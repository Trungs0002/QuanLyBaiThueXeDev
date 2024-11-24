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
            dsXe = ctrlXe.findAll();
            load_Xe();
        }
        private void load_Xe()
        {
            var list = from a in dsXe
                       select new { a.BienSoXe, a.MaLoaiXe, a.MauSon, a.TinhTrang, a.MoTa };
            dtGridViewXe.DataSource = list.ToList();
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
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            xe = new Xe
            {
                BienSoXe = txtBienSoXe.Text.Trim(),
                MaLoaiXe = int.Parse(txtMaLoaiXe.Text),
                MauSon = txtMauSon.Text.Trim(),
                TinhTrang = txtTinhTrang.Text.Trim(),
                MoTa = txtMoTa.Text.Trim()
            };

            ctrlXe.add(xe);
            dsXe.Add(xe);
            load_Xe();
            ClearFields();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (xe != null)
            {
                xe.MaLoaiXe = int.Parse(txtMaLoaiXe.Text);
                xe.MauSon = txtMauSon.Text.Trim();
                xe.TinhTrang = txtTinhTrang.Text.Trim();
                xe.MoTa = txtMoTa.Text.Trim();

                ctrlXe.upDate(xe);
                load_Xe();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Chưa chọn xe để cập nhật!!!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (xe != null)
            {
                ctrlXe.remove(xe);
                dsXe.Remove(xe);
                load_Xe();
                ClearFields();
                xe = null;
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
            txtTinhTrang.Clear();
            txtMoTa.Clear();
            txtTimKiem.Clear();
        }
    }
}
