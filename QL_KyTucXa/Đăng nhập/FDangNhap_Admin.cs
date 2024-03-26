using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KyTucXa.Đăng_nhập
{
    public partial class FDangNhap_Admin : Form
    {
        QLKYTUCXAEntities db = new QLKYTUCXAEntities();
        List<Admin> dsAdmin = new List<Admin>();
        public FDangNhap_Admin()
        {
            InitializeComponent();
        }

        private void llContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            dsAdmin = db.Admins.ToList();

            bool dangNhapThanhCong = false;
            foreach (Admin taiKhoan in dsAdmin)
            {
                if (user == taiKhoan.TenDangNhap && pass == taiKhoan.MatKhau)
                {
                    dangNhapThanhCong = true;
                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FDuyetDon duyetDon = new FDuyetDon();
                    this.Hide();
                    duyetDon.Show();
                    break;
                }
            }

            if (!dangNhapThanhCong)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FDangNhap_Admin_Load(object sender, EventArgs e)
        {
            lblAdmin.Parent = ptb_Wallpaper_VLU;
            lblAdmin.BackColor = Color.Transparent;
        }

        private void lblSystem_Click(object sender, EventArgs e)
        {
            FKyTucXa ktx = new FKyTucXa();
            this.Hide();
            ktx.Show();
        }
    }
}
