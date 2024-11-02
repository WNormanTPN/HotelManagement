using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUI.GUI_HOME
{
    public partial class HomeForm : Form
    {
        private Image[] image;
        int indexPic1, indexPic2, indexPic3, indexPic4;
        public HomeForm()
        {
            InitializeComponent();
            image = new Image[] { global::GUI.Properties.Resources.ks,
                                  global::GUI.Properties.Resources.background1,
                                  global::GUI.Properties.Resources.abc,
                                  global::GUI.Properties.Resources.ks2,
                                  global::GUI.Properties.Resources.bbb,
                                  global::GUI.Properties.Resources.aaa,};
            indexPic1 = 0;
            indexPic2 = 1;
            indexPic3 = 2;
            indexPic4 = 3;
        }
        private void LoadImage()
        {
            this.pictureBox1.Image = image[indexPic1];
            indexPic1++;
            if(indexPic1 > 5)
            {
                indexPic1 = 0;
            }
            this.pictureBox2.Image = image[indexPic2];
            indexPic2++;
            if (indexPic2 > 5)
            {
                indexPic2 = 0;
            }
            this.pictureBox3.Image = image[indexPic3];
            indexPic3++;
            if (indexPic3 > 5)
            {
                indexPic3 = 0;
            }
            this.pictureBox4.Image = image[indexPic4];
            indexPic4++;
            if (indexPic4 > 5)
            {
                indexPic4 = 0;
            }
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            ChangeImage.Start();
        }

        private void ChangeImage_Tick(object sender, EventArgs e)
        {
            LoadImage();
        }
    }
}
