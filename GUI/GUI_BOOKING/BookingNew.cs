using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;
using GUI.GUI_COMPONENT;
using GUI.GUI_ROOM;
using static GUI.GUI_BOOKING.rpThongTinPhieuThue;

namespace GUI.GUI_BOOKING
{
    public partial class BookingNew : Form
    {
        PhongBUS phong = new PhongBUS();
        List<PhongDTO> rooms = new List<PhongDTO>();
        public BookingNew()
        {
            InitializeComponent();
            rooms = phong.getListPhong_DTO();
        }

        private void BookingNew_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            RenderRoom(this.rooms);
            DateTime dt = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,7,0,0);
            dtNgayThue.Value = dt;
            dtNgayTra.Value = dt;
        }
        public void RenderRoom(List<PhongDTO> rooms)
        {
            this.pnSoDoPhong.Controls.Clear();
            foreach (PhongDTO room in rooms)
            {
                ItemRoom itemRoom = new ItemRoom(room, this);
                itemRoom.TopLevel = false;
                this.pnSoDoPhong.Controls.Add(itemRoom);
                itemRoom.Show();
            }
        }
        public bool checkBooking = false;
        public bool isValid = false;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (checkBooking)
            {
                DateTime now = DateTime.Now;
                if (dtNgayThue.Value < now)
                {
                    MessageBoxDialog message = new MessageBoxDialog();
                    message.ShowDialog("Thông báo", "Thông báo", "Ngày giờ thuê phải lớn hơn hoặc bằng ngày giờ hiện tại", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                }
                else
                {
                    #region Thuê theo ngày
                    if (radioButton1.Checked)
                    {
                        if (dtNgayTra.Value <= dtNgayThue.Value)
                        {
                            MessageBoxDialog message = new MessageBoxDialog();
                            message.ShowDialog("Thông báo", "Thông báo", "Ngày giờ trả phải lớn hơn ngày giờ thuê", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                        }
                        else
                        {
                            ChiTietThuePhongBUS cttPhong = new ChiTietThuePhongBUS();
                            ChiTietThueBUS ctThue = new ChiTietThueBUS();
                            PhongBUS phong = new PhongBUS();
                            var cttList = from cttp in cttPhong.GetDSListCTTP()
                                          join ctt in ctThue.getDSChiTietThue() on cttp.MaCTT equals ctt.MaCTT
                                          join room in phong.getListPhong_DTO() on cttp.MaP equals room.MaP
                                          where ctt.XuLy == 0 && ctt.TinhTrangXuLy == 0 && cttp.NgayThue <= dtNgayTra.Value && (cttp.NgayTra >= dtNgayThue.Value || !cttp.NgayTra.HasValue)
                                          select room;
                            var roomsValid = phong.getListPhong_DTO().Where(room => room.TinhTrang == 0 && !cttList.ToList().Any(ctt => ctt.MaP == room.MaP));

                            #region Giá
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
                            #endregion
                            var listTmp = roomsValid.Where(room => cbLoaiP.SelectedIndex == -1 || room.LoaiP == cbLoaiP.SelectedIndex)
                                 .Where(room => cbCTLP.SelectedIndex == -1 || room.ChiTietLoaiP == cbCTLP.SelectedIndex)
                                 .Where(room => cbTinhTrang.SelectedIndex == -1 || room.TinhTrang == cbTinhTrang.SelectedIndex)
                                 .Where(room => cbHienTrang.SelectedIndex == -1 || room.HienTrang == cbHienTrang.SelectedIndex)
                                 .Where(room => cbGiaP.SelectedIndex == -1 || (cbGiaP.SelectedIndex == 5 && room.GiaP >= start)
                                 || (room.GiaP >= start && room.GiaP <= end));
                            RenderRoom(listTmp.ToList());
                            isValid = true;
                            groupBox1.Enabled = false;
                            groupBox2.Enabled = false;
                        }
                    }
                    #endregion
                    #region Thuê theo giờ
                    else if (radioButton2.Checked)
                    {
                        if (dtNgayTra.Value <= dtNgayThue.Value)
                        {
                            MessageBoxDialog message = new MessageBoxDialog();
                            message.ShowDialog("Thông báo", "Thông báo", "Ngày giờ trả phải lớn hơn ngày giờ thuê", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                        }
                        else
                        {
                            TimeSpan timeSpan = dtNgayTra.Value.Subtract(dtNgayThue.Value);
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
                                ChiTietThuePhongBUS cttPhong = new ChiTietThuePhongBUS();
                                ChiTietThueBUS ctThue = new ChiTietThueBUS();
                                PhongBUS phong = new PhongBUS();
                                var cttList = from cttp in cttPhong.GetDSListCTTP()
                                              join ctt in ctThue.getDSChiTietThue() on cttp.MaCTT equals ctt.MaCTT
                                              join room in phong.getListPhong_DTO() on cttp.MaP equals room.MaP
                                              where ctt.XuLy == 0 && ctt.TinhTrangXuLy == 0 && cttp.NgayThue <= dtNgayTra.Value && (cttp.NgayTra >= dtNgayThue.Value || !cttp.NgayTra.HasValue)
                                              select room;
                                var roomsValid = phong.getListPhong_DTO().Where(room => room.TinhTrang == 0 && !cttList.ToList().Any(ctt => ctt.MaP == room.MaP));

                                #region Giá
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
                                #endregion
                                var listTmp = roomsValid.Where(room => cbLoaiP.SelectedIndex == -1 || room.LoaiP == cbLoaiP.SelectedIndex)
                                     .Where(room => cbCTLP.SelectedIndex == -1 || room.ChiTietLoaiP == cbCTLP.SelectedIndex)
                                     .Where(room => cbTinhTrang.SelectedIndex == -1 || room.TinhTrang == cbTinhTrang.SelectedIndex)
                                     .Where(room => cbHienTrang.SelectedIndex == -1 || room.HienTrang == cbHienTrang.SelectedIndex)
                                     .Where(room => cbGiaP.SelectedIndex == -1 || (cbGiaP.SelectedIndex == 5 && room.GiaP >= start)
                                     || (room.GiaP >= start && room.GiaP <= end));
                                RenderRoom(listTmp.ToList());
                                isValid = true;
                                groupBox1.Enabled = false;
                                groupBox2.Enabled = false;
                            }
                        }
                    }
                    #endregion
                    #region Thuê chưa xác định ngày trả
                    else
                    {
                        ChiTietThuePhongBUS cttPhong = new ChiTietThuePhongBUS();
                        ChiTietThueBUS ctThue = new ChiTietThueBUS();
                        PhongBUS phong = new PhongBUS();
                        var cttList = from cttp in cttPhong.GetDSListCTTP()
                                      join ctt in ctThue.getDSChiTietThue() on cttp.MaCTT equals ctt.MaCTT
                                      join room in phong.getListPhong_DTO() on cttp.MaP equals room.MaP
                                      where ctt.TinhTrangXuLy == 0
                                      where (cttp.NgayThue <= dtNgayThue.Value && (cttp.NgayTra >= dtNgayThue.Value || !cttp.NgayTra.HasValue))
                                       || cttp.NgayThue >= dtNgayThue.Value
                                      select room;
                        var roomsValid = phong.getListPhong_DTO().Where(room => room.TinhTrang == 0 && !cttList.ToList().Any(ctt => ctt.MaP == room.MaP));

                        #region Giá
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
                        #endregion
                        var listTmp = roomsValid.Where(room => cbLoaiP.SelectedIndex == -1 || room.LoaiP == cbLoaiP.SelectedIndex)
                             .Where(room => cbCTLP.SelectedIndex == -1 || room.ChiTietLoaiP == cbCTLP.SelectedIndex)
                             .Where(room => cbTinhTrang.SelectedIndex == -1 || room.TinhTrang == cbTinhTrang.SelectedIndex)
                             .Where(room => cbHienTrang.SelectedIndex == -1 || room.HienTrang == cbHienTrang.SelectedIndex)
                             .Where(room => cbGiaP.SelectedIndex == -1 || (cbGiaP.SelectedIndex == 5 && room.GiaP >= start)
                             || (room.GiaP >= start && room.GiaP <= end));
                        RenderRoom(listTmp.ToList());
                        isValid = true;
                        groupBox1.Enabled = false;
                        groupBox2.Enabled = false;
                    }
                    #endregion
                }
            }
            else
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
                List<PhongDTO> list = phong.getListPhong_DTO();
                var listTmp = list.Where(room => cbLoaiP.SelectedIndex == -1 || room.LoaiP == cbLoaiP.SelectedIndex)
                                     .Where(room => cbCTLP.SelectedIndex == -1 || room.ChiTietLoaiP == cbCTLP.SelectedIndex)
                                     .Where(room => cbTinhTrang.SelectedIndex == -1 || room.TinhTrang == cbTinhTrang.SelectedIndex)
                                     .Where(room => cbHienTrang.SelectedIndex == -1 || room.HienTrang == cbHienTrang.SelectedIndex)
                                     .Where(room => cbGiaP.SelectedIndex == -1 || (cbGiaP.SelectedIndex == 5 && room.GiaP >= start)
                                     || (room.GiaP >= start && room.GiaP <= end));
                RenderRoom(listTmp.ToList());
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            checkBooking = true;
            dtNgayTra.CustomFormat = "dd/MM/yyyy";
            dtNgayTra.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            checkBooking = true;
            dtNgayTra.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtNgayTra.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            checkBooking = true;
            dtNgayTra.CustomFormat = " ";
            dtNgayTra.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbCTLP.SelectedIndex = -1;
            cbGiaP.SelectedIndex = -1;
            cbHienTrang.SelectedIndex = -1;
            cbLoaiP.SelectedIndex = -1;
            cbTinhTrang.SelectedIndex = -1;
            checkBooking = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            dtNgayThue.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtNgayTra.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtNgayTra.Enabled = true;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            isValid = false;
            RenderRoom(rooms);
        }
    }
}
