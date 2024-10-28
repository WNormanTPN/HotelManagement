using BUS;
using DTO;
using GUI.GUI_COMPONENT;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmForgotPassword : Form
    {
        public frmForgotPassword()
        {
            InitializeComponent();
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

        private void buttonRounded1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin();
            login.ShowDialog();
            this.Close();
        }

        private void frmChangePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pnTop_MouseDown(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;
            mouseOffset = new Point(-mouseX, -mouseY);
        }

        private void pnTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                this.Location = mousePos;
            }
        }

        private void buttonRounded2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmChangePassword login = new frmChangePassword();
            login.ShowDialog();
            this.Close();
        }

        private async void buttonRounded3_Click(object sender, EventArgs e)
        {
            TaiKhoanBUS tkBUS = new TaiKhoanBUS();
            TaiKhoanDTO tkDTO = tkBUS.GetTK(txtTK.Text);

            if (!string.IsNullOrEmpty(tkDTO.TaiKhoan))
            {
                NhanVienBUS nvBUS = new NhanVienBUS();
                NhanVienDTO nvDTO = nvBUS.GetNV(tkDTO.MaNV);
                try
                {
                    GMailer gmailer = new GMailer("luxury.hotel.bot@gmail.com", "Luxury Hotel", "vinhstarmcpc@gmail.com", "Phan Phước Vinh");

                    Random random = new Random();
                    int n = random.Next(0, 1000000);
                    string code = n.ToString("D6");

                    string subject = "Verification Code";
                    string messageBody = $"Dear Phan Phước Vinh,\r\n\r\nThis is your verification code:\r\n{code}\r\n\r\nBest regards,\r\nLuxury Hotel.";

                    await gmailer.SendMail(subject, messageBody);

                    Console.WriteLine("Email đã được gửi thành công!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    Console.WriteLine("Gửi email thất bại: " + ex.Message);
                }
            }
            else
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Lỗi", "", "Không tìm thấy tài khoản", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Có", "", "");
            }
        }

    }
}
