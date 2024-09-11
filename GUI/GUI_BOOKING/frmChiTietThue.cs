using BUS;
using DTO;
using Org.BouncyCastle.Asn1.Cms;
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
    public partial class frmChiTietThue : Form
    {
        ChiTietThueBUS cttBus = new ChiTietThueBUS();
        KhachHangBUS khachHang = new KhachHangBUS();
        NhanVienBUS nhanVien = new NhanVienBUS();
        #region Màu sắc
        Color pnClicked = Color.Lavender;
        Color pnBorder = Color.CornflowerBlue;
        Color white = Color.White;
        #endregion
        public frmChiTietThue(int option, string maCTT)
        {
            InitializeComponent();
            HienThiMaCTT();
            if (option == 0)
            {                
                for (int i = 0; i < cbMaCTT.Items.Count; i++)
                {
                    if (cbMaCTT.Items[i].ToString().Contains(maCTT))
                    {
                        cbMaCTT.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                panel7.Visible = false;
                panel9.Visible = false;
                for (int i = 0; i < cbMaCTT.Items.Count; i++)
                {
                    if (cbMaCTT.Items[i].ToString().Contains(maCTT))
                    {
                        cbMaCTT.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void pnALL_Click(object sender, EventArgs e)
        {
            ResetBackAndBorder();
            pnALL.BackColor = pnClicked;
            panel5.BackColor = pnBorder;
            HienThiALL();
        }

        private void pnROOM_Click(object sender, EventArgs e)
        {
            ResetBackAndBorder();
            pnROOM.BackColor = pnClicked;
            panel7.BackColor = pnBorder;
            HienThiROOM();
        }

        private void pnSERVICE_Click(object sender, EventArgs e)
        {
            ResetBackAndBorder();
            pnSERVICE.BackColor = pnClicked;
            panel9.BackColor = pnBorder;
            HienThiSERVICE();
        }

        private void ResetBackAndBorder()
        {
            pnALL.BackColor = white;
            panel5.BackColor = white;
            pnROOM.BackColor = white;
            panel7.BackColor = white;
            pnSERVICE.BackColor = white;
            panel9.BackColor = white;
        }
        private void HienThiMaCTT()
        {
            cbMaCTT.Items.Clear();
            List<ChiTietThueDTO> list = cttBus.getDSChiTietThue();
            foreach (ChiTietThueDTO ctt in list)
            {
                cbMaCTT.Items.Add(ctt.MaCTT);
            }
        }

        private void frmChiTietThue_Load(object sender, EventArgs e)
        {
            HienThiALL();
        }

        private void cbMaCTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaCTT.SelectedIndex == -1)
            {
                ResetInformation();
            }
            else
            {
                var info = from ctt in cttBus.getDSChiTietThue()
                           join kh in khachHang.GetDSKH() on ctt.MaKH equals kh.MaKH
                           join nv in nhanVien.getDSNhanVien() on ctt.MaNV equals nv.MaNV
                           where ctt.XuLy == 0
                           select new
                           {
                               maCTT = ctt.MaCTT,
                               tenKH = kh.TenKH,
                               tenNV = nv.TenNV,
                               cMND = kh.CMND,
                               ngayLapPhieu = ctt.NgayLapPhieu.ToString("dd/MM/yyyy HH:mm:ss"),
                               sDT = kh.SDT,
                               tienDatCoc = ctt.TienDatCoc.ToString("###,###0 VNĐ"),
                               tinhTrangXuLy = ctt.TinhTrangXuLy
                           };
                foreach (var item in info)
                {
                    if (item.maCTT.Equals(cbMaCTT.SelectedItem.ToString()))
                    {
                        txtTienDatCoc.Text = item.tienDatCoc;
                    txt_CMND.Text = item.cMND;
                    txt_NgayLapPhieu.Text = item.ngayLapPhieu;
                    txt_SDT.Text = item.sDT;
                    txt_TenKH.Text = item.tenKH;
                    txt_TenNV.Text = item.tenNV;
                    if (item.tinhTrangXuLy == 0)
                    {
                        txt_TinhTrang.Text = "Chưa xử lý";
                    } else
                    {
                        txt_TinhTrang.Text = "Đã xử lý";
                    }
                        break;
                    }
                }
                ResetBackAndBorder();
                pnALL.BackColor = pnClicked;
                panel5.BackColor = pnBorder;
                HienThiALL();
            }
        }
        private void HienThiALL()
        {
            pnContent.Controls.Clear();
            if(txt_TinhTrang.Text.Equals("Chưa xử lý"))
            {
                frmChiTietPhieuThue frmCTT = new frmChiTietPhieuThue(cbMaCTT.SelectedItem.ToString(), 0, this);
                frmCTT.TopLevel = false;
                pnContent.Controls.Add(frmCTT);
                frmCTT.Dock = DockStyle.Fill;
                frmCTT.Show();
                panel7.Visible = true;
                panel9.Visible = true;
            } else
            {
                frmChiTietPhieuThue frmCTT = new frmChiTietPhieuThue(cbMaCTT.SelectedItem.ToString(), 1, this);
                frmCTT.TopLevel = false;
                pnContent.Controls.Add(frmCTT);
                frmCTT.Dock = DockStyle.Fill;
                frmCTT.Show();
                panel7.Visible = false;
                panel9.Visible = false;
            } 
        }
        private void HienThiROOM()
        {
            pnContent.Controls.Clear();
            frmChiTietThuePhong frmCTT = new frmChiTietThuePhong(cbMaCTT.SelectedItem.ToString(),this);
            frmCTT.TopLevel = false;
            pnContent.Controls.Add(frmCTT);
            frmCTT.Dock = DockStyle.Fill;
            frmCTT.Show();
        }
        public void renderAll()
        {
            ResetBackAndBorder();
            pnALL.BackColor = pnClicked;
            panel5.BackColor = pnBorder;
            HienThiALL();
        }
        private void HienThiSERVICE()
        {
            pnContent.Controls.Clear();
            frmChiTietThueDichVu frmCTT = new frmChiTietThueDichVu(cbMaCTT.SelectedItem.ToString(), this);
            frmCTT.TopLevel = false;
            pnContent.Controls.Add(frmCTT);
            frmCTT.Dock = DockStyle.Fill;
            frmCTT.Show();
        }
        private void ResetInformation()
        {
            txtTienDatCoc.Text = string.Empty;
            txt_TinhTrang.Text = string.Empty;
            txt_CMND.Text = string.Empty;
            txt_NgayLapPhieu.Text = string.Empty;
            txt_SDT.Text = string.Empty;
            txt_TenKH.Text = string.Empty;
            txt_TenNV.Text = string.Empty;
        }
    }
}
