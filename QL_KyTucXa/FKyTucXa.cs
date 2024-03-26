using QL_KyTucXa.Đăng_nhập;
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
    public partial class FKyTucXa : Form
    {
        public FKyTucXa()
        {
            InitializeComponent();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            FMainSinhVien msv = new FMainSinhVien();            
            msv.Show();

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FDangNhap_Admin dna = new FDangNhap_Admin();
            dna.Show();
        }
    }
}
