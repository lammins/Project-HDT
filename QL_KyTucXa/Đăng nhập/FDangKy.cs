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
    public partial class FDangKy : Form
    {
        QLKYTUCXAEntities db = new QLKYTUCXAEntities();
        List<SinhVien> dsSinhVien = new List<SinhVien>();
        SinhVien sinhVien = null;
        public FDangKy()
        {
            InitializeComponent();
        }

        private void btnNopDon_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text;
            string tenSV = txtTenSV.Text;
            string sdt = txtSDT.Text;
            string loaiPhong = txtLoaiPhong.Text;
            string email = txtEmail.Text;

            if (sinhVien != null && maSV == sinhVien.MaSV) return;
            List<SinhVien> x = db.SinhViens.Where(sv => sv.MaSV == maSV).ToList();

            if (x.Count > 0)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sinhVien = new SinhVien();
            sinhVien.MaSV = maSV;
            sinhVien.TenSV = tenSV;
            sinhVien.SDT = sdt;
            sinhVien.LoaiPhong = loaiPhong;
            sinhVien.Email = email;
            sinhVien.NgayVao = dtpNgayVao.Value;
            sinhVien.NgaySinh = dtpNgaySinh.Value;
            if (rdbNam.Checked)
            {
                sinhVien.GioiTinh = "Nam";
            }
            else if (rdbNu.Checked)
            {
                sinhVien.GioiTinh = "Nữ";
            }
            else
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sinhVien.DuyetDon = "Chưa duyệt";

            dsSinhVien.Add(sinhVien);
            db.SinhViens.Add(sinhVien);
            db.SaveChanges();

            DialogResult dialogResult = MessageBox.Show("Chúc mừng bạn đăng ký thành công! " +
                "Bạn có muốn trở về form đăng nhập không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                DangNhap dangNhap = new DangNhap();
                this.Hide();
                dangNhap.Show();
            }
            else
            {
                this.Close();
            }

        }

        private void txtMaSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' || e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Ngăn chặn ký tự được nhập vào
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' || e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Ngăn chặn ký tự được nhập vào
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' || e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Ngăn chặn ký tự được nhập vào
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            FDangKy dangKy = new FDangKy();
            this.Hide();
            dangNhap.ShowDialog();
        }
    }
}
