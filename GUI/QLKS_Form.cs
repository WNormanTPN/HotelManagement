using GUI.GUI_COMPONENT;
using GUI.GUI_ROOM;
using GUI.GUI_SERVICE;
using GUI.GUI_HOME;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GUI.GUI_CUSTOMER;
using GUI.GUI_STAFF;
using GUI.GUI_BOOKING;
using GUI.GUI_BILL;
using GUI.GUI_ROLE;
using System.Data;
using BUS;
using DTO;
using System.Windows.Forms.DataVisualization.Charting;
using GUI.GUI_THONGKE;

namespace GUI
{
    public partial class QLKS_Form : Form
    {
        public QLKS_Form()
        {
            InitializeComponent();
        }

        bool menuExpand = false;
        private void timerMenuTransition_Tick(object sender, EventArgs e)
        {
            if (!menuExpand)
            {
                pnBooking.Height += 10;
                if (pnBooking.Height >= 110)
                {
                    timerMenuTransition.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                pnBooking.Height -= 10;
                if (pnBooking.Height <= 48)
                {
                    timerMenuTransition.Stop();
                    menuExpand = false;
                }
            }
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            pnContent.SuspendLayout();
            timerMenuTransition.Start();
            pnContent.ResumeLayout();
        }

        bool sliderBar = true;
        private void picMenu_Click(object sender, EventArgs e)
        {
            timerSliderBar.Start();
        }

        private void timerSliderBar_Tick(object sender, EventArgs e)
        {
            if (sliderBar)
            {
                pnMenu.Width -= 5;
                if (pnMenu.Width <= 70)
                {
                    Show_HideTextButton(false);
                    sliderBar = false;
                    timerSliderBar.Stop();
                    pnHome.Width = pnMenu.Width;
                    pnRoom.Width = pnMenu.Width;
                    pnService.Width = pnMenu.Width;
                    pnStaff.Width = pnMenu.Width;
                    pnCustomer.Width = pnMenu.Width;
                    pnRole.Width = pnMenu.Width;
                    pnBooking.Width = pnMenu.Width;
                    pnBill.Width = pnMenu.Width;
                    pnStatistic.Width = pnMenu.Width;
                    btnHome.Width = pnHome.Width - 12;
                    btnRoom.Width = pnRoom.Width - 12;
                    btnService.Width = pnService.Width - 12;
                    btnStaff.Width = pnStaff.Width - 12;
                    btnCustomer.Width = pnCustomer.Width - 12;
                    btnBooking.Width = pnBooking.Width - 12;
                    btnBookingNew.Width = pnBooking.Width - 12;
                    btnListBooking.Width = pnBooking.Width - 12;
                    btnBill.Width = pnBill.Width - 12;
                    btnStatistic.Width = pnStatistic.Width - 12;
                    btnRole.Width = pnRole.Width - 12;
                }
            }
            else
            {
                pnMenu.Width += 5;
                if (pnMenu.Width >= 240)
                {
                    Show_HideTextButton(true);
                    sliderBar = true;
                    timerSliderBar.Stop();
                    pnHome.Width = pnMenu.Width;
                    pnRoom.Width = pnMenu.Width;
                    pnService.Width = pnMenu.Width;
                    pnStaff.Width = pnMenu.Width;
                    pnCustomer.Width = pnMenu.Width;
                    pnRole.Width = pnMenu.Width;
                    pnBooking.Width = pnMenu.Width;
                    pnBill.Width = pnMenu.Width;
                    pnStatistic.Width = pnMenu.Width;
                    btnHome.Width = pnHome.Width - 12;
                    btnRoom.Width = pnRoom.Width - 12;
                    btnService.Width = pnService.Width - 12;
                    btnStaff.Width = pnStaff.Width - 12;
                    btnCustomer.Width = pnCustomer.Width - 12;
                    btnBooking.Width = pnBooking.Width - 12;
                    btnBookingNew.Width = pnBooking.Width - 12;
                    btnListBooking.Width = pnBooking.Width - 12;
                    btnBill.Width = pnBill.Width - 12;
                    btnStatistic.Width = pnStatistic.Width - 12;
                    btnRole.Width = pnRole.Width - 12;
                }
            }
        }
        private void Show_HideTextButton(bool show_hide)
        {
            if (show_hide)
            {
                btnHome.Text = "        Màn hình chính";
                btnRoom.Text = "        Quản lý phòng";
                btnService.Text = "        Quản lý dịch vụ";
                btnStaff.Text = "        Quản lý nhân viên";
                btnCustomer.Text = "        Quản lý khách hàng";
                btnRole.Text = "        Quản lý phân quyền";
                btnBooking.Text = "        Quản lý đặt phòng";
                btnBookingNew.Text = "        Đặt phòng mới";
                btnListBooking.Text = "        Danh sách đặt phòng";
                btnBill.Text = "        Quản lý hóa đơn";
                btnStatistic.Text = "        Xem thống kê";
            }
            else
            {
                btnHome.Text = "";
                btnRoom.Text = "";
                btnService.Text = "";
                btnStaff.Text = "";
                btnCustomer.Text = "";
                btnRole.Text = "";
                btnBooking.Text = "";
                btnBookingNew.Text = "";
                btnListBooking.Text = "";
                btnBill.Text = "";
                btnStatistic.Text = "";
            }
        }

        private MessageBoxDialog message;
        private void QLKS_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            message = new MessageBoxDialog();
            int ans = message.ShowDialog("Thông báo", "Thông báo", "Bạn có muốn thoát chương trình", MessageBoxDialog.INFO, MessageBoxDialog.YES_NO, "Đồng ý", "Không đồng ý", "");
            if (ans == MessageBoxDialog.YES_OPTION)
            {
                this.Hide();
                frmLogin ld = new frmLogin();
                ld.ShowDialog();
                this.Dispose();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            SetColorBackground();
            btnRoom.BackColor = Color.CornflowerBlue;
            btnRoom.ForeColor = Color.White;
            RoomForm home = new RoomForm();
            home.TopLevel = false;
            pnContent.Controls.Add(home);
            home.Dock = DockStyle.Fill;
            home.Show();
        }
        private void SetColorBackground()
        {
            btnHome.BackColor = Color.White;
            btnRoom.BackColor = Color.White;
            btnService.BackColor = Color.White;
            btnStaff.BackColor = Color.White;
            btnCustomer.BackColor = Color.White;
            btnStatistic.BackColor = Color.White;
            btnBooking.BackColor = Color.White;
            btnBill.BackColor = Color.White;
            btnRole.BackColor = Color.White;

            btnHome.ForeColor = Color.Black;
            btnRoom.ForeColor = Color.Black;
            btnService.ForeColor = Color.Black;
            btnStaff.ForeColor = Color.Black;
            btnCustomer.ForeColor = Color.Black;
            btnStatistic.ForeColor = Color.Black;
            btnBooking.ForeColor = Color.Black;
            btnBill.ForeColor = Color.Black;
            btnRole.ForeColor = Color.Black;

            btnBookingNew.BackColor = Color.WhiteSmoke;
            btnBookingNew.ForeColor = Color.Black;
            btnListBooking.BackColor = Color.WhiteSmoke;
            btnListBooking.ForeColor = Color.Black;
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            SetColorBackground();
            btnService.BackColor = Color.CornflowerBlue;
            btnService.ForeColor = Color.White;
            ServiceForm home = new ServiceForm();
            home.TopLevel = false;
            pnContent.Controls.Add(home);
            home.Dock = DockStyle.Fill;
            home.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            SetColorBackground();
            btnCustomer.BackColor = Color.CornflowerBlue;
            btnCustomer.ForeColor = Color.White;
            CustomerForm home = new CustomerForm();
            home.TopLevel = false;
            pnContent.Controls.Add(home);
            home.Dock = DockStyle.Fill;
            home.Show();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            SetColorBackground();
            btnStaff.BackColor = Color.CornflowerBlue;
            btnStaff.ForeColor = Color.White;
            StaffForm home = new StaffForm();
            home.TopLevel = false;
            pnContent.Controls.Add(home);
            home.Dock = DockStyle.Fill;
            home.Show();
        }

        private void btnRole_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            SetColorBackground();
            btnRole.BackColor = Color.CornflowerBlue;
            btnRole.ForeColor = Color.White;
            RoleForm home = new RoleForm();
            home.TopLevel = false;
            pnContent.Controls.Add(home);
            home.Dock = DockStyle.Fill;
            home.Show();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            SetColorBackground();
            btnBill.BackColor = Color.CornflowerBlue;
            btnBill.ForeColor = Color.White;
            BillForm home = new BillForm();
            home.TopLevel = false;
            pnContent.Controls.Add(home);
            home.Dock = DockStyle.Fill;
            home.Show();
        }
        private void btnStatistic_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            SetColorBackground();
            btnStatistic.BackColor = Color.CornflowerBlue;
            btnStatistic.ForeColor = Color.White;
            FormChart home = new FormChart();
            home.TopLevel = false;
            pnContent.Controls.Add(home);
            home.Dock = DockStyle.Fill;
            home.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            SetColorBackground();
            btnHome.BackColor = Color.CornflowerBlue;
            btnHome.ForeColor = Color.White;
            HomeForm home = new HomeForm();
            home.TopLevel = false;
            pnContent.Controls.Add(home);
            home.Dock = DockStyle.Fill;
            home.Show();
        }

