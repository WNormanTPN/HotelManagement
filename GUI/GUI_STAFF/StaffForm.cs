using BUS;
using DTO;
using GUI.GUI_COMPONENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Text.RegularExpressions;

namespace GUI.GUI_STAFF
{
    public partial class StaffForm : Form
    {

        NhanVienBUS nhanVienBUS = new NhanVienBUS();

        /// <summary>
        /// Initializes a new instance of the StaffForm class, sets up event handlers, and loads initial data
        /// </summary>
        public StaffForm()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(StaffForm_KeyDown);
            this.KeyPreview = true;
            txtMaNV.TextChanged += TxtMaNV_TextChanged;
            txtTenNV.TextChanged += OtherFields_TextChanged;
            cbGioiTinh.TextChanged += OtherFields_TextChanged;
            cbChucVu.TextChanged += OtherFields_TextChanged;
            cbNgayNghiPhep.TextChanged += OtherFields_TextChanged;
            cbLuong1Ngay.TextChanged += OtherFields_TextChanged;
            dtpNgaySinhTu.ValueChanged += OtherFields_TextChanged;
            dtpNgaySinhDen.ValueChanged += OtherFields_TextChanged;
            dtpNgayVaoLamTu.ValueChanged += OtherFields_TextChanged;
            dtpNgayVaoLamDen.ValueChanged += OtherFields_TextChanged;
            txtEmail.TextChanged += OtherFields_TextChanged;
            onLoad();
        }

        /// <summary>
        /// Handles the TextChanged event for the txtMaNV TextBox to enable or disable other fields based on the employee ID input
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void TxtMaNV_TextChanged(object sender, EventArgs e)
        {
            bool isMaNVNotEmpty = !string.IsNullOrEmpty(txtMaNV.Text);
            SetOtherFieldsEnable(!isMaNVNotEmpty);
        }

        /// <summary>
        /// Handles the TextChanged event for various fields to enable or disable the txtMaNV TextBox based on the input in other fields
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void OtherFields_TextChanged(object sender, EventArgs e)
        {
            //CheckAndEnableMaNV();

            bool areOtherFieldsEmpty = string.IsNullOrEmpty(txtTenNV.Text) && 
                string.IsNullOrEmpty(cbGioiTinh.Text) &&
                string.IsNullOrEmpty(cbChucVu.Text) &&
                string.IsNullOrEmpty(txtEmail.Text) &&
                string.IsNullOrEmpty(cbNgayNghiPhep.Text) &&
                string.IsNullOrEmpty(cbLuong1Ngay.Text) &&
                dtpNgaySinhTu.Text == " " &&
                dtpNgaySinhDen.Text == " " &&
                dtpNgayVaoLamTu.Text == " " &&
                dtpNgayVaoLamDen.Text == " ";
            if (areOtherFieldsEmpty)
            {
                txtMaNV.Enabled = true;
            }
            else
            {
                txtMaNV.Enabled = false;
            }
        }

        /// <summary>
        /// Checks if all relevant fields are empty and enables or disables the txtMaNV TextBox accordingly
        /// </summary>
        private void CheckAndEnableMaNV()
        {
            if (string.IsNullOrEmpty(txtTenNV.Text) &&
                string.IsNullOrEmpty(cbGioiTinh.Text) &&
                string.IsNullOrEmpty(cbChucVu.Text) &&
                string.IsNullOrEmpty(txtEmail.Text) &&
                string.IsNullOrEmpty(cbNgayNghiPhep.Text) &&
                string.IsNullOrEmpty(cbLuong1Ngay.Text) &&
                dtpNgaySinhTu.Text == " " &&
                dtpNgaySinhDen.Text == " " &&
                dtpNgayVaoLamTu.Text == " " &&
                dtpNgayVaoLamDen.Text == " ")
            {
                txtMaNV.Enabled = true;
            } 
            else
            {
                txtMaNV.Enabled = false;
            }
        }

        /// <summary>
        /// Enables or disables other input fields based on the provided boolean value
        /// </summary>
        /// <param name="enabled">A boolean value indicating whether to enable or disable the fields</param>
        private void SetOtherFieldsEnable(bool enabled)
        {
            
            txtTenNV.Enabled = enabled;
            cbGioiTinh.Enabled = enabled;
            cbChucVu.Enabled = enabled;
            cbLuong1Ngay.Enabled = enabled;
            cbNgayNghiPhep.Enabled = enabled;
            dtpNgaySinhTu.Enabled = enabled;
            dtpNgaySinhDen.Enabled = enabled;
            dtpNgayVaoLamTu.Enabled = enabled;
            dtpNgayVaoLamDen.Enabled = enabled;
            txtEmail.Enabled = enabled;
        }

