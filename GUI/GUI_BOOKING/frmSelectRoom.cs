using BUS;
using DTO;
using GUI.GUI_COMPONENT;
using GUI.GUI_ROOM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Drawing;

namespace GUI.GUI_BOOKING
{
    public partial class frmSelectRoom : Form
    {
        PhongBUS phong = new PhongBUS();
        ChiTietThuePhongBUS cttPhong = new ChiTietThuePhongBUS();
        ChiTietThueBUS ctt = new ChiTietThueBUS();
        List<PhongDTO> listPhong = new List<PhongDTO>();
        public object[] arr;
        DataTable dt;
        public frmSelectRoom(DataTable dt)
        {
            this.dt = new DataTable();
            this.dt = dt;
            InitializeComponent();
            arr = new object[5];
            DialogResult = DialogResult.Cancel;
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
            dateTimeThue.Value = date;
            dateTimeTra.Value = date;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;
            mouseOffset = new Point(-mouseX, -mouseY);
        }
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                this.Location = mousePos;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            this.listPhong.Clear();
            cbCTLP.SelectedIndex = -1;
            cbLoaiP.SelectedIndex = -1;
            cbHT.SelectedIndex = -1;
            cbGiaP.SelectedIndex = -1;
            SetEnable(false);
            rdNgay.Checked = false;
            rdGio.Checked = false;
            rdKhac.Checked = false;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            dateTimeTra.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dateTimeTra.Enabled = true;
            pnSoDoPhong.Controls.Clear();
        }

        private void rdNgay_CheckedChanged(object sender, EventArgs e)
        {
            dateTimeTra.CustomFormat = "dd/MM/yyyy";
            dateTimeTra.Enabled = true;
        }

        private void rdGio_CheckedChanged(object sender, EventArgs e)
        {
            dateTimeTra.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dateTimeTra.Enabled = true;
        }

