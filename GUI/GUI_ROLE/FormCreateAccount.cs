using BUS;
using DTO;
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

namespace GUI.GUI_ROLE
{
    public partial class FormCreateAccount : Form
    {
        string maNV;
        int option = 0;
        public FormCreateAccount(string maNV)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            textBox1.MaxLength = 20;
            HienThiDataPQ();
            this.maNV = maNV;
        }
        public FormCreateAccount(string tenTK, int option)
        {
            this.option = option;
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            textBox1.MaxLength = 20;
            HienThiDataPQ();
            textBox1.ReadOnly = true;
            textBox1.Text = tenTK;
            buttonRounded1.Text = "Đổi phân quyền";
            TaiKhoanBUS tkBus = new TaiKhoanBUS();
            TaiKhoanDTO taiKhoanDTO = tkBus.GetTK(tenTK);
            comboBox1.SelectedValue = taiKhoanDTO.MaPQ;
            label1.Text = "XEM PHÂN QUYỀN";
        }

        private void buttonRounded2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCreateAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void HienThiDataPQ()
        {
            PhanQuyenBUS pq = new PhanQuyenBUS();
            DataTable dt = pq.GetListPQ();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "TenPQ";
            comboBox1.ValueMember = "MaPQ";
        }

        private void buttonRounded1_Click(object sender, EventArgs e)
        {
            if(option == 0)
            {
                if (textBox1.Text.Trim().Length == 0)
                {
                    MessageBoxDialog message = new MessageBoxDialog();
                    message.ShowDialog("Thông báo", "Thông báo", "Vui lòng nhập tên tài khoản", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                    textBox1.Focus();
                    return;
                }
                NhanVienBUS nhanVienBus = new NhanVienBUS();
                NhanVienDTO nhanVien = nhanVienBus.GetNV(maNV);
                TaiKhoanBUS taiKhoan = new TaiKhoanBUS();
                try
                {
                    taiKhoan.ThemTaiKhoan(textBox1.Text.Trim(), maNV, comboBox1.SelectedValue.ToString(), frmChangePassword.GetHash(nhanVien.NgaySinh.ToString("ddMMyyyy")), "0");
                    this.DialogResult = DialogResult.Yes;
                }
                catch(Exception)
                {
                    MessageBoxDialog message = new MessageBoxDialog();
                    message.ShowDialog("Thông báo", "Thông báo", "Tên tài khoản đã được sử dụng vui lòng nhập tài khoản khác", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                    textBox1.Focus();
                    return;
                }
            } else
            {
                MessageBoxDialog message = new MessageBoxDialog();
                int ans = message.ShowDialog("Thông báo", "Thông báo", "Bạn có chắc muốn đổi phân quyền cho tài khoản này không", MessageBoxDialog.INFO, MessageBoxDialog.YES_NO, "Chắc chắn", "Hủy","");
                if(ans == MessageBoxDialog.YES_OPTION)
                {
                    TaiKhoanBUS taiKhoan = new TaiKhoanBUS();
                    taiKhoan.SuaPhanQuyen(textBox1.Text.Trim(), comboBox1.SelectedValue.ToString());
                    this.DialogResult = DialogResult.Yes;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = (int)e.KeyChar;
            if (!(ascii >= 65 && ascii <= 90) && !(ascii >= 97 && ascii <= 122))
            {
                e.Handled = true;
            }
        }
        public string GetHash(string matKhau)
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
    }
}
