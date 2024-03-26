using QL_KyTucXa.Quản_Lý;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KyTucXa
{
    public partial class FQuanLySinhVien : Form
    {
        QLKYTUCXAEntities db = new QLKYTUCXAEntities();
        List<LoaiPhong> loaiPhongs = new List<LoaiPhong>();
        LoaiPhong loaiPhong = null;
        List<Phong> phongs = new List<Phong>();
        Phong phong = null;
        List<SinhVien> sinhViens = new List<SinhVien>();
        SinhVien sinhVien = null;
        public FQuanLySinhVien()
        {
            InitializeComponent();
        }
        void loadDataSinhVien()
        {
            dtgvSinhVien.DataSource = sinhViens;
            dtgvSinhVien.Columns[15].Width = 0;
            dtgvSinhVien.Columns[15].Visible = false;
            dtgvSinhVien.Columns[14].Width = 0;
            dtgvSinhVien.Columns[14].Visible = false;
            dtgvSinhVien.Columns[16].Width = 0;
            dtgvSinhVien.Columns[16].Visible = false;
            dtgvSinhVien.Columns[17].Width = 0;
            dtgvSinhVien.Columns[17].Visible = false;
            int width = panel1.Width;
            dtgvSinhVien.Columns[0].Width = width * 10 / 100;
            dtgvSinhVien.Columns[1].Width = width * 15 / 100;
            dtgvSinhVien.Columns[2].Width = width * 15 / 100;
            dtgvSinhVien.Columns[3].Width = width * 15 / 100;
            dtgvSinhVien.Columns[4].Width = width * 15 / 100;
            dtgvSinhVien.Columns[5].Width = width * 15 / 100;
            dtgvSinhVien.Columns[6].Width = width * 15 / 100;
            dtgvSinhVien.Columns[7].Width = width * 15 / 100;
            dtgvSinhVien.Columns[8].Width = width * 15 / 100;
            dtgvSinhVien.Columns[9].Width = width * 15 / 100;
            dtgvSinhVien.Columns[10].Width = width * 15 / 100;
            dtgvSinhVien.Columns[11].Width = width * 15 / 100;
            dtgvSinhVien.Columns[12].Width = width * 15 / 100;
            dtgvSinhVien.Columns[13].Width = width * 15 / 100;
            dtgvSinhVien.Columns[14].Width = width * 15 / 100;
        }
        void loadDataLoaiPhong()
        {
            dtgvLoaiPhong.DataSource = loaiPhongs;
            dtgvLoaiPhong.Columns[2].Width = 0;
            dtgvLoaiPhong.Columns[2].Visible = false;
            int width = panel1.Width;
            dtgvLoaiPhong.Columns[0].Width = width * 10 / 100;
            dtgvLoaiPhong.Columns[1].Width = width * 20 / 100;

        }
        void loadDataPhong(List<Phong> x)
        {
            
            dtgvPhong.Rows.Clear();
            foreach (Phong a in x)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtgvPhong);
                row.Cells[0].Value = a.MaPhong;
                row.Cells[1].Value = a.MaLoai;
                row.Cells[2].Value = a.SoGiuong;
                row.Cells[3].Value = a.GiaTien;
                dtgvPhong.Rows.Add(row);
            }
            if (x.Count > 0)
            {
                phong = x[0];
            }
        }
        void loadPhong(Phong x)
        {
            txtMaPhong.Text = x.MaPhong;
        }
        void clearPhong()
        {
            txtMaPhong.Text = "";
        }
        
        private void FQuanLySinhVien_Load(object sender, EventArgs e)
        {
            cmbPhong.SelectedIndex = 0;
            sinhViens = db.SinhViens.Where(sv => sv.DuyetDon != "Chưa duyệt").ToList();
            loadDataSinhVien();
            dtgvPhong.Columns.Add("MaPhong", "Mã Phòng");
            dtgvPhong.Columns.Add("MaLoai", "Mã Loại");
            dtgvPhong.Columns.Add("SoGiuong", "Số Giường");
            dtgvPhong.Columns.Add("GiaTien", "Giá Tiền");

            loaiPhongs = db.LoaiPhongs.ToList();
            phongs = db.Phongs.ToList();
            loadDataLoaiPhong();

            SinhVien sv1 = sinhViens[0];
            // Gán thông tin của sinh viên đó cho các textbox
            txtMaSV.Text = sv1.MaSV.ToString();
            txtTenSV.Text = sv1.TenSV;
            txtSDT.Text = sv1.SDT;
            cmbGioiTinh.Text = sv1.GioiTinh;
            dtpNgaySinh.Value = sv1.NgaySinh.Value;
            dtpNgayVao.Value = sv1.NgayVao.Value;
            txtLoaiPhong.Text = sv1.LoaiPhong;
            txtDaDong.Text = sv1.DaDong + "";
            txtEmail.Text = sv1.Email;
            
            if (loaiPhongs.Count > 0)
            {
                loaiPhong = loaiPhongs[0];
                loadDataPhong(loaiPhong.Phongs.ToList());
            }
            cmbDatCoc.Visible = false;
        }

        private void dtgvLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = dtgvLoaiPhong.CurrentRow;
            int index = row.Index;
            if (index >= dtgvLoaiPhong.Rows.Count)
                return;
            loaiPhong = loaiPhongs[index];
            loadDataPhong(loaiPhong.Phongs.ToList());
            if (loaiPhong.Phongs.ToList().Count > 0)
                loadPhong(loaiPhong.Phongs.ToList()[0]);
            else
                clearPhong();
        }

        private void dtgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvSinhVien.Rows[e.RowIndex];
                txtMaSV.Text = row.Cells["MaSV"].Value.ToString();
                txtTenSV.Text = row.Cells["TenSV"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                cmbGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                dtpNgaySinh.Value = DateTime.Parse(row.Cells["NgaySinh"].Value.ToString());
                dtpNgayVao.Value = DateTime.Parse(row.Cells["NgayVao"].Value.ToString());
                txtLoaiPhong.Text = row.Cells["LoaiPhong"].Value.ToString();
                txtDaDong.Text = row.Cells["DaDong"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void btnTimKiemSV_Click(object sender, EventArgs e)
        {
            string keyWord = txtTimKiem.Text.Trim();
            dtgvSinhVien.DataSource = db.SinhViens.Where(t => t.TenSV.Contains(keyWord)
            || t.MaSV.Contains(keyWord) || t.Email.Contains(keyWord)
            || t.GioiTinh.Contains(keyWord) || t.SDT.Contains(keyWord)
            || t.MaPhong.Contains(keyWord) || t.LoaiPhong.Contains(keyWord)).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbPhong.Text == "Đã có phòng")
            {
                dtgvSinhVien.DataSource = db.SinhViens.Where(t => t.MaPhong != null).ToList();
                cmbDatCoc.Visible = false;
            }
            else if (cmbPhong.Text == "Chưa có phòng")
            {
                dtgvSinhVien.DataSource = db.SinhViens.Where(t => t.MaPhong == null).ToList();

                cmbDatCoc.Visible = true;

                if (cmbDatCoc.Text == "Đã đặt cọc")
                {
                    dtgvSinhVien.DataSource = db.SinhViens.Where(t => t.DaDong == 400 && t.MaPhong == null).ToList();
                }
                else if (cmbDatCoc.Text == "Chưa đặt cọc")
                {
                    dtgvSinhVien.DataSource = db.SinhViens.Where(t => t.DaDong != 400 && t.MaPhong == null && t.DuyetDon != "Chưa duyệt").ToList();
                }
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã nhập đầy đủ thông tin hay chưa
            if (txtMaSV.Text == "" || txtTenSV.Text == "" || cmbGioiTinh.Text == "" || dtpNgaySinh.Text == "" || txtSDT.Text == "" || txtEmail.Text == "" || txtDaDong.Text == "" || txtLoaiPhong.Text == "")
            {
                // Thông báo yêu cầu nhập đầy đủ thông tin
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sinh viên và phòng");
            }
            else
            {
                // Lấy mã sinh viên từ ô TextBox
                string masv = txtMaSV.Text;
                // Tìm sinh viên có mã số tương ứng trong cơ sở dữ liệu
                var sinhVien = db.SinhViens.Find(masv);
                // Nếu tìm thấy sinh viên
                if (sinhVien != null)
                {
                    // Cập nhật thông tin sinh viên từ các ô TextBox
                    sinhVien.TenSV = txtTenSV.Text;
                    sinhVien.GioiTinh = cmbGioiTinh.Text;
                    sinhVien.NgaySinh = DateTime.Parse(dtpNgaySinh.Text);
                    sinhVien.SDT = txtSDT.Text;
                    sinhVien.Email = txtEmail.Text;
                    sinhVien.DaDong = decimal.Parse(txtDaDong.Text);
                    // Lấy mã phòng từ ô TextBox
                    string maphong = txtMaPhong.Text;
                    // Tìm phòng có mã số tương ứng trong cơ sở dữ liệu
                    var phong = db.Phongs.Find(maphong);
                    // Nếu tìm thấy phòng
                    if (phong != null)
                    {
                        // Cập nhật mã phòng cho sinh viên
                        sinhVien.MaPhong = phong.MaPhong;

                        // Lưu thay đổi vào cơ sở dữ liệu
                        db.SaveChanges();

                        // Thông báo thêm thành công
                        MessageBox.Show("Thêm sinh viên vào phòng thành công");

                        // Làm mới lại hai DataGridView
                        loadDataSinhVien();
                    }
                    else
                    {
                        // Thông báo không tìm thấy sinh viên
                        MessageBox.Show("Không tìm thấy sinh viên có mã số " + masv);
                    }
                }
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string masv = dtgvSinhVien.CurrentRow.Cells["MaSV"].Value.ToString();

                    // Tìm sinh viên có mã số tương ứng trong DbSet
                    var delete = db.SinhViens.Find(masv);

                    // Nếu tìm thấy sinh viên
                    if (delete != null)
                    {
                        // Xóa sinh viên khỏi DbSet
                        db.SinhViens.Remove(delete);
                        // Lưu thay đổi vào database
                        db.SaveChanges();
                        sinhViens.Remove(sinhVien);
                        dtgvSinhVien.DataSource = null;
                        loadDataSinhVien();
                        sinhVien = null;
                    
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một hàng để xóa.");
                }
            
          
                
            }
            catch
            {
                MessageBox.Show("Không xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem người dùng đã nhập đầy đủ thông tin hay chưa
                if (txtMaSV.Text == "" || txtTenSV.Text == "" || cmbGioiTinh.Text == "" || dtpNgaySinh.Text == "" || txtSDT.Text == "" || dtpNgayVao.Text == "" || txtLoaiPhong.Text == "" || txtDaDong.Text == "")
                {
                    // Thông báo yêu cầu nhập đầy đủ thông tin
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin sinh viên");
                }
                else
                {
                    // Lấy mã sinh viên từ ô TextBox
                    string masv = txtMaSV.Text;
                    // Tìm sinh viên có mã số tương ứng trong cơ sở dữ liệu
                    var sinhVien = db.SinhViens.Find(masv);
                    // Nếu tìm thấy sinh viên
                    if (sinhVien != null)
                    {
                        // Cập nhật thông tin sinh viên từ các ô TextBox
                        sinhVien.TenSV = txtTenSV.Text;
                        sinhVien.GioiTinh = cmbGioiTinh.Text;
                        sinhVien.NgaySinh = DateTime.Parse(dtpNgaySinh.Text);
                        sinhVien.SDT = txtSDT.Text;
                        sinhVien.NgayVao = DateTime.Parse(dtpNgayVao.Text);
                        sinhVien.LoaiPhong = txtLoaiPhong.Text;
                        sinhVien.DaDong = decimal.Parse(txtDaDong.Text);
                        sinhVien.Email = txtEmail.Text;
                        // Lưu thay đổi vào cơ sở dữ liệu
                        db.SaveChanges();
                        // Thông báo sửa thành công
                        MessageBox.Show("Sửa thông tin sinh viên thành công");
                        dtgvSinhVien.DataSource = null;
                        loadDataSinhVien();
                    }
                    else
                    {
                        // Thông báo không tìm thấy sinh viên
                        MessageBox.Show("Không tìm thấy sinh viên có mã số ");
                    }
                }
            }
            catch
            {
                
                MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvPhong.Rows.Count == 0) return;
            int idRow = dtgvPhong.CurrentRow.Index;
            if (idRow >= dtgvPhong.Rows.Count - 1) return;
            phong = loaiPhong.Phongs.ToList()[idRow];
            loadPhong(phong);
        }

        private void cmbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPhong.SelectedIndex == 0)
            {
                cmbDatCoc.Visible = false;
            }
            else
            {
                cmbDatCoc.Visible = true;
                cmbDatCoc.SelectedIndex = 0;
            }
        }

        private void lblPhong_Click(object sender, EventArgs e)
        {
            this.Hide();
            FQuanLyPhong chuyen = new FQuanLyPhong();
            chuyen.Show();
           
        }

        private void lblSinhVien_Click(object sender, EventArgs e)
        {

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

        private void dtgvSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
