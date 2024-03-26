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
    public partial class FDuyetDon : Form
    {
        QLKYTUCXAEntities db = new QLKYTUCXAEntities();
        List<SinhVien> dsSinhVien = new List<SinhVien>();
        SinhVien sinhVien = null;

        List<DonXinTham> dsDonXinTham = new List<DonXinTham>();
        DonXinTham donXinTham = null;
        public FDuyetDon()
        {
            InitializeComponent();
        }
        void LoadDataSV()
        {
            dtgvDuyetDon.DataSource = dsSinhVien;

            //dtgvDuyetDon.Columns[14].Width = 0;
            //dtgvDuyetDon.Columns[14].Visible = false;
            dtgvDuyetDon.Columns[14].Width = 0;
            dtgvDuyetDon.Columns[14].Visible = false;
            dtgvDuyetDon.Columns[15].Width = 0;
            dtgvDuyetDon.Columns[15].Visible = false;
            dtgvDuyetDon.Columns[16].Width = 0;
            dtgvDuyetDon.Columns[16].Visible = false;
            dtgvDuyetDon.Columns[17].Width = 0;
            dtgvDuyetDon.Columns[17].Visible = false;
        }

        void LoadDataDon()
        {
            dtgvDuyetDon.DataSource = dsDonXinTham;
            dtgvDuyetDon.Columns[7].Width = 0;
            dtgvDuyetDon.Columns[7].Visible = false;

        }

        void SetDefaultDateForDateTimePicker(DateTimePicker dateTimePicker, DateTime defaultDate)
        {
            if (dateTimePicker.Value == dateTimePicker.MinDate)
            {
                dateTimePicker.Value = defaultDate;
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            string chon = cmbLoaiDon.SelectedItem.ToString();

            switch (chon)
            {
                case "Đơn đăng ký":
                    if (sinhVien == null)
                    {
                        MessageBox.Show("Vui lòng chọn đơn cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    txtMaSV.Text = "";
                    txtEmail.Text = "";
                    txtLoaiPhong.Text = "";
                    txtSDT.Text = "";
                    txtTenSV.Text = "";
                    dtpNgaySinh.Value = DateTime.Now;
                    dtpNgayRa.Value = DateTime.Now;
                    dtpNgayVao.Value = DateTime.Now;
                    rdbNam.Checked = false;
                    rdbNu.Checked = false;

                    dsSinhVien.Remove(sinhVien);
                    db.SinhViens.Remove(sinhVien);
                    db.SaveChanges();

                    dtgvDuyetDon.DataSource = null;
                    LoadDataSV();
                    break;

                case "Đơn cho người thân":
                    if (donXinTham == null)
                    {
                        MessageBox.Show("Vui lòng chọn đơn cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    txtMaSV.Text = "";
                    txtTenSV.Text = "";
                    dtpNgayRa.Value = DateTime.Now;
                    dtpNgayVao.Value = DateTime.Now;

                    dsDonXinTham.Remove(donXinTham);
                    db.DonXinThams.Remove(donXinTham);
                    db.SaveChanges();

                    dtgvDuyetDon.DataSource = null;
                    LoadDataDon();
                    break;

                case "Đơn xin ra":
                    if (sinhVien == null)
                    {
                        MessageBox.Show("Vui lòng chọn đơn cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    sinhVien.NgayRa = new DateTime(1990, 1, 1);
                    sinhVien.XinRa = null;
                    db.SaveChanges();

                    DateTime tuChoi = new DateTime(1990, 1, 1);
                    dtgvDuyetDon.DataSource = null;
                    dsSinhVien = db.SinhViens.Where(sv => sv.NgayRa != null && sv.NgayRa != tuChoi && sv.XinRa == "Chưa duyệt").ToList();
                    LoadDataSV();

                    break;
            }
        }

        private void btnDuyetDon_Click(object sender, EventArgs e)
        {
            string chon = cmbLoaiDon.SelectedItem.ToString();

            switch (chon)
            {
                case "Đơn đăng ký":
                    if (sinhVien.DuyetDon == "Chưa duyệt")
                    {
                        sinhVien.DuyetDon = "Đã duyệt";
                        sinhVien.DaDong = 0;

                        TaiKhoan taiKhoan = new TaiKhoan();
                        taiKhoan.TenTaiKhoan = sinhVien.MaSV;
                        taiKhoan.MatKhau = "1";
                        taiKhoan.Email = sinhVien.Email;
                        db.TaiKhoans.Add(taiKhoan);

                    }

                    db.SaveChanges();

                    MessageBox.Show("Đã thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dsSinhVien = db.SinhViens.Where(sv => sv.DuyetDon == "Chưa duyệt").ToList();
                    dtgvDuyetDon.DataSource = null;
                    LoadDataSV();
                    break;

                case "Đơn cho người thân":
                    if (donXinTham.DuyetDon == "Chưa duyệt")
                    {
                        donXinTham.DuyetDon = "Đã duyệt";
                    }

                    db.SaveChanges();
                    MessageBox.Show("Đã thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dsDonXinTham = db.DonXinThams.Where(xt => xt.DuyetDon == "Chưa duyệt").ToList();
                    dtgvDuyetDon.DataSource = null;
                    LoadDataDon();
                    break;

                case "Đơn xin ra":
                    if (sinhVien.XinRa == "Chưa duyệt")
                    {
                        sinhVien.XinRa = "Đã duyệt";
                    }

                    db.SaveChanges();
                    MessageBox.Show("Đã thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dtgvDuyetDon.DataSource = null;
                    dsSinhVien = db.SinhViens.Where(sv => sv.XinRa == "Chưa duyệt").ToList();
                    LoadDataSV();

                    break;
            }
        
        }

        private void dtgvDuyetDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtgvDuyetDon.CurrentRow;
            int id = row.Index;

            string chon = cmbLoaiDon.SelectedItem.ToString();

            switch (chon)
            {
                case "Đơn đăng ký":
                    if (id < 0) return;
                    if (id >= dsSinhVien.Count) return;

                    sinhVien = dsSinhVien[id];
                    txtMaSV.Text = row.Cells[0].Value.ToString();
                    txtTenSV.Text = row.Cells[1].Value.ToString();
                    txtEmail.Text = row.Cells[2].Value.ToString();
                    dtpNgaySinh.Value = sinhVien.NgaySinh.Value;
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
                    dtpNgayVao.Value = sinhVien.NgayVao.Value;
                    txtSDT.Text = row.Cells[3].Value.ToString();
                    txtLoaiPhong.Text = row.Cells[7].Value.ToString();

                    break;

                case "Đơn cho người thân":
                    if (id < 0) return;
                    if (id >= dsDonXinTham.Count) return;

                    donXinTham = dsDonXinTham[id];
                    txtMaSV.Text = donXinTham.MaSV + "";
                    txtTenSV.Text = donXinTham.TenNguoiThan + "";
                    dtpNgayVao.Value = donXinTham.ThoiGian.Value;
                    dtpNgayRa.Value = donXinTham.NgayXin.Value;

                    break;

                case "Đơn xin ra":
                    if (id < 0) return;
                    if (id >= dsSinhVien.Count) return;

                    sinhVien = dsSinhVien[id];
                    txtMaSV.Text = row.Cells[0].Value.ToString();
                    txtTenSV.Text = row.Cells[1].Value.ToString();
                    txtEmail.Text = row.Cells[2].Value.ToString();
                    dtpNgaySinh.Value = sinhVien.NgaySinh.Value;
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
                    dtpNgayVao.Value = sinhVien.NgayVao.Value;
                    dtpNgayRa.Value = sinhVien.NgayRa.Value;
                    txtSDT.Text = row.Cells[3].Value.ToString();
                    txtLoaiPhong.Text = row.Cells[8].Value.ToString();
                    break;
            }
        }

        private void cmbLoaiDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string chon = cmbLoaiDon.SelectedItem.ToString();

            switch (chon)
            {
                case "Đơn đăng ký":
                    lblMa.Text = "Mã số sinh viên";
                    lblTenSV.Text = "Tên sinh viên";
                    panelThongTin.Visible = true;
                    lblNgayVao.Text = "Ngày vào";
                    lblNgayRa.Text = "Ngày ra";
                    dtpNgayRa.Visible = false;
                    lblNgayRa.Visible = false;

                    dtgvDuyetDon.DataSource = null;
                    dsSinhVien = db.SinhViens.Where(sv => sv.DuyetDon == "Chưa duyệt").ToList();
                    LoadDataSV();
                    break;

                case "Đơn cho người thân":
                    lblTenSV.Text = "Tên người thân";
                    panelThongTin.Visible = false;
                    lblNgayRa.Visible = true;
                    dtpNgayRa.Visible = true;
                    lblNgayVao.Text = "TG làm đơn";
                    lblNgayRa.Text = "TG xin";

                    dtgvDuyetDon.DataSource = null;
                    dsDonXinTham = db.DonXinThams.Where(nt => nt.DuyetDon == "Chưa duyệt").ToList();
                    LoadDataDon();
                    break;

                case "Đơn xin ra":
                    lblMa.Text = "Mã số sinh viên";
                    lblTenSV.Text = "Tên sinh viên";
                    panelThongTin.Visible = true;
                    lblNgayRa.Visible = true;
                    dtpNgayRa.Visible = true;
                    lblNgayVao.Text = "Ngày vào";
                    lblNgayRa.Text = "Ngày ra";


                    DateTime tuChoi = new DateTime(1990, 1, 1);
                    dtgvDuyetDon.DataSource = null;
                    dsSinhVien = db.SinhViens.Where(sv => sv.NgayRa != null && sv.NgayRa != tuChoi && sv.XinRa == "Chưa duyệt").ToList();
                    LoadDataSV();
                    break;
            }
        }

        private void FDuyetDon_Load(object sender, EventArgs e)
        {
            cmbLoaiDon.SelectedIndex = 0;
        }

        private void lblDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.Show();
          
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
    }
}
