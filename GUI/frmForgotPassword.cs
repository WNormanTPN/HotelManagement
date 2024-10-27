using BUS;
using DTO;
using Google.Apis.Auth.OAuth2;
using GUI.GUI_COMPONENT;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
                string email = nvDTO.Email;

                try
                {
                    // Tạo nội dung email
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Tên của bạn", "your_email@gmail.com"));
                    message.To.Add(new MailboxAddress("Tên người nhận", email));
                    message.Subject = "Thông báo quan trọng từ hệ thống";
                    message.Body = new TextPart("plain")
                    {
                        Text = "Đây là nội dung email thông báo về tài khoản của bạn."
                    };

                    // Đường dẫn tới file JSON đã tải từ Google Cloud Console
                    var credentialPath = "path/to/your/client_secret.json";
                    var clientSecrets = GoogleClientSecrets.Load(File.OpenRead(credentialPath)).Secrets;

                    // Xác thực OAuth2
                    var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        clientSecrets,
                        new[] { "https://mail.google.com/" },
                        "user",
                        CancellationToken.None);

                    using (var client = new SmtpClient())
                    {
                        await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

                        // Sử dụng OAuth2 để xác thực và gửi email
                        var oauth2 = new SaslMechanismOAuth2("your_email@gmail.com", credential.Token.AccessToken);
                        await client.AuthenticateAsync(oauth2);
                        await client.SendAsync(message);
                        await client.DisconnectAsync(true);
                    }

                    MessageBox.Show("Email đã được gửi thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gửi email thất bại: " + ex.Message);
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
