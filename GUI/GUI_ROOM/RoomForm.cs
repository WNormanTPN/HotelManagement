using BUS;
using DTO;
using GUI.GUI_COMPONENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.GUI_ROOM
{
    public partial class RoomForm : Form
    {
        #region Variable BUS
        PhongBUS phong = new PhongBUS();
        TienIchBUS tienIch = new TienIchBUS();
        List<PhongDTO> list;
        #endregion

        private Color colorBtnThemTienIch = Color.Green;
        private Color colorBtnSuaTienIch = Color.DarkOrange;
        private Color colorBtnXoaTienIch = Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
        public RoomForm()
        {
            list = phong.getListPhong_DTO();
            InitializeComponent();
            HienThiTienIch("");
            HienThiPhong(this.list);
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            setButton(true);
            tbTienIch.ClearSelection();
            tbPhong.ClearSelection();
            Reset();
        }

        // Giao diện phòng
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            frmAddRoom addRoom = new frmAddRoom(0, null);
            if (addRoom.ShowDialog() == DialogResult.OK)
            {
                list.Clear();
                list = phong.getListPhong_DTO();
                Reset_Phong();
            }
            else
            {
                Reset_Phong();
            }
        }
        private void HienThiPhong(List<PhongDTO> list)
        {
            tbPhong.Rows.Clear();
            int k = 0;
            foreach (PhongDTO phong in list)
            {
                string loaiP = "";
                string chiTietLoaiP = "";
                string tinhTrang = "";
                string hienTrang = "";
                if (phong.LoaiP == 0)
                {
                    loaiP = "Vip";
                }
                else
                {
                    loaiP = "Thường";
                }
                if (phong.ChiTietLoaiP == 0)
                {
                    chiTietLoaiP = "Phòng đơn";
                }
                else if (phong.ChiTietLoaiP == 1)
                {
                    chiTietLoaiP = "Phòng đôi";
                }
                else
                {
                    chiTietLoaiP = "Phòng gia đình";
                }
                if (phong.TinhTrang == 0)
                {
                    tinhTrang = "Trống";
                }
                else if (phong.TinhTrang == 1)
                {
                    tinhTrang = "Đang được thuê";
                }
                else
                {
                    tinhTrang = "Chưa dọn phòng";
                }
                if (phong.HienTrang == 0)
                {
                    hienTrang = "Mới";
                }
                else
                {
                    hienTrang = "Cũ";
                }
                tbPhong.Rows.Add(++k, phong.MaP, phong.TenP, loaiP, phong.GiaP.ToString("###,###0 VNĐ"), chiTietLoaiP, tinhTrang, hienTrang);
            }
            tbPhong.ClearSelection();
        }
        // Giao diện tiện ích
        private void txtSearchTienIch_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtSearchTienIch.Text.Trim().Equals("Nhập mã/tên tiện ích cần tìm..."))
            {
                txtSearchTienIch.Text = "";
            }
        }

        private void txtSearchTienIch_MouseLeave(object sender, EventArgs e)
        {
            if (txtSearchTienIch.Text.Trim().Length == 0)
            {
                txtSearchTienIch.Text = "Nhập mã/tên tiện ích cần tìm...";
                this.ActiveControl = null;
            }
        }

        private void txtSearchTienIch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchTienIch.Text != "Nhập mã/tên tiện ích cần tìm...")
            {
                if (txtSearchTienIch.Text.Trim().Length != 0)
                    HienThiTienIch(txtSearchTienIch.Text);
                else HienThiTienIch("");
            }
        }
        private void setButton(bool check)
        {
            if (check)
            {
                btnThemTienIch.BackColor = colorBtnThemTienIch;
                btnSuaTienIch.BackColor = colorBtnSuaTienIch;
                btnXoaTienIch.BackColor = colorBtnXoaTienIch;
                btnHuyTienIch.BackColor = SystemColors.Control;
                btnLuuTienIch.BackColor = SystemColors.Control;
            }
            else
            {
                btnThemTienIch.BackColor = SystemColors.Control;
                btnSuaTienIch.BackColor = SystemColors.Control;
                btnXoaTienIch.BackColor = SystemColors.Control;
                btnHuyTienIch.BackColor = Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
                btnLuuTienIch.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            }
            btnThemTienIch.Enabled = check;
            btnSuaTienIch.Enabled = check;
            btnXoaTienIch.Enabled = check;
            btnLuuTienIch.Enabled = !check;
            btnHuyTienIch.Enabled = !check;
        }
        private bool addTI = false;
        private bool isFunction = false;
        private void btnThemTienIch_Click(object sender, EventArgs e)
        {
            setButton(false);
            isFunction = true;
            Reset();
            addTI = true;
            tbTienIch.Enabled = false;
            ActiveControl = null;
            txtTenTienIch.Focus();
        }
        private void btnSuaTienIch_Click(object sender, EventArgs e)
        {
            if (tbTienIch.SelectedRows.Count > 0)
            {
                setButton(false);
                isFunction = true;
                ActiveControl = null;
            }
            else
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Lỗi chưa chọn dữ liệu", "Vui lòng chọn tiện ích cần sửa", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đồng ý", "", "");
            }
        }

        private void btnXoaTienIch_Click(object sender, EventArgs e)
        {
            if (tbTienIch.SelectedRows.Count > 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                int ans = message.ShowDialog("Thông báo", "Xác nhận xóa dữ liệu", "Bạn có muôn xóa dữ liệu", MessageBoxDialog.INFO, MessageBoxDialog.YES_NO, "Đồng ý", "Không đồng ý", "");
                if (ans == MessageBoxDialog.YES_OPTION)
                {
                    tienIch.XoaTienIch(txtMaTI.Text.Trim());
                    message = new MessageBoxDialog();
                    message.ShowDialog("Thành công", "Thành công", "Xóa dữ liệu thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                    Reset();
                    addTI = false;
                    tbTienIch.Enabled = true;
                    setButton(true);
                }
                else
                {
                    message.Close();
                }
            }
            else
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Lỗi chưa chọn dữ liệu", "Vui lòng chọn tiện ích cần xóa", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đồng ý", "", "");
            }
        }
        private void Reset()
        {
            HienThiTienIch("");
            txtMaTI.Text = "";
            txtTenTienIch.Text = "";
            lbErrorTenTI.Text = "";
            txtSearchTienIch.Text = "Nhập mã/tên tiện ích cần tìm...";
            tbTienIch.ClearSelection();
        }
        private void btnLuuTienIch_Click(object sender, EventArgs e)
        {
            if (txtTenTienIch.Text.Trim().Length == 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Lỗi không nhập dữ liệu", "Vui lòng nhập tên tiện ích", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đồng ý", "", "");
            }
            else
            {
                if (addTI)
                {
                    string dateNow = DateTime.Now.ToString("ddMMyy");
                    int countTI = tienIch.GetSoLuongTienIch() + 1;
                    string str = countTI.ToString("D4");
                    string id = "TI" + dateNow + str;
                    txtMaTI.Text = id;
                    tienIch.ThemTienIch(txtMaTI.Text.Trim(), txtTenTienIch.Text.Trim());
                    MessageBoxDialog message = new MessageBoxDialog();
                    message.ShowDialog("Thành công", "Thành công", "Thêm dữ liệu mới thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                    Reset();
                    addTI = false;
                    tbTienIch.Enabled = true;
                    setButton(true);
                }
                else
                {
                    MessageBoxDialog message = new MessageBoxDialog();
                    int ans = message.ShowDialog("Thông báo", "Xác nhận lưu dữ liệu", "Bạn có muôn sửa dữ liệu", MessageBoxDialog.INFO, MessageBoxDialog.YES_NO, "Đồng ý", "Không đồng ý", "");
                    if (ans == MessageBoxDialog.YES_OPTION)
                    {
                        tienIch.SuaTienIch(txtMaTI.Text.Trim(), txtTenTienIch.Text.Trim());
                        message = new MessageBoxDialog();
                        message.ShowDialog("Thành công", "Thành công", "Sửa dữ liệu thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                        Reset();
                        addTI = false;
                        tbTienIch.Enabled = true;
                        setButton(true);
                    }
                    else
                    {
                        message.Close();
                    }
                }
                isFunction = false;
            }
        }
        private void btnHuyTienIch_Click(object sender, EventArgs e)
        {
            setButton(true);
            HienThiTienIch("");
            txtMaTI.Text = "";
            txtTenTienIch.Text = "";
            lbErrorTenTI.Text = "";
            addTI = false;
            tbTienIch.Enabled = true;
            isFunction = false;
            ActiveControl = null;
        }
        private void HienThiTienIch(string search)
        {
            tbTienIch.Rows.Clear();
            DataTable dt = tienIch.getListTienIch();
            int k = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString().ToUpper().Contains(search.ToUpper()) ||
                    dt.Rows[i][1].ToString().ToUpper().Contains(search.ToUpper()))
                {
                    tbTienIch.Rows.Add(++k + "", dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
                }
            }
            txtTenTienIch.Text = "";
            txtMaTI.Text = "";
            tbTienIch.ClearSelection();
        }
        private void tbTienIch_SelectionChanged(object sender, EventArgs e)
        {
            if (tbTienIch.SelectedRows.Count > 0)
            {
                txtMaTI.Text = tbTienIch.SelectedRows[0].Cells[1].Value.ToString();
                txtTenTienIch.Text = tbTienIch.SelectedRows[0].Cells[2].Value.ToString();
            }
            else
            {
                txtMaTI.Text = string.Empty;
                txtTenTienIch.Text = string.Empty;
            }
        }
        private void txtTenTienIch_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtTenTienIch.Text.Trim().Length == 0 && isFunction)
            {
                lbErrorTenTI.Text = "Vui lòng nhập tên tiện ích";
            }
            else
            {
                lbErrorTenTI.Text = "";
            }
        }
        private void txtTenTienIch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTenTienIch.Text.Trim().Length == 0 && isFunction)
            {
                lbErrorTenTI.Text = "Vui lòng nhập tên tiện ích";
            }
            else
            {
                lbErrorTenTI.Text = "";
            }
        }

        private void txtTenTienIch_TextChanged(object sender, EventArgs e)
        {
            if (isFunction && txtTenTienIch.Text.Trim().Length == 0)
            {
                lbErrorTenTI.Text = "Vui lòng nhập tên tiện ích";
            }
            else
            {
                lbErrorTenTI.Text = "";
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (tbPhong.SelectedRows.Count == 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Lỗi chưa chọn dữ liệu", "Vui lòng chọn phòng muốn xem chi tiết", MessageBoxDialog.WARNING, MessageBoxDialog.YES, "Đóng", "", "");
            }
            else
            {
                var item = from room in this.list
                           where room.MaP.Equals(tbPhong.SelectedRows[0].Cells[1].Value.ToString())
                           select room;
                frmAddRoom addRoom = new frmAddRoom(1, item.ToList()[0]);
                if (addRoom.ShowDialog() == DialogResult.OK)
                {
                    list.Clear();
                    list = phong.getListPhong_DTO();
                    Reset_Phong();
                }
                else
                {
                    Reset_Phong();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset_Phong();
        }
        private void Reset_Phong()
        {
            txtTenP.Text = "";
            txtMaP.Text = "";
            cbLoaiP.SelectedIndex = -1;
            cbGiaP.SelectedIndex = -1;
            cbCTLP.SelectedIndex = -1;
            cbTinhTrang.SelectedIndex = -1;
            cbHienTrang.SelectedIndex = -1;
            HienThiPhong(this.list);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int start = 0, end = 0;
            if (cbGiaP.SelectedIndex == 0)
            {
                end = int.Parse(cbGiaP.SelectedItem.ToString().Split(' ')[1].Replace(",", ""));
            }
            else if (cbGiaP.SelectedIndex == 4)
            {
                start = int.Parse(cbGiaP.SelectedItem.ToString().Split(' ')[1].Replace(",", ""));
            }
            else if (cbGiaP.SelectedIndex == 1 || cbGiaP.SelectedIndex == 2 || cbGiaP.SelectedIndex == 3)
            {
                start = int.Parse(cbGiaP.SelectedItem.ToString().Split(' ')[1].Replace(",", ""));
                end = int.Parse(cbGiaP.SelectedItem.ToString().Split(' ')[4].Replace(",", ""));
            }
            var rooms = this.list.Where(room => txtMaP.Text.Trim().Length == 0 || room.MaP.ToUpper().Contains(txtMaP.Text.Trim().ToUpper()))
                                 .Where(room => txtTenP.Text.Trim().Length == 0 || room.TenP.ToUpper().Contains(txtTenP.Text.Trim().ToUpper()))
                                 .Where(room => cbLoaiP.SelectedIndex == -1 || room.LoaiP == cbLoaiP.SelectedIndex)
                                 .Where(room => cbCTLP.SelectedIndex == -1 || room.ChiTietLoaiP == cbCTLP.SelectedIndex)
                                 .Where(room => cbTinhTrang.SelectedIndex == -1 || room.TinhTrang == cbTinhTrang.SelectedIndex)
                                 .Where(room => cbHienTrang.SelectedIndex == -1 || room.HienTrang == cbHienTrang.SelectedIndex)
                                 .Where(room => cbGiaP.SelectedIndex == -1 || (cbGiaP.SelectedIndex == 4 && room.GiaP >= start)
                                 || (room.GiaP >= start && room.GiaP <= end));
            if (rooms.ToList().Count == 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Thông báo", "Không tìm thấy phòng phù hợp", MessageBoxDialog.INFO, MessageBoxDialog.YES, "Đóng", "", "");
                Reset_Phong();
            }
            else
                HienThiPhong(rooms.ToList());
        }

        private void tbPhong_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < tbPhong.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    tbPhong.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
                }
                else
                {
                    tbPhong.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void tbTienIch_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < tbTienIch.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    tbTienIch.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
                }
                else
                {
                    tbTienIch.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void cbGiaP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbGiaP.Text == String.Empty)
            {
                e.Handled = true;
                return;
            }

            bool isSelectMany = false;
            if (cbGiaP.SelectionLength > 0)
            {
                isSelectMany = true;
            }

            if (isSelectMany)
            {
                var selectedText = cbGiaP.SelectedText;
                var selectStart = cbGiaP.SelectionStart;
                var count = cbGiaP.SelectionLength;

                if (int.TryParse(selectedText, out var _))
                {
                    if (char.IsDigit(e.KeyChar))
                    {
                        e.Handled = false;
                        return;
                    }
                    else if (e.KeyChar == (char)Keys.Back)
                    {
                        if (selectStart == 0 || selectStart + count >= cbGiaP.Text.Length)
                        {
                            e.Handled = true;
                            return;
                        }
                        if (int.TryParse(cbGiaP.Text[selectStart - 1].ToString(), out var _) || int.TryParse(cbGiaP.Text[selectStart + count].ToString(), out var _))
                        {
                            e.Handled = false;
                            return;
                        }
                        else if (cbGiaP.Text[selectStart - 1] == ' ' && cbGiaP.Text[selectStart + count] == ' ')
                        {
                            e.Handled = true;
                            cbGiaP.Text = cbGiaP.Text.Remove(selectStart, count);
                            cbGiaP.Text = cbGiaP.Text.Insert(selectStart, "0");
                            cbGiaP.SelectionStart = selectStart;
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
                var cursorPos = cbGiaP.SelectionStart;
                if (char.IsDigit(e.KeyChar))
                {
                    if (cursorPos == 0)
                    {
                        e.Handled = true;
                        return;
                    }
                    if (int.TryParse(cbGiaP.Text[cursorPos - 1].ToString(), out var _) || int.TryParse(cbGiaP.Text[cursorPos].ToString(), out var _))
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
                    if (int.TryParse(cbGiaP.Text[cursorPos - 1].ToString(), out var _) && int.TryParse(cbGiaP.Text[cursorPos - 2].ToString(), out var _))
                    {
                        e.Handled = false;
                        return;
                    }
                    else if (int.TryParse(cbGiaP.Text[cursorPos - 1].ToString(), out var _) && int.TryParse(cbGiaP.Text[cursorPos].ToString(), out var _))
                    {
                        e.Handled = false;
                        return;
                    }
                    else if (int.TryParse(cbGiaP.Text[cursorPos - 1].ToString(), out var _) && !int.TryParse(cbGiaP.Text[cursorPos].ToString(), out var _))
                    {
                        e.Handled = true;
                        cbGiaP.Text = cbGiaP.Text.Remove(cursorPos - 1, 1);
                        cbGiaP.Text = cbGiaP.Text.Insert(cursorPos - 1, "0");
                        cbGiaP.SelectionStart = cursorPos;
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

        private void cbGiaP_MouseClick(object sender, MouseEventArgs e)
        {
            if (cbGiaP.SelectionLength == 0)
            {
                cbGiaP.Text = cbGiaP.Text.Replace(",", "");
            }
        }

        private void cbGiaP_Leave(object sender, EventArgs e)
        {
            var arr = cbGiaP.Text.Split(' ');
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
            cbGiaP.Text = String.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                cbGiaP.Text += arr[i] + " ";
            }
            cbGiaP.Text.Remove(cbGiaP.Text.Length - 1);
        }

        private void txtMaP_TextChanged(object sender, EventArgs e)
        {
            bool isMaPEmpty = string.IsNullOrWhiteSpace(txtMaP.Text);
            txtTenP.Enabled = isMaPEmpty;
            cbLoaiP.Enabled = isMaPEmpty;
            cbCTLP.Enabled = isMaPEmpty;
            cbGiaP.Enabled = isMaPEmpty;
            cbTinhTrang.Enabled = isMaPEmpty;
            cbHienTrang.Enabled = isMaPEmpty;

        }

        private void otherTextChanged(object sender, EventArgs e)
        {
            bool isTenPEmpty = string.IsNullOrEmpty(txtTenP.Text);
            if (isTenPEmpty == true &&
                cbCTLP.Text == String.Empty &&
                cbGiaP.Text == String.Empty &&
                cbLoaiP.Text == String.Empty &&
                cbHienTrang.Text == String.Empty &&
                cbTinhTrang.Text == String.Empty)
            {
                txtMaP.Enabled = true;
            }
            else
            {
                txtMaP.Enabled = false;
            }
        }
    }
}
