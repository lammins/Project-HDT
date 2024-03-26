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
    public partial class FMainSinhVien : Form
    {
        public FMainSinhVien()
        {
            InitializeComponent();
        }

        private void FMainSinhVien_Load(object sender, EventArgs e)
        {

        }

        private void lblDangNhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap chuyen = new DangNhap();
            chuyen.Show();
  
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
