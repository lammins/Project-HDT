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

namespace QL_KyTucXa.Sinh_viên
{
    public partial class FThongTinCN : Form
    {
        QLKYTUCXAEntities db = new QLKYTUCXAEntities();

        List<SinhVien> dsSinhVien = new List<SinhVien>();
        public FThongTinCN(string maSinhVien)
        {
            InitializeComponent();
            txtMaSV.Text = maSinhVien;
        }

        private void FThongTinCN_Load(object sender, EventArgs e)
        {
            string masv = txtMaSV.Text;
            dsSinhVien = db.SinhViens.Where(sv => sv.MaSV == masv).ToList();

            if (dsSinhVien.Count > 0)
            {
                SinhVien sinhVien = dsSinhVien[0];
                txtTenSV.Text = sinhVien.TenSV;
                txtSDT.Text = sinhVien.SDT;
                txtLoaiPhong.Text = sinhVien.LoaiPhong;
                dtpNgayVao.Value = sinhVien.NgayVao.Value;
                dtpNgaySinh.Value = sinhVien.NgaySinh.Value;
                //dtpNgayRa.Value = sinhVien.NgayRa.Value;
                if (sinhVien.GioiTinh == "Nam")
                {
                    rdbNam.Checked = true;
                    rdbNu.Checked = false;
                }
                else
                {
                    rdbNu.Checked = true;
                    rdbNam.Checked = false;
                }
            }
        }

        private void lblDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.Show();
            dn = null;
        }

        private void lblXinGiayXN_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            
        }

        private void lblTaiChinhSV_Click(object sender, EventArgs e)
        {
            this.Hide();
            string masv = txtMaSV.Text;
            FTaiChinhSV chuyen = new FTaiChinhSV(masv);
            chuyen.Show();
        }

        private void lblXinGiayXN_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            string masv = txtMaSV.Text;
            FXinGiayXacNhan chuyen = new FXinGiayXacNhan(masv);
            chuyen.Show();
        }

        private void lblDangKyDichVu_Click(object sender, EventArgs e)
        {
            this.Hide();
            string masv = txtMaSV.Text;
            FDangKyDichVu chuyen = new FDangKyDichVu(masv);
            chuyen.Show();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
