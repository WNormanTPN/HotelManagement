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

        /// <summary>
        /// Initialize a new instance of the frmAddStaff form.
        /// </summary>
        /// <return>None</return>
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

        /// <summary>
        /// Initialize a new instance of the frmAddStaff form with specific parameters.
        /// </summary>
        /// <param name="manv">Employee ID</param>
        /// <param name="tennv">Employee Name</param>
        /// <param name="gioitinh">Gender (0 for male, 1 for female</param>
        /// <param name="songayphep">Number of leave days</param>
        /// <param name="chucvu">Position index</param>
        /// <param name="ngaysinh">Date of birth</param>
        /// <param name="ngayvaolam">Date of joining</param>
        /// <param name="email">Email address</param>
        /// <param name="luong1ngay">Daily salary</param>
        /// <return>None</return>
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


        /// <summary>
        /// Set the employee ID based on gender, joining date, and current employee.
        /// </summary>
        private void setMaNV()
        {
            var gioitinh = (rbtnNam.Checked) ? 0 : 1;
            var nvl = dtpNgayVaoLam.Value.ToString("ddMMyy");
            var manv = "000" + (NVCount + 1);
            manv = manv.Substring(manv.Length - 4);
            txtMaNV.Text = "NV" + gioitinh + nvl + manv;
        }

        /// <summary>
        /// Handle the KeyPress event for the txtTenNV TextBox to ensure only letters, backspace, and space are allowed
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">A KeyPressEventArgs that contains the event data</param>
        private void txtTenNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        /// <summary>
        /// Handle the ValueChanged event for the dtpNgaySinh DateTimePicker to validate the employee's age
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
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

        /// <summary>
        /// Calculate the correct age based on the birth data and the current date
        /// </summary>
        /// <param name="birthDate">The birth date of the employee</param>
        /// <param name="now">The current date or the date to compare with</param>
        /// <returns>The calculated age as an integer</returns>
        public int CalculateAgeCorrect(DateTime birthDate, DateTime now)
        {
            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;

            return age;
        }

        /// <summary>
        /// Handles the TextChanged event for the txtEmail TextBox to validate the email format
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
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

        /// <summary>
        /// Handles the ValueChanged event for the dtpNgayVaoLam DateTimePicker to validate the employee's age at the date of joining
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
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

        /// <summary>
        /// Handles the KeyPress event for the txtLuong1Ngay TextBox to ensure only numeric input is allowed
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">A KeyPressEventArgs that contains the event data</param>
        private void txtLuong1Ngay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the KeyPress event for the txtSoNgayPhep TextBox to ensure only numeric input is allowed
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">A KeyPressEventArgs that contains the event data</param>
        private void txtSoNgayPhep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the click event for the button1 to validate and save the staff information
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
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

        /// <summary>
        /// Handle the TextChanged event for the txtTenNV TextBox
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
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

        /// <summary>
        /// Handles the click event for the btnClose button to close the form
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        ///  Handles the CheckedChanged event for the rbtnNam RadioButton to update the employee ID if adding a new employee
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void rbtnNam_CheckedChanged(object sender, EventArgs e)
        {
            if (this.isAdd)
                setMaNV();
        }

        /// <summary>
        /// Handles the MouseDown event for the pnTop panel to capture the mouse position for dragging the form
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void pnTop_MouseDown(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;
            mouseOffset = new Point(-mouseX, -mouseY);
        }

        /// <summary>
        /// Handles the MouseMove event for the pnTop panel to move the form when the left mouse button is held down
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void pnTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                this.Location = mousePos;
            }
        }

        /// <summary>
        /// Handles the TextChanged event for the txtLuong1Ngay TextBox to validate the daily salary input
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
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

        /// <summary>
        /// Handles the TextChanged event for the txtSoNgayPhep TextBox to validate the number of leave days input
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
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