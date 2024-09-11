using BUS;
using GUI.GUI_COMPONENT;
using Org.BouncyCastle.Asn1.X509;
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
using static GUI.GUI_BOOKING.rpThongTinPhieuThue;

namespace GUI.GUI_BOOKING
{
    public partial class frmChiTietThueDichVu : Form
    {
        string maCTT;
        frmChiTietThue frmCTT;
        public frmChiTietThueDichVu(string maCTT, frmChiTietThue frmCTT)
        {
            this.maCTT = maCTT;
            this.frmCTT = frmCTT;
            InitializeComponent();
        }
        DichVuBUS dichvu = new DichVuBUS();
        private void frmChiTietThueDichVu_Load(object sender, EventArgs e)
        {
            ListDichVu();
            this.dtgvChiTiet.Columns[0].ReadOnly = true;
            this.dtgvChiTiet.Columns[1].ReadOnly = true;
            this.dtgvChiTiet.Columns[2].ReadOnly = true;
            this.dtgvChiTiet.Columns[3].ReadOnly = true;
            this.dtgvChiTiet.Columns[4].ReadOnly = true;
            this.dtgvChiTiet.Columns[5].ReadOnly = true;
            this.dtgvChiTiet.Columns[6].ReadOnly = true;
            this.dtgvChiTiet.Columns[7].ReadOnly = true;
            this.dtgvChiTiet.Columns[8].ReadOnly = true;
            dtgvChiTiet.ClearSelection();

        }
        private void ListDichVu()
        {
            flpMain.Controls.Clear();
            DataTable dt = new DataTable();
            dt = dichvu.getListDichVuCTPhieuThue(textBox1.Text.Trim(), comboBox1.Text.Trim());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Panel pn = new Panel();
                pn.BackColor = Color.White;
                pn.Size = new System.Drawing.Size(187, 180);
                pn.AutoScroll = false;
                pn.BorderStyle = BorderStyle.FixedSingle;

                PictureBox img = new PictureBox();
                img.Size = new System.Drawing.Size(100, 100);
                img.Location = new Point(40, 7);
                string stringImg = dt.Rows[i]["hinhAnh"].ToString();

                if (stringImg != "")
                {
                    img.Image = ConvertStringtoImage(stringImg);
                }
                else
                {
                    img.BackColor = Color.FromArgb(224, 224, 224);
                }
                img.SizeMode = PictureBoxSizeMode.StretchImage;

                Label labelcode = new Label();
                labelcode.Location = new Point(0, 0);
                labelcode.Text = dt.Rows[i]["madv"].ToString();
                labelcode.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelcode.AutoSize = true;
                labelcode.Visible = false;

                Label labelname = new Label();
                labelname.Location = new Point(3, 120);
                labelname.Text = "Tên dịch vụ :";
                labelname.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelname.AutoSize = true;

                Label labelnamevalue = new Label();
                labelnamevalue.Location = new Point(90, 120);
                labelnamevalue.Text = dt.Rows[i]["tendv"].ToString();
                labelnamevalue.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelnamevalue.AutoSize = true;

                Label labeltype = new Label();
                labeltype.Location = new Point(3, 140);
                labeltype.Text = "Loại dịch vụ :";
                labeltype.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labeltype.AutoSize = true;

                Label labeltypevalue = new Label();
                labeltypevalue.Location = new Point(90, 140);
                labeltypevalue.Text = dt.Rows[i]["loaidv"].ToString();
                labeltypevalue.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labeltypevalue.AutoSize = true;

                Label labelprice = new Label();
                labelprice.Location = new Point(3, 160);
                labelprice.Text = "Giá dịch vụ :";
                labelprice.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelprice.AutoSize = true;

                Label labelpricevalue = new Label();
                labelpricevalue.Location = new Point(90, 160);
                labelpricevalue.Text = dt.Rows[i]["giadv"].ToString();
                labelpricevalue.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelpricevalue.AutoSize = true;
                labelpricevalue.ForeColor = Color.Red;

                pn.Controls.Add(img);
                pn.Controls.Add(labelname);
                pn.Controls.Add(labeltype);
                pn.Controls.Add(labelprice);
                pn.Controls.Add(labelnamevalue);
                pn.Controls.Add(labeltypevalue);
                pn.Controls.Add(labelpricevalue);
                pn.Controls.Add(labelcode);
                pn.DoubleClick += new EventHandler((sender, e) => ClickDichVu(sender, e, labelcode.Text, labelnamevalue.Text, labelpricevalue.Text));
                img.DoubleClick += new EventHandler((sender, e) => ClickDichVu(sender, e, labelcode.Text, labelnamevalue.Text, labelpricevalue.Text));
                flpMain.Controls.Add(pn);
            }
        }
        public System.Drawing.Image ConvertStringtoImage(string commands)
        {
            byte[] photoarray = Convert.FromBase64String(commands);
            MemoryStream ms = new MemoryStream(photoarray, 0, photoarray.Length);
            ms.Write(photoarray, 0, photoarray.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ListDichVu();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListDichVu();
        }
        private void ClickDichVu(object sender, EventArgs e, string madv, string tendv, string giadv)
        {
            int i = 0;
            var j = 0;
            foreach (DataGridViewRow dr in dtgvChiTiet.Rows)
            {
                string col1 = dr.Cells[1].Value.ToString();
                if (col1 == madv)
                {
                    j = dr.Index;
                    i = 1;
                    break;
                }
            }

            if (i == 1)
            {
                dtgvChiTiet.Rows[j].Cells[4].Value = int.Parse(dtgvChiTiet.Rows[j].Cells[4].Value.ToString()) + 1;
                decimal dg = decimal.Parse(dtgvChiTiet.Rows[j].Cells[5].Value.ToString());
                decimal sl = decimal.Parse(dtgvChiTiet.Rows[j].Cells[4].Value.ToString());
                dtgvChiTiet.Rows[j].Cells[6].Value = dg * sl;
            }
            else
            {
                int STT = dtgvChiTiet.Rows.Count + 1;
                string ngaydv = DateTime.Now.ToString("dd/MM/yyyy");
                string soluong = "1";
                dtgvChiTiet.Rows.Add(new object[] { STT, madv, tendv, ngaydv, soluong, giadv, giadv });
            }
        }
        private void dtgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = this.dtgvChiTiet.Columns[e.ColumnIndex].Name;
            if (columnName == "Edit")
            {
                formInput frmInput = new formInput();
                frmInput.ShowDialog();
                if (frmInput.DialogResult == DialogResult.Yes)
                {
                    int soLuong = frmInput.number;
                    decimal dg = decimal.Parse(dtgvChiTiet.Rows[e.RowIndex].Cells[5].Value.ToString());
                    dtgvChiTiet.Rows[e.RowIndex].Cells[4].Value = soLuong;
                    dtgvChiTiet.Rows[e.RowIndex].Cells[6].Value = dg * soLuong;
                    MessageBoxDialog messageError = new MessageBoxDialog();
                    messageError.ShowDialog("Thông báo", "Thông báo", "Sửa dịch vụ này thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                }
                else
                {
                    dtgvChiTiet.ClearSelection();
                }
            }
            if (columnName == "Delete")
            {
                DialogResult dr = MessageBox.Show("Có chắc xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dtgvChiTiet.SelectedRows)
                    {
                        dtgvChiTiet.Rows.RemoveAt(item.Index);
                    }
                    int index = 0;
                    for (int i = 0; i < dtgvChiTiet.Rows.Count; i++)
                    {
                        dtgvChiTiet.Rows[i].Cells[0].Value = ++index;
                    }
                }
                else
                    return;
            }
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox1.Text.Trim().Equals("Nhập Mã/Tên dịch vụ cần tìm"))
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                textBox1.Text = "Nhập Mã/Tên dịch vụ cần tìm";
            }
            ActiveControl = null;
        }