        /// <summary>
        /// Handles the TextChanged event for the txtTenNV TextBox. Throws an exception to indicate that a method or a block of code has not been implemented
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void TxtTenNV_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes the form by clearing and setting up the data grid and date pickers, then loads employee data into the data grid.
        /// </summary>
        private void onLoad()
        {
            dataNhanVien.Rows.Clear();
            dtpNgaySinhTu.Checked = false;
            dtpNgaySinhTu.CustomFormat = " ";
            dtpNgaySinhTu.Format = DateTimePickerFormat.Custom;
            dtpNgaySinhDen.Checked = false;
            dtpNgaySinhDen.CustomFormat = " ";
            dtpNgaySinhDen.Format = DateTimePickerFormat.Custom;
            dtpNgayVaoLamTu.Checked = false;
            dtpNgayVaoLamTu.CustomFormat = " ";
            dtpNgayVaoLamTu.Format = DateTimePickerFormat.Custom;
            dtpNgayVaoLamDen.Checked = false;
            dtpNgayVaoLamDen.CustomFormat = " ";
            dtpNgayVaoLamDen.Format = DateTimePickerFormat.Custom;
            var dt = nhanVienBUS.getNhanVien();
            int stt = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var manv = dt.Rows[i][0].ToString();
                var tennv = dt.Rows[i][1].ToString();
                var gt = dt.Rows[i][2].ToString();
                string gioitinh;
                if (gt == "0")
                    gioitinh = "Nam";
                else
                    gioitinh = "Nu";
                var songayphep = dt.Rows[i][3].ToString();
                string chucvu;
                var cv = dt.Rows[i][4].ToString();
                if (cv == "0")
                    chucvu = "Quản lý";
                else if (cv == "1")
                    chucvu = "Lễ tân";
                else if (cv == "2")
                    chucvu = " Kê toán";
                else
                    chucvu = "Bếp";

                var ngaysinh = DateTime.Parse(dt.Rows[i][5].ToString().Split()[0]).ToString("dd/MM/yyyy");
                var ngayvaolam = DateTime.Parse(dt.Rows[i][6].ToString().Split()[0]).ToString("dd/MM/yyyy");
                var email = dt.Rows[i][7].ToString();
                var luong1ngay = dt.Rows[i][8].ToString();
                dataNhanVien.Rows.Add(stt, manv, tennv, gioitinh, ngaysinh, ngayvaolam, chucvu, songayphep, luong1ngay, email);
                stt++;//*****
            }
            dataNhanVien.ClearSelection();
        }

        /// <summary>
        /// Loads employee data from the provided DataTable into the data grid.
        /// </summary>
        /// <param name="dt">A DataTable containing employee data</param>
        private void onLoad(DataTable dt)
        {
            dataNhanVien.Rows.Clear();
            int stt = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var manv = dt.Rows[i][0].ToString();
                var tennv = dt.Rows[i][1].ToString();
                var gt = dt.Rows[i][2].ToString();
                string gioitinh;
                if (gt == "0")
                    gioitinh = "Nam";
                else
                    gioitinh = "Nu";
                var songayphep = dt.Rows[i][3].ToString();
                string chucvu;
                var cv = dt.Rows[i][4].ToString();
                if (cv == "0")
                    chucvu = "Quản lý";
                else if (cv == "1")
                    chucvu = "Lễ tân";
                else if (cv == "2")
                    chucvu = " Kê toán";
                else
                    chucvu = "Bếp";
                var ngaysinh = DateTime.Parse(dt.Rows[i][5].ToString().Split()[0]).ToString("dd/MM/yyyy");
                var ngayvaolam = DateTime.Parse(dt.Rows[i][6].ToString().Split()[0]).ToString("dd/MM/yyyy");
                var email = dt.Rows[i][7].ToString();
                var luong1ngay = dt.Rows[i][8].ToString();
                dataNhanVien.Rows.Add(stt, manv, tennv, gioitinh, ngaysinh, ngayvaolam, chucvu, songayphep, luong1ngay, email);
                stt++;//*****
            }
            dataNhanVien.ClearSelection();
        }

        /// <summary>
        /// Handles the Load event of the StaffForm.
        /// Disables the control box and clears any selection in the data grid.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void StaffForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            dataNhanVien.ClearSelection();
        }

        /// <summary>
        /// Handles the Click event of the buttonRounded4 control.
        /// Opens the frmAddStaff form to add a new staff member.
        /// If the dialog result is OK, clears the data grid and refreshes the data.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void buttonRounded4_Click(object sender, EventArgs e)
        {
            var addStaff = new frmAddStaff();
            var result = addStaff.ShowDialog();
            if (result == DialogResult.OK)
            {
                dataNhanVien.Rows.Clear();
                refresh();//*****
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// Gathers search criteria from the form fields and uses them to find matching employees.
        /// Loads the search results into the data grid.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var manv = txtMaNV.Text;
            var tennv = txtTenNV.Text;
            var gioitinh = cbGioiTinh.SelectedIndex;
            var chucvu = cbChucVu.SelectedIndex;
            var songayphep = cbNgayNghiPhep.Text;
            var luong1ngay = cbLuong1Ngay.Text;
            var ngaysinhtu = (dtpNgaySinhTu.CustomFormat.ToString().Length == 1) ? DateTime.MinValue : dtpNgaySinhTu.Value;
            var ngaysinhden = (dtpNgaySinhDen.CustomFormat.ToString().Length == 1) ? DateTime.MinValue : dtpNgaySinhDen.Value;
            var ngayvaolamtu = (dtpNgayVaoLamTu.CustomFormat.ToString().Length == 1) ? DateTime.MinValue : dtpNgayVaoLamTu.Value;
            var ngayvaolamden = (dtpNgayVaoLamDen.CustomFormat.ToString().Length == 1) ? DateTime.MinValue : dtpNgayVaoLamDen.Value;
            var email = txtEmail.Text;
            var dt = nhanVienBUS.findNhanVien(manv, tennv, gioitinh, chucvu, songayphep, luong1ngay, ngaysinhtu, ngaysinhden, ngayvaolamtu, ngayvaolamden, email);
            onLoad(dt);
        }

        /// <summary>
        /// Handles the KeyDown event of the StaffForm.
        /// If the Enter key is pressed, triggers the search button click event and suppresses the key press.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">A KeyEventArgs that contains the event data</param>
        private void StaffForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnReset control.
        /// Calls the refresh method to reset the form to its initial state.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void btnReset_Click(object sender, EventArgs e)//*****
        {
            refresh();
        }

        /// <summary>
        /// Resets the form fields to their default values and reloads the data grid.
        /// </summary>
        private void refresh()//*****
        {
            txtMaNV.Text = String.Empty;
            txtTenNV.Text = String.Empty;
            cbGioiTinh.SelectedItem = null;
            cbGioiTinh.SelectedIndex = -1;
            cbGioiTinh.Text = String.Empty;
            cbChucVu.SelectedItem = null;
            cbChucVu.SelectedIndex = -1;
            cbChucVu.Text = String.Empty;
            cbNgayNghiPhep.SelectedItem = null;
            cbNgayNghiPhep.SelectedIndex = -1;
            cbNgayNghiPhep.Text = String.Empty;
            cbLuong1Ngay.SelectedItem = null;
            cbLuong1Ngay.SelectedIndex = -1;
            cbLuong1Ngay.Text = String.Empty;
            dtpNgaySinhTu.Value = DateTime.Now;
            dtpNgaySinhDen.Value = DateTime.Now;
            dtpNgayVaoLamTu.Value = DateTime.Now;
            dtpNgayVaoLamDen.Value = DateTime.Now;
            SetOtherFieldsEnable(true);
            txtMaNV.Enabled = true;
            txtEmail.Text = string.Empty;
            dataNhanVien.Rows.Clear();
            onLoad();
        }

        /// <summary>
        /// Handles the ValueChanged event of the dtpNgaySinhTu control.
        /// Sets the custom date format to "dd/MM/yyyy" when the date value changes.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void dtpNgaySinhTu_ValueChanged(object sender, EventArgs e)
        {
            dtpNgaySinhTu.CustomFormat = "dd/MM/yyyy";
        }

        /// <summary>
        /// Handles the ValueChanged event of the dtpNgaySinhDen control.
        /// Sets the custom date format to "dd/MM/yyyy" when the date value changes.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void dtpNgaySinhDen_ValueChanged(object sender, EventArgs e)
        {
            dtpNgaySinhDen.CustomFormat = "dd/MM/yyyy";
        }

        /// <summary>
        /// Handles the ValueChanged event of the dtpNgayVaoLamTu control.
        /// Sets the custom date format to "dd/MM/yyyy" when the date value changes.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void dtpNgayVaoLamTu_ValueChanged(object sender, EventArgs e)
        {
            dtpNgayVaoLamTu.CustomFormat = "dd/MM/yyyy";
        }

        /// <summary>
        /// Handles the ValueChanged event of the dtpNgayVaoLamDen control.
        /// Sets the custom date format to "dd/MM/yyyy" when the date value changes.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void dtpNgayVaoLamDen_ValueChanged(object sender, EventArgs e)
        {
            dtpNgayVaoLamDen.CustomFormat = "dd/MM/yyyy";
        }

        /// <summary>
        /// Handles the Click event of the buttonRounded1 control.
        /// Prompts the user for confirmation to delete selected employees.
        /// If confirmed, deletes the selected employees and shows a success message.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void buttonRounded1_Click(object sender, EventArgs e)
        {
            MessageBoxDialog message = new MessageBoxDialog();
            var result = message.ShowDialog("Thông báo", "", "Bạn có chắc chắn muốn xóa?", MessageBoxDialog.WARNING, MessageBoxDialog.YES_NO, "Có", "Không", "");
            if (result != 1) return;
            for (int i = 0; i < dataNhanVien.SelectedRows.Count; i++)
            {
                nhanVienBUS.deleteNhanVien(dataNhanVien.SelectedRows[i].Cells[1].Value.ToString());
            }
            message = new MessageBoxDialog();
            message.ShowDialog("Thông báo", "Thành công", "Xóa nhân viên thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
            onLoad();
        }

        /// <summary>
        /// Handles the DoubleClick event of the dataNhanVien control.
        /// Opens a form to edit the selected employee's details if exactly one row is selected.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void dataNhanVien_DoubleClick(object sender, EventArgs e)
        {
            if (dataNhanVien.SelectedRows.Count != 1) return;
            var nhanvien = dataNhanVien.SelectedRows[0].Cells;
            var manv = nhanvien["MaNV"].Value.ToString();
            var tennv = nhanvien["TenNV"].Value.ToString();
            var gioitinh = (nhanvien["GioiTinh"].Value.ToString() == "Nam") ? 0 : 1;
            var songayphep = Convert.ToInt32(nhanvien["SoNgayPhep"].Value.ToString());
            int chucvu;
            if (nhanvien["ChucVu"].Value.ToString() == "Quản lý")
            {
                chucvu = 0;
            }
            else if (nhanvien["ChucVu"].Value.ToString() == "Lễ tân")
            {
                chucvu = 1;
            }
            else if (nhanvien["ChucVu"].Value.ToString() == "Kế toán")
            {
                chucvu = 2;
            }
            else
            {
                chucvu = 3;
            }
            var ngaysinh = DateTime.ParseExact(nhanvien["NgaySinh"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var ngayvaolam = DateTime.ParseExact(nhanvien["NgayVaoLam"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var email = nhanvien["Email"].Value.ToString();
            var luong1ngay = Convert.ToInt32(nhanvien["Luong1Ngay"].Value.ToString());
            var addStaff = new frmAddStaff(manv, tennv, gioitinh, songayphep, chucvu, ngaysinh, ngayvaolam, email, luong1ngay);
            var result = addStaff.ShowDialog();
            if (result == DialogResult.OK)
            {
                dataNhanVien.Rows.Clear();
                refresh();//*****
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonRounded7 control.
        /// Opens a form to edit the selected employee's details if exactly one row is selected.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void buttonRounded7_Click(object sender, EventArgs e)
        {
            if (dataNhanVien.SelectedRows.Count != 1) return;//*****
            var nhanvien = dataNhanVien.SelectedRows[0].Cells;
            var manv = nhanvien["MaNV"].Value.ToString();
            var tennv = nhanvien["TenNV"].Value.ToString();
            var gioitinh = (nhanvien["GioiTinh"].Value.ToString() == "Nam") ? 0 : 1;
            var songayphep = Convert.ToInt32(nhanvien["SoNgayPhep"].Value.ToString());
            int chucvu;
            if (nhanvien["ChucVu"].Value.ToString() == "Quản lý")
            {
                chucvu = 0;
            }
            else if (nhanvien["ChucVu"].Value.ToString() == "Lễ tân")
            {
                chucvu = 1;
            }
            else if (nhanvien["ChucVu"].Value.ToString() == "Kế toán")
            {
                chucvu = 2;
            }
            else
            {
                chucvu = 3;
            }
            var ngaysinh = DateTime.ParseExact(nhanvien["NgaySinh"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var ngayvaolam = DateTime.ParseExact(nhanvien["NgayVaoLam"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var email = nhanvien["Email"].Value.ToString();
            var luong1ngay = Convert.ToInt32(nhanvien["Luong1Ngay"].Value.ToString());
            var addStaff = new frmAddStaff(manv, tennv, gioitinh, songayphep, chucvu, ngaysinh, ngayvaolam, email, luong1ngay);
            var result = addStaff.ShowDialog();
            if (result == DialogResult.OK)
            {
                dataNhanVien.Rows.Clear();
                refresh();//*****
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the dataNhanVien control.
        /// Enables or disables buttons based on the number of selected rows.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void dataNhanVien_SelectionChanged(object sender, EventArgs e)//*****
        {
            if (dataNhanVien.SelectedRows.Count == 1)
                buttonRounded7.Enabled = true;
            else
                buttonRounded7.Enabled = false;

            if (dataNhanVien.SelectedRows.Count >= 1)
                buttonRounded1.Enabled = true;
            else
                buttonRounded1.Enabled = false;
        }

        /// <summary>
        /// Handles the KeyPress event of the cbNgayNghiPhep control.
        /// Ensures that only valid numeric input is allowed in the cbNgayNghiPhep ComboBox.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">A KeyPressEventArgs that contains the event data</param>
        private void cbNgayNghiPhep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbNgayNghiPhep.Text == String.Empty)
            {
                e.Handled = true;
                return;
            }

            bool isSelectMany = false;
            if (cbNgayNghiPhep.SelectionLength > 0)
            {
                isSelectMany = true;
            }

            if (isSelectMany)
            {
                var selectedText = cbNgayNghiPhep.SelectedText;
                var selectStart = cbNgayNghiPhep.SelectionStart;
                var count = cbNgayNghiPhep.SelectionLength;

                if (int.TryParse(selectedText, out var _))
                {
                    if (char.IsDigit(e.KeyChar))
                    {
                        e.Handled = false;
                        return;
                    }
                    else if (e.KeyChar == (char)Keys.Back)
                    {
                        if (selectStart == 0 || selectStart + count >= cbNgayNghiPhep.Text.Length)
                        {
                            e.Handled = true;
                            return;
                        }
                        if (int.TryParse(cbNgayNghiPhep.Text[selectStart - 1].ToString(), out var _) || int.TryParse(cbNgayNghiPhep.Text[selectStart + count].ToString(), out var _))
                        {
                            e.Handled = false;
                            return;
                        }
                        else if (cbNgayNghiPhep.Text[selectStart - 1] == ' ' && cbNgayNghiPhep.Text[selectStart + count] == ' ')
                        {
                            e.Handled = true;
                            cbNgayNghiPhep.Text = cbNgayNghiPhep.Text.Remove(selectStart, count);
                            cbNgayNghiPhep.Text = cbNgayNghiPhep.Text.Insert(selectStart, "0");
                            cbNgayNghiPhep.SelectionStart = selectStart;
                        }
                        else
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                    else
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }
            else
            {
                var cursorPos = cbNgayNghiPhep.SelectionStart;
                if (char.IsDigit(e.KeyChar))
                {
                    if (cursorPos == 0)
                    {
                        e.Handled = true;
                        return;
                    }
                    if (int.TryParse(cbNgayNghiPhep.Text[cursorPos - 1].ToString(), out var _) || int.TryParse(cbNgayNghiPhep.Text[cursorPos].ToString(), out var _))
                    {
                        e.Handled = false;
                        return;
                    }
                    else
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else if (e.KeyChar == (char)Keys.Back)
                {
                    if (cursorPos < 2)
                    {
                        e.Handled = true;
                        return;
                    }
                    if (int.TryParse(cbNgayNghiPhep.Text[cursorPos - 1].ToString(), out var _) && int.TryParse(cbNgayNghiPhep.Text[cursorPos - 2].ToString(), out var _))
                    {
                        e.Handled = false;
                        return;
                    }
                    else if (int.TryParse(cbNgayNghiPhep.Text[cursorPos - 1].ToString(), out var _) && int.TryParse(cbNgayNghiPhep.Text[cursorPos].ToString(), out var _))
                    {
                        e.Handled = false;
                        return;
                    }
                    else if (int.TryParse(cbNgayNghiPhep.Text[cursorPos - 1].ToString(), out var _) && !int.TryParse(cbNgayNghiPhep.Text[cursorPos].ToString(), out var _))
                    {
                        e.Handled = true;
                        cbNgayNghiPhep.Text = cbNgayNghiPhep.Text.Remove(cursorPos - 1, 1);
                        cbNgayNghiPhep.Text = cbNgayNghiPhep.Text.Insert(cursorPos - 1, "0");
                        cbNgayNghiPhep.SelectionStart = cursorPos;
                    }
                    else
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// Handles the KeyPress event for the cbLuong1Ngay ComboBox to ensure only valid input is allowed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A KeyPressEventArgs that contains the event data.</param>
        private void cbLuong1Ngay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbLuong1Ngay.Text == String.Empty)
            {
                e.Handled = true;
                return;
            }

            bool isSelectMany = false;
            if (cbLuong1Ngay.SelectionLength > 0)
            {
                isSelectMany = true;
            }

            if (isSelectMany)
            {
                var selectedText = cbLuong1Ngay.SelectedText;
                var selectStart = cbLuong1Ngay.SelectionStart;
                var count = cbLuong1Ngay.SelectionLength;

                if (int.TryParse(selectedText, out var _))
                {
                    if (char.IsDigit(e.KeyChar))
                    {
                        e.Handled = false;
                        return;
                    }
                    else if (e.KeyChar == (char)Keys.Back)
                    {
                        if (selectStart == 0 || selectStart + count >= cbLuong1Ngay.Text.Length)
                        {
                            e.Handled = true;
                            return;
                        }
                        if (int.TryParse(cbLuong1Ngay.Text[selectStart - 1].ToString(), out var _) || int.TryParse(cbLuong1Ngay.Text[selectStart + count].ToString(), out var _))
                        {
                            e.Handled = false;
                            return;
                        }
                        else if (cbLuong1Ngay.Text[selectStart - 1] == ' ' && cbLuong1Ngay.Text[selectStart + count] == ' ')
                        {
                            e.Handled = true;
                            cbLuong1Ngay.Text = cbLuong1Ngay.Text.Remove(selectStart, count);
                            cbLuong1Ngay.Text = cbLuong1Ngay.Text.Insert(selectStart, "0");
                            cbLuong1Ngay.SelectionStart = selectStart;
                        }
                        else
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                    else
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }
            else
            {
                var cursorPos = cbLuong1Ngay.SelectionStart;
                if (char.IsDigit(e.KeyChar))
                {
                    if (cursorPos == 0)
                    {
                        e.Handled = true;
                        return;
                    }
                    if (int.TryParse(cbLuong1Ngay.Text[cursorPos - 1].ToString(), out var _) || int.TryParse(cbLuong1Ngay.Text[cursorPos].ToString(), out var _))
                    {
                        e.Handled = false;
                        return;
                    }
                    else
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else if (e.KeyChar == (char)Keys.Back)
                {
                    if (cursorPos < 2)
                    {
                        e.Handled = true;
                        return;
                    }
                    if (int.TryParse(cbLuong1Ngay.Text[cursorPos - 1].ToString(), out var _) && int.TryParse(cbLuong1Ngay.Text[cursorPos - 2].ToString(), out var _))
                    {
                        e.Handled = false;
                        return;
                    }
                    else if (int.TryParse(cbLuong1Ngay.Text[cursorPos - 1].ToString(), out var _) && int.TryParse(cbLuong1Ngay.Text[cursorPos].ToString(), out var _))
                    {
                        e.Handled = false;
                        return;
                    }
                    else if (int.TryParse(cbLuong1Ngay.Text[cursorPos - 1].ToString(), out var _) && !int.TryParse(cbLuong1Ngay.Text[cursorPos].ToString(), out var _))
                    {
                        e.Handled = true;
                        cbLuong1Ngay.Text = cbLuong1Ngay.Text.Remove(cursorPos - 1, 1);
                        cbLuong1Ngay.Text = cbLuong1Ngay.Text.Insert(cursorPos - 1, "0");
                        cbLuong1Ngay.SelectionStart = cursorPos;
                    }
                    else
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// Handles the MouseClick event for the cbLuong1Ngay ComboBox to remove commas from the text if no text is selected.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A MouseEventArgs that contains the event data.</param>
        private void cbLuong1Ngay_MouseClick(object sender, MouseEventArgs e)
        {
            if (cbLuong1Ngay.SelectionLength == 0)
            {
                cbLuong1Ngay.Text = cbLuong1Ngay.Text.Replace(",", "");
            }
        }

        /// <summary>
        /// Handles the Leave event for the cbLuong1Ngay ComboBox to format the text with commas for thousands separators.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void cbLuong1Ngay_Leave(object sender, EventArgs e)
        {
            var arr = cbLuong1Ngay.Text.Split(' ');
            for (int i = 0; i < arr.Length; i++)
            {
                if (int.TryParse(arr[i], out var _))
                {
                    int dem = 0;
                    for (int j = arr[i].Length - 1; j > 0; j--)
                    {
                        dem++;
                        if (dem % 3 == 0)
                        {
                            arr[i] = arr[i].Insert(j, ",");
                        }
                    }
                }
            }
            cbLuong1Ngay.Text = String.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                cbLuong1Ngay.Text += arr[i] + " ";
            }
            cbLuong1Ngay.Text.Remove(cbLuong1Ngay.Text.Length - 1);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var message = new MessageBoxDialog();
            var result = message.ShowDialog("Thông báo", "Xuất file", "Bạn có muốn xuất file Excel không?", MessageBoxDialog.INFO, MessageBoxDialog.YES_NO, "Có", "Không", "");
            if (result == MessageBoxDialog.YES)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Documents (*.xls)|*.xls";
                sfd.FileName = "Inventory_Adjustment_Export.xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Copy DataGridView results to clipboard
                    copyAlltoClipboard();

                    object misValue = System.Reflection.Missing.Value;
                    Excel.Application xlexcel = new Excel.Application();

                    xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
                    Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
                    Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    // Format column D as text before pasting results, this was required for my data
                    //Excel.Range rng = xlWorkSheet.get_Range("C:C").Cells;
                    Excel.Range rng = xlWorkSheet.Columns;
                    rng.NumberFormat = "@";

                    // Paste clipboard results to worksheet range
                    Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 2];
                    CR.Select();
                    xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                    xlWorkSheet.Columns.AutoFit();

                    // For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
                    // Delete blank column A and select cell A1
                    Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
                    delRng.Delete(Type.Missing);
                    xlWorkSheet.get_Range("A1").Select();

                    // Save the excel file under the captured location from the SaveFileDialog
                    xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlexcel.DisplayAlerts = true;
                    xlWorkBook.Close(true, misValue, misValue);
                    xlexcel.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlexcel);

                    // Clear Clipboard and DataGridView selection
                    Clipboard.Clear();
                    dataNhanVien.ClearSelection();

                    // Open the newly saved excel file
                    if (File.Exists(sfd.FileName))
                        System.Diagnostics.Process.Start(sfd.FileName);
                }
            }
        }

        /// <summary>
        /// Handles the Leave event for the cbLuong1Ngay ComboBox to format the text with commas for thousands separators.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void copyAlltoClipboard()
        {

            dataNhanVien.SelectAll();
            DataObject dataObj = dataNhanVien.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        /// <summary>
        /// Releases a COM object to free up resources.
        /// </summary>
        /// <param name="obj">The COM object to be released.</param>
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// Handles the click event for the Import button to import employee data from an Excel file.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            var message = new MessageBoxDialog();
            var result = message.ShowDialog("Thông báo", "Nhập file", "Bạn có muốn nhập file Excel không?", MessageBoxDialog.INFO, MessageBoxDialog.YES_NO, "Có", "Không", "");
            if (result == MessageBoxDialog.YES)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Excel Documents (*.xls)|*.xls";
                ofd.FileName = "Inventory_Adjustment_Export.xls";
                string fileName;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                }
                else return;
                object misValue = System.Reflection.Missing.Value;
                Excel.Application xlApp = new Excel.Application();
                xlApp.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(fileName);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
                loadDataNhanVien(xlWorkSheet);
                xlWorkBook.Close();
            }
        }

        /// <summary>
        /// Loads employee data from an Excel worksheet, checking for duplicate employee IDs both within the Excel file and against the database.
        /// </summary>
        /// <param name="sheet">The Excel worksheet containing the employee data.</param>
        private void loadDataNhanVien(Excel.Worksheet sheet)
        {
            var usedRange = sheet.UsedRange;
            int rowCount = usedRange.Rows.Count;

            // Check duplicate Employee Id in Excel
            for (int i = 2; i <= rowCount; i++)
            {
                string manvi = usedRange.Cells[i, 2].Value2.ToString();
                for (int j = i + 1; j <= rowCount; j++)
                {
                    string manvj = usedRange.Cells[j, 2].value2.ToString();
                    if (manvi == manvj) // if Employee Id is duplicate
                    {
                        var message = new MessageBoxDialog();
                        var result = message.ShowDialog("Thông báo", "Lỗi nhập file", "Trong file có 2 mã nhân viên " + manvi + " trùng nhau, vui lòng cập nhật lại", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "OK", "", "");
                        return;
                    }
                }
            }

            // Check duplicate Employee Id in Excel and Database
            for (int i = 2; i <= rowCount; i++)
            {
                var isDuplicate = false;
                string manv = usedRange.Cells[i, 2].Value2.ToString().Trim();
                foreach (DataRow nvRow in nhanVienBUS.getNhanVien().Rows)
                {
                    if (manv == nvRow["MaNV"].ToString()) // if Employee Id is duplicate
                    {
                        isDuplicate = true;
                        var message = new MessageBoxDialog();
                        var result = message.ShowDialog("Thông báo", "Trùng mã nhân viên", "Trong file có mã nhân viên " + nvRow["MaNV"] + " trùng với mã nhân viên sẵn có, bạn hãy chọn cách xử lý", MessageBoxDialog.WARNING, MessageBoxDialog.YES_NO_CANCEL, "Keep old", "Keep current", "Add current");
                        if (result == MessageBoxDialog.YES)
                        {
                            continue;
                        }
                        else if (result == MessageBoxDialog.NO_OPTION)
                        {
                            checkAndUpdateNhanVien(i, usedRange);
                        }
                        else if (result == MessageBoxDialog.CANCEL_OPTION)
                        {
                            checkAndAddNhanVien(i, usedRange);
                        }
                    }
                }
                if (!isDuplicate)
                {
                    checkAndAddNhanVien(i, usedRange);
                }
            }
        }

        /// <summary>
        /// Updates employee information based on data from an Excel worksheet row.
        /// </summary>
        /// <param name="row">The row number in the Excel worksheet.</param>
        /// <param name="usedRange">The used range of the Excel worksheet.</param>
        public void checkAndUpdateNhanVien(int row, Excel.Range usedRange)
        {
            var manv = usedRange.Cells[row, 2].Value2.ToString().Trim();
            var tennv = usedRange.Cells[row, 3].Value2.ToString().Trim();
            if (tennv == "")
            {
                var message = new MessageBoxDialog();
                var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thay đổi thông  tin nhân viên thất bại, tên nhân viên không được để trống.", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                return;
            }

            string strgt = usedRange.Cells[row, 4].Value2.ToString().Trim();
            int gt;
            if (string.Equals(strgt, "Nam", StringComparison.OrdinalIgnoreCase))
            {
                gt = 0;
            }
            else if (string.Equals(strgt, "Nu", StringComparison.OrdinalIgnoreCase))
            {
                gt = 1;
            }
            else
            {
                var message = new MessageBoxDialog();
                var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thay đổi thông  tin nhân viên thất bại, giới tính phải là Nam hoặc Nữ.", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                return;
            }

            var strns = usedRange.Cells[row, 5].Value.ToString().Trim().Substring(0, 10);
            if (DateTime.TryParseExact(strns,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out DateTime ns))
            {
                var age = CalculateAgeCorrect(ns, DateTime.Now);
                if (age < 18)
                {
                    var message = new MessageBoxDialog();
                    var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thay đổi thông  tin nhân viên thất bại, nhân viên phải đủ 18 tuổi.", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                    return;
                }
            }
            else
            {
                var message = new MessageBoxDialog();
                var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thay đổi thông  tin nhân viên thất bại, ngày sinh phải đúng định dạng dd/mm/yyyy.", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                return;
            }

            var strnvl = usedRange.Cells[row, 6].Value.ToString().Trim().Substring(0, 10);
            if (DateTime.TryParseExact(strnvl,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out DateTime nvl))
            {
                var age = CalculateAgeCorrect(ns, nvl);
                if (age < 18)
                {
                    var message = new MessageBoxDialog();
                    var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thay đổi thông  tin nhân viên thất bại, nhân viên phải đủ 18 tuổi khi vào làm.", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                    return;
                }
            }
            else
            {
                var message = new MessageBoxDialog();
                var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thay đổi thông  tin nhân viên thất bại, ngày vào làm phải đúng định dạng dd/mm/yyyy.", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                return;
            }

            var strcv = usedRange.Cells[row, 7].Value2.ToString().Trim();
            int cv;
            if (string.Equals(strcv, "quản lý", StringComparison.OrdinalIgnoreCase))
            {
                cv = 0;
            }
            else if (string.Equals(strcv, "lễ tân", StringComparison.OrdinalIgnoreCase))
            {
                cv = 1;
            }
            else if (string.Equals(strcv, "kế toán", StringComparison.OrdinalIgnoreCase))
            {
                cv = 2;
            }
            else if (string.Equals(strcv, "bếp", StringComparison.OrdinalIgnoreCase))
            {
                cv = 3;
            }
            else
            {
                var message = new MessageBoxDialog();
                var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thay đổi thông  tin nhân viên thất bại, chức vụ " + strcv + " không tồn tại.", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                return;
            }

            int snp = Convert.ToInt32(usedRange.Cells[row, 8].Value2.ToString().Trim());
            if (snp > 30)
            {
                var message = new MessageBoxDialog();
                var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thay đổi thông  tin nhân viên thất bại, số ngày phép không được quá 30 ngày.", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                return;
            }

            int l1n = Convert.ToInt32(usedRange.Cells[row, 9].Value2.ToString().Trim());
            if (l1n > Int32.MaxValue)
            {
                var message = new MessageBoxDialog();
                var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thay đổi thông  tin nhân viên thất bại, lương 1 ngày không được quá " + Int32.MaxValue, MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                return;
            }

            var email = usedRange.Cells[row, 10].Value2.ToString().Trim();
            string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(email))
            {
                var message = new MessageBoxDialog();
                var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thay đổi thông  tin nhân viên thất bại, email không đúng định dạng", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                return;
            }
            nhanVienBUS.updateNhanVien(manv, tennv, gt, snp, cv, ns, nvl, email, l1n);
            refresh();
        }

        /// <summary>
        /// Adds a new employee to the database after validating the data from the Excel sheet.
        /// </summary>
        /// <param name="row">The row number in the Excel sheet.</param>
        /// <param name="usedRange">The range of used cells in the Excel sheet.</param>
        public void checkAndAddNhanVien(int row, Excel.Range usedRange)
        {
            var tennv = usedRange.Cells[row, 3].Value2.ToString().Trim();
            if (tennv == "")
            {
                var message = new MessageBoxDialog();
                var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thêm nhân viên dòng " + row + " thất bại, tên nhân viên không được để trống.", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                return;
            }

            string strgt = usedRange.Cells[row, 4].Value2.ToString().Trim();
            int gt;
            if (string.Equals(strgt, "nam", StringComparison.OrdinalIgnoreCase))
            {
                gt = 0;
            }
            else if (string.Equals(strgt, "nu", StringComparison.OrdinalIgnoreCase))
            {
                gt = 1;
            }
            else
            {
                var message = new MessageBoxDialog();
                var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thêm nhân viên dòng " + row + " thất bại, giới tính phải là Nam hoặc Nữ.", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                return;
            }

            var strns = usedRange.Cells[row, 5].Value.ToString().Trim().Substring(0, 10);
            if (DateTime.TryParseExact(strns,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out DateTime ns))
            {
                var age = CalculateAgeCorrect(ns, DateTime.Now);
                if (age < 18)
                {
                    var message = new MessageBoxDialog();
                    var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thêm nhân viên dòng " + row + " thất bại, nhân viên phải đủ 18 tuổi.", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                    return;
                }
            }
            else
            {
                var message = new MessageBoxDialog();
                var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thêm nhân viên dòng " + row + " thất bại, ngày sinh phải đúng định dạng dd/mm/yyyy.", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                return;
            }

            var strnvl = usedRange.Cells[row, 6].Value.ToString().Trim().Substring(0, 10);
            if (DateTime.TryParseExact(strnvl,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out DateTime nvl))
            {
                var age = CalculateAgeCorrect(ns, nvl);
                if (age < 18)
                {
                    var message = new MessageBoxDialog();
                    var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thêm nhân viên dòng " + row + " thất bại, nhân viên phải đủ 18 tuổi khi vào làm.", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                    return;
                }
            }
            else
            {
                var message = new MessageBoxDialog();
                var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thêm nhân viên dòng " + row + " thất bại, ngày vào làm phải đúng định dạng dd/mm/yyyy.", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                return;
            }

            var strcv = usedRange.Cells[row, 7].Value2.ToString().Trim();
            int cv;
            if (string.Equals(strcv, "quản lý", StringComparison.OrdinalIgnoreCase))
            {
                cv = 0;
            }
            else if (string.Equals(strcv, "lễ tân", StringComparison.OrdinalIgnoreCase))
            {
                cv = 1;
            }
            else if (string.Equals(strcv, "kế toán", StringComparison.OrdinalIgnoreCase))
            {
                cv = 2;
            }
            else if (string.Equals(strcv, "bếp", StringComparison.OrdinalIgnoreCase))
            {
                cv = 3;
            }
            else
            {
                var message = new MessageBoxDialog();
                var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thêm nhân viên dòng " + row + " thất bại, chức vụ " + strcv + " không tồn tại.", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                return;
            }

            int snp = Convert.ToInt32(usedRange.Cells[row, 8].Value2.ToString().Trim());
            if (snp > 30)
            {
                var message = new MessageBoxDialog();
                var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thêm nhân viên dòng " + row + " thất bại, số ngày phép không được quá 30 ngày.", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                return;
            }

            int l1n = Convert.ToInt32(usedRange.Cells[row, 9].Value2.ToString().Trim());
            if (l1n > Int32.MaxValue)
            {
                var message = new MessageBoxDialog();
                var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thêm nhân viên dòng " + row + " thất bại, lương 1 ngày không được quá " + Int32.MaxValue, MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                return;
            }

            var email = usedRange.Cells[row, 10].Value2.ToString().Trim();
            string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(email))
            {
                var message = new MessageBoxDialog();
                var result = message.ShowDialog("Thông báo", "Lỗi định dạng", "Thêm nhân viên dòng " + row + " thất bại, email không đúng định dạng", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Bỏ qua", "", "");
                return;
            }

            var manv = getMaNV(gt, nvl);
            nhanVienBUS.addNhanVien(manv, tennv, gt, snp, cv, ns, nvl, email, l1n);
            refresh();
        }

        /// <summary>
        /// Calculates the correct age of a person based on their birth date and the current date.
        /// </summary>
        /// <param name="birthDate">The birth date of the person.</param>
        /// <param name="now">The current date.</param>
        /// <returns>The calculated age as an integer.</returns>
        public int CalculateAgeCorrect(DateTime birthDate, DateTime now)
        {
            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;
            return age;
        }

        /// <summary>
        /// Generates a unique employee ID based on gender, date of joining, and the current count of employees.
        /// </summary>
        /// <param name="gioitinh">Gender of the employee (0 for male, 1 for female)</param>
        /// <param name="ngayvaolam">Date of joining</param>
        /// <returns>A unique employee ID string</returns>
        private string getMaNV(int gioitinh, DateTime ngayvaolam)
        {
            var NVCount = nhanVienBUS.getNhanVienCount();
            var nvl = ngayvaolam.ToString("ddMMyy");
            var manv = "000" + (NVCount + 1);
            manv = manv.Substring(manv.Length - 4);
            return "NV" + gioitinh + nvl + manv;
        }

        /// <summary>
        /// Handles the RowPrePaint event of the dataNhanVien DataGridView to alternate row colors for better readability.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A DataGridViewRowPrePaintEventArgs that contains the event data.</param>
        private void dataNhanVien_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dataNhanVien.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dataNhanVien.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
                }
                else
                {
                    dataNhanVien.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
    }
}
