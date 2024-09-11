using BUS;
using GUI.GUI_COMPONENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI.GUI_STAFF
{
    public partial class frmAddStaff : Form
    {
        NhanVienBUS nhanVienBUS = new NhanVienBUS();
        private int NVCount;
        private bool isAdd;
        private Point mouseOffset;
        public frmAddStaff()
        {
            this.isAdd = true;
            InitializeComponent();
            cbChucVu.SelectedItem = cbChucVu.Items[0];
            cbChucVu.SelectedText = cbChucVu.Items[0].ToString();
            NVCount = nhanVienBUS.getNhanVienCount();
            if (this.isAdd)
                setMaNV();
        }

        public frmAddStaff(string manv, string tennv, int gioitinh, int songayphep, int chucvu, DateTime ngaysinh, DateTime ngayvaolam, string email, int luong1ngay)
        {
            this.isAdd = false;
            InitializeComponent();
            txtMaNV.Text = manv;
            txtTenNV.Text = tennv;
            if (gioitinh == 1)
                rbtnNu.Checked = true;
            txtSoNgayPhep.Text = songayphep.ToString();
            cbChucVu.SelectedIndex = chucvu;
            dtpNgaySinh.Value = ngaysinh;
            dtpNgayVaoLam.Value = ngayvaolam;
            txtEmail.Text = email;
            txtLuong1Ngay.Text = luong1ngay.ToString();
        }

        private void setMaNV()
        {
            var gioitinh = (rbtnNam.Checked) ? 0 : 1;
            var nvl = dtpNgayVaoLam.Value.ToString("ddMMyy");
            var manv = "000" + (NVCount + 1);
            manv = manv.Substring(manv.Length - 4);
            txtMaNV.Text = "NV" + gioitinh + nvl + manv;
        }

        private void txtTenNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            var birthday = dtpNgaySinh.Value;
            var now = DateTime.Now;
            var age = CalculateAgeCorrect(birthday, now);
            if (age < 18)
            {
                lblNgaySinhAlert.Visible = true;
            }
            else
            {
                lblNgaySinhAlert.Visible = false;
            }
            var ngayVaoLam = dtpNgayVaoLam.Value;
            age = CalculateAgeCorrect(birthday, ngayVaoLam);
            if (age < 18)
            {
                lblNgayVaoLamAlert.Visible = true;
            }
            else
            {
                lblNgayVaoLamAlert.Visible = false;
            }
        }

        public int CalculateAgeCorrect(DateTime birthDate, DateTime now)
        {
            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;

            return age;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

            Regex regex = new Regex(pattern);

            bool isValid = regex.IsMatch(txtEmail.Text);
            if (isValid)
            {
                lblEmailAlert.Visible = false;
            }
            else { lblEmailAlert.Visible = true; }
        }

        private void dtpNgayVaoLam_ValueChanged(object sender, EventArgs e)
        {
            var birthday = dtpNgaySinh.Value;
            var ngayVaoLam = dtpNgayVaoLam.Value;
            var age = CalculateAgeCorrect(birthday, ngayVaoLam);
            if (age < 18)
            {
                lblNgayVaoLamAlert.Visible = true;
            }
            else
            {
                lblNgayVaoLamAlert.Visible = false;
            }
            if (this.isAdd)
                setMaNV();
        }

        private void txtLuong1Ngay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoNgayPhep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool xacNhan = true;
            if (txtTenNV.Text == "")
            {
                lblTenNVAlert.Visible = true;
                xacNhan = false;
            }

            var birthday = dtpNgaySinh.Value;
            var now = DateTime.Now;
            var age = CalculateAgeCorrect(birthday, now);
            if (age < 18)
            {
                lblNgaySinhAlert.Visible = true;
                xacNhan = false;
            }

            if (txtEmail.Text == "")
            {
                lblEmailAlert.Visible = true;
                xacNhan = false;
            }

            var ngayVaoLam = dtpNgayVaoLam.Value;
            age = CalculateAgeCorrect(birthday, ngayVaoLam);
            if (age < 18)
            {
                lblNgayVaoLamAlert.Visible = true;
                xacNhan = false;
            }

            if (txtLuong1Ngay.Text == "")
            {
                lblLuong1NgayAlert.Visible = true;
                xacNhan = false;
            }

            if (txtSoNgayPhep.Text == "")
            {
                lblSoNgayPhepAlert.Visible = true;
                xacNhan = false;
            }

            if (lblEmailAlert.Visible || lblLuong1NgayAlert.Visible || lblNgaySinhAlert.Visible || lblNgayVaoLamAlert.Visible || lblSoNgayPhepAlert.Visible || lblTenNVAlert.Visible)
            {
                xacNhan = false;
            }

            if (xacNhan)
            {
                var manv = txtMaNV.Text;
                var tennv = txtTenNV.Text;
                var gioitinh = (rbtnNam.Checked) ? 0 : 1;
                var songayphep = Convert.ToInt32(txtSoNgayPhep.Text);
                var chucvu = cbChucVu.SelectedIndex;
                var ngaysinh = dtpNgaySinh.Value;
                var ngayvaolam = dtpNgayVaoLam.Value;
                var email = txtEmail.Text;
                var luong1ngay = Convert.ToInt32(txtLuong1Ngay.Text);
                if (this.isAdd)
                {
                    nhanVienBUS.addNhanVien(manv, tennv, gioitinh, songayphep, chucvu, ngaysinh, ngayvaolam, email, luong1ngay);
                    MessageBoxDialog message = new MessageBoxDialog();
                    message.ShowDialog("Thông báo", "Thành công", "Thêm nhân viên mới thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                }
                else
                {
                    nhanVienBUS.updateNhanVien(manv, tennv, gioitinh, songayphep, chucvu, ngaysinh, ngayvaolam, email, luong1ngay);
                    MessageBoxDialog message = new MessageBoxDialog();
                    message.ShowDialog("Thông báo", "Thành công", "Thay đổi thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {
            if (txtTenNV.Text == "")
            {
                lblTenNVAlert.Visible = true;
            }
            else
            {
                lblTenNVAlert.Visible = false;
            }

            if (txtTenNV.Text.Length > 50)
            {
                txtTenNV.Text = txtTenNV.Text.Substring(0, 50);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtnNam_CheckedChanged(object sender, EventArgs e)
        {
            if (this.isAdd)
                setMaNV();
        }

        private void pnTop_MouseDown(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;
            mouseOffset = new Point(-mouseX, -mouseY);
        }

        private void pnTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                this.Location = mousePos;
            }
        }

        private void txtLuong1Ngay_TextChanged(object sender, EventArgs e)
        {
            if (txtLuong1Ngay.Text == string.Empty)
            {
                lblLuong1NgayAlert.Visible = true;
                return;
            }
            else lblLuong1NgayAlert.Visible = false;
            var luong1ngay = Convert.ToInt64(txtLuong1Ngay.Text);
            if (luong1ngay > Int32.MaxValue)
            {
                txtLuong1Ngay.Text = Int32.MaxValue.ToString();
            }
        }

        private void txtSoNgayPhep_TextChanged(object sender, EventArgs e)
        {
            if (txtSoNgayPhep.Text == string.Empty)
            {
                lblSoNgayPhepAlert.Visible = true;
                return;
            }
            else lblSoNgayPhepAlert.Visible = false;
            var songayphep = Convert.ToInt32(txtSoNgayPhep.Text);
            if (songayphep > 30)
            {
                txtSoNgayPhep.Text = 30.ToString();
            }
        }
    }
}