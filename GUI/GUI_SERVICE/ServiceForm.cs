using BUS;
using GUI.GUI_COMPONENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI.GUI_SERVICE
{
    public partial class ServiceForm : Form
    {
        #region Variable BUS
        DichVuBUS dichvu = new DichVuBUS();
        #endregion
        private bool luu;
        private MessageBoxDialog message;

        public ServiceForm()
        {
            InitializeComponent();
            LoadLoaiDV();
            ListDichVu();
            boolcontrols(true);
            setButton(true);
            this.ActiveControl = null;
        }

        private void LoadLoaiDV()
        {
            DataTable dataTable = new DataTable();
            cboLoaiDV.Items.Clear();
            dataTable.Columns.Add("loaiDV", typeof(string));
            dataTable.Columns.Add("tenloaiDV", typeof(string));
            dataTable.Rows.Add("Ăn uống", "Ăn uống");
            dataTable.Rows.Add("Chăm sóc sắc đẹp", "Chăm sóc sắc đẹp");
            dataTable.Rows.Add("Tổ chức tiệc", "Tổ chức tiệc");
            dataTable.Rows.Add("Giải trí", "Giải trí");
            cboLoaiDV.DataSource = dataTable;
            cboLoaiDV.DisplayMember = "tenloaiDV";
            cboLoaiDV.ValueMember = "loaiDV";
            dtgvData.ClearSelection();
            this.ActiveControl = null;
            HideAllSearchFields();
        }
        private void boolcontrols(bool iss)
        {
            btnThem.Enabled = iss;
            btnSua.Enabled = iss;
            btnXoa.Enabled = iss;
            btnLuu.Enabled = !iss;
            btnHuy.Enabled = !iss;

            txttenDV.ReadOnly = iss;
            cboLoaiDV.Enabled = !iss;
            txtgiaDV.Enabled = !iss;
        }
        private void ServiceForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            dtgvData.ClearSelection();
            this.ActiveControl = null;
        }
        private void ListDichVu()
        {
            DataTable dt = new DataTable();
            dt = dichvu.getListDichVu(txtmadv_search.Text.Trim(), txttendv_search.Text.Trim(), cboloaidv_search.Text.Trim(), cbogiadv_search.Text.Trim());
            dtgvData.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string maDV = dt.Rows[i]["maDV"].ToString();
                string tenDV = dt.Rows[i]["tenDV"].ToString();
                string loaiDV = dt.Rows[i]["loaiDV"].ToString();
                string giaDV = dt.Rows[i]["giaDV"].ToString();
                string v = dt.Rows[i]["hinhAnh"].ToString();
                if (v != "")
                {
                    System.Drawing.Image img = ConvertStringtoImage(dt.Rows[i]["hinhAnh"].ToString());
                    dtgvData.Rows.Add(new object[] { maDV, tenDV, loaiDV, giaDV, img });
                }
                else
                {
                    dtgvData.Rows.Add(new object[] { maDV, tenDV, loaiDV, giaDV, null });
                    foreach (var column in dtgvData.Columns)
                    {
                        if (column is DataGridViewImageColumn)
                            (column as DataGridViewImageColumn).DefaultCellStyle.NullValue = null;
                    }
                }
            }
            foreach (DataGridViewRow r in dtgvData.Rows)
                r.Height = 60;
            if (dtgvData.Rows.Count == 0)
            {
                txtmadv.Text = "";
                txttenDV.Text = "";
                txtgiaDV.Text = "";
                pchinhAnh.Image = null;
            }
            else
            {
                var row = this.dtgvData.Rows[0];
                txtmadv.Text = row.Cells[0].Value.ToString().Trim();
                txttenDV.Text = row.Cells[1].Value.ToString().Trim();
                cboLoaiDV.Text = row.Cells[2].Value.ToString().Trim();
                txtgiaDV.Text = row.Cells[3].Value.ToString().Trim();

                DataTable dtimg = new DataTable();
                dtimg = dichvu.getImageDichVubyMaDV(txtmadv.Text.Trim());
                if (dtimg.Rows.Count > 0)
                {
                    if (dtimg.Rows[0]["HinhAnh"].ToString() != "")
                    {
                        pchinhAnh.Image = ConvertStringtoImage(dtimg.Rows[0]["HinhAnh"].ToString());
                    }

                }
            }
            dtgvData.ClearSelection();
        }
        public System.Drawing.Image ConvertStringtoImage(string commands)
        {
            byte[] photoarray = Convert.FromBase64String(commands);
            MemoryStream ms = new MemoryStream(photoarray, 0, photoarray.Length);
            ms.Write(photoarray, 0, photoarray.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }
        private void dtgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvData.Rows[e.RowIndex];
                txtmadv.Text = row.Cells[0].Value.ToString().Trim();
                txttenDV.Text = row.Cells[1].Value.ToString().Trim();
                cboLoaiDV.Text = row.Cells[2].Value.ToString().Trim();
                txtgiaDV.Text = row.Cells[3].Value.ToString().Trim();

                DataTable dtimg = new DataTable();
                dtimg = dichvu.getImageDichVubyMaDV(txtmadv.Text.Trim());
                if (dtimg.Rows[0]["HinhAnh"].ToString() != "")
                {
                    pchinhAnh.Image = ConvertStringtoImage(dtimg.Rows[0]["HinhAnh"].ToString());
                    dtHinhAnh = dtimg.Rows[0]["HinhAnh"].ToString();
                }
            }
        }


        private Boolean choseImage = false;
        public static System.Drawing.Image img2;
        private string dtHinhAnh;

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtmadv_search.Text = "";
            txttendv_search.Text = "";
            cbogiadv_search.Text = "";
            cboloaidv_search.Text = "";
            comboBox1.SelectedIndex = 0;
            ListDichVu();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ListDichVu();
        }
        private void setButton(bool check)
        {
            if (check)
            {
                btnThem.BackColor = Color.Green;
                btnSua.BackColor = Color.DarkOrange;
                btnXoa.BackColor = Color.Red;
                btnHuy.BackColor = SystemColors.Control;
                btnLuu.BackColor = SystemColors.Control;
            }
            else
            {
                btnThem.BackColor = SystemColors.Control;
                btnSua.BackColor = SystemColors.Control;
                btnXoa.BackColor = SystemColors.Control;
                btnHuy.BackColor = Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
                btnLuu.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            }
            btnThem.Enabled = check;
            btnSua.Enabled = check;
            btnXoa.Enabled = check;
            btnLuu.Enabled = !check;
            btnHuy.Enabled = !check;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            setButton(false);
            for (int i = 1; i <= 1000; i++)
            {
                string maDV = "DV" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString().Substring(2) + i.ToString("D4");
                DataTable dt = new DataTable();
                dt = dichvu.IsMaDVExists(maDV);
                if (dt.Rows.Count == 0)
                {
                    txtmadv.Text = maDV;
                    break;
                }
            }

            choseImage = true;
            pchinhAnh.Image = null;
            img2 = null;
            dtHinhAnh = "";

            txttenDV.Text = "";
            txtgiaDV.Text = "";
            boolcontrols(false);
            setButton(false);
            luu = true;
            txttenDV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            setButton(false);
            if (dtgvData.Rows.Count == 0)
            {
                message = new MessageBoxDialog();
                int ans = message.ShowDialog("Thông báo", "Thông báo", "Không có dịch vụ để sửa", MessageBoxDialog.INFO, MessageBoxDialog.YES, "Đóng", "", "");
                return;
            }
            luu = false;
            boolcontrols(false);
            setButton(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgvData.Rows.Count == 0)
            {
                return;
            }
            message = new MessageBoxDialog();
            int ans = message.ShowDialog("Thông báo", "Thông báo", "Bạn có muốn xóa dịch vụ này", MessageBoxDialog.INFO, MessageBoxDialog.YES_NO, "Đồng ý", "Không đồng ý", "");
            if (ans == MessageBoxDialog.YES_OPTION)
            {
                dichvu.Xoa(dtgvData.Rows[dtgvData.CurrentCell.RowIndex].Cells[0].Value.ToString());
                message = new MessageBoxDialog();
                int ans1 = message.ShowDialog("Thông báo", "Thông báo", "Xóa thành công", MessageBoxDialog.INFO, MessageBoxDialog.YES, "Đóng", "", "");
                ListDichVu();
                setButton(true);
            }
            else
            {
                return;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txttenDV.Text == "")
            {
                message = new MessageBoxDialog();
                int ans = message.ShowDialog("Thông báo", "Thông báo", "Tên dịch vụ không được trống", MessageBoxDialog.INFO, MessageBoxDialog.YES, "Đóng", "", "");
                txttenDV.Focus();
                return;
            }
            if (txtgiaDV.Text == "")
            {
                message = new MessageBoxDialog();
                int ans = message.ShowDialog("Thông báo", "Thông báo", "Giá dịch vụ không được trống", MessageBoxDialog.INFO, MessageBoxDialog.YES, "Đóng", "", "");
                txtgiaDV.Focus();
                return;
            }
            if (luu == true)
            {
                //try
                //{
                    dichvu.Them(txtmadv.Text, txttenDV.Text, cboLoaiDV.SelectedValue.ToString(), int.Parse(txtgiaDV.Text), dtHinhAnh);
                    boolcontrols(true);
                    ListDichVu();
                    setButton(true);
                //}
                //catch (Exception)
                //{
                //    message = new MessageBoxDialog();
                //    int ans = message.ShowDialog("Thông báo", "Thông báo", "Mã dịch vụ đã tồn tại, vui lòng tạo mã khác", MessageBoxDialog.INFO, MessageBoxDialog.YES, "Đóng", "", "");
                //    txtmadv.Focus();
                //    return;
                //}
            }
            else
            {
                DataGridViewRow row = this.dtgvData.Rows[dtgvData.CurrentCell.RowIndex];
                try
                {
                    dichvu.Sua(txtmadv.Text, row.Cells[0].Value.ToString(), txttenDV.Text, cboLoaiDV.SelectedValue.ToString(), int.Parse(txtgiaDV.Text), dtHinhAnh);
                    message = new MessageBoxDialog();
                    int ans = message.ShowDialog("Thông báo", "Thông báo", "Sửa thành công", MessageBoxDialog.INFO, MessageBoxDialog.YES, "Đóng", "", "");
                    ListDichVu();
                    boolcontrols(true);
                    setButton(true);
                }
                catch (Exception)
                {
                    message = new MessageBoxDialog();
                    int ans = message.ShowDialog("Thông báo", "Thông báo", "Mã dịch vụ đã tồn tại, vui lòng tạo mã khác", MessageBoxDialog.INFO, MessageBoxDialog.YES, "Đóng", "", "");
                    txtmadv.Focus();
                    return;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ListDichVu();
            boolcontrols(true);
            setButton(true);
        }


        private void txttenDV_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttenDV.Text))
            {
                label14.Text = "Vui lòng nhập tên Dịch Vụ";
            }
            else
            {

                label14.Text = ""; // Xóa thông báo lỗi nếu có thông tin
            }
        }

        private void txtgiaDV_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtgiaDV.Text))
            {
                label13.Text = "Vui lòng nhập giá Dịch Vụ";
            }
            else
            {
                label13.Text = ""; // Xóa thông báo lỗi nếu có thông tin
            }
        }

        private void txtgiaDV_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void txtgiaDV_Keypress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dtgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            string filename;
            OpenFile.Multiselect = false;
            OpenFile.Filter = "Images (*.png, *.gif, *.tif, *.tiff, *.bmp, *.jpg, *.jpeg, *.jpe, *.jfif)|*.png;*.gif;*.tif;*.tiff;*.bmp;*.jpg;*.jpeg;*.jpe;*.jfif";
            if (OpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = OpenFile.FileName;
                OpenFile.Dispose();
                if (filename != "")
                {
                    choseImage = true;
                    System.Drawing.Image img;
                    try
                    {
                        img = System.Drawing.Image.FromFile(filename);
                        if (img != null)
                        {
                            pchinhAnh.Image = img;
                            img2 = img;
                            ImageConverter converter = new ImageConverter();
                            var bytes = (byte[])converter.ConvertTo((Bitmap)pchinhAnh.Image, typeof(byte[]));
                            dtHinhAnh = Convert.ToBase64String(bytes);
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        private void btnXoaHinh_Click(object sender, EventArgs e)
        {
            choseImage = true;
            pchinhAnh.Image = null;
            img2 = null;
            dtHinhAnh = "";
        }

        private void txtgiaDV_KeyPress_2(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void dtgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dtgvData.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dtgvData.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
                }
                else
                {
                    dtgvData.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSearchType = comboBox1.SelectedItem.ToString();

            if (selectedSearchType == "Tìm kiếm theo mã")
            {
                ShowSearchByIdField();
            }
            else if (selectedSearchType == "Tìm kiếm khác")
            {
                ShowOtherSearchFields();
            }

            // Dọn sạch các trường thông tin và hiển thị danh sách dịch vụ
            Emptytextfiled();
            ListDichVu();
        }
        private void ShowSearchByIdField()
        {
            txtmadv_search.Enabled = true;  // Mã khách hàng
            txttendv_search.Enabled = false;
            cboloaidv_search.Enabled = false;
            cbogiadv_search.Enabled = false;
        }

        // Hiển thị các trường tìm kiếm khác, ẩn trường mã khách hàng
        private void ShowOtherSearchFields()
        {
            txtmadv_search.Enabled = false;  // Mã khách hàng
            txttendv_search.Enabled = true;
            cboloaidv_search.Enabled = true;
            cbogiadv_search.Enabled = true;
        }
        private void HideAllSearchFields()
        {
            txtmadv_search.Enabled = false;
            txttendv_search.Enabled = false;
            cboloaidv_search.Enabled = false;
            cbogiadv_search.Enabled = false;
        }

        private void Emptytextfiled()
        {
            txtmadv_search.Text = String.Empty;
            txttendv_search.Text = String.Empty;
            cboloaidv_search.SelectedIndex = -1;
            cbogiadv_search.SelectedIndex = -1;
        }

        private void cbogiadv_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbogiadv_search.Text == String.Empty)
            {
                e.Handled = true;
                return;
            }

            bool isSelectMany = false;
            if (cbogiadv_search.SelectionLength > 0)
            {
                isSelectMany = true;
            }

            if (isSelectMany)
            {
                var selectedText = cbogiadv_search.SelectedText;
                var selectStart = cbogiadv_search.SelectionStart;
                var count = cbogiadv_search.SelectionLength;

                if (int.TryParse(selectedText, out var _))
                {
                    if (char.IsDigit(e.KeyChar))
                    {
                        e.Handled = false;
                        return;
                    }
                    else if (e.KeyChar == (char)Keys.Back)
                    {
                        if (selectStart == 0 || selectStart + count >= cbogiadv_search.Text.Length)
                        {
                            e.Handled = true;
                            return;
                        }
                        if (int.TryParse(cbogiadv_search.Text[selectStart - 1].ToString(), out var _) || int.TryParse(cbogiadv_search.Text[selectStart + count].ToString(), out var _))
                        {
                            e.Handled = false;
                            return;
                        }
                        else if (cbogiadv_search.Text[selectStart - 1] == ' ' && cbogiadv_search.Text[selectStart + count] == ' ')
                        {
                            e.Handled = true;
                            cbogiadv_search.Text = cbogiadv_search.Text.Remove(selectStart, count);
                            cbogiadv_search.Text = cbogiadv_search.Text.Insert(selectStart, "0");
                            cbogiadv_search.SelectionStart = selectStart;
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
                var cursorPos = cbogiadv_search.SelectionStart;
                if (char.IsDigit(e.KeyChar))
                {
                    if (cursorPos == 0)
                    {
                        e.Handled = true;
                        return;
                    }
                    if (int.TryParse(cbogiadv_search.Text[cursorPos - 1].ToString(), out var _) || int.TryParse(cbogiadv_search.Text[cursorPos].ToString(), out var _))
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
                    if (int.TryParse(cbogiadv_search.Text[cursorPos - 1].ToString(), out var _) && int.TryParse(cbogiadv_search.Text[cursorPos - 2].ToString(), out var _))
                    {
                        e.Handled = false;
                        return;
                    }
                    else if (int.TryParse(cbogiadv_search.Text[cursorPos - 1].ToString(), out var _) && int.TryParse(cbogiadv_search.Text[cursorPos].ToString(), out var _))
                    {
                        e.Handled = false;
                        return;
                    }
                    else if (int.TryParse(cbogiadv_search.Text[cursorPos - 1].ToString(), out var _) && !int.TryParse(cbogiadv_search.Text[cursorPos].ToString(), out var _))
                    {
                        e.Handled = true;
                        cbogiadv_search.Text = cbogiadv_search.Text.Remove(cursorPos - 1, 1);
                        cbogiadv_search.Text = cbogiadv_search.Text.Insert(cursorPos - 1, "0");
                        cbogiadv_search.SelectionStart = cursorPos;
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

        private void cbogiadv_search_MouseClick(object sender, MouseEventArgs e)
        {
            if (cbogiadv_search.SelectionLength == 0)
            {
                cbogiadv_search.Text = cbogiadv_search.Text.Replace(",", "");
            }
        }

        private void cbogiadv_search_Leave(object sender, EventArgs e)
        {
            var arr = cbogiadv_search.Text.Split(' ');
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
            cbogiadv_search.Text = String.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                cbogiadv_search.Text += arr[i] + " ";
            }
            cbogiadv_search.Text.Remove(cbogiadv_search.Text.Length - 1);
        }
    }
}
