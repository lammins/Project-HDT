using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KyTucXa.Sinh_viên
{
    public partial class FDangKyDichVu : Form
    {
        QLKYTUCXAEntities db = new QLKYTUCXAEntities();
        List<DichVu> dichVus = new List<DichVu>();
        List<DangKyDichVu> dangKyDichVus = new List<DangKyDichVu>();
        DichVu dichVu = null;
        DangKyDichVu dangKyDichVu = null;
        public FDangKyDichVu(string masv)
        {
            InitializeComponent();
            txtMaSV.Text = masv;
        }

        void loadData()
        {
            dtgvDichVu.DataSource = dichVus;
            dtgvDichVu.Columns[3].Width = 0;
            dtgvDichVu.Columns[3].Visible = false;

            int width = dtgvDichVu.Width;
            dtgvDichVu.Columns[0].Width = width * 20 / 100;
            dtgvDichVu.Columns[1].Width = width * 50 / 100;
            dtgvDichVu.Columns[2].Width = width * 20 / 100;
        }

        void showDichVu(DichVu a)
        {
            txtDichVu.Text = a.TenDV;
        }

        private void FDangKyDichVu_Load(object sender, EventArgs e)
        {
            dichVus = db.DichVus.ToList();
            loadData();
            if (dichVus.Count > 0)
            {
                dichVu = dichVus[0];
                showDichVu(dichVu);
            }
        }

        private void dtgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtgvDichVu.CurrentRow;
            int index = row.Index;
            if (index >= dtgvDichVu.Rows.Count)
                return;
            dichVu = dichVus[index];
            showDichVu(dichVu);
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dtgvDichVu.CurrentRow;
            int index = row.Index;
            if (index >= dtgvDichVu.Rows.Count)
                return;
            dichVu = dichVus[index];
            string id = dichVu.MaDV + txtMaSV.Text;
            string madichvu = dichVu.MaDV;
            string masinhvien = txtMaSV.Text;
            dangKyDichVu = new DangKyDichVu();
            dangKyDichVu.Id = id;
            dangKyDichVu.MaDV = madichvu;
            dangKyDichVu.MaSV = masinhvien;

            List<DangKyDichVu> x = dangKyDichVus.Where(t => t.Id == id).ToList();
            if (x.Count > 0)
            {
                MessageBox.Show("Bạn đã đăng ký dịch vụ này.");
                return;
            }

            if (dangKyDichVus.Contains(dangKyDichVu))
            {
                MessageBox.Show("Dịch vụ này đã được đăng ký.");
                return;
            }
            dangKyDichVus.Add(dangKyDichVu);

            db.DangKyDichVus.Add(dangKyDichVu);
            db.SaveChanges();

            MessageBox.Show("Bạn đã đăng ký dịch vụ này thành công!.");
        }


        private void lblThongTinCN_Click(object sender, EventArgs e)
        {
            this.Hide();
            string masv = txtMaSV.Text;
            FThongTinCN chuyen = new FThongTinCN(masv);
            chuyen.Show();
        }

        private void lblTaiChinhSV_Click(object sender, EventArgs e)
        {
            this.Hide();
            string masv = txtMaSV.Text;
            FTaiChinhSV chuyen = new FTaiChinhSV(masv);
            chuyen.Show();
        }

        private void lblXinGiayXN_Click(object sender, EventArgs e)
        {
            this.Hide();
            string masv = txtMaSV.Text;
            FXinGiayXacNhan chuyen = new FXinGiayXacNhan(masv);
            chuyen.Show();

        }

        private void lblDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void lblDangKyDichVu_Click(object sender, EventArgs e)
        {

        }

        private void dtgvDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
