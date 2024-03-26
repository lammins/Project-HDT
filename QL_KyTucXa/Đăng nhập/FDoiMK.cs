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
    public partial class FDoiMK : Form
    {
        QLKYTUCXAEntities db = new QLKYTUCXAEntities();
        List<TaiKhoan> dsTaiKhoan = new List<TaiKhoan>();
        public FDoiMK()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtCurrentPass.Text.Trim();
            string newPass = txtNewPass.Text.Trim();
            string cfPass = txtConfirmPass.Text.Trim();

            if (newPass != cfPass)
            {
                MessageBox.Show("Mật khẩu mới không trùng nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TaiKhoan taiKhoan = db.TaiKhoans.FirstOrDefault(tk => tk.TenTaiKhoan == user && tk.MatKhau == pass);

            if (taiKhoan != null)
            {
                taiKhoan.MatKhau = newPass;
                // Lưu thay đổi vào cơ sở dữ liệu
                db.SaveChanges();
                MessageBox.Show("Mật khẩu đã được thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtCurrentPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' || e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Ngăn chặn ký tự được nhập vào
            }
        }

        private void txtNewPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' || e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Ngăn chặn ký tự được nhập vào
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' || e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Ngăn chặn ký tự được nhập vào
            }
        }

        private void txtConfirmPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' || e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Ngăn chặn ký tự được nhập vào
            }
        }

        private void lblBackToLogin_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            this.Hide();
            dangNhap.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
