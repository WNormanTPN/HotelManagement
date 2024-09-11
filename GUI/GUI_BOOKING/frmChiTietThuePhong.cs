using BUS;
using DTO;
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
using static System.Net.WebRequestMethods;

namespace GUI.GUI_BOOKING
{
    public partial class frmChiTietThuePhong : Form
    {
        DataTable dt;
        ChiTietThuePhongBUS cttp = new ChiTietThuePhongBUS();
        string maCTT;
        frmChiTietThue frmCTT;
        public frmChiTietThuePhong(string maCTT, frmChiTietThue frmCTT)
        {
            this.frmCTT = frmCTT;
            dt = new DataTable();
            dt.Columns.Add("MaP");
            dt.Columns.Add("TenP");
            dt.Columns.Add("TinhTrang");
            dt.Columns.Add("LoaiHinhThue");
            dt.Columns.Add("NgayThue");
            dt.Columns.Add("NgayTra");
            dt.Columns.Add("NgayCheckOut");
            dt.Columns.Add("GiaThuc");
            InitializeComponent();
            this.maCTT = maCTT;
        }

        private void btnSelectRoom_Click(object sender, EventArgs e)
        {
            frmSelectRoom frm = new frmSelectRoom(dt);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                PhongDTO phong = (PhongDTO)frm.arr[0];
                try
                {
                    dt.Rows.Add(phong.MaP, phong.TenP, "Đang xử lý", frm.arr[1], DateTime.Parse(frm.arr[2].ToString()), DateTime.Parse(frm.arr[3].ToString()), "", int.Parse(frm.arr[4].ToString()));
                }
                catch (Exception)
                {
                    dt.Rows.Add(phong.MaP, phong.TenP, "Đang xử lý", frm.arr[1], DateTime.Parse(frm.arr[2].ToString()), frm.arr[3].ToString(), "", int.Parse(frm.arr[4].ToString()));
                }
                HienThiDanhSachPhongThue();
            }
        }
        private void HienThiDanhSachPhongThue()
        {
            tbRoom.Rows.Clear();
            int stt = 0;
            int total = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    tbRoom.Rows.Add(++stt, dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), DateTime.Parse(dt.Rows[i][4].ToString()).ToString("dd/MM/yyyy HH:mm:ss"), DateTime.Parse(dt.Rows[i][5].ToString()).ToString("dd/MM/yyyy HH:mm:ss"), dt.Rows[i][6].ToString(), int.Parse(dt.Rows[i][7].ToString()).ToString("###,###0 VNĐ"));
                }
                catch (Exception)
                {
                    tbRoom.Rows.Add(stt, dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), DateTime.Parse(dt.Rows[i][4].ToString()).ToString("dd/MM/yyyy HH:mm:ss"), dt.Rows[i][5].ToString(), dt.Rows[i][6].ToString(), "Chưa tính");
                }
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!dt.Rows[i][3].ToString().ToUpper().Equals("KHÁC"))
                {
                    total += int.Parse(dt.Rows[i][7].ToString());
                }
            }
            tbRoom.ClearSelection();
        }

        private void tbRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = 9;
            if (e.ColumnIndex == index && e.RowIndex >= 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                int ans = message.ShowDialog("Thông báo", "Cảnh báo", "Bạn có muốn xóa phòng thuê này", MessageBoxDialog.WARNING, MessageBoxDialog.YES_NO, "Đồng ý", "Không đồng ý", "");
                if (ans == MessageBoxDialog.YES_OPTION)
                {
                    dt.Rows.RemoveAt(e.RowIndex);
                    HienThiDanhSachPhongThue();
                }
                else
                {
                    tbRoom.ClearSelection();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][3].ToString().ToUpper().Equals("THEO NGÀY"))
                    cttp.InsertCTTP(true, maCTT.Trim(), dt.Rows[i][0].ToString().Trim(), DateTime.Parse(dt.Rows[i][4].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Parse(dt.Rows[i][5].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"), "0", dt.Rows[i][7].ToString());
                else if (dt.Rows[i][3].ToString().ToUpper().Equals("THEO GIỜ"))
                    cttp.InsertCTTP(true, maCTT.Trim(), dt.Rows[i][0].ToString().Trim(), DateTime.Parse(dt.Rows[i][4].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Parse(dt.Rows[i][5].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"), "1", dt.Rows[i][7].ToString());
                else
                    cttp.InsertCTTP(false, maCTT.Trim(), dt.Rows[i][0].ToString().Trim(), DateTime.Parse(dt.Rows[i][4].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Parse(dt.Rows[i][4].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"), "2", dt.Rows[i][7].ToString());
            }
            MessageBoxDialog message = new MessageBoxDialog();
            message.ShowDialog("Thông báo", "Thành công", "Thêm phòng mới cho phiếu thuê này thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
            frmCTT.renderAll();
        }

        private void tbRoom_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < tbRoom.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    tbRoom.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
                }
                else
                {
                    tbRoom.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
        
    }
}