        private void buttonRounded2_Click(object sender, EventArgs e)
        {
            if (dtgvChiTiet.Rows.Count == 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Thông báo", "Vui lòng chọn dịch vụ thuê cho khách", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                return;
            }
            for (int i = 0; i < dtgvChiTiet.Rows.Count; i++)
            {
                string maDV = dtgvChiTiet.Rows[i].Cells[1].Value.ToString();
                string ngaySuDung = DateTime.ParseExact(dtgvChiTiet.Rows[i].Cells[3].Value.ToString().Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                string soLuong = dtgvChiTiet.Rows[i].Cells[4].Value.ToString();
                string giaDV = dtgvChiTiet.Rows[i].Cells[5].Value.ToString();
                try
                {
                    ChiTietThueDichVuBUS cttDV = new ChiTietThueDichVuBUS();
                    cttDV.ThemCTTDV(maCTT, maDV, ngaySuDung, soLuong, giaDV);
                }
                catch (Exception)
                {
                    ChiTietThueDichVuBUS cttDV = new ChiTietThueDichVuBUS();
                    cttDV.SuaSoLuong(maCTT, maDV, ngaySuDung, soLuong);
                }
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Thông báo", "Thêm dịch vụ thuê cho khách thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                frmCTT.renderAll();
            }
        }
    }
}
