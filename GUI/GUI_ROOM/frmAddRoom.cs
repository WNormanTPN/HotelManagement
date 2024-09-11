using BUS;
using DTO;
using GUI.GUI_COMPONENT;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.GUI_ROOM
{
    public partial class frmAddRoom : Form
    {
        PhongBUS phong = new PhongBUS();
        TienIchBUS tienich = new TienIchBUS();
        DataTable dtTienIch = new DataTable();
        int action = 2;
        public frmAddRoom(int action, PhongDTO phong)
        {
            InitializeComponent();
            HienThiTienIch_ListTienIchHienCo("");
            this.DialogResult = DialogResult.Cancel;
            //tbTienIchHienCo.ColumnHeadersDefaultCellStyle.BackColor = Color.Azure;
            //tbTienIchHienCo.EnableHeadersVisualStyles = false;
            switch (action)
            {
                // case add
                case 0:
                    this.action = 0;
                    btnUpdateRoom.Visible = false;
                    btnDeleteRoom.Visible = false;
                    this.tableLayoutPanel4.Controls.Add(this.btnAddRoom, 2, 0);
                    cbHT.SelectedIndex = 0;
                    cbHT.Enabled = false;
                    break;
                // case update
                case 1:
                    Title.Text = "Thông tin phòng khách sạn";
                    label1.Text = "Thông tin chi tiết phòng";
                    this.action = 1;
                    txtMaP.Text = phong.MaP;
                    txtTenP.Text = phong.TenP;
                    txtGiaP.Text = phong.GiaP.ToString();
                    if (phong.LoaiP == 0)
                    {
                        rdVip.Checked = true;
                    }
                    else
                    {
                        rdThuong.Checked = true;
                    }
                    if (phong.TinhTrang == 0)
                    {
                        txtTT.Text = "Trống";
                    }
                    else if (phong.TinhTrang == 1)
                    {
                        txtTT.Text = "Đang được thuê";
                    }
                    else
                    {
                        txtTT.Text = "Chưa dọn phòng";
                    }
                    cbHT.SelectedIndex = phong.HienTrang;
                    if (phong.ChiTietLoaiP == 0)
                    {
                        rdDon.Checked = true;
                    }
                    else if (phong.ChiTietLoaiP == 1)
                    {
                        rdDoi.Checked = true;
                    }
                    else
                    {
                        rdGiaDinh.Checked = true;
                    }
                    HienThiTienIch_ListTienIchPhongView("");
                    btnAddRoom.Visible = false;
                    break;
                // case view
                default:
                    Title.Text = "Thông tin phòng khách sạn";
                    label1.Text = "Thông tin chi tiết phòng";
                    txtMaP.Text = phong.MaP;
                    txtTenP.Text = phong.TenP;
                    txtGiaP.Text = phong.GiaP.ToString("###,###0 VNĐ");
                    if (phong.LoaiP == 0)
                    {
                        rdVip.Checked = true;
                    }
                    else
                    {
                        rdThuong.Checked = true;
                    }
                    if (phong.TinhTrang == 0)
                    {
                        txtTT.Text = "Trống";
                    }
                    else if (phong.TinhTrang == 1)
                    {
                        txtTT.Text = "Đang được thuê";
                    }
                    else
                    {
                        txtTT.Text = "Chưa dọn phòng";
                    }
                    cbHT.SelectedIndex = phong.HienTrang;
                    if (phong.ChiTietLoaiP == 0)
                    {
                        rdDon.Checked = true;
                    }
                    else if (phong.ChiTietLoaiP == 1)
                    {
                        rdDoi.Checked = true;
                    }
                    else
                    {
                        rdGiaDinh.Checked = true;
                    }
                    txtGiaP.ReadOnly = true;
                    txtTenP.ReadOnly = true;
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    panel18.Visible = false;
                    btnAddRoom.Visible = false;
                    btnUpdateRoom.Visible = false;
                    btnDeleteRoom.Visible = false;
                    tableLayoutPanel5.Controls.Remove(panel15);
                    this.tableLayoutPanel5.Controls.Add(this.panel16, 0, 0);
                    tableLayoutPanel5.RowCount = 1;
                    btnReset.Visible = false;
                    cbHT.Enabled = false;
                    HienThiTienIch_ListTienIchPhongView("");
                    break;
            }
        }
        private const int CS_DropShadow = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DropShadow;
                return cp;
            }
        }
        private Point mouseOffset;
        private void pnTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                this.Location = mousePos;
            }
        }
        private void pnTop_MouseDown(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;
            mouseOffset = new Point(-mouseX, -mouseY);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }
        private void btnCloseRoom_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            bool check = false;
            if (txtGiaP.Text.Trim().Length == 0)
            {
                check = true;
                txtGiaP.Text = "";
                txtGiaP.Focus();
                lbErrorGiaP.Visible = true;
            }
            if (txtTenP.Text.Trim().Length == 0)
            {
                check = true;
                txtTenP.Text = "";
                txtTenP.Focus();
                lbErrorTenP.Visible = true;
            }
            if (!check)
            {
                if (dtTienIch.Rows.Count != 0)
                {
                    int count = phong.getCountPhong() + 1;
                    DateTime now = DateTime.Now;
                    string date = now.ToString("ddMMyy");
                    string str = count.ToString("D3");
                    txtMaP.Text = "P" + date + str;
                    string loaiP = string.Empty;
                    if (rdVip.Checked)
                    {
                        loaiP = 0 + "";
                    }
                    else
                    {
                        loaiP = 1 + "";
                    }
                    string chiTietLoaiP = string.Empty;
                    if (rdDon.Checked)
                    {
                        chiTietLoaiP = 0 + "";
                    }
                    else
                    {
                        if (rdDoi.Checked)
                        {
                            chiTietLoaiP = 1 + "";
                        }
                        else
                        {
                            chiTietLoaiP = 2 + "";
                        }
                    }
                    phong.ThemPhong(txtMaP.Text.Trim(), txtTenP.Text.Trim(), loaiP, txtGiaP.Text.Trim(), chiTietLoaiP, 0 + "", 0 + "");
                    for (int i = 0; i < dtTienIch.Rows.Count; i++)
                    {
                        string maTI = dtTienIch.Rows[i][0].ToString();
                        string SL = dtTienIch.Rows[i][2].ToString();
                        tienich.ThemTienIchPhong(txtMaP.Text.Trim(), maTI, SL);
                    }
                    this.DialogResult = DialogResult.OK;
                    MessageBoxDialog message = new MessageBoxDialog();
                    message.ShowDialog("Thông báo", "Thành công", "Thêm phòng mới thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                    this.Dispose();
                }
                else
                {
                    MessageBoxDialog message = new MessageBoxDialog();
                    message.ShowDialog("Thông báo", "Lỗi tiện ích trống", "Vui lòng thêm tiện ích cho phòng", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đồng ý", "", "");
                }
            }
            else
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Lỗi không nhập dữ liệu", "Vui lòng nhập thông tin phòng", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đồng ý", "", "");
            }
        }
        private void txtGiaP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtTenP_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTenP.Text.Trim().Length == 0)
            {
                lbErrorTenP.Visible = true;
            }
            else
            {
                lbErrorTenP.Visible = false;
            }
        }
        private void txtGiaP_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtGiaP.Text.Trim().Length == 0)
            {
                lbErrorGiaP.Visible = true;
            }
            else
            {
                lbErrorGiaP.Visible = false;
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            lbErrorGiaP.Visible = false;
            lbErrorTenP.Visible = false;
            txtGiaP.Text = "";
            txtTenP.Text = "";
        }
        private void HienThiTienIch_ListTienIchHienCo(string search)
        {
            tbTienIchHienCo.Rows.Clear();
            DataTable dt = tienich.getListTienIch();
            int k = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString().ToUpper().Contains(search.ToUpper()) ||
                    dt.Rows[i][1].ToString().ToUpper().Contains(search.ToUpper()))
                {
                    ++k;
                    tbTienIchHienCo.Rows.Add(k + "", dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
                }
            }
            tbTienIchHienCo.ClearSelection();
        }
        private void HienThiTienIch_ListTienIchPhongView(string search)
        {
            tbTienIchPhong.Rows.Clear();
            DataTable dt = tienich.getListTienIch_Phong(txtMaP.Text);
            int k = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString().ToUpper().Contains(search.ToUpper()) ||
                    dt.Rows[i][1].ToString().ToUpper().Contains(search.ToUpper()))
                {
                    tbTienIchPhong.Rows.Add(++k, dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString());
                }
            }
            tbTienIchPhong.ClearSelection();
        }
        private void HienThiTienIch_ListTienIchPhong(string search)
        {
            tbTienIchPhong.Rows.Clear();
            int k = 0;
            for (int i = 0; i < dtTienIch.Rows.Count; i++)
            {
                if (dtTienIch.Rows[i][0].ToString().ToUpper().Contains(search.ToUpper()) ||
                    dtTienIch.Rows[i][1].ToString().ToUpper().Contains(search.ToUpper()))
                {
                    ++k;
                    tbTienIchPhong.Rows.Add(k + "", dtTienIch.Rows[i][0].ToString(), dtTienIch.Rows[i][1].ToString(), dtTienIch.Rows[i][2].ToString());
                }
            }
            tbTienIchPhong.ClearSelection();
        }
        private void frmAddRoom_Load(object sender, EventArgs e)
        {
            tbTienIchHienCo.ClearSelection();
            tbTienIchPhong.ClearSelection();
            dtTienIch.Columns.Add("MaTI");
            dtTienIch.Columns.Add("TenTI");
            dtTienIch.Columns.Add("SoLuong");
        }
        private void txtSearchTI_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtSearchTI.Text.Trim().Equals("Nhập mã/tên tiện ích cần tìm..."))
            {
                txtSearchTI.Text = "";
            }
        }
        private void txtSearchTI_MouseLeave(object sender, EventArgs e)
        {
            if (txtSearchTI.Text.Trim().Length == 0)
            {
                txtSearchTI.Text = "Nhập mã/tên tiện ích cần tìm...";
            }
            ActiveControl = null;
        }
        private void txtSearchTI_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchTI.Text.Trim().Equals("Nhập mã/tên tiện ích cần tìm...")) HienThiTienIch_ListTienIchHienCo("");
            else HienThiTienIch_ListTienIchHienCo(txtSearchTI.Text.Trim());
        }
        private void buttonRounded1_Click(object sender, EventArgs e)
        {
            if (tbTienIchHienCo.SelectedRows.Count > 0)
            {
                if ((int)spinerSL.Value == 0)
                {
                    MessageBoxDialog message = new MessageBoxDialog();
                    message.ShowDialog("Thông báo", "Lỗi dữ liệu số lượng", "Số lượng tiện ích phải là số lớn hơn 0", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                    lbErrorSoLuong.Visible = true;
                }
                else
                {
                    if (action == 0)
                    {
                        for (int i = 0; i < dtTienIch.Rows.Count; i++)
                        {
                            DataGridViewRow row_Seleted = tbTienIchHienCo.SelectedRows[0];
                            if (row_Seleted.Cells[1].Value.ToString().Equals(dtTienIch.Rows[i][0].ToString()))
                            {
                                dtTienIch.Rows[i][2] = (int.Parse(dtTienIch.Rows[i][2].ToString()) + (int)spinerSL.Value) + "";
                                spinerSL.Value = 0;
                                HienThiTienIch_ListTienIchPhong("");
                                HienThiTienIch_ListTienIchHienCo("");
                                lbErrorSoLuong.Visible = false;
                                txtSearchTI.Text = "Nhập mã/tên tiện ích cần tìm...";
                                txtSearchTI_P.Text = "Nhập mã/tên tiện ích cần tìm...";
                                return;
                            }
                        }
                        DataGridViewRow row = tbTienIchHienCo.SelectedRows[0];
                        DataRow rowTI = dtTienIch.NewRow();
                        rowTI["MaTI"] = row.Cells[1].Value.ToString();
                        rowTI["TenTI"] = row.Cells[2].Value.ToString();
                        rowTI["SoLuong"] = spinerSL.Value;
                        dtTienIch.Rows.Add(rowTI);
                        spinerSL.Value = 0;
                        ResetTI();
                    }
                    else if (action == 1)
                    {
                        DataTable dtTienIchPhong = tienich.getListTienIch_Phong(txtMaP.Text.Trim());
                        bool check = false;
                        for (int i = 0; i < dtTienIchPhong.Rows.Count; i++)
                        {
                            if (dtTienIchPhong.Rows[i][0].ToString().Equals(tbTienIchHienCo.SelectedRows[0].Cells[1].Value.ToString()))
                            {
                                check = true;
                                break;
                            }
                        }
                        if (check)
                        {
                            tienich.SuaTienIch_Phong_CoTienIch(txtMaP.Text.Trim(), tbTienIchHienCo.SelectedRows[0].Cells[1].Value.ToString(), spinerSL.Value.ToString());
                            spinerSL.Value = 0;
                            ResetTI();
                        }
                        else
                        {
                            tienich.ThemTienIchPhong(txtMaP.Text.Trim(), tbTienIchHienCo.SelectedRows[0].Cells[1].Value.ToString(), spinerSL.Value.ToString());
                            spinerSL.Value = 0;
                            ResetTI();
                        }
                    }
                }
            }
            else
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Lỗi chưa chọn tiện ích muốn thêm", "Vui lòng chọn tiện ích muốn thêm và nhập số lượng", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
            }
        }
        private void spinerSL_ValueChanged(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (spinerSL.Value == 0)
            {
                lbErrorSoLuong.Visible = true;
            }
            else
            {
                lbErrorSoLuong.Visible = false;
            }
        }
        private void buttonRounded3_Click(object sender, EventArgs e)
        {
            if (action == 0)
            {
                if (dtTienIch.Rows.Count == 0)
                {
                    MessageBoxDialog message = new MessageBoxDialog();
                    message.ShowDialog("Thông báo", "Thông báo", "Danh sách tiện ích của phòng đang trống", MessageBoxDialog.WARNING, MessageBoxDialog.YES, "Đóng", "", "");
                    return;
                }
            }
            else
            {
                if (tienich.getListTienIch_Phong(txtMaP.Text).Rows.Count == 0)
                {
                    MessageBoxDialog message = new MessageBoxDialog();
                    message.ShowDialog("Thông báo", "Thông báo", "Danh sách tiện ích của phòng đang trống", MessageBoxDialog.WARNING, MessageBoxDialog.YES, "Đóng", "", "");
                    return;
                }
            }
            if (tbTienIchPhong.SelectedRows.Count == 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Lỗi chưa chọn dữ liệu", "Vui lòng chọn dữ liệu muốn xóa trong bản danh sách tiện ích phòng", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
            }
            else
            {
                if (action == 0)
                {
                    for (int i = 0; i < dtTienIch.Rows.Count; i++)
                    {
                        if (tbTienIchPhong.SelectedRows[0].Cells[1].Value.ToString().Equals(dtTienIch.Rows[i][0].ToString()))
                        {
                            dtTienIch.Rows.Remove(dtTienIch.Rows[i]);
                            ResetTI();
                        }
                    }
                }
                else if (action == 1)
                {
                    tienich.XoaTienIch_Phong(tbTienIchPhong.SelectedRows[0].Cells[1].Value.ToString(), txtMaP.Text.Trim());
                    ResetTI();
                }
            }
        }
        private void buttonRounded2_Click(object sender, EventArgs e)
        {
            if (action == 0)
            {
                if (dtTienIch.Rows.Count == 0)
                {
                    MessageBoxDialog message = new MessageBoxDialog();
                    message.ShowDialog("Thông báo", "Thông báo", "Danh sách tiện ích của phòng đang trống", MessageBoxDialog.WARNING, MessageBoxDialog.YES, "Đóng", "", "");
                    return;
                }
            }
            else
            {
                if (tienich.getListTienIch_Phong(txtMaP.Text).Rows.Count == 0)
                {
                    MessageBoxDialog message = new MessageBoxDialog();
                    message.ShowDialog("Thông báo", "Thông báo", "Danh sách tiện ích của phòng đang trống", MessageBoxDialog.WARNING, MessageBoxDialog.YES, "Đóng", "", "");
                    return;
                }
            }
            if (tbTienIchPhong.SelectedRows.Count == 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Lỗi chưa chọn dữ liệu", "Vui lòng chọn dữ liệu muốn sửa trong bản danh sách tiện ích phòng", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
            }
            else
            {
                if (spinerSLPhong.Value == 0)
                {
                    lbErrorTienIchPhong.Visible = true;
                    MessageBoxDialog message = new MessageBoxDialog();
                    message.ShowDialog("Thông báo", "Lỗi dữ liệu số lượng", "Số lượng tiện ích phải là số lớn hơn 0", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                }
                else
                {
                    if (action == 0)
                    {
                        for (int i = 0; i < dtTienIch.Rows.Count; i++)
                        {
                            if (tbTienIchPhong.SelectedRows[0].Cells[1].Value.ToString().Equals(dtTienIch.Rows[i][0].ToString()))
                            {
                                dtTienIch.Rows[i][2] = spinerSLPhong.Value;
                                spinerSLPhong.Value = 0;
                                ResetTI();
                            }
                        }
                    }
                    else if (action == 1)
                    {
                        tienich.SuaTienIch_Phong(txtMaP.Text.Trim(), tbTienIchPhong.SelectedRows[0].Cells[1].Value.ToString(), spinerSLPhong.Value.ToString());
                        spinerSLPhong.Value = 0;
                        ResetTI();
                    }
                }
            }
        }
        private void ResetTI()
        {
            if (action == 0)
            {
                HienThiTienIch_ListTienIchPhong("");
                HienThiTienIch_ListTienIchHienCo("");
            }
            else if (action == 1)
            {
                HienThiTienIch_ListTienIchPhongView("");
                HienThiTienIch_ListTienIchHienCo("");
            }
            lbErrorSoLuong.Visible = false;
            lbErrorTienIchPhong.Visible = false;
            txtSearchTI.Text = "Nhập mã/tên tiện ích cần tìm...";
            txtSearchTI_P.Text = "Nhập mã/tên tiện ích cần tìm...";
        }
        private void spinerSLPhong_ValueChanged(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (spinerSLPhong.Value == 0)
            {
                lbErrorTienIchPhong.Visible = true;
            }
            else
            {
                lbErrorTienIchPhong.Visible = false;
            }
        }

        private void txtSearchTI_P_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtSearchTI_P.Text.Trim().Equals("Nhập mã/tên tiện ích cần tìm..."))
            {
                txtSearchTI_P.Text = "";
            }
        }

        private void txtSearchTI_P_MouseLeave(object sender, EventArgs e)
        {
            if (txtSearchTI_P.Text.Trim().Length == 0)
            {
                txtSearchTI_P.Text = "Nhập mã/tên tiện ích cần tìm...";
            }
            ActiveControl = null;
        }

        private void txtSearchTI_P_TextChanged(object sender, EventArgs e)
        {
            if (action == 0)
            {
                if (txtSearchTI_P.Text.Trim().Equals("Nhập mã/tên tiện ích cần tìm...")) HienThiTienIch_ListTienIchPhong("");
                else HienThiTienIch_ListTienIchPhong(txtSearchTI_P.Text.Trim());
            }
            else if (action == 2)
            {
                if (txtSearchTI_P.Text.Trim().Equals("Nhập mã/tên tiện ích cần tìm...")) HienThiTienIch_ListTienIchPhongView("");
                else HienThiTienIch_ListTienIchPhongView(txtSearchTI_P.Text.Trim());
            }
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (txtTT.Text.Contains("Đang được thuê"))
            {
                MessageBoxDialog message_Error = new MessageBoxDialog();
                message_Error.ShowDialog("Thông báo", "Báo lỗi", "Phòng đang được thuê không thể xóa", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                return;
            }
            MessageBoxDialog message = new MessageBoxDialog();
            int ans = message.ShowDialog("Thông báo", "Thông báo", "Bạn có chắc muốn xóa phòng này", MessageBoxDialog.WARNING, MessageBoxDialog.YES_NO_CANCEL, "Chắc chắn", "Không", "Đóng");
            if (ans == MessageBoxDialog.YES_OPTION)
            {
                phong.XoaPhong(txtMaP.Text.Trim());
                MessageBoxDialog message_success = new MessageBoxDialog();
                message_success.ShowDialog("Thông báo", "Thành công", "Xóa phòng thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }

        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            bool check = false;
            if (txtGiaP.Text.Trim().Length == 0)
            {
                check = true;
                txtGiaP.Text = "";
                txtGiaP.Focus();
                lbErrorGiaP.Visible = true;
            }
            if (txtTenP.Text.Trim().Length == 0)
            {
                check = true;
                txtTenP.Text = "";
                txtTenP.Focus();
                lbErrorTenP.Visible = true;
            }
            if (!check)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                int ans = message.ShowDialog("Thông báo", "Thông báo", "Bạn có muốn sửa thông tin phòng này không?", MessageBoxDialog.INFO, MessageBoxDialog.YES_NO, "Đồng ý", "Không đồng ý", "");
                if (ans == MessageBoxDialog.YES_OPTION)
                {
                    string loaiP = string.Empty;
                    if (rdVip.Checked)
                    {
                        loaiP = 0 + "";
                    }
                    else
                    {
                        loaiP = 1 + "";
                    }
                    string chiTietLoaiP = string.Empty;
                    if (rdDon.Checked)
                    {
                        chiTietLoaiP = 0 + "";
                    }
                    else
                    {
                        if (rdDoi.Checked)
                        {
                            chiTietLoaiP = 1 + "";
                        }
                        else
                        {
                            chiTietLoaiP = 2 + "";
                        }
                    }
                    phong.SuaPhong(txtMaP.Text.Trim(), txtTenP.Text.Trim(), loaiP, txtGiaP.Text.Trim(), chiTietLoaiP, cbHT.SelectedIndex.ToString());
                    this.DialogResult = DialogResult.OK;
                    MessageBoxDialog message_info = new MessageBoxDialog();
                    message_info.ShowDialog("Thông báo", "Thành công", "Sửa thông tin phòng thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                    this.Dispose();
                }
            }
            else
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Lỗi không nhập dữ liệu", "Vui lòng nhập thông tin phòng", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đồng ý", "", "");
            }
        }

        private void tbTienIchHienCo_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < tbTienIchHienCo.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    tbTienIchHienCo.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
                }
                else
                {
                    tbTienIchHienCo.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void tbTienIchPhong_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < tbTienIchPhong.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    tbTienIchPhong.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
                }
                else
                {
                    tbTienIchPhong.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
    }
}
