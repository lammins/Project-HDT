using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KyTucXa.Quản_Lý
{
    public partial class FQuanLyNguoiThan : Form
    {
        QLKYTUCXAEntities db = new QLKYTUCXAEntities();
        List<SinhVien> sinhViens = new List<SinhVien>();
        SinhVien sinhVien = null;
        List<DonXinTham> donXinThams = new List<DonXinTham>();
        DonXinTham donXinTham = null;
        public FQuanLyNguoiThan()
        {
            InitializeComponent();
        }
        void loadDataSinhVien()
        {
            dtgvSv.DataSource = sinhViens;
            dtgvSv.Columns[14].Width = 0;
            dtgvSv.Columns[14].Visible = false;
            dtgvSv.Columns[15].Width = 0;
            dtgvSv.Columns[15].Visible = false;
            dtgvSv.Columns[16].Width = 0;
            dtgvSv.Columns[16].Visible = false;
            dtgvSv.Columns[17].Width = 0;
            dtgvSv.Columns[17].Visible = false;
            int width = panel1.Width;
            dtgvSv.Columns[0].Width = width * 10 / 100;
            dtgvSv.Columns[1].Width = width * 15 / 100;
            dtgvSv.Columns[2].Width = width * 15 / 100;
            dtgvSv.Columns[3].Width = width * 15 / 100;
            dtgvSv.Columns[4].Width = width * 15 / 100;
            dtgvSv.Columns[5].Width = width * 15 / 100;
            dtgvSv.Columns[6].Width = width * 15 / 100;
            dtgvSv.Columns[7].Width = width * 15 / 100;
            dtgvSv.Columns[8].Width = width * 15 / 100;
            dtgvSv.Columns[9].Width = width * 15 / 100;
            dtgvSv.Columns[10].Width = width * 15 / 100;
            dtgvSv.Columns[11].Width = width * 15 / 100;
            dtgvSv.Columns[12].Width = width * 15 / 100;
            dtgvSv.Columns[13].Width = width * 15 / 100;
            dtgvSv.Columns[14].Width = width * 15 / 100;
        }
        void loadDataNguoiThan(List<DonXinTham> x)
        {
            dtgvNguoiThan.Rows.Clear();
            foreach (DonXinTham a in x)
            {
                DataGridViewRow row = new DataGridViewRow();
                if ( a.DuyetDon != "Chưa duyệt")
                {
                    row.CreateCells(dtgvNguoiThan);
                    row.Cells[0].Value = a.MaDon;
                    row.Cells[1].Value = a.TenNguoiThan;
                    row.Cells[2].Value = a.MaSV;
                    row.Cells[3].Value = a.QuanHe;
                    row.Cells[4].Value = a.NgayXin;
                    row.Cells[5].Value = a.ThoiGian;
                    row.Cells[6].Value = a.DuyetDon;
                    
                } 
                dtgvNguoiThan.Rows.Add(row);
            }
            
        }
        void loadSinhVien(SinhVien x)
        {
            txtMaSV.Text = x.MaSV + "";
            txtTenSV.Text = x.TenSV + "";
            cmbGioiTinh.Text = x.GioiTinh + "";
            txtSDT.Text = x.SDT + "";
            txtLoaiPhong.Text = x.LoaiPhong + "";
            dtpNgaySinh.Value = x.NgaySinh.Value;
            dtpNgayVao.Value = x.NgayVao.Value;
            //dtpNgayRa.Value = x.NgayRa.Value;
        } 
        
        private void FQuanLyNguoiThan_Load(object sender, EventArgs e)
        {
           

            dtgvNguoiThan.Columns.Add("MaDon", "Mã Đơn");
            dtgvNguoiThan.Columns.Add("TenNguoiThan", "Tên Người Thân");
            dtgvNguoiThan.Columns.Add("MaSV", "Mã Sinh Viên");
            dtgvNguoiThan.Columns.Add("QuanHe", "Quan hệ");
            dtgvNguoiThan.Columns.Add("NgayXin", "Ngày Xin");
            dtgvNguoiThan.Columns.Add("ThoiGian", "Thời Gian");
            dtgvNguoiThan.Columns.Add("DuyetDon", "Duyệt Đơn");

            sinhViens = db.SinhViens.ToList();
            donXinThams = db.DonXinThams.ToList();
            loadDataSinhVien();

            if (sinhViens.Count > 0)
            {
                sinhVien = sinhViens[0];
                loadDataNguoiThan(sinhVien.DonXinThams.ToList());
            }
            loadSinhVien(sinhVien);
        }

        private void dtgvSv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtgvSv.CurrentRow;
            int index = row.Index;
            if (index >= dtgvSv.Rows.Count)
                return;
            sinhVien = sinhViens[index];
            loadSinhVien(sinhVien);
            //dtGridViewDauSach.DataSource = loaiSach.DauSaches.ToList() ;
            loadDataNguoiThan(sinhVien.DonXinThams.ToList());
            
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyWord = txtTimKiem.Text.Trim();
            dtgvSv.DataSource = db.SinhViens.Where(t => t.TenSV.Contains(keyWord) 
            || t.MaSV.Contains(keyWord) || t.Email.Contains(keyWord) 
            || t.GioiTinh.Contains(keyWord) || t.SDT.Contains(keyWord) 
            || t.MaPhong.Contains(keyWord) || t.LoaiPhong.Contains(keyWord)).ToList();
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
            this.Hide();
            FQuanLyDichVu chuyen = new FQuanLyDichVu();
            chuyen.Show();
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

        private void lblDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.Show();
            
        }

        private void dtgvNguoiThan_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
