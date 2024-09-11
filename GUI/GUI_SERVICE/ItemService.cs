using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.GUI_SERVICE
{
    public partial class ItemService : Form
    {
        DichVuDTO dichVu;
        public ItemService(DichVuDTO dichVu)
        {
            InitializeComponent();
            this.dichVu = dichVu;
        }

        private void itemService_MouseEnter(object sender, EventArgs e)
        {
            pnContainer.BackColor = Color.Green;
            pnContent.BackColor = Color.PaleGreen;
        }

        private void itemService_MouseLeave(object sender, EventArgs e)
        {
            pnContent.BackColor = Color.White;
            pnContainer.BackColor = Color.Gray; 
        }

        private void pnContainer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
        }

        private void ItemService_Load(object sender, EventArgs e)
        {
            System.Drawing.Image img = ConvertStringtoImage(dichVu.HinhAnh);
            imgDichVu.Image = img;
            lbTenDV.Text = dichVu.TenDV;
            lbLoaiDV.Text = dichVu.LoaiDV;
            lbGiaDV.Text = dichVu.GiaDV.ToString("###,###0 VNĐ");
        }
        public System.Drawing.Image ConvertStringtoImage(string commands)
        {
            byte[] photoarray = Convert.FromBase64String(commands);
            MemoryStream ms = new MemoryStream(photoarray, 0, photoarray.Length);
            ms.Write(photoarray, 0, photoarray.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }
    }
}
