namespace QuanLyBaiThueXeDev.View
{
    partial class FPhieuThue
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxXe = new System.Windows.Forms.ComboBox();
            this.comboBoxKhachHang = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerNgayThue = new System.Windows.Forms.DateTimePicker();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoNgayMuon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoPhieuThue = new System.Windows.Forms.TextBox();
            this.dataGridViewPhieuThue = new System.Windows.Forms.DataGridView();
            this.dataGridViewKhachHang = new System.Windows.Forms.DataGridView();
            this.dataGridViewXe = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhieuThue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXe)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.panel2.Controls.Add(this.txtTimKiem);
            this.panel2.Controls.Add(this.btnTimKiem);
            this.panel2.Location = new System.Drawing.Point(1261, 257);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(720, 64);
            this.panel2.TabIndex = 11;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTimKiem.Location = new System.Drawing.Point(44, 18);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(509, 24);
            this.txtTimKiem.TabIndex = 14;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.btnTimKiem.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(585, 12);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(107, 37);
            this.btnTimKiem.TabIndex = 13;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.comboBoxXe);
            this.panel1.Controls.Add(this.comboBoxKhachHang);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dateTimePickerNgayThue);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtSoNgayMuon);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSoPhieuThue);
            this.panel1.Location = new System.Drawing.Point(79, 257);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1128, 210);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 12.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(16, 17);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(217, 25);
            this.label8.TabIndex = 32;
            this.label8.Text = "QUẢN LÍ PHIẾU THUÊ";
            // 
            // comboBoxXe
            // 
            this.comboBoxXe.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold);
            this.comboBoxXe.FormattingEnabled = true;
            this.comboBoxXe.Location = new System.Drawing.Point(447, 112);
            this.comboBoxXe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxXe.Name = "comboBoxXe";
            this.comboBoxXe.Size = new System.Drawing.Size(183, 24);
            this.comboBoxXe.TabIndex = 24;
            this.comboBoxXe.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBoxKhachHang
            // 
            this.comboBoxKhachHang.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold);
            this.comboBoxKhachHang.FormattingEnabled = true;
            this.comboBoxKhachHang.Location = new System.Drawing.Point(447, 63);
            this.comboBoxKhachHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxKhachHang.Name = "comboBoxKhachHang";
            this.comboBoxKhachHang.Size = new System.Drawing.Size(183, 24);
            this.comboBoxKhachHang.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(688, 66);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Ngày Thuê";
            // 
            // dateTimePickerNgayThue
            // 
            this.dateTimePickerNgayThue.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold);
            this.dateTimePickerNgayThue.Location = new System.Drawing.Point(807, 63);
            this.dateTimePickerNgayThue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerNgayThue.Name = "dateTimePickerNgayThue";
            this.dateTimePickerNgayThue.Size = new System.Drawing.Size(265, 24);
            this.dateTimePickerNgayThue.TabIndex = 21;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.btnXoa.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(307, 151);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(107, 37);
            this.btnXoa.TabIndex = 18;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.btnSua.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(181, 151);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(107, 37);
            this.btnSua.TabIndex = 17;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.btnThem.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(56, 151);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(107, 37);
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(688, 116);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Số Ngày Thuê";
            // 
            // txtSoNgayMuon
            // 
            this.txtSoNgayMuon.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtSoNgayMuon.Location = new System.Drawing.Point(807, 112);
            this.txtSoNgayMuon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSoNgayMuon.Name = "txtSoNgayMuon";
            this.txtSoNgayMuon.Size = new System.Drawing.Size(129, 24);
            this.txtSoNgayMuon.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(339, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Biển Số Xe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(339, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Khách Hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(47, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số Phiếu Thuê";
            // 
            // txtSoPhieuThue
            // 
            this.txtSoPhieuThue.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtSoPhieuThue.Location = new System.Drawing.Point(165, 63);
            this.txtSoPhieuThue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSoPhieuThue.Name = "txtSoPhieuThue";
            this.txtSoPhieuThue.Size = new System.Drawing.Size(140, 24);
            this.txtSoPhieuThue.TabIndex = 0;
            this.txtSoPhieuThue.TextChanged += new System.EventHandler(this.txtSoPhieuThue_TextChanged);
            // 
            // dataGridViewPhieuThue
            // 
            this.dataGridViewPhieuThue.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPhieuThue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPhieuThue.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPhieuThue.Location = new System.Drawing.Point(1260, 364);
            this.dataGridViewPhieuThue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewPhieuThue.Name = "dataGridViewPhieuThue";
            this.dataGridViewPhieuThue.RowHeadersWidth = 51;
            this.dataGridViewPhieuThue.Size = new System.Drawing.Size(721, 594);
            this.dataGridViewPhieuThue.TabIndex = 9;
            this.dataGridViewPhieuThue.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPhieuThue_CellClick);
            this.dataGridViewPhieuThue.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPhieuThue_CellContentClick);
            // 
            // dataGridViewKhachHang
            // 
            this.dataGridViewKhachHang.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewKhachHang.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewKhachHang.Location = new System.Drawing.Point(79, 527);
            this.dataGridViewKhachHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewKhachHang.Name = "dataGridViewKhachHang";
            this.dataGridViewKhachHang.RowHeadersWidth = 51;
            this.dataGridViewKhachHang.Size = new System.Drawing.Size(1128, 188);
            this.dataGridViewKhachHang.TabIndex = 12;
            // 
            // dataGridViewXe
            // 
            this.dataGridViewXe.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewXe.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewXe.Location = new System.Drawing.Point(79, 768);
            this.dataGridViewXe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewXe.Name = "dataGridViewXe";
            this.dataGridViewXe.RowHeadersWidth = 51;
            this.dataGridViewXe.Size = new System.Drawing.Size(1128, 191);
            this.dataGridViewXe.TabIndex = 13;
            this.dataGridViewXe.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewXe_CellContentClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cambria", 12.25F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(1255, 336);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(434, 25);
            this.label11.TabIndex = 34;
            this.label11.Text = "DANH SÁCH PHIẾU THUÊ TRONG HỆ THỐNG";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 12.25F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(1256, 229);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(414, 25);
            this.label9.TabIndex = 33;
            this.label9.Text = "TÌM KIẾM PHIẾU THUÊ TRONG HỆ THỐNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 12.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(73, 498);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(364, 25);
            this.label2.TabIndex = 35;
            this.label2.Text = "CHI TIẾT PHIẾU THUÊ: KHÁCH HÀNG";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 12.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(73, 740);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(316, 25);
            this.label6.TabIndex = 36;
            this.label6.Text = "CHI TIẾT PHIẾU THUÊ: XE THUÊ";
            // 
            // FPhieuThue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.ClientSize = new System.Drawing.Size(2172, 1237);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridViewXe);
            this.Controls.Add(this.dataGridViewKhachHang);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewPhieuThue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FPhieuThue";
            this.Text = "FPhieuThue";
            this.Load += new System.EventHandler(this.FPhieuThue_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhieuThue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoNgayMuon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoPhieuThue;
        private System.Windows.Forms.DataGridView dataGridViewPhieuThue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayThue;
        private System.Windows.Forms.ComboBox comboBoxKhachHang;
        private System.Windows.Forms.ComboBox comboBoxXe;
        private System.Windows.Forms.DataGridView dataGridViewKhachHang;
        private System.Windows.Forms.DataGridView dataGridViewXe;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
    }
}