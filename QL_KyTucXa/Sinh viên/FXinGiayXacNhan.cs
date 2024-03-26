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
    public partial class FXinGiayXacNhan : Form
    {
        QLKYTUCXAEntities db = new QLKYTUCXAEntities ();
        List<SinhVien> sinhViens = new List<SinhVien>();
        SinhVien sinhVien = new SinhVien();
        List<DonXinTham> donXinThams = new List<DonXinTham>();
        DonXinTham donXinTham = null;
        public FXinGiayXacNhan(string maSinhVien)
        {
            InitializeComponent();
            txtMaSV.Text = maSinhVien;
        }

        private void rdbXinTham_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbXinTham.Checked)
            {
                lbHoTen.Visible = true;
                txtHoTen.Visible = true;
                lbQuanHe.Visible = true;
                txtQuanHe.Visible = true;
                lbMaDon.Visible = true;
                txtMaDon.Visible = true;
            
            }
        }

        private void rdbXinRa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbXinRa.Checked)
            {
                lbQuanHe.Visible = false;
                txtQuanHe.Visible = false;
                lbHoTen.Visible = false;
                txtHoTen.Visible = false;
                //lbMaSv.Visible = false;
                //txtMaSV.Visible = false;
                lbMaDon.Visible = false;
                txtMaDon.Visible = false;
            }
        }

        private void btnNopDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbXinTham.Checked)
                {
                    string maDon = txtMaDon.Text;
                    string maSV = txtMaSV.Text;
                    string hoTen = txtHoTen.Text;
                    string quanHe = txtQuanHe.Text;
                    DateTime ngayXin = dtpNgayXinRa.Value;
                    DateTime tGLamDon = DateTime.Now;
                    donXinTham = new DonXinTham();
                    donXinTham.MaDon = maDon;
                    donXinTham.MaSV = maSV;
                    donXinTham.TenNguoiThan = hoTen;
                    donXinTham.QuanHe = quanHe;
                    donXinTham.NgayXin = ngayXin;
                    donXinTham.ThoiGian = tGLamDon;
                    donXinTham.DuyetDon = "";
                    if (donXinTham.DuyetDon == "")
                    {
                        donXinTham.DuyetDon = "Chưa duyệt";
                    }
                    db.DonXinThams.Add(donXinTham);
                    db.SaveChanges();
                    MessageBox.Show("Đã thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Mỗi lần nộp đơn được 1 lần!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (rdbXinRa.Checked)
            {
                string maSV = txtMaSV.Text;
                var sinhVien = db.SinhViens.FirstOrDefault(sv => sv.MaSV == maSV);

                if (sinhVien != null)
                {
                    if (sinhVien.NgayRa == null || sinhVien.NgayRa != new DateTime(1990, 1, 1))
                    {
                        sinhVien.NgayRa = dtpNgayXinRa.Value;
                        sinhVien.XinRa = "Chưa duyệt";

                        try
                        {
                            db.SaveChanges();
                            MessageBox.Show("Đã thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi lưu vào cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ngày ra đã được cập nhật trước đó.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void FXinGiayXacNhan_Load(object sender, EventArgs e)
        {
            DateTime day = DateTime.Now;
            string maDon = day.ToString("yyyyMMddmmss");
            txtMaDon.Text = maDon;

            string masv = txtMaSV.Text;
            sinhViens = db.SinhViens.Where(sv => sv.MaSV == masv).ToList();
        }
        
        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
