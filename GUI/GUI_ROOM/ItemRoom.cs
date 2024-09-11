using System;
using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using BUS;
using DTO;
using GUI.GUI_BOOKING;
using GUI.GUI_COMPONENT;

namespace GUI.GUI_ROOM
{
    public partial class ItemRoom : Form
    {
        PhongDTO phongDTO = new PhongDTO();
        ChiTietThuePhongBUS cttp = new ChiTietThuePhongBUS();
        PhongBUS phongBUS = new PhongBUS();
        private Color originalColor;
        BookingNew bookingNew;
        public ItemRoom(PhongDTO phongDTO, BookingNew bookingNew)
        {
            this.bookingNew = bookingNew;
            this.phongDTO = phongDTO;
            InitializeComponent();
            lbTenP.Text = phongDTO.TenP.ToString();
            if (phongDTO.TinhTrang == 0)
            {
                BackColor = Color.MediumSeaGreen;
                lbTenP.BackColor = Color.Green;
            }
            else if (phongDTO.TinhTrang == 1)
            {
                BackColor = Color.OrangeRed;
                lbTenP.BackColor = Color.FromArgb(191, 4, 4);
            }
            else if (phongDTO.TinhTrang == 2)
            {
                BackColor = Color.Gold;
                lbTenP.BackColor = Color.FromArgb(153, 153, 0);
            }
            originalColor = this.BackColor;
            if (phongDTO.TinhTrang == 0)
            {
                lbTT.Text = "Phòng trống";
                panel1.Visible = false;
            }
            else if (phongDTO.TinhTrang == 1)
            {
                lbTT.Text = "Phòng có khách";
                DataTable dt = cttp.GetInfoRoom(phongDTO.MaP);
                txtMaCTT.Text = dt.Rows[0][0].ToString();
                txtTenKH.Text = dt.Rows[0][1].ToString();
                try
                {
                    txtNgayTra.Text = DateTime.Parse(dt.Rows[0][2].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch (Exception)
                {
                    txtNgayTra.Text = "Chưa xác định";
                }
            }
            else
            {
                lbTT.Text = "Phòng chưa dọn";
                panel1.Visible = false;
            }
            lbGiaP.Text = phongDTO.GiaP.ToString("###,###0 VNĐ");
            if (phongDTO.ChiTietLoaiP == 0)
            {
                lbCTLP.Text = "Phòng đơn";
            }
            else if (phongDTO.ChiTietLoaiP == 1)
            {
                lbCTLP.Text = "Phòng đôi";
            }
            else
            {
                lbCTLP.Text = "Phòng gia đình";
            }
            if (phongDTO.TinhTrang == 1 || phongDTO.TinhTrang == 2)
            {
                mItemBooking.Enabled = false;
            }
            if (phongDTO.TinhTrang == 0 || phongDTO.TinhTrang == 1)
            {
                mItemCleanRoom.Enabled = false;
            }
            if (phongDTO.LoaiP == 0)
            {
                lbLoaiP.Text = "Phòng Vip";
            }
            else
            {
                lbLoaiP.Text = "Phòng Thường";
            }
            mItemView.Click += ViewClick;
            timerRealTime.Start();
        }
        private void ViewClick(object sender, EventArgs e)
        {
            frmAddRoom frmAdd = new frmAddRoom(2, phongDTO);
            frmAdd.ShowDialog();
        }

        private void ItemRoom_MouseEnter(object sender, EventArgs e)
        {
            Color currentColor = this.BackColor;
            Color darkerColor = Color.FromArgb(
                Math.Max(0, currentColor.R - 10),
                Math.Max(0, currentColor.G - 10),
                Math.Max(0, currentColor.B - 10)
            );
            this.BackColor = darkerColor;
        }

        private void ItemRoom_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = originalColor;
        }

        private void timerRealTime_Tick(object sender, EventArgs e)
        {
            lbRealTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lbRealDay.Text = DateTime.Now.ToString("ddd dd/MM/yyyy");
        }

        private void mItemBooking_Click(object sender, EventArgs e)
        {
            if (bookingNew.isValid)
            {
                frmBookingNew frmBookingNew = new frmBookingNew();
                BookingNew frm = (BookingNew)getParentForm_2(this);
                if (frm.radioButton1.Checked == true)
                {
                    DateTime date = frm.dtNgayTra.Value;
                    DateTime dateTra = new DateTime(date.Year, date.Month, date.Day, frm.dtNgayThue.Value.Hour, frm.dtNgayThue.Value.Minute, frm.dtNgayThue.Value.Second);
                    TimeSpan sub2day = dateTra.Subtract(frm.dtNgayThue.Value);
                    int gia = 0;
                    if (phongDTO.HienTrang == 0)
                    {
                        gia = sub2day.Days * phongDTO.GiaP;
                    }
                    else
                    {
                        gia = (sub2day.Days * phongDTO.GiaP) / 2;
                    }
                    PhongDTO phong = (PhongDTO)phongDTO;
                    frmBookingNew.dt.Rows.Add(phong.MaP, phong.TenP, "Đang xử lý", "Theo ngày", frm.dtNgayThue.Value, dateTra, "", gia);
                }
                else if (frm.radioButton2.Checked == true)
                {
                    DateTime dateTra = new DateTime(frm.dtNgayTra.Value.Year, frm.dtNgayTra.Value.Month, frm.dtNgayTra.Value.Day, frm.dtNgayTra.Value.Hour, frm.dtNgayTra.Value.Minute, frm.dtNgayTra.Value.Second);
                    TimeSpan sub2Day = dateTra.Subtract(frm.dtNgayThue.Value);
                    double gia = 0;
                    switch (sub2Day.Hours)
                    {
                        case 1:
                            gia = phongDTO.GiaP * 0.15 + phongDTO.GiaP * sub2Day.Days;
                            break;
                        case 2:
                            gia = phongDTO.GiaP * 0.2 + phongDTO.GiaP * sub2Day.Days;
                            break;
                        case 3:
                            gia = phongDTO.GiaP * 0.25 + phongDTO.GiaP * sub2Day.Days;
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                            gia = phongDTO.GiaP * 0.5 + phongDTO.GiaP * sub2Day.Days;
                            break;
                        default:
                            gia = phongDTO.GiaP + phongDTO.GiaP * sub2Day.Days;
                            break;
                    }
                    if (phongDTO.HienTrang == 1)
                    {
                        gia = int.Parse(gia.ToString()) / 2;
                    }
                    int gia2 = (int)gia;
                    PhongDTO phong = (PhongDTO)phongDTO;
                    frmBookingNew.dt.Rows.Add(phong.MaP, phong.TenP, "Đang xử lý", "Theo giờ", frm.dtNgayThue.Value, dateTra, "", gia2);
                }
                else
                {
                    int gia = 0;
                    if (phongDTO.HienTrang == 0)
                    {
                        gia = phongDTO.GiaP;
                    }
                    else
                    {
                        gia = phongDTO.GiaP / 2;
                    }
                    PhongDTO phong = (PhongDTO)phongDTO;
                    frmBookingNew.dt.Rows.Add(phong.MaP, phong.TenP, "Đang xử lý", "Khác", frm.dtNgayThue.Value, "Chưa xác định", "", gia);
                }
                frmBookingNew.TopLevel = false;
                QLKS_Form form = (QLKS_Form)getParentForm(this);
                Panel pnContent = form.pnContent;
                pnContent.Controls.Clear();
                pnContent.Controls.Add(frmBookingNew);
                frmBookingNew.Dock = DockStyle.Fill;
                frmBookingNew.Show();
            }
            else
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Thông báo", "Vui lòng chọn hình thức thuê và chọn thời gian phù hợp và bấm tìm kiếm", MessageBoxDialog.WARNING, MessageBoxDialog.YES, "Đóng", "", "");
                return;
            }
        }
        private Control getParentForm(Control a)
        {
            if (a is QLKS_Form)
            {
                return a;
            }
            return getParentForm(a.Parent);
        }
        private Control getParentForm_2(Control a)
        {
            if (a is BookingNew)
            {
                return a;
            }
            return getParentForm_2(a.Parent);
        }

        private void mItemCleanRoom_Click(object sender, EventArgs e)
        {
            phongBUS.SuaTinhTrang(phongDTO.MaP, "0");
            MessageBoxDialog message = new MessageBoxDialog();
            message.ShowDialog("Thông báo", "Thành công", "Dọn phòng này thành công, hiện có thể đặt phòng", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
            bookingNew.RenderRoom(phongBUS.getListPhong_DTO());
        }
    }
}
