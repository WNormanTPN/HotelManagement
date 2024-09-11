using GUI.GUI_COMPONENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.GUI_BOOKING
{
    public partial class formInput : Form
    {
        public int number;
        public formInput()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void formInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if(txtSoLuong.Text.Trim().Length != 0)
            {
                number = int.Parse(txtSoLuong.Text.Trim());
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            else
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Thông báo", "Vui lòng nhập số lượng cần thay đổi", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
