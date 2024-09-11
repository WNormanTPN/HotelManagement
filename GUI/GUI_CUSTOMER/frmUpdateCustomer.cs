using BUS;
using DTO;
using GUI.GUI_COMPONENT;
using Org.BouncyCastle.Asn1.X500;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GUI.GUI_BOOKING.rpThongTinPhieuThue;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI.GUI_CUSTOMER
{
    public partial class frmUpdateCustomer : Form
    {
        KhachHangBUS kh = new KhachHangBUS();
        public frmUpdateCustomer(string maKH)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            txtCMND.MaxLength = 12;
            KhachHangDTO khTmp = new KhachHangDTO();
            foreach(KhachHangDTO x in kh.GetDSKH())
            {
                if(x.MaKH.Equals(maKH))
                {
                    khTmp = x;
                    break;
                }
            }
            lbMaKH.Text = khTmp.MaKH;
            txtTenKH.Text = khTmp.TenKH;
            txtCMND.Text = khTmp.CMND;
            txtSDT.Text = khTmp.SDT;
            dateNgaySinh.Value = khTmp.NgaySinh;
            if(khTmp.GioiTinh == 0)
            {
                radioButton1.Checked = true;
            } else
            {
                radioButton2.Checked = true;
            }
            txtDuong.Text = khTmp.QueQuan.Split(',')[0];
            txtPhuong.Text = khTmp.QueQuan.Split(',')[1];
            txtQuan.Text = khTmp.QueQuan.Split(',')[2];
            txtThanhPho.Text = khTmp.QueQuan.Split(',')[3];
            txtQuocTich.Text = khTmp.QuocTich;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        int Years(DateTime start, DateTime end)
        {
            return (end.Year - start.Year - 1) +
                (((end.Month > start.Month) ||
                ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
        }
        private bool IsValidPhone(string phone)
        {
            phone = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            return phone.Length == 10 && phone.All(char.IsDigit);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBoxDialog message = new MessageBoxDialog();
            int ans = message.ShowDialog("Thông báo", "Thông báo", "Bạn có muốn thay đổi thông tin khách hàng này không?", MessageBoxDialog.WARNING, MessageBoxDialog.YES_NO, "Đúng vậy", "Không", "");
            if (ans == MessageBoxDialog.YES_OPTION)
            {
                if (txtCMND.Text.Trim().Length == 0)
                {
                    lbErrorCMND.Visible = true;
                }
                if (txtTenKH.Text.Trim().Length == 0)
                {
                    lbErrorTenKH.Visible = true;
                }
                if (Years(dateNgaySinh.Value, DateTime.Now) >= 18)
                {
                    lbErrorNgaySinh.Visible = false;
                }
                else
                {
                    lbErrorNgaySinh.Visible = true;
                }
                string textSDT = txtSDT.Text;
                bool valid = IsValidPhone(textSDT);
                if (!valid)
                {
                    lbErrorSDT.Visible = true;
                }
                if (txtDuong.Text.Trim().Length == 0
                && txtPhuong.Text.Trim().Length == 0
                && txtQuan.Text.Trim().Length == 0
                && txtThanhPho.Text.Trim().Length == 0)
                {
                    lbErrorDiaChi.Visible = true;
                }
                else
                {
                    lbErrorDiaChi.Visible = false;
                }
                if (txtQuocTich.Text.Trim().Length == 0)
                {
                    lbErrorQuocTich.Visible = true;
                }
                if (lbErrorCMND.Visible ||
                    lbErrorDiaChi.Visible ||
                    lbErrorNgaySinh.Visible ||
                    lbErrorQuocTich.Visible ||
                    lbErrorSDT.Visible ||
                    lbErrorTenKH.Visible)
                {
                    MessageBoxDialog messageError = new MessageBoxDialog();
                    messageError.ShowDialog("Thông báo", "Thông báo lỗi chưa nhập dữ liệu", "Vui lòng nhập dữ liệu phiếu thuê", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                }
                if (!lbErrorCMND.Visible &&
                    !lbErrorDiaChi.Visible &&
                    !lbErrorNgaySinh.Visible &&
                    !lbErrorQuocTich.Visible &&
                    !lbErrorSDT.Visible &&
                    !lbErrorTenKH.Visible)
                {
                    KhachHangBUS kh = new KhachHangBUS();
                    string maKH = lbMaKH.Text.Trim();
                    string tenKH = txtTenKH.Text.Trim();
                    string CMND = txtCMND.Text.Trim();
                    string SDT = txtSDT.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                    string gioiTinh = radioButton1.Checked ? "0" : "1";
                    string diaChi = txtDuong.Text.Trim() + "," + txtPhuong.Text.Trim() + "," + txtQuan.Text.Trim() + "," + txtThanhPho.Text.Trim();
                    string quocTich = txtQuocTich.Text.Trim();
                    kh.UpdateKhachHang(maKH,tenKH,CMND, gioiTinh,SDT, diaChi, quocTich, dateNgaySinh.Value.ToString("yyyy-MM-dd"));
                    MessageBoxDialog messageSuccess = new MessageBoxDialog();
                    messageSuccess.ShowDialog("Thông báo", "Thành công", "Sửa thông tin khách hàng thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                    DialogResult = DialogResult.Yes;
                    this.Close();
                }
            }
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            if (txtTenKH.Text.Trim().Length == 0)
            {
                lbErrorTenKH.Visible = true;
            }
            else
            {
                lbErrorTenKH.Visible = false;
            }
        }

        private void txtCMND_TextChanged(object sender, EventArgs e)
        {
            if (txtCMND.Text.Trim().Length == 0)
            {
                lbErrorCMND.Visible = true;
            }
            else
            {
                lbErrorCMND.Visible = false;
            }
        }

        private void txtDuong_TextChanged(object sender, EventArgs e)
        {
            if (txtDuong.Text.Trim().Length == 0
                && txtPhuong.Text.Trim().Length == 0
                && txtQuan.Text.Trim().Length == 0
                && txtThanhPho.Text.Trim().Length == 0)
            {
                lbErrorDiaChi.Visible = true;
            }
            else
            {
                lbErrorDiaChi.Visible = false;
            }
        }

        private void txtQuocTich_TextChanged(object sender, EventArgs e)
        {
            if (txtQuocTich.Text.Trim().Length == 0)
            {
                lbErrorQuocTich.Visible = true;
            }
            else
            {
                lbErrorQuocTich.Visible = false;
            }
        }

        private void dateNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            if (Years(dateNgaySinh.Value, DateTime.Now) >= 16)
            {
                lbErrorNgaySinh.Visible = false;
            }
            else
            {
                lbErrorNgaySinh.Visible = true;
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            string textSDT = txtSDT.Text;
            bool valid = IsValidPhone(textSDT);
            if (valid)
            {
                lbErrorSDT.Visible = false;
            }
            else
            {
                lbErrorSDT.Visible = true;
            }
        }
    }
}
