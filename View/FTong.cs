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
    public partial class FTong : Form
    {
        FDoanhThu doanhthu;
        FKhachHang khachhang;
        FLoaiXe loaixe;
        FNhanVien nhanvien;
        FPhieuNopPhat phieunopphat;
        FPhieuThue phieuthue;
        FXe xe;

        bool menuExpand = false;
        bool menuExpand1 = false;
        bool sideExpand = true;

        private Form currentForm = null;
        private void OpenForm(Form newForm)
        {
            if (currentForm != null)
            {
                currentForm.Close(); 
            }
            currentForm = newForm; 
            currentForm.MdiParent = this; 
            currentForm.Dock = DockStyle.Fill; 
            currentForm.Show(); 
        }

        private void mdiProp()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232, 234, 237);
        }
        public FTong()
        {
            InitializeComponent();
            mdiProp();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (doanhthu == null)
            //{
            //    doanhthu = new FDoanhThu();
            //    doanhthu.FormClosed += Doanhthu_FormClosed; 
            //    doanhthu.MdiParent = this;
            //    doanhthu.Dock = DockStyle.Fill;
            //    doanhthu.Show();
            //}
            //else
            //{
            //    doanhthu.Activate();
            //}
            OpenForm(new FDoanhThu());
        }

        private void Doanhthu_FormClosed(object sender, FormClosedEventArgs e)
        {
            doanhthu = null;
        }

        private void menuTrans_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                menuContainer1.Height += 10; 
                if (menuContainer1.Height >= 233)
                {
                    menuTrans.Stop(); 
                    menuExpand = true;
                }
            }
            else
            {
                menuContainer1.Height -= 10;
                if (menuContainer1.Height <= 73)
                {
                    menuTrans.Stop(); 
                    menuExpand = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menuTrans.Start();
            if (sidebar.Width <= 107)
            { sideTrans.Start(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (xe == null)
            //{
            //    xe = new FXe();
            //    xe.FormClosed += Xe_FormClosed; 
            //    xe.MdiParent = this;
            //    xe.Dock = DockStyle.Fill;
            //    xe.Show();
            //}
            //else
            //{
            //    xe.Activate();
            //}
            OpenForm(new FXe());
           label1.Text = "QUẢN LÍ BÃI THUÊ XE | XE";
        }

        private void Xe_FormClosed(object sender, FormClosedEventArgs e)
        {
            xe = null;
        }

        private void sideTrans_Tick(object sender, EventArgs e)
        {
            if (sideExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 107)
                {
                    sideExpand = false;
                    sideTrans.Stop();

                    pnProfile.Width = sidebar.Width;
                    pnNhanVien.Width = sidebar.Width;
                    pnKhachHang.Width = sidebar.Width;
                    pnLogout.Width = sidebar.Width;
                    menuContainer1.Width = sidebar.Width;
                    menuContainer2.Width = sidebar.Width;
                    pnDoanhThu.Width = sidebar.Width;
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 351)
                {
                    sideExpand = true;
                    sideTrans.Stop();

                    pnProfile.Width = sidebar.Width;
                    pnNhanVien.Width = sidebar.Width;
                    pnKhachHang.Width = sidebar.Width;
                    pnLogout.Width = sidebar.Width;
                    menuContainer1.Width = sidebar.Width;
                    menuContainer2.Width = sidebar.Width;
                    pnDoanhThu.Width = sidebar.Width;
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuTrans2_Tick(object sender, EventArgs e)
        {
            if (menuExpand1 == false)
            {
                menuContainer2.Height += 10;
                if (menuContainer2.Height >= 233)
                {
                    menuTrans2.Stop();
                    menuExpand1 = true;
                }
            }
            else
            {
                menuContainer2.Height -= 10;
                if (menuContainer2.Height <= 73)
                {
                    menuTrans2.Stop();
                    menuExpand1 = false;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            menuTrans2.Start();
            if (sidebar.Width <= 107)
            { sideTrans.Start(); }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            sideTrans.Start();
            if (menuContainer2.Height >= 233)
            { menuTrans2.Start(); }
            if (menuContainer1.Height >= 233)
            { menuTrans.Start(); }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void FTong_Load(object sender, EventArgs e)
        {
            label2.Text = "Hello, J97!";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //if (khachhang == null)
            //{
            //    khachhang = new FKhachHang();
            //    khachhang.FormClosed += Khachhang_FormClosed;
            //    khachhang.MdiParent = this;
            //    khachhang.Dock = DockStyle.Fill;
            //    khachhang.Show();
            //}
            //else
            //{
            //    khachhang.Activate();
            //}
            OpenForm(new FKhachHang());
        }

        private void Khachhang_FormClosed(object sender, FormClosedEventArgs e)
        {
            khachhang = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (nhanvien == null)
            //{
            //    nhanvien = new FNhanVien();
            //    nhanvien.FormClosed += Nhanvien_FormClosed; 
            //    nhanvien.MdiParent = this;
            //    nhanvien.Dock = DockStyle.Fill;
            //    nhanvien.Show();
            //}
            //else
            //{
            //    nhanvien.Activate();
            //}
            OpenForm(new FNhanVien());
        }

        private void Nhanvien_FormClosed(object sender, FormClosedEventArgs e)
        {
            nhanvien = null;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //if (phieuthue == null)
            //{
            //    phieuthue = new FPhieuThue();
            //    phieuthue.FormClosed += Phieuthue_FormClosed; 
            //    phieuthue.MdiParent = this;
            //    phieuthue.Dock = DockStyle.Fill;
            //    phieuthue.Show();
            //}
            //else
            //{
            //    phieuthue.Activate();
            //}
            OpenForm(new FPhieuThue());
        }

        private void Phieuthue_FormClosed(object sender, FormClosedEventArgs e)
        {
            phieuthue = null;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //if (phieunopphat == null)
            //{
            //    phieunopphat = new FPhieuNopPhat();
            //    phieunopphat.FormClosed += Phieunopphat_FormClosed; 
            //    phieunopphat.MdiParent = this;
            //    phieunopphat.Dock = DockStyle.Fill;
            //    phieunopphat.Show();
            //}
            //else
            //{
            //    phieunopphat.Activate();
            //}
            OpenForm(new FPhieuNopPhat());
        }

        private void Phieunopphat_FormClosed(object sender, FormClosedEventArgs e)
        {
            phieunopphat = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //if (loaixe == null)
            //{
            //    loaixe = new FLoaiXe();
            //    loaixe.FormClosed += Loaixe_FormClosed; 
            //    loaixe.MdiParent = this;
            //    loaixe.Dock = DockStyle.Fill;
            //    loaixe.Show();
            //}
            //else
            //{
            //    loaixe.Activate();
            //}
            OpenForm(new FLoaiXe());
        }

        private void Loaixe_FormClosed(object sender, FormClosedEventArgs e)
        {
            loaixe = null;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
