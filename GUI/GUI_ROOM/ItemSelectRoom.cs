using BUS;
using DTO;
using GUI.GUI_BOOKING;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.GUI_ROOM
{
    public partial class ItemSelectRoom : Form
    {
        PhongDTO phongDTO = new PhongDTO();
        private Color originalColor;
        public ItemSelectRoom(PhongDTO phongDTO)
        {
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
            }
            else if (phongDTO.TinhTrang == 1)
            {
                lbTT.Text = "Phòng có khách";
            }
            else
            {
                lbTT.Text = "Phòng chưa dọn";
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
            if (phongDTO.LoaiP == 0)
            {
                lbLoaiP.Text = "Phòng Vip";
            }
            else
            {
                lbLoaiP.Text = "Phòng Thường";
            }
            if (phongDTO.HienTrang == 0)
            {
                lbHienTrang.Text = "Phòng mới";
            }
            else
            {
                lbHienTrang.Text = "Phòng cũ";
            }
            mItemView.Click += ViewClick;
            timerRealTime.Start();
            mItemBooking.Click += Booking_Click;
        }
        private void ViewClick(object sender, EventArgs e)
        {
            frmAddRoom frmAdd = new frmAddRoom(2, phongDTO);
            frmAdd.ShowDialog();
        }
        private void Booking_Click(object sender, EventArgs e)
        {
            frmSelectRoom frm = (frmSelectRoom)getParentForm(this);
            frm.DialogResult = DialogResult.OK;
            frm.arr[0] = phongDTO;
            if (frm.rdNgay.Checked == true)
            {
                DateTime date = frm.dateTimeTra.Value;
                DateTime dateTra = new DateTime(date.Year, date.Month, date.Day, frm.dateTimeThue.Value.Hour, frm.dateTimeThue.Value.Minute, frm.dateTimeThue.Value.Second);
                frm.arr[1] = "Theo ngày";
                frm.arr[2] = frm.dateTimeThue.Value;
                frm.arr[3] = dateTra;
                TimeSpan sub2day = dateTra.Subtract(frm.dateTimeThue.Value);
                if (phongDTO.HienTrang == 0)
                {
                    frm.arr[4] = sub2day.Days * phongDTO.GiaP;
                }
                else
                {
                    frm.arr[4] = (sub2day.Days * phongDTO.GiaP) / 2;
                }
            }
            else if (frm.rdGio.Checked == true)
            {
                DateTime dateTra = new DateTime(frm.dateTimeTra.Value.Year, frm.dateTimeTra.Value.Month, frm.dateTimeTra.Value.Day, frm.dateTimeTra.Value.Hour, frm.dateTimeTra.Value.Minute, frm.dateTimeTra.Value.Second);
                frm.arr[1] = "Theo giờ";
                frm.arr[2] = frm.dateTimeThue.Value;
                frm.arr[3] = dateTra;
                TimeSpan sub2Day = dateTra.Subtract(frm.dateTimeThue.Value);
                switch (sub2Day.Hours)
                {
                    case 1:
                        frm.arr[4] = phongDTO.GiaP * 0.15 + phongDTO.GiaP * sub2Day.Days;
                        break;
                    case 2:
                        frm.arr[4] = phongDTO.GiaP * 0.2 + phongDTO.GiaP * sub2Day.Days;
                        break;
                    case 3:
                        frm.arr[4] = phongDTO.GiaP * 0.25 + phongDTO.GiaP * sub2Day.Days;
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
                        frm.arr[4] = phongDTO.GiaP * 0.5 + phongDTO.GiaP * sub2Day.Days;
                        break;
                    default:
                        frm.arr[4] = phongDTO.GiaP + phongDTO.GiaP * sub2Day.Days;
                        break;
                }
                if (phongDTO.HienTrang == 1)
                {
                    frm.arr[4] = int.Parse(frm.arr[4].ToString()) / 2;
                }
            }
            else
            {
                frm.arr[1] = "Khác";
                frm.arr[2] = frm.dateTimeThue.Value;
                frm.arr[3] = "Chưa xác định";
                frm.arr[4] = phongDTO.GiaP;
                if (phongDTO.HienTrang == 0)
                {
                    frm.arr[4] = phongDTO.GiaP;
                }
                else
                {
                    frm.arr[4] = phongDTO.GiaP / 2;
                }
            }
        }
        private void timerRealTime_Tick(object sender, EventArgs e)
        {
            lbRealTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lbRealDay.Text = DateTime.Now.ToString("ddd dd/MM/yyyy");
        }

        private void ItemSelectRoom_MouseEnter(object sender, EventArgs e)
        {
            Color currentColor = this.BackColor;
            Color darkerColor = Color.FromArgb(
                Math.Max(0, currentColor.R - 10),
                Math.Max(0, currentColor.G - 10),
                Math.Max(0, currentColor.B - 10)
            );
            this.BackColor = darkerColor;
        }

        private void ItemSelectRoom_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = originalColor;
        }
        private Control getParentForm(Control a)
        {
            if (a is frmSelectRoom)
            {
                return a;
            }
            return getParentForm(a.Parent);
        }
    }
}
