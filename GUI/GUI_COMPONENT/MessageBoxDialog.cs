using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.GUI_COMPONENT
{
    public partial class MessageBoxDialog : Form
    {
        public static int SUCCESS = 1;
        public static int ERROR = 2;
        public static int WARNING = 3;
        public static int INFO = 4;
        public static int YES = 1;
        public static int YES_NO = 2;
        public static int YES_NO_CANCEL = 3;
        public static int YES_OPTION = 1;
        public static int NO_OPTION = 2;
        public static int CANCEL_OPTION = 3;
        private int _result = 3;
        public MessageBoxDialog()
        {
        }

        public int ShowDialog(String titleTop, String title, String content, int type, int button, String btnYes, String btnNo, String btnCancel)
        {
            InitializeComponent();
            timerOpacity.Start();
            Title.Text = titleTop;
            lbTitle.Text = title;
            lbContent.Text = content;
            this.btnYes.Text = btnYes;
            this.btnNo.Text = btnNo;
            this.btnCancel.Text = btnCancel;
            switch (type)
            {
                case 1:
                    Icon.Image = Properties.Resources.icons8_checkmark_70px; break;
                case 2:
                    Icon.Image = Properties.Resources.icons8_cancel_70px; break;
                case 3:
                    Icon.Image = Properties.Resources.icons8_warning_shield_70px; break;
                default:
                    Icon.Image = Properties.Resources.icons8_info_70px; break;
            }
            switch (button)
            {
                case 1:
                    pnButton.Controls.Remove(this.btnNo);
                    pnButton.Controls.Remove(this.btnCancel);
                    pnButton.Controls.Add(this.btnYes, 2, 0);
                    break;
                case 2:
                    pnButton.Controls.Remove(this.btnCancel);
                    pnButton.Controls.Add(this.btnYes, 1, 0);
                    pnButton.Controls.Add(this.btnNo, 2, 0);
                    break;
                default:
                    pnButton.Controls.Add(this.btnCancel, 2, 0);
                    pnButton.Controls.Add(this.btnYes, 0, 0);
                    pnButton.Controls.Add(this.btnNo, 1, 0);
                    break;
            }
            ShowDialog();
            return this._result;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _result = 3;
            this.Close();
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
        private void pnTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                this.Location = mousePos;
            }
        }

        private void pnTop_MouseDown(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;
            mouseOffset = new Point(-mouseX, -mouseY);
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            _result = YES_OPTION;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            _result = NO_OPTION;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _result = CANCEL_OPTION;
            this.Close();
        }

        private void timerOpacity_Tick(object sender, EventArgs e)
        {
            if(Opacity >= 1)
            {
                timerOpacity.Stop();
            } else
            {
                Opacity += 0.03;
            }
            if(p.Y <= 278)
            {
                Location = p;
                p.Y += 2;
            }
        }
        Point p;
        private void MessageBoxDialog_Load(object sender, EventArgs e)
        {
            p = new Point(Location.X, 250);
        }
    }
}
