using BUS;
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

namespace GUI.GUI_ROLE
{
    public partial class FormAddNewRole : Form
    {
        public FormAddNewRole()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            textBox1.MaxLength = 50;
        }

        private void buttonRounded2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormAddNewRole_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void buttonRounded1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim().Length == 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Thông báo", "Vui lòng nhập tên vị trí muốn thêm", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                return;
            }
            PhanQuyenBUS pq = new PhanQuyenBUS();
            pq.ThemPhanQuyen("PQ" + pq.GetCountPQ().ToString("D2"), textBox1.Text.Trim());
            this.DialogResult = DialogResult.Yes;
        }
    }
}
