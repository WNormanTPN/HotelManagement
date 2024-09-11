using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmLoading : Form
    {
        public frmLoading()
        {
            InitializeComponent();
            this.label1.Parent = pictureBox1;
            this.label1.BackColor = Color.Transparent;
            this.label2.Parent = pictureBox1;
            this.label2.BackColor = Color.Transparent;
            this.label3.Parent = pictureBox1;
            this.label3.BackColor = Color.Transparent;
            this.label3.Visible = false;
            timerRun.Start();
        }

        private void timerRun_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 100)
            {
                label2.Text = "Tải tài nguyên hoàn tất";
                timerRun.Stop();
                label3.Visible = true;
                pictureBox1.Click += PictureBox1_Click;
            }
            else
            {
                progressBar1.Value++;
                label2.Text = "Đang tải tài nguyên..." + progressBar1.Value.ToString() + "%";
                if (progressBar1.Value > 20)
                {
                    pictureBox1.Image = Properties.Resources.abc;
                }
                if (progressBar1.Value > 40)
                {
                    pictureBox1.Image = Properties.Resources.background1;
                } 
                if(progressBar1.Value > 60)
                {
                    pictureBox1.Image = Properties.Resources.bbb;
                }
                if(progressBar1.Value > 80)
                {
                    pictureBox1.Image = Properties.Resources.aaa;
                    label1.ForeColor = Color.White;
                    label2.ForeColor = Color.White;
                }
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin lg = new frmLogin();
            lg.ShowDialog();
            this.Close();
        }

        private void frmLoading_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }
    }
}
