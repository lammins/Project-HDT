using QL_KyTucXa.Quản_Lý;
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
    public partial class FQuanLyDichVu : Form
    {
        QLKYTUCXAEntities db = new QLKYTUCXAEntities();
        List<DichVu> dichVus = new List<DichVu>();
        List<SinhVien> sinhViens = new List<SinhVien>();
        List<DangKyDichVu> dangKyDichVus = new List<DangKyDichVu>();
        DichVu dichVu = null;
        SinhVien sinhVien = null;
        DangKyDichVu dangKyDichVu = null;
        public FQuanLyDichVu()
        {
            InitializeComponent();
        }

        void loadData()
        {
            dtgvDichVu.DataSource = dichVus;
            dtgvDichVu.Columns[3].Width = 0;
            dtgvDichVu.Columns[3].Visible = false;

            int width = dtgvDichVu.Width;
            dtgvDichVu.Columns[0].Width = width * 20 / 100;
            dtgvDichVu.Columns[1].Width = width * 40 / 100;
            dtgvDichVu.Columns[2].Width = width * 25 / 100;
        }


        void loadDataSinhVien(List<DangKyDichVu> x)
        {
            dtgvSinhVien.Rows.Clear();

            foreach (DangKyDichVu a in x)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtgvSinhVien);
                row.Cells[0].Value = a.MaSV;
                row.Cells[1].Value = a.SinhVien.TenSV;
                row.Cells[2].Value = a.SinhVien.MaPhong;
                dtgvSinhVien.Rows.Add(row);
            }
        }

        void showDichVu(DichVu a)
        {
            txtMaDichVu.Text = a.MaDV;
            txtDichVu.Text = a.TenDV;
            txtGiaTien.Text = a.GiaTien + "";
        }

        private void FQuanLyDichVu_Load(object sender, EventArgs e)
        {
            dichVus = db.DichVus.ToList();
            sinhViens = db.SinhViens.ToList();
            dangKyDichVus = db.DangKyDichVus.ToList();
            loadData();
            if (dichVus.Count > 0)
            {
                dichVu = dichVus[0];
                dtgvSinhVien.Columns.Add("MaSV", "Mã sinh viên");
                dtgvSinhVien.Columns.Add("TenSV", "Tên sinh viên");
                dtgvSinhVien.Columns.Add("MaPhong", "Mã phòng");
                loadDataSinhVien(dichVu.DangKyDichVus.ToList());
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
            txtMaDichVu.Text = dichVu.MaDV;
            txtDichVu.Text = dichVu.TenDV;
            txtGiaTien.Text = dichVu.GiaTien + "";
            loadDataSinhVien(dichVu.DangKyDichVus.ToList());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string madv = txtMaDichVu.Text;
            string tendv = txtDichVu.Text;
            decimal giatien = decimal.Parse(txtGiaTien.Text);
            dichVu = new DichVu();
            dichVu.MaDV = madv;
            dichVu.TenDV = tendv;
            dichVu.GiaTien = giatien;

            List<DichVu> x = dichVus.Where(t => t.MaDV == madv || t.TenDV.Equals(dichVu.TenDV)).ToList();
            if (x.Count > 0)
            {
                MessageBox.Show("Nhập mã khác để thêm");
                return;
            }

            if (dichVus.Contains(dichVu))
            {
                MessageBox.Show("Dịch vụ này đã tồn tại.");
                return;
            }
            dichVus.Add(dichVu);
            dtgvDichVu.DataSource = null;
            loadData();

            db.DichVus.Add(dichVu);
            db.SaveChanges();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dichVu == null) return;
            string madv = txtMaDichVu.Text;
            string tendv = txtDichVu.Text.Trim();
            decimal giatien = decimal.Parse(txtGiaTien.Text);
            List<DichVu> listkiemtra = dichVus.Where(t => t.TenDV == tendv && t.MaDV != madv).ToList();
            if (listkiemtra.Count > 0)
            {
                MessageBox.Show("Dịch vụ này đã có !!!");
                return;
            }
            if (dichVu == null) return;
            dichVu.TenDV = txtDichVu.Text;
            dichVu.GiaTien = decimal.Parse(txtGiaTien.Text);
            dtgvDichVu.DataSource = null;
            loadData();
            db.SaveChanges();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dichVu == null) return;
                db.DichVus.Remove(dichVu);
                db.SaveChanges();
                dichVus.Remove(dichVu);
                dtgvDichVu.DataSource = null;
                loadData();
                dichVu = null;
            }
            catch { }
        }

        private void lblPhong_Click(object sender, EventArgs e)
        {
            this.Hide();
            FQuanLyPhong chuyen = new FQuanLyPhong();
            chuyen.Show();
            
        }

        private void lblSinhVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            FQuanLySinhVien chuyen = new FQuanLySinhVien();
            chuyen.Show();
            
        }

        private void lblDichVu_Click(object sender, EventArgs e)
        {

        }

        private void lblDuyetDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            FDuyetDon chuyen = new FDuyetDon();
            chuyen.Show();
            
        }

        private void lblHoaDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            FQuanLyHoaDon chuyen = new FQuanLyHoaDon();
            chuyen.Show();
            
        }

        private void lblNguoiThan_Click(object sender, EventArgs e)
        {
            this.Hide();
            FQuanLyNguoiThan chuyen = new FQuanLyNguoiThan();
            chuyen.Show();
            
        }

        private void lblDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.Show();
            
        }

        private void dtgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
