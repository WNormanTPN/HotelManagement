using BUS;
using GUI.GUI_COMPONENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmChangePassword : Form
    {
        TaiKhoanBUS taiKhoan = new TaiKhoanBUS();
        NhanVienBUS nhanVien = new NhanVienBUS();
        public frmChangePassword()
        {
            InitializeComponent();
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

        private void buttonRounded2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmForgotPassword login = new frmForgotPassword();
            login.ShowDialog();
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

            if (txtTK.Text.Length == 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Thông báo", "Vui lòng nhập tài khoản", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                txtTK.Focus();
                return;
            }
            if (txtPassOld.Text.Length == 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Thông báo", "Vui lòng nhập mật khẩu cũ", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                txtPassOld.Focus();
                return;
            }
            if (txtPassNew.Text.Length == 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Thông báo", "Vui lòng nhập mật khẩu mới", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                txtPassNew.Focus();
                return;
            }
            var item = from taikhoan in taiKhoan.GetListTaiKhoan()
                       join nhanvien in nhanVien.getAllDSNhanVien() on taikhoan.MaNV equals nhanvien.MaNV
                       select new
                       {
                           taiKhoan = taikhoan.TaiKhoan,
                           matKhau = taikhoan.MatKhau,
                           tinhTrang = taikhoan.TinhTrang,
                           maNV = nhanvien.MaNV,
                           tenNV = nhanvien.TenNV,
                           gioiTinh = nhanvien.GioiTinh,
                           xuly = nhanvien.XuLy
                       };
            bool check = false;
            foreach (var it in item)
            {
                if (it.taiKhoan.Equals(txtTK.Text))
                {
                    check = true;
                    if (it.tinhTrang == 1)
                    {
                        MessageBoxDialog message = new MessageBoxDialog();
                        message.ShowDialog("Thông báo", "Thông báo", "Tài khoản đã bị khóa vui lòng liên hệ admin", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                        txtTK.Focus();
                        return;
                    }
                    else
                    {
                        if (it.xuly == 1)
                        {
                            MessageBoxDialog message = new MessageBoxDialog();
                            message.ShowDialog("Thông báo", "Thông báo", "Nhân viên sử dụng tài khoản này đã nghỉ việc", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                            txtTK.Focus();
                            return;
                        }
                        else
                        {
                            string pass = GetHash(txtPassOld.Text);
                            if (pass.Equals(it.matKhau))
                            {
                                if(txtPassNew.Text.Equals(txtPassOld.Text))
                                {
                                    MessageBoxDialog message = new MessageBoxDialog();
                                    message.ShowDialog("Thông báo", "Thông báo", "Mật khẩu mới phải khác mật khẩu cũ", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                                    txtPassNew.Focus();
                                    return;
                                } else
                                {
                                    string matKhau = GetHash(txtPassNew.Text);
                                    try
                                    {
                                        taiKhoan.SuaMatKhau(txtTK.Text, matKhau);
                                        MessageBoxDialog message = new MessageBoxDialog();
                                        message.ShowDialog("Thông báo", "Thành công", "Đổi mật khẩu thành công vui lòng đăng nhập", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                                        this.Hide();
                                        frmLogin lg = new frmLogin();
                                        lg.ShowDialog();
                                        this.Close();
                                    }
                                    catch(Exception ex) {
                                        MessageBoxDialog message = new MessageBoxDialog();
                                        message.ShowDialog("Thông báo", "Thông báo", "Đổi mật khẩu không thành công vui lòng thử lại", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                MessageBoxDialog message = new MessageBoxDialog();
                                message.ShowDialog("Thông báo", "Thông báo", "Sai mật khẩu cũ", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                                txtPassOld.Focus();
                                return;
                            }
                        }
                    }
                }
                if (check)
                {
                    break;
                }
            }
            if (!check)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Thông báo", "Tài khoản không tồn tại", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                txtTK.Focus();
                return;
            }
        }
        public static string GetHash(string matKhau)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(matKhau));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
        bool checkPassOld = true;
        bool checkPassNew = true;
        private void buttonRounded3_Click(object sender, EventArgs e)
        {
            if(checkPassOld)
            {
                txtPassOld.UseSystemPasswordChar = false;
                checkPassOld = false;
            } else
            {
                txtPassOld.UseSystemPasswordChar = true;
                checkPassOld = true;
            }
        }

        private void buttonRounded4_Click(object sender, EventArgs e)
        {
            if (checkPassNew)
            {
                txtPassNew.UseSystemPasswordChar = false;
                checkPassNew = false;
            }
            else
            {
                txtPassNew.UseSystemPasswordChar = true;
                checkPassNew = true;
            }
        }
    }
}
