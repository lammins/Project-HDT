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
    public partial class FTaiChinhSV : Form
    {
        QLKYTUCXAEntities db = new QLKYTUCXAEntities();
        List<HoaDon> hd = new List<HoaDon>();
        public FTaiChinhSV(string maSinhVien)
        {
            InitializeComponent();
            txtMaSV.Text = maSinhVien;
        }
        void loadDataTCSV()
        {
            dtgvTaiChinh.DataSource = hd;
        }
        private void FTaiChinhSV_Load(object sender, EventArgs e)
        {
            string masv = txtMaSV.Text;
            hd = db.HoaDons.Where(t => t.MaSV == masv).ToList();
            loadDataTCSV();
        }

        private void dtgvTaiChinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblThongTinCN_Click(object sender, EventArgs e)
        {
            this.Hide();
            string masv = txtMaSV.Text;
            FThongTinCN chuyen = new FThongTinCN(masv);
            chuyen.Show();
        }

        private void lblXinGiayXN_Click(object sender, EventArgs e)
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

        private void lblDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
