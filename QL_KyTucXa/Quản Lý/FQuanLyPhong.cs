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
    public partial class FQuanLyPhong : Form
    {
        QLKYTUCXAEntities db = new QLKYTUCXAEntities();
        List<LoaiPhong> loaiPhongs = new List<LoaiPhong>();
        List<Phong> phongs = new List<Phong>();
        List<SinhVien> sinhViens = new List<SinhVien>();
        LoaiPhong loaiPhong = null;
        Phong phong = null;
        SinhVien sinhVien = null;
        public FQuanLyPhong()
        {
            InitializeComponent();
        }

        void loadData()
        {
            dtgvLoaiPhong.DataSource = loaiPhongs;
            dtgvLoaiPhong.Columns[2].Width = 0;
            dtgvLoaiPhong.Columns[2].Visible = false;

            int width = dtgvLoaiPhong.Width;
            dtgvLoaiPhong.Columns[0].Width = width * 20 / 100;
            dtgvLoaiPhong.Columns[1].Width = width * 65 / 100;
        }

        void loadPhong(Phong x)
        {
            txtMaPhong.Text = x.MaPhong + "";
            txtSoGiuong.Text = x.SoGiuong + "";
            txtGiaTien.Text = x.GiaTien + "";
        }

        void loadDataPhong(List<Phong> x)
        {
            dtgvPhong.Rows.Clear();

            foreach (Phong a in x)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtgvPhong);
                row.Cells[0].Value = a.MaPhong;
                row.Cells[1].Value = a.SoGiuong;
                row.Cells[2].Value = a.GiaTien;
                dtgvPhong.Rows.Add(row);
            }
            if (x.Count > 0)
            {
                loadPhong(x[0]);
                phong = x[0];
            }

        }

        void loadDataSinhVien(List<SinhVien> x)
        {
            dtgvSinhVien.Rows.Clear();
            foreach (SinhVien a in x)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtgvSinhVien);
                row.Cells[0].Value = a.MaSV;
                row.Cells[1].Value = a.TenSV;
                row.Cells[2].Value = a.GioiTinh;
                row.Cells[3].Value = a.NgaySinh;
                row.Cells[4].Value = a.SDT;
                row.Cells[5].Value = a.NgayVao;
                row.Cells[6].Value = a.NgayRa;
                dtgvSinhVien.Rows.Add(row);
            }
        }

        void showLoaiPhong(LoaiPhong a)
        {
            txtMaLoai.Text = a.MaLoai + "";
            txtChiTiet.Text = a.TenLoai;
        }
        private void FQuanLyPhong_Load(object sender, EventArgs e)
        {
            loaiPhongs = db.LoaiPhongs.ToList();
            phongs = db.Phongs.ToList();
            loadData();
            //phongs = db.Phongs.ToList();
            if (loaiPhongs.Count > 0)
            {
                loaiPhong = loaiPhongs[0];
                dtgvPhong.Columns.Add("MaPhong", "Mã phòng");
                dtgvPhong.Columns.Add("SoGiuong", "Số giường");
                dtgvPhong.Columns.Add("GiaTien", "Giá tiền");

                dtgvSinhVien.Columns.Add("MaSV", "Mã sinh viên");
                dtgvSinhVien.Columns.Add("TenSV", "Tên sinh viên");
                dtgvSinhVien.Columns.Add("GioiTinh", "Giới tính");
                dtgvSinhVien.Columns.Add("NgaySinh", "Ngày sinh");
                dtgvSinhVien.Columns.Add("SDT", "SĐT");
                dtgvSinhVien.Columns.Add("NgayVao", "Ngày vào");
                dtgvSinhVien.Columns.Add("NgayRa", "Ngày ra");
                loadDataPhong(loaiPhong.Phongs.ToList());
                loadDataSinhVien(phong.SinhViens.ToList());
                showLoaiPhong(loaiPhong);
            }
        }

        void clearDataPhong()
        {
            txtMaPhong.Text = "";
            txtSoGiuong.Text = "";
            txtGiaTien.Text = "";
        }

        private void dtgvLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtgvLoaiPhong.CurrentRow;
            int index = row.Index;
            if (index >= dtgvLoaiPhong.Rows.Count)
                return;
            loaiPhong = loaiPhongs[index];
            txtMaLoai.Text = loaiPhong.MaLoai + "";
            txtChiTiet.Text = loaiPhong.TenLoai;
            loadDataPhong(loaiPhong.Phongs.ToList());
            loadDataSinhVien(phong.SinhViens.ToList());
            if (loaiPhong.Phongs.ToList().Count > 0)
                loadPhong(loaiPhong.Phongs.ToList()[0]);
            else
                clearDataPhong();
        }

        private void dtgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtgvPhong.CurrentRow;
            int index = row.Index;
            phong = loaiPhong.Phongs.ToList()[index];
            if (index < 0 || index >= dtgvPhong.Rows.Count)
                return;
            txtMaPhong.Text = phong.MaPhong + "";
            txtSoGiuong.Text = phong.SoGiuong + "";
            txtGiaTien.Text = phong.GiaTien + "";
            loadDataSinhVien(phong.SinhViens.ToList());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maloai = txtMaLoai.Text;
            string tenloai = txtChiTiet.Text;
            loaiPhong = new LoaiPhong();
            loaiPhong.MaLoai = maloai;
            loaiPhong.TenLoai = tenloai;

            List<LoaiPhong> x = loaiPhongs.Where(t => t.MaLoai == maloai || t.TenLoai.Equals(loaiPhong.TenLoai)).ToList();
            if (x.Count > 0)
            {
                MessageBox.Show("Nhập mã khác để thêm");
                return;
            }

            if (loaiPhongs.Contains(loaiPhong))
            {
                MessageBox.Show("Loại phòng này đã tồn tại.");
                return;
            }
            loaiPhongs.Add(loaiPhong);
            dtgvLoaiPhong.DataSource = null;
            loadData();

            db.LoaiPhongs.Add(loaiPhong);
            db.SaveChanges();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (loaiPhong == null) return;
            string maloai = txtMaLoai.Text;
            string tenloai = txtChiTiet.Text.Trim();
            List<LoaiPhong> listkiemtra = loaiPhongs.Where(t => t.TenLoai == tenloai && t.MaLoai != maloai).ToList();
            if (listkiemtra.Count > 0)
            {
                MessageBox.Show("Loại phòng này đã có !!!");
                return;
            }
            if (loaiPhong == null) return;
            loaiPhong.TenLoai = txtChiTiet.Text;
            dtgvLoaiPhong.DataSource = null;
            loadData();
            db.SaveChanges();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (loaiPhong == null) return;
                if (loaiPhong.Phongs.Count > 0)
                {
                    MessageBox.Show("Không thể xóa loại phòng này.");
                    return;
                }
                db.LoaiPhongs.Remove(loaiPhong);
                db.SaveChanges();
                loaiPhongs.Remove(loaiPhong);
                dtgvLoaiPhong.DataSource = null;
                loadData();
                loaiPhong = null;
            }
            catch { }
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            string maphong = txtMaPhong.Text;
            int sogiuong = int.Parse(txtSoGiuong.Text);
            decimal giatien = decimal.Parse(txtGiaTien.Text);
            string maloai = txtMaLoai.Text;
            phong = new Phong();
            phong.MaPhong = maphong;
            phong.SoGiuong = sogiuong;
            phong.GiaTien = giatien;
            phong.MaLoai = maloai;

            List<Phong> x = phongs.Where(t => t.MaPhong == maphong).ToList();
            if (x.Count > 0)
            {
                MessageBox.Show("Phòng này đã tồn tại.");
                return;
            }

            if (phongs.Contains(phong))
            {
                MessageBox.Show("Phòng này đã tồn tại.");
                return;
            }
            phongs.Add(phong);
            dtgvPhong.DataSource = null;
            //dtgvPhong.DataSource = phongs;
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dtgvPhong);
            row.Cells[0].Value = phong.MaPhong;
            row.Cells[1].Value = phong.SoGiuong;
            row.Cells[2].Value = phong.GiaTien;
            dtgvPhong.Rows.Add(row);

            db.Phongs.Add(phong);
            db.SaveChanges();
        }

        private void btnSuaPhong_Click(object sender, EventArgs e)
        {
            if (phong == null) return;
            phong.SoGiuong = int.Parse(txtSoGiuong.Text);
            phong.GiaTien = decimal.Parse(txtGiaTien.Text);
            db.SaveChanges();
            DataGridViewRow row = dtgvPhong.CurrentRow;
            row.Cells[1].Value = phong.SoGiuong;
            row.Cells[2].Value = phong.GiaTien;
        }

        private void btnXoaPhong_Click(object sender, EventArgs e)
        {
            try
            {
                if (phong == null) return;
                db.Phongs.Remove(phong);
                db.SaveChanges();
                int index = dtgvPhong.CurrentCell.RowIndex;
                dtgvPhong.Rows.RemoveAt(index);
                phongs.RemoveAt(index);
                phong = null;
            }
            catch { }
        }

        private void lblPhong_Click(object sender, EventArgs e)
        {
          
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
            chuyen.ShowDialog();
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

        private void dtgvLoaiPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void dtgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
