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
    public partial class FQuanLyHoaDon : Form
    {
        QLKYTUCXAEntities db = new QLKYTUCXAEntities();
        List<SinhVien> sinhViens = new List<SinhVien>();
        SinhVien sv = null;
        List<HoaDon> hoaDons = new List<HoaDon>();
        HoaDon hd = null;
        List<DichVu> DichVus = new List<DichVu>();
        DichVu dv = null;
        List<Phong> Phongs = new List<Phong>();
        Phong p = null;
        List<DangKyDichVu> dangKyDichVus = new List<DangKyDichVu>();
        DangKyDichVu dangKyDichVu = null;
        public FQuanLyHoaDon()
        {
            InitializeComponent();
        }
        void loadDataHD()
        {
            dtgvHoaDon.DataSource = hoaDons;
            dtgvSinhVien.Columns[7].Width = 0;
            dtgvSinhVien.Columns[7].Visible = false;
        }
        void loadDataSV()
        {
            dtgvSinhVien.DataSource = sinhViens;
            dtgvSinhVien.Columns[10].Width = 0;
            dtgvSinhVien.Columns[10].Visible = false;
            dtgvSinhVien.Columns[11].Width = 0;
            dtgvSinhVien.Columns[11].Visible = false;
            dtgvSinhVien.Columns[12].Width = 0;
            dtgvSinhVien.Columns[12].Visible = false;
            dtgvSinhVien.Columns[13].Width = 0;
            dtgvSinhVien.Columns[13].Visible = false;
            dtgvSinhVien.Columns[14].Width = 0;
            dtgvSinhVien.Columns[14].Visible = false;
            dtgvSinhVien.Columns[15].Width = 0;
            dtgvSinhVien.Columns[15].Visible = false;
            dtgvSinhVien.Columns[16].Width = 0;
            dtgvSinhVien.Columns[16].Visible = false;
            dtgvSinhVien.Columns[17].Width = 0;
            dtgvSinhVien.Columns[17].Visible = false;

        }
        void loadDataSinhVien(SinhVien x)
        {
            txtMaSV.Text = x.MaSV;
            txtTenSV.Text = x.TenSV;
            txtSDT.Text = x.SDT;
            cmbGioiTinh.Text = x.GioiTinh;
            txtLoaiPhong.Text = x.LoaiPhong;
            dtpNgaySinh.Value = x.NgaySinh.Value;
            dtpNgayVao.Value = x.NgayVao.Value;
            //dtpNgayRa.Value = x.NgayRa.Value;
        }

        void loadDataHoaDon(List<HoaDon> x)
        {
            dtgvHoaDon.Rows.Clear();
            foreach (HoaDon a in x)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtgvHoaDon);
                row.Cells[0].Value = a.MaHD;
                row.Cells[1].Value = a.TienDien;
                row.Cells[2].Value = a.TienNuoc;
                row.Cells[3].Value = a.TienPhong;
                row.Cells[4].Value = a.TienDV;
                row.Cells[5].Value = a.NgayXuatHoaDon;
                dtgvHoaDon.Rows.Add(row);
            }
            if (x.Count > 0)
            {
                loadDataSinhVien(x[0]);
                hd = x[0];
            }
        }

        private void loadDataSinhVien(HoaDon hoaDon)
        {
            throw new NotImplementedException();
        }

        private void FQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            sinhViens = db.SinhViens.Where(sv => sv.DuyetDon != "Chưa duyệt").ToList();
            hoaDons = db.HoaDons.ToList();
            Phongs = db.Phongs.ToList();
            dangKyDichVus = db.DangKyDichVus.ToList();
            DichVus = db.DichVus.ToList();
            loadDataSV();
            if (sinhViens.Count > 0)
            {
                sv = sinhViens[0];
                //loadDataHoaDon(sv.HoaDons.ToList());
                loadDataSinhVien(sv);                
            }
        }

        private void dtgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtgvSinhVien.CurrentRow;
            int index = row.Index;
            if (index >= dtgvSinhVien.Rows.Count)
                return;
            sv = sinhViens[index];
            txtMaSV.Text = sv.MaSV;
            txtTenSV.Text = sv.TenSV;
            txtSDT.Text = sv.SDT;
            cmbGioiTinh.Text = sv.GioiTinh;
            txtLoaiPhong.Text = sv.LoaiPhong;
            dtpNgaySinh.Value = sv.NgaySinh.Value;
            dtpNgayVao.Value = sv.NgayVao.Value;
            //dtpNgayRa.Value = sv.NgayRa.Value;
            dtgvHoaDon.DataSource = sv.HoaDons.ToList();
        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            string masv = txtMaSV.Text;
            DateTime day = DateTime.Now;
            string strDay = day.ToString("yyyyMMHHmmss");
            string mahd = strDay;
            decimal tiendien = 22104;
            decimal tiennuoc = 22104;
            decimal tienphong = 0;
            decimal tiendichvu = 0;
            DateTime ngayxuathd = DateTime.Now;

            DataGridViewRow row = dtgvSinhVien.CurrentRow;
            int index = row.Index;
            if (index >= dtgvSinhVien.Rows.Count)
                return;
            sv = sinhViens[index];
            string maphong = sv.MaPhong;

            hd = new HoaDon();

            List<DangKyDichVu> dk = dangKyDichVus.Where(d => d.MaSV == masv).ToList();
            if (dk.Count > 0)
            {
                var sum = (from y in dk
                           join dv in DichVus on y.MaDV equals dv.MaDV
                           select dv.GiaTien).Sum();
                tiendichvu = (decimal)sum;
            }

            List<Phong> ph = Phongs.Where(p => p.MaPhong == maphong).ToList();
            if (ph.Count > 0)
            {
                p = ph[0];
                tienphong = (decimal)p.GiaTien;
            }

            hd.MaSV = masv;
            hd.MaHD = mahd;
            hd.TienDien = tiendien;
            hd.TienNuoc = tiennuoc;
            hd.TienPhong = tienphong;
            hd.TienDV = tiendichvu;
            hd.NgayXuatHoaDon = ngayxuathd;

            List<HoaDon> x = hoaDons.Where(t => t.MaSV == masv && t.NgayXuatHoaDon.Value.Month.Equals(ngayxuathd.Month)).ToList();
            if (x.Count > 0)
            {
                MessageBox.Show("Sinh viên đã có hóa đơn tháng này...");
                return;
            }

            hoaDons.Add(hd);
            dtgvHoaDon.DataSource = sv.HoaDons.ToList();
            //loadDataHD();

            db.HoaDons.Add(hd);
            db.SaveChanges();
            MessageBox.Show("Tao HD thanh cong.");

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (sv == null) return;
            string masv = txtMaSV.Text;

            List<SinhVien> x = sinhViens.Where(t => t.TenSV == txtTenSV.Text.Trim()
                                               && t.MaSV != masv).ToList();
            if (x.Count > 0)
            {
                MessageBox.Show("Sinh viên này đã tồn tại.");
                return;
            }
            sv.TenSV = txtTenSV.Text;
            sv.GioiTinh = cmbGioiTinh.Text;
            sv.SDT = txtSDT.Text;
            sv.NgaySinh = dtpNgaySinh.Value;
            sv.LoaiPhong = txtLoaiPhong.Text;
            sv.NgayVao = dtpNgayVao.Value;
            //sv.NgayRa = dtpNgayRa.Value;
            dtgvSinhVien.DataSource = null;
            loadDataSV();
            db.SaveChanges();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (sv == null)
                return;
            if (sv.HoaDons.Count > 0)
            {
                MessageBox.Show("Không thể xóa sinh viên này !!!");
                return;
            }
            db.SinhViens.Remove(sv);
            db.SaveChanges();
            sinhViens.Remove(sv);
            dtgvSinhVien.DataSource = null;
            loadDataSV();
            sv = null;
        }

        private void btnTimKiemHD_Click(object sender, EventArgs e)
        {
            string keyWord = txtTimKiem.Text.Trim();
            dtgvHoaDon.DataSource = db.HoaDons.Where(t => t.MaHD.Contains(keyWord)
            || t.MaHD.Contains(keyWord)).ToList();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDuyetDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            FDuyetDon chuyen = new FDuyetDon();
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
    }
}
