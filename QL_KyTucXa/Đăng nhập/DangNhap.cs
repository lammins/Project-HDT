using QL_KyTucXa.Đăng_nhập;
using QL_KyTucXa.Sinh_viên;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KyTucXa
{
    public partial class DangNhap : Form
    {
        QLKYTUCXAEntities db = new QLKYTUCXAEntities();

        List<TaiKhoan> dsTaiKhoan = new List<TaiKhoan>();
        List<SinhVien> dsSinhVien = new List<SinhVien>();
        SinhVien sinhVien = new SinhVien();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();



            dsTaiKhoan = db.TaiKhoans.ToList();
            bool dangNhapThanhCong = false;
            foreach (TaiKhoan taiKhoan in dsTaiKhoan)
            {
                if (user == taiKhoan.TenTaiKhoan && pass == taiKhoan.MatKhau)
                {
                    dangNhapThanhCong = true;
                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FThongTinCN thongTin = new FThongTinCN(user);
                    this.Hide();
                    thongTin.Show();
                    break;
                }
            }

            if (!dangNhapThanhCong)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' || e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' || e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void llForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            FDoiMK doiMK = new FDoiMK();
            this.Hide();
            doiMK.Show();
        }

        private void btnSigup_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            FDangKy dangKy = new FDangKy();
            this.Hide();
            dangKy.Show();
        }

        private void panel_Login_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            lblSinhVien.Parent = ptb_Wallpaper_VLU;
            lblSinhVien.BackColor = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            FKyTucXa ktx = new FKyTucXa();
            this.Hide();
            ktx.Show();
        }
    }
}