        private void rdKhac_CheckedChanged(object sender, EventArgs e)
        {
            dateTimeTra.Enabled = false;
        }
        private void RenderRoom(List<PhongDTO> rooms)
        {
            pnSoDoPhong.Controls.Clear();
            foreach (PhongDTO room in rooms)
            {
                bool check = false;
                int index = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString().Equals(room.MaP))
                    {
                        check = true;
                        index = i;
                        break;
                    }
                }
                if (!check)
                {
                    ItemSelectRoom itemRoom = new ItemSelectRoom(room);
                    itemRoom.TopLevel = false;
                    this.pnSoDoPhong.Controls.Add(itemRoom);
                    itemRoom.Show();
                }
                else
                {
                    if (dt.Rows[index][3].ToString().ToUpper().Equals("THEO NGÀY") ||
                        dt.Rows[index][3].ToString().ToUpper().Equals("THEO GIỜ"))
                    {
                        if (rdNgay.Checked)
                        {
                            DateTime dateTra = new DateTime(dateTimeTra.Value.Year, dateTimeTra.Value.Month, dateTimeTra.Value.Day, dateTimeThue.Value.Hour, dateTimeThue.Value.Minute, dateTimeThue.Value.Second);
                            if (dateTimeThue.Value >= DateTime.Parse(dt.Rows[index][5].ToString()) ||
                                dateTra <= DateTime.Parse(dt.Rows[index][4].ToString()))
                            {
                                ItemSelectRoom itemRoom = new ItemSelectRoom(room);
                                itemRoom.TopLevel = false;
                                this.pnSoDoPhong.Controls.Add(itemRoom);
                                itemRoom.Show();
                            }
                        }
                        else if (rdGio.Checked)
                        {
                            DateTime dateTra = new DateTime(dateTimeTra.Value.Year, dateTimeTra.Value.Month, dateTimeTra.Value.Day, dateTimeTra.Value.Hour, dateTimeTra.Value.Minute, dateTimeTra.Value.Second);
                            if (dateTimeThue.Value >= DateTime.Parse(dt.Rows[index][5].ToString()) ||
                                dateTra <= DateTime.Parse(dt.Rows[index][4].ToString()))
                            {
                                ItemSelectRoom itemRoom = new ItemSelectRoom(room);
                                itemRoom.TopLevel = false;
                                this.pnSoDoPhong.Controls.Add(itemRoom);
                                itemRoom.Show();
                            }
                        }
                        else
                        {
                            if (dateTimeThue.Value >= DateTime.Parse(dt.Rows[index][5].ToString()))
                            {
                                ItemSelectRoom itemRoom = new ItemSelectRoom(room);
                                itemRoom.TopLevel = false;
                                this.pnSoDoPhong.Controls.Add(itemRoom);
                                itemRoom.Show();
                            }
                        }
                    }
                    else
                    {
                        if (rdNgay.Checked || rdGio.Checked)
                        {
                            DateTime dateTra = new DateTime(dateTimeTra.Value.Year, dateTimeTra.Value.Month, dateTimeTra.Value.Day, dateTimeThue.Value.Hour, dateTimeThue.Value.Minute, dateTimeThue.Value.Second);
                            if (dateTra <= DateTime.Parse(dt.Rows[index][4].ToString()))
                            {
                                ItemSelectRoom itemRoom = new ItemSelectRoom(room);
                                itemRoom.TopLevel = false;
                                this.pnSoDoPhong.Controls.Add(itemRoom);
                                itemRoom.Show();
                            }
                        }
                    }
                }
            }
        }
        private void SetEnable(bool check)
        {
            cbCTLP.Enabled = check;
            cbLoaiP.Enabled = check;
            cbHT.Enabled = check;
            cbGiaP.Enabled = check;
            groupBox1.Enabled = !check;
            groupBox2.Enabled = !check;
        }
        private bool check = true;
        private void Search(List<PhongDTO> list)
        {
            int start = 0, end = 0;
            if (cbGiaP.SelectedIndex == 0)
            {
                end = int.Parse(cbGiaP.SelectedItem.ToString().Split(' ')[1].Replace(",", ""));
            }
            else if (cbGiaP.SelectedIndex == 5)
            {
                start = int.Parse(cbGiaP.SelectedItem.ToString().Split(' ')[1].Replace(",", ""));
            }
            else if (cbGiaP.SelectedIndex == 1 || cbGiaP.SelectedIndex == 2 || cbGiaP.SelectedIndex == 3)
            {
                start = int.Parse(cbGiaP.SelectedItem.ToString().Split(' ')[1].Replace(",", ""));
                end = int.Parse(cbGiaP.SelectedItem.ToString().Split(' ')[4].Replace(",", ""));
            }
            var rooms = list.Where(room => cbLoaiP.SelectedIndex == -1 || room.LoaiP == cbLoaiP.SelectedIndex)
                                 .Where(room => cbCTLP.SelectedIndex == -1 || room.ChiTietLoaiP == cbCTLP.SelectedIndex)
                                 .Where(room => cbHT.SelectedIndex == -1 || room.TinhTrang == cbHT.SelectedIndex)
                                 .Where(room => cbGiaP.SelectedIndex == -1 || (cbGiaP.SelectedIndex == 5 && room.GiaP >= start)
                                 || (room.GiaP >= start && room.GiaP <= end));
            if (rooms.ToList().Count == 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Thông báo", "Không tìm thấy phòng phù hợp", MessageBoxDialog.INFO, MessageBoxDialog.YES, "Đóng", "", "");
                RenderRoom(listPhong);
                check = false;
                cbCTLP.SelectedIndex = -1;
                cbLoaiP.SelectedIndex = -1;
                cbHT.SelectedIndex = -1;
                cbGiaP.SelectedIndex = -1;
                check = true;
            }
            else
            {
                RenderRoom(rooms.ToList());
            }
        }
        private void btnFindRoom_Click(object sender, EventArgs e)
        {
            if (rdNgay.Checked == false && rdGio.Checked == false && rdKhac.Checked == false)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Lỗi chưa chọn dữ liệu", "Vui lòng chọn hình thức thuê", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
            }
            else
            {
                DateTime now = DateTime.Now;
                if (dateTimeThue.Value < now)
                {
                    MessageBoxDialog message = new MessageBoxDialog();
                    message.ShowDialog("Thông báo", "Thông báo", "Ngày giờ thuê phải lớn hơn hoặc bằng ngày giờ hiện tại", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                }
                else
                {
                    #region Thuê theo ngày
                    if (rdNgay.Checked)
                    {
                        if (dateTimeTra.Value <= dateTimeThue.Value)
                        {
                            MessageBoxDialog message = new MessageBoxDialog();
                            message.ShowDialog("Thông báo", "Thông báo", "Ngày giờ trả phải lớn hơn ngày giờ thuê", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                        }
                        else
                        {
                            SetEnable(true);
                            var cttList = from cttp in cttPhong.GetDSListCTTP()
                                          join ctt in ctt.getDSChiTietThue() on cttp.MaCTT equals ctt.MaCTT
                                          join room in phong.getListPhong_DTO() on cttp.MaP equals room.MaP
                                          where ctt.XuLy == 0 && ctt.TinhTrangXuLy == 0 && cttp.NgayThue <= dateTimeTra.Value && (cttp.NgayTra >= dateTimeThue.Value || !cttp.NgayTra.HasValue)
                                          select room;
                            var roomsValid = phong.getListPhong_DTO().Where(room => room.TinhTrang == 0 && !cttList.ToList().Any(ctt => ctt.MaP == room.MaP));
                            this.listPhong.Clear();
                            this.listPhong = roomsValid.ToList();
                            RenderRoom(listPhong);
                        }
                    }
                    #endregion
                    #region Thuê theo giờ
                    else if (rdGio.Checked)
                    {
                        if (dateTimeTra.Value <= dateTimeThue.Value)
                        {
                            MessageBoxDialog message = new MessageBoxDialog();
                            message.ShowDialog("Thông báo", "Thông báo", "Ngày giờ trả phải lớn hơn ngày giờ thuê", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                        }
                        else
                        {
                            TimeSpan timeSpan = dateTimeTra.Value.Subtract(dateTimeThue.Value);
                            if (timeSpan.Days > 0 && timeSpan.Hours < 1)
                            {
                                MessageBoxDialog message = new MessageBoxDialog();
                                message.ShowDialog("Thông báo", "Thông báo", "Có lẽ bạn muốn thuê theo ngày vui lòng kiểm tra lại", MessageBoxDialog.WARNING, MessageBoxDialog.YES, "Đóng", "", "");
                            }
                            else if (timeSpan.Days == 0 && timeSpan.Hours < 1)
                            {
                                MessageBoxDialog message = new MessageBoxDialog();
                                message.ShowDialog("Thông báo", "Thông báo", "Vui lòng thuê ít nhất 1 giờ", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                            }
                            else
                            {
                                SetEnable(true);
                                var cttList = from cttp in cttPhong.GetDSListCTTP()
                                              join ctt in ctt.getDSChiTietThue() on cttp.MaCTT equals ctt.MaCTT
                                              join room in phong.getListPhong_DTO() on cttp.MaP equals room.MaP
                                              where ctt.XuLy == 0 && ctt.TinhTrangXuLy == 0 && cttp.NgayThue <= dateTimeTra.Value && (cttp.NgayTra >= dateTimeThue.Value || !cttp.NgayTra.HasValue)
                                              select room;
                                var roomsValid = phong.getListPhong_DTO().Where(room => room.TinhTrang == 0 && !cttList.ToList().Any(ctt => ctt.MaP == room.MaP));
                                this.listPhong.Clear();
                                this.listPhong = roomsValid.ToList();
                                RenderRoom(listPhong);
                            }
                        }
                    }
                    #endregion
                    #region Thuê chưa xác định ngày trả
                    else
                    {
                        SetEnable(true);
                        var cttList = from cttp in cttPhong.GetDSListCTTP()
                                      join ctt in ctt.getDSChiTietThue() on cttp.MaCTT equals ctt.MaCTT
                                      join room in phong.getListPhong_DTO() on cttp.MaP equals room.MaP
                                      where ctt.TinhTrangXuLy == 0
                                      where (cttp.NgayThue <= dateTimeThue.Value && (cttp.NgayTra >= dateTimeThue.Value || !cttp.NgayTra.HasValue))
                                       || cttp.NgayThue >= dateTimeThue.Value
                                      select room;
                        var roomsValid = phong.getListPhong_DTO().Where(room => room.TinhTrang == 0 && !cttList.ToList().Any(ctt => ctt.MaP == room.MaP));
                        this.listPhong.Clear();
                        this.listPhong = roomsValid.ToList();
                        RenderRoom(listPhong);
                    }
                    #endregion
                }
            }
        }

        private void cbCTLP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (check)
                Search(listPhong);
        }

        private void frmSelectRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
