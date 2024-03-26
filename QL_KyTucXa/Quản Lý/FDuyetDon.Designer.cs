namespace QL_KyTucXa
{
    partial class FDuyetDon
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
            this.cmbLoaiDon = new System.Windows.Forms.ComboBox();
            this.lblNgayVao = new System.Windows.Forms.Label();
            this.txtTenSV = new System.Windows.Forms.TextBox();
            this.dtpNgayVao = new System.Windows.Forms.DateTimePicker();
            this.lblTenSV = new System.Windows.Forms.Label();
            this.dtpNgayRa = new System.Windows.Forms.DateTimePicker();
            this.btnDuyetDon = new System.Windows.Forms.Button();
            this.lblNgayRa = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.lblMa = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.txtLoaiPhong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNguoiThan = new System.Windows.Forms.Label();
            this.lblHoaDon = new System.Windows.Forms.Label();
            this.lblDuyetDon = new System.Windows.Forms.Label();
            this.lblDichVu = new System.Windows.Forms.Label();
            this.lblPhong = new System.Windows.Forms.Label();
            this.lblSinhVien = new System.Windows.Forms.Label();
            this.lblDangXuat = new System.Windows.Forms.Label();
            this.dtgvDuyetDon = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelThongTin = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.rdbNu = new System.Windows.Forms.RadioButton();
            this.rdbNam = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDuyetDon)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbLoaiDon
            // 
            this.cmbLoaiDon.FormattingEnabled = true;
            this.cmbLoaiDon.Items.AddRange(new object[] {
            "Đơn đăng ký",
            "Đơn cho người thân",
            "Đơn xin ra"});
            this.cmbLoaiDon.Location = new System.Drawing.Point(21, 11);
            this.cmbLoaiDon.Margin = new System.Windows.Forms.Padding(2);
            this.cmbLoaiDon.Name = "cmbLoaiDon";
            this.cmbLoaiDon.Size = new System.Drawing.Size(150, 21);
            this.cmbLoaiDon.TabIndex = 58;
            this.cmbLoaiDon.SelectedIndexChanged += new System.EventHandler(this.cmbLoaiDon_SelectedIndexChanged);
            // 
            // lblNgayVao
            // 
            this.lblNgayVao.AutoSize = true;
            this.lblNgayVao.Location = new System.Drawing.Point(324, 69);
            this.lblNgayVao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNgayVao.Name = "lblNgayVao";
            this.lblNgayVao.Size = new System.Drawing.Size(53, 13);
            this.lblNgayVao.TabIndex = 53;
            this.lblNgayVao.Text = "Ngày vào";
            // 
            // txtTenSV
            // 
            this.txtTenSV.Location = new System.Drawing.Point(612, 18);
            this.txtTenSV.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenSV.Name = "txtTenSV";
            this.txtTenSV.Size = new System.Drawing.Size(158, 20);
            this.txtTenSV.TabIndex = 43;
            // 
            // dtpNgayVao
            // 
            this.dtpNgayVao.Location = new System.Drawing.Point(385, 65);
            this.dtpNgayVao.Margin = new System.Windows.Forms.Padding(2);
            this.dtpNgayVao.Name = "dtpNgayVao";
            this.dtpNgayVao.Size = new System.Drawing.Size(151, 20);
            this.dtpNgayVao.TabIndex = 52;
            // 
            // lblTenSV
            // 
            this.lblTenSV.AutoSize = true;
            this.lblTenSV.Location = new System.Drawing.Point(529, 18);
            this.lblTenSV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTenSV.Name = "lblTenSV";
            this.lblTenSV.Size = new System.Drawing.Size(71, 13);
            this.lblTenSV.TabIndex = 42;
            this.lblTenSV.Text = "Tên sinh viên";
            // 
            // dtpNgayRa
            // 
            this.dtpNgayRa.Location = new System.Drawing.Point(605, 64);
            this.dtpNgayRa.Margin = new System.Windows.Forms.Padding(2);
            this.dtpNgayRa.Name = "dtpNgayRa";
            this.dtpNgayRa.Size = new System.Drawing.Size(151, 20);
            this.dtpNgayRa.TabIndex = 50;
            // 
            // btnDuyetDon
            // 
            this.btnDuyetDon.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDuyetDon.Location = new System.Drawing.Point(377, 251);
            this.btnDuyetDon.Margin = new System.Windows.Forms.Padding(2);
            this.btnDuyetDon.Name = "btnDuyetDon";
            this.btnDuyetDon.Size = new System.Drawing.Size(74, 33);
            this.btnDuyetDon.TabIndex = 39;
            this.btnDuyetDon.Text = "Duyệt đơn";
            this.btnDuyetDon.UseVisualStyleBackColor = true;
            this.btnDuyetDon.Click += new System.EventHandler(this.btnDuyetDon_Click);
            // 
            // lblNgayRa
            // 
            this.lblNgayRa.AutoSize = true;
            this.lblNgayRa.Location = new System.Drawing.Point(558, 68);
            this.lblNgayRa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNgayRa.Name = "lblNgayRa";
            this.lblNgayRa.Size = new System.Drawing.Size(44, 13);
            this.lblNgayRa.TabIndex = 51;
            this.lblNgayRa.Text = "Ngày ra";
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(404, 15);
            this.txtMaSV.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(104, 20);
            this.txtMaSV.TabIndex = 40;
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(325, 18);
            this.lblMa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(81, 13);
            this.lblMa.TabIndex = 38;
            this.lblMa.Text = "Mã số sinh viên";
            // 
            // btnHuy
            // 
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Location = new System.Drawing.Point(471, 251);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(56, 33);
            this.btnHuy.TabIndex = 12;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // txtLoaiPhong
            // 
            this.txtLoaiPhong.Location = new System.Drawing.Point(268, 92);
            this.txtLoaiPhong.Margin = new System.Windows.Forms.Padding(2);
            this.txtLoaiPhong.Name = "txtLoaiPhong";
            this.txtLoaiPhong.Size = new System.Drawing.Size(104, 20);
            this.txtLoaiPhong.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "Loại Phòng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 66;
            this.label5.Text = "Ngày sinh";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(50, 51);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(104, 20);
            this.txtEmail.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Email";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(50, 92);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(2);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(104, 20);
            this.txtSDT.TabIndex = 65;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.lblNguoiThan);
            this.panel1.Controls.Add(this.lblHoaDon);
            this.panel1.Controls.Add(this.lblDuyetDon);
            this.panel1.Controls.Add(this.lblDichVu);
            this.panel1.Controls.Add(this.lblPhong);
            this.panel1.Controls.Add(this.lblSinhVien);
            this.panel1.Controls.Add(this.lblDangXuat);
            this.panel1.Location = new System.Drawing.Point(0, 119);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 35);
            this.panel1.TabIndex = 24;
            // 
            // lblNguoiThan
            // 
            this.lblNguoiThan.AutoSize = true;
            this.lblNguoiThan.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNguoiThan.ForeColor = System.Drawing.Color.White;
            this.lblNguoiThan.Location = new System.Drawing.Point(508, 8);
            this.lblNguoiThan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNguoiThan.Name = "lblNguoiThan";
            this.lblNguoiThan.Size = new System.Drawing.Size(86, 17);
            this.lblNguoiThan.TabIndex = 21;
            this.lblNguoiThan.Text = "Người thân";
            this.lblNguoiThan.Click += new System.EventHandler(this.lblNguoiThan_Click);
            // 
            // lblHoaDon
            // 
            this.lblHoaDon.AutoSize = true;
            this.lblHoaDon.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblHoaDon.ForeColor = System.Drawing.Color.White;
            this.lblHoaDon.Location = new System.Drawing.Point(417, 8);
            this.lblHoaDon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHoaDon.Name = "lblHoaDon";
            this.lblHoaDon.Size = new System.Drawing.Size(67, 17);
            this.lblHoaDon.TabIndex = 13;
            this.lblHoaDon.Text = "Hóa đơn";
            this.lblHoaDon.Click += new System.EventHandler(this.lblHoaDon_Click);
            // 
            // lblDuyetDon
            // 
            this.lblDuyetDon.AutoSize = true;
            this.lblDuyetDon.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDuyetDon.ForeColor = System.Drawing.Color.White;
            this.lblDuyetDon.Location = new System.Drawing.Point(308, 8);
            this.lblDuyetDon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDuyetDon.Name = "lblDuyetDon";
            this.lblDuyetDon.Size = new System.Drawing.Size(80, 17);
            this.lblDuyetDon.TabIndex = 12;
            this.lblDuyetDon.Text = "Duyệt đơn";
            this.lblDuyetDon.Click += new System.EventHandler(this.lblDuyetDon_Click);
            // 
            // lblDichVu
            // 
            this.lblDichVu.AutoSize = true;
            this.lblDichVu.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDichVu.ForeColor = System.Drawing.Color.White;
            this.lblDichVu.Location = new System.Drawing.Point(215, 8);
            this.lblDichVu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDichVu.Name = "lblDichVu";
            this.lblDichVu.Size = new System.Drawing.Size(58, 17);
            this.lblDichVu.TabIndex = 11;
            this.lblDichVu.Text = "Dịch vụ";
            this.lblDichVu.Click += new System.EventHandler(this.lblDichVu_Click);
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPhong.ForeColor = System.Drawing.Color.White;
            this.lblPhong.Location = new System.Drawing.Point(27, 8);
            this.lblPhong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(53, 17);
            this.lblPhong.TabIndex = 10;
            this.lblPhong.Text = "Phòng";
            this.lblPhong.Click += new System.EventHandler(this.lblPhong_Click);
            // 
            // lblSinhVien
            // 
            this.lblSinhVien.AutoSize = true;
            this.lblSinhVien.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSinhVien.ForeColor = System.Drawing.Color.White;
            this.lblSinhVien.Location = new System.Drawing.Point(112, 8);
            this.lblSinhVien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSinhVien.Name = "lblSinhVien";
            this.lblSinhVien.Size = new System.Drawing.Size(72, 17);
            this.lblSinhVien.TabIndex = 9;
            this.lblSinhVien.Text = "Sinh Viên";
            this.lblSinhVien.Click += new System.EventHandler(this.lblSinhVien_Click);
            // 
            // lblDangXuat
            // 
            this.lblDangXuat.AutoSize = true;
            this.lblDangXuat.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDangXuat.ForeColor = System.Drawing.Color.White;
            this.lblDangXuat.Location = new System.Drawing.Point(705, 8);
            this.lblDangXuat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDangXuat.Name = "lblDangXuat";
            this.lblDangXuat.Size = new System.Drawing.Size(80, 17);
            this.lblDangXuat.TabIndex = 6;
            this.lblDangXuat.Text = "Đăng xuất";
            this.lblDangXuat.Click += new System.EventHandler(this.lblDangXuat_Click);
            // 
            // dtgvDuyetDon
            // 
            this.dtgvDuyetDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDuyetDon.Location = new System.Drawing.Point(9, 41);
            this.dtgvDuyetDon.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvDuyetDon.Name = "dtgvDuyetDon";
            this.dtgvDuyetDon.RowHeadersWidth = 51;
            this.dtgvDuyetDon.RowTemplate.Height = 24;
            this.dtgvDuyetDon.Size = new System.Drawing.Size(298, 256);
            this.dtgvDuyetDon.TabIndex = 26;
            this.dtgvDuyetDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDuyetDon_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelThongTin);
            this.panel2.Controls.Add(this.cmbLoaiDon);
            this.panel2.Controls.Add(this.lblNgayVao);
            this.panel2.Controls.Add(this.txtTenSV);
            this.panel2.Controls.Add(this.dtpNgayVao);
            this.panel2.Controls.Add(this.lblTenSV);
            this.panel2.Controls.Add(this.dtpNgayRa);
            this.panel2.Controls.Add(this.btnDuyetDon);
            this.panel2.Controls.Add(this.lblNgayRa);
            this.panel2.Controls.Add(this.txtMaSV);
            this.panel2.Controls.Add(this.lblMa);
            this.panel2.Controls.Add(this.dtgvDuyetDon);
            this.panel2.Controls.Add(this.btnHuy);
            this.panel2.Location = new System.Drawing.Point(4, 158);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(775, 299);
            this.panel2.TabIndex = 25;
            // 
            // panelThongTin
            // 
            this.panelThongTin.Controls.Add(this.txtLoaiPhong);
            this.panelThongTin.Controls.Add(this.label3);
            this.panelThongTin.Controls.Add(this.label5);
            this.panelThongTin.Controls.Add(this.txtEmail);
            this.panelThongTin.Controls.Add(this.label1);
            this.panelThongTin.Controls.Add(this.txtSDT);
            this.panelThongTin.Controls.Add(this.label8);
            this.panelThongTin.Controls.Add(this.dtpNgaySinh);
            this.panelThongTin.Controls.Add(this.rdbNu);
            this.panelThongTin.Controls.Add(this.rdbNam);
            this.panelThongTin.Controls.Add(this.label7);
            this.panelThongTin.Location = new System.Drawing.Point(327, 110);
            this.panelThongTin.Margin = new System.Windows.Forms.Padding(2);
            this.panelThongTin.Name = "panelThongTin";
            this.panelThongTin.Size = new System.Drawing.Size(428, 116);
            this.panelThongTin.TabIndex = 59;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 92);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 63;
            this.label8.Text = "SDT";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Location = new System.Drawing.Point(268, 6);
            this.dtpNgaySinh.Margin = new System.Windows.Forms.Padding(2);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(151, 20);
            this.dtpNgaySinh.TabIndex = 61;
            // 
            // rdbNu
            // 
            this.rdbNu.AutoSize = true;
            this.rdbNu.Location = new System.Drawing.Point(119, 6);
            this.rdbNu.Margin = new System.Windows.Forms.Padding(2);
            this.rdbNu.Name = "rdbNu";
            this.rdbNu.Size = new System.Drawing.Size(39, 17);
            this.rdbNu.TabIndex = 60;
            this.rdbNu.TabStop = true;
            this.rdbNu.Text = "Nữ";
            this.rdbNu.UseVisualStyleBackColor = true;
            // 
            // rdbNam
            // 
            this.rdbNam.AutoSize = true;
            this.rdbNam.Location = new System.Drawing.Point(62, 6);
            this.rdbNam.Margin = new System.Windows.Forms.Padding(2);
            this.rdbNam.Name = "rdbNam";
            this.rdbNam.Size = new System.Drawing.Size(47, 17);
            this.rdbNam.TabIndex = 59;
            this.rdbNam.TabStop = true;
            this.rdbNam.Text = "Nam";
            this.rdbNam.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 6);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 58;
            this.label7.Text = "Giới tính";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QL_KyTucXa.Properties.Resources.panel;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(794, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // FDuyetDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 462);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FDuyetDon";
            this.Text = "FDuyetDon";
            this.Load += new System.EventHandler(this.FDuyetDon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDuyetDon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelThongTin.ResumeLayout(false);
            this.panelThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLoaiDon;
        private System.Windows.Forms.Label lblNgayVao;
        private System.Windows.Forms.TextBox txtTenSV;
        private System.Windows.Forms.DateTimePicker dtpNgayVao;
        private System.Windows.Forms.Label lblTenSV;
        private System.Windows.Forms.DateTimePicker dtpNgayRa;
        private System.Windows.Forms.Button btnDuyetDon;
        private System.Windows.Forms.Label lblNgayRa;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.TextBox txtLoaiPhong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNguoiThan;
        private System.Windows.Forms.Label lblHoaDon;
        private System.Windows.Forms.Label lblDuyetDon;
        private System.Windows.Forms.Label lblDichVu;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.Label lblSinhVien;
        private System.Windows.Forms.Label lblDangXuat;
        private System.Windows.Forms.DataGridView dtgvDuyetDon;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelThongTin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.RadioButton rdbNu;
        private System.Windows.Forms.RadioButton rdbNam;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}