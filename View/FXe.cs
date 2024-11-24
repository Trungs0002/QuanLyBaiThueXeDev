﻿using QuanLyBaiThueXeDev.Ctrl_QLBTX;
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
                // Kiểm tra các trường nhập liệu có bị bỏ trống hay không
                if (string.IsNullOrWhiteSpace(txtBienSoXe.Text) ||
                    string.IsNullOrWhiteSpace(txtMaLoaiXe.Text) ||
                    string.IsNullOrWhiteSpace(txtMauSon.Text) ||
                    string.IsNullOrWhiteSpace(txtTinhTrang.Text) ||
                    string.IsNullOrWhiteSpace(txtGiaThueXe.Text))
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin.");
                }

                // Kiểm tra độ dài của các trường nhập liệu
                if (txtBienSoXe.Text.Length > 15)
                {
                    throw new Exception("Biển số xe không được dài quá 15 ký tự.");
                }

                if (txtMauSon.Text.Length > 50)
                {
                    throw new Exception("Màu sơn không được dài quá 50 ký tự.");
                }

                if (txtTinhTrang.Text.Length > 50)
                {
                    throw new Exception("Tình trạng không được dài quá 50 ký tự.");
                }

                if (txtMoTa.Text.Length > 255)
                {
                    throw new Exception("Mô tả không được dài quá 255 ký tự.");
                }

                // Kiểm tra MaLoaiXe là số
                if (!int.TryParse(txtMaLoaiXe.Text, out int maLoaiXe))
                {
                    throw new Exception("Mã loại xe phải là số.");
                }

                // Kiểm tra GiaThueXe là số
                if (!int.TryParse(txtGiaThueXe.Text, out int giaThueXe))
                {
                    throw new Exception("Giá thuê xe phải là số.");
                }

                // Kiểm tra biển số xe có trùng lặp hay không
                var xeTrung = dsXe.Find(x => x.BienSoXe.Equals(txtBienSoXe.Text.Trim(), StringComparison.OrdinalIgnoreCase));
                if (xeTrung != null)
                {
                    throw new Exception("Biển số xe đã tồn tại. Vui lòng nhập biển số khác.");
                }

                // Nếu không có lỗi, thêm mới xe
                xe = new Xe
                {
                    BienSoXe = txtBienSoXe.Text.Trim(),
                    MaLoaiXe = maLoaiXe,
                    MauSon = txtMauSon.Text.Trim(),
                    TinhTrang = txtTinhTrang.Text.Trim(),
                    MoTa = txtMoTa.Text.Trim(),
                    GiaThueXe = giaThueXe
                };

                // Thêm xe vào cơ sở dữ liệu và danh sách hiển thị
                ctrlXe.add(xe);
                dsXe.Add(xe);
                load_Xe();            // Cập nhật lại DataGridView
                ClearFields();        // Xóa các trường nhập liệu
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (xe != null)
            {
                xe.MaLoaiXe = int.Parse(txtMaLoaiXe.Text);
                xe.MauSon = txtMauSon.Text.Trim();
                xe.TinhTrang = txtTinhTrang.Text.Trim();
                xe.MoTa = txtMoTa.Text.Trim();
                xe.GiaThueXe = int.Parse(txtGiaThueXe.Text);

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
            txtGiaThueXe.Clear();
        }

        private void txtBienSoXe_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
