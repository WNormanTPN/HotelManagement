using BUS;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.GUI_CUSTOMER
{
    public partial class frmSearchCustomer : Form
    {
        List<KhachHangDTO> list;
        public KhachHangDTO khachHang;
        public frmSearchCustomer(List<KhachHangDTO> list)
        {
            khachHang = new KhachHangDTO();
            this.list = list;
            InitializeComponent();
            HienThiDSKhachHang(list);
            this.DialogResult = DialogResult.Cancel;
        }
        public void HienThiDSKhachHang(List<KhachHangDTO> list)
        {
            tbKH.Rows.Clear();
            int stt = 0;
            foreach (KhachHangDTO x in list)
            {
                string gioiTinh = "";
                if (x.GioiTinh == 0)
                {
                    gioiTinh = "Nam";
                }
                else
                {
                    gioiTinh = "Nữ";
                }
                tbKH.Rows.Add(++stt, x.MaKH, x.TenKH, gioiTinh, x.CMND, x.SDT, x.QueQuan, x.QuocTich, x.NgaySinh.ToString("dd/MM/yyyy"));
            }
            tbKH.ClearSelection();
        }

        private void tbKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            khachHang = new KhachHangDTO();
            Array arr = list.ToArray();
            khachHang = (KhachHangDTO)arr.GetValue(tbKH.SelectedRows[0].Index);
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void frmSearchCustomer_Load(object sender, EventArgs e)
        {
            tbKH.ClearSelection();
        }

        private void frmSearchCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }
    }
}