        private void QLKS_Form_Load(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            HomeForm home = new HomeForm();
            home.TopLevel = false;
            pnContent.Controls.Add(home);
            home.Dock = DockStyle.Fill;
            home.Show();
            ChucNangBUS cn = new ChucNangBUS();
            TaiKhoanBUS tkbus = new TaiKhoanBUS();
            TaiKhoanDTO tk = tkbus.GetTKNV(Program.nhanVien.MaNV);
            DataTable dt = cn.GetTBChucNang(tk.MaPQ);
            if (bool.Parse(dt.Rows[0][2].ToString()) != true)
            {
                pnRoom.Dispose();
            }
            if (bool.Parse(dt.Rows[1][2].ToString()) != true)
            {
                pnService.Dispose();
            }
            if (bool.Parse(dt.Rows[2][2].ToString()) != true)
            {
                pnCustomer.Dispose();
            }
            if (bool.Parse(dt.Rows[3][2].ToString()) != true)
            {
                pnStaff.Dispose();
            }
            if (bool.Parse(dt.Rows[4][2].ToString()) != true)
            {
                pnRole.Dispose();
            }
            if (bool.Parse(dt.Rows[5][2].ToString()) != true)
            {
                pnBooking.Dispose();
            }
            if (bool.Parse(dt.Rows[6][2].ToString()) != true)
            {
                pnBill.Dispose();
            }
            if (bool.Parse(dt.Rows[7][2].ToString()) != true)
            {
                pnStatistic.Dispose();
            }
        }

        private void btnBookingNew_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            SetColorBackground();
            btnBookingNew.BackColor = Color.Gray;
            btnBookingNew.ForeColor = Color.White;
            BookingNew home = new BookingNew();
            home.TopLevel = false;
            pnContent.Controls.Add(home);
            home.Dock = DockStyle.Fill;
            home.Show();
        }

        private void btnListBooking_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            SetColorBackground();
            btnListBooking.BackColor = Color.Gray;
            btnListBooking.ForeColor = Color.White;
            BookingList home = new BookingList();
            home.TopLevel = false;
            pnContent.Controls.Add(home);
            home.Dock = DockStyle.Fill;
            home.Show();
        }
    }
}
