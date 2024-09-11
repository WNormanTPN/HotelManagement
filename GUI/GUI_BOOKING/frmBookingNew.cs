using BUS;
using DTO;
using GUI.GUI_COMPONENT;
using GUI.GUI_CUSTOMER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;

namespace GUI.GUI_BOOKING
{
    public partial class frmBookingNew : Form
    {
        KhachHangBUS kh = new KhachHangBUS();
        ChiTietThueBUS ctt = new ChiTietThueBUS();
        ChiTietThuePhongBUS cttp = new ChiTietThuePhongBUS();
        public DataTable dt;
        public frmBookingNew()
        {
            InitializeComponent();
            dt = new DataTable();
            dt.Columns.Add("MaP");
            dt.Columns.Add("TenP");
            dt.Columns.Add("TinhTrang");
            dt.Columns.Add("LoaiHinhThue");
            dt.Columns.Add("NgayThue");
            dt.Columns.Add("NgayTra");
            dt.Columns.Add("NgayCheckOut");
            dt.Columns.Add("GiaThuc");
            txtNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            timerClock.Start();
            txtNhanVien.Text = Program.nhanVien.TenNV;
            HienThiDanhSachPhongThue();
        }

        private void frmBookingNew_Load(object sender, EventArgs e)
        {
            tbRoom.ClearSelection();
            HienThiDanhSachPhongThue();
        }
        private void timerClock_Tick(object sender, EventArgs e)
        {
            txtNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void txtCMND_TextChanged(object sender, EventArgs e)
        {
            txtTenKH.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtDuong.Text = string.Empty;
            txtPhuong.Text = string.Empty;
            txtQuan.Text = string.Empty;
            txtThanhPho.Text = string.Empty;
            txtQuocTich.Text = string.Empty;
            txtMaKH.Text = string.Empty;
            if (txtCMND.Text.Trim().Length >= 9)
            {
                txtTenKH.Enabled = true;
                txtSDT.Enabled = true;
                dateNgaySinh.Enabled = true;
                rdNam.Enabled = true;
                rdNu.Enabled = true;
                txtDuong.Enabled = true;
                txtPhuong.Enabled = true;
                txtQuan.Enabled = true;
                txtThanhPho.Enabled = true;
                txtQuocTich.Enabled = true;

                txtTenKH.BackColor = Color.White;
                txtSDT.BackColor = Color.White;
                dateNgaySinh.BackColor = Color.White;
                rdNam.BackColor = Color.White;
                rdNu.BackColor = Color.White;
                txtDuong.BackColor = Color.White;
                txtPhuong.BackColor = Color.White;
                txtQuan.BackColor = Color.White;
                txtThanhPho.BackColor = Color.White;
                txtQuocTich.BackColor = Color.White;
            }
            else
            {
                txtTenKH.Enabled = false;
                txtSDT.Enabled = false;
                dateNgaySinh.Enabled = false;
                rdNam.Enabled = false;
                rdNu.Enabled = false;
                txtDuong.Enabled = false;
                txtPhuong.Enabled = false;
                txtQuan.Enabled = false;
                txtThanhPho.Enabled = false;
                txtQuocTich.Enabled = false;

                txtTenKH.BackColor = SystemColors.Control;
                txtSDT.BackColor = SystemColors.Control;
                dateNgaySinh.BackColor = SystemColors.Control;
                rdNam.BackColor = SystemColors.Control;
                rdNu.BackColor = SystemColors.Control;
                txtDuong.BackColor = SystemColors.Control;
                txtPhuong.BackColor = SystemColors.Control;
                txtQuan.BackColor = SystemColors.Control;
                txtThanhPho.BackColor = SystemColors.Control;
                txtQuocTich.BackColor = SystemColors.Control;
                txtTenKH.Text = string.Empty;
                txtSDT.Text = string.Empty;
                txtDuong.Text = string.Empty;
                txtPhuong.Text = string.Empty;
                txtQuan.Text = string.Empty;
                txtThanhPho.Text = string.Empty;
                txtQuocTich.Text = string.Empty;
                txtMaKH.Text = string.Empty;
            }
            if (txtCMND.Text.Trim().Length == 0)
            {
                lbErrorCMND.Visible = true;
            }
            else
            {
                List<KhachHangDTO> list = kh.GetDSKH();
                var khachhangs = from khachhang in list
                                 where khachhang.CMND.Equals(txtCMND.Text.Trim())
                                 select khachhang;
                if (khachhangs.ToList().Count != 0)
                {
                    frmSearchCustomer frmSearch = new frmSearchCustomer(khachhangs.ToList());
                    frmSearch.ShowDialog();
                    if (frmSearch.DialogResult == DialogResult.OK)
                    {
                        txtTenKH.Text = frmSearch.khachHang.TenKH;
                        dateNgaySinh.Value = frmSearch.khachHang.NgaySinh;
                        if (frmSearch.khachHang.GioiTinh == 0)
                        {
                            rdNam.Checked = true;
                        }
                        else
                        {
                            rdNu.Checked = true;
                        }
                        txtQuocTich.Text = frmSearch.khachHang.QuocTich;
                        txtMaKH.Text = frmSearch.khachHang.MaKH;
                        txtSDT.Text = frmSearch.khachHang.SDT;
                        txtDuong.Text = frmSearch.khachHang.QueQuan.Split(',')[0].ToString();
                        txtPhuong.Text = frmSearch.khachHang.QueQuan.Split(',')[1].ToString();
                        txtQuan.Text = frmSearch.khachHang.QueQuan.Split(',')[2].ToString();
                        txtThanhPho.Text = frmSearch.khachHang.QueQuan.Split(',')[3].ToString();

                        txtTenKH.BackColor = SystemColors.Control;
                        txtSDT.BackColor = SystemColors.Control;
                        dateNgaySinh.BackColor = SystemColors.Control;
                        rdNam.BackColor = SystemColors.Control;
                        rdNu.BackColor = SystemColors.Control;
                        txtDuong.BackColor = SystemColors.Control;
                        txtPhuong.BackColor = SystemColors.Control;
                        txtQuan.BackColor = SystemColors.Control;
                        txtThanhPho.BackColor = SystemColors.Control;
                        txtQuocTich.BackColor = SystemColors.Control;

                        txtTenKH.Enabled = false;
                        txtSDT.Enabled = false;
                        dateNgaySinh.Enabled = false;
                        rdNam.Enabled = false;
                        rdNu.Enabled = false;
                        txtDuong.Enabled = false;
                        txtPhuong.Enabled = false;
                        txtQuan.Enabled = false;
                        txtThanhPho.Enabled = false;
                        txtQuocTich.Enabled = false;
                    }
                }
                lbErrorCMND.Visible = false;
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

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            frmSelectRoom frmSelectRoom = new frmSelectRoom(dt);
            frmSelectRoom.ShowDialog();
            if (frmSelectRoom.DialogResult == DialogResult.OK)
            {
                PhongDTO phong = (PhongDTO)frmSelectRoom.arr[0];
                try
                {
                    dt.Rows.Add(phong.MaP, phong.TenP, "Đang xử lý", frmSelectRoom.arr[1], DateTime.Parse(frmSelectRoom.arr[2].ToString()), DateTime.Parse(frmSelectRoom.arr[3].ToString()), "", int.Parse(frmSelectRoom.arr[4].ToString()));
                }
                catch (Exception)
                {
                    dt.Rows.Add(phong.MaP, phong.TenP, "Đang xử lý", frmSelectRoom.arr[1], DateTime.Parse(frmSelectRoom.arr[2].ToString()), frmSelectRoom.arr[3].ToString(), "", int.Parse(frmSelectRoom.arr[4].ToString()));
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
            lbTotal.Text = total.ToString("###,###0 VNĐ");
            tbRoom.ClearSelection();
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void buttonRounded2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim().Length == 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                int ans = message.ShowDialog("Thông báo", "Thông báo", "Bạn có chắc tạo phiếu thuê mới này mà không nhập tiền cọc", MessageBoxDialog.WARNING, MessageBoxDialog.YES_NO, "Đúng vậy", "Không", "");
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
                    if (Years(dateNgaySinh.Value, DateTime.Now) >= 16)
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
                        if (dt.Rows.Count == 0)
                        {
                            MessageBoxDialog messageError = new MessageBoxDialog();
                            messageError.ShowDialog("Thông báo", "Thông báo lỗi chưa chọn phòng thuê", "Vui lòng chọn phòng khách muốn thuê", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                        }
                        else
                        {
                            string count = ctt.GetCountAll(DateTime.Now.ToString("yyyy-MM-dd")).ToString("D5");
                            txtMaCTT.Text = "CTT" + DateTime.Now.ToString("ddMMyy") + count;
                            //Thêm khách hàng mới
                            if (txtMaKH.Text.Trim().Length == 0)
                            {
                                if (rdNam.Checked)
                                {
                                    txtMaKH.Text = "KH" + "0" + dateNgaySinh.Value.ToString("ddMMyy") + kh.GetCountAllKH().ToString("D6");
                                    string diaChi = txtDuong.Text.Trim() + "," + txtPhuong.Text.Trim() + "," + txtQuan.Text.Trim() + "," + txtThanhPho.Text.Trim();
                                    kh.InsertKhachHang(txtMaKH.Text.Trim(), txtTenKH.Text.Trim(), txtCMND.Text.Trim(), "0", txtSDT.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""), diaChi, txtQuocTich.Text, dateNgaySinh.Value.ToString("yyyy-MM-dd"));
                                }
                                else
                                {
                                    txtMaKH.Text = "KH" + "1" + dateNgaySinh.Value.ToString("ddMMyy") + kh.GetCountAllKH().ToString("D6");
                                    string diaChi = txtDuong.Text.Trim() + "," + txtPhuong.Text.Trim() + "," + txtQuan.Text.Trim() + "," + txtThanhPho.Text.Trim();
                                    kh.InsertKhachHang(txtMaKH.Text.Trim(), txtTenKH.Text.Trim(), txtCMND.Text.Trim(), "1", txtSDT.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""), diaChi, txtQuocTich.Text, dateNgaySinh.Value.ToString("yyyy-MM-dd"));
                                }
                            }
                            timerClock.Stop();
                            if (textBox4.Text.Trim().Length == 0)
                            {
                                textBox4.Text = "0";
                            }
                            ctt.InsertCTT(txtMaCTT.Text.Trim(), txtMaKH.Text.Trim(), Program.nhanVien.MaNV, DateTime.ParseExact(txtNgayLap.Text.Trim(), "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss"), textBox4.Text);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (dt.Rows[i][3].ToString().ToUpper().Equals("THEO NGÀY"))
                                    cttp.InsertCTTP(true, txtMaCTT.Text.Trim(), dt.Rows[i][0].ToString().Trim(), DateTime.Parse(dt.Rows[i][4].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Parse(dt.Rows[i][5].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"), "0", dt.Rows[i][7].ToString());
                                else if (dt.Rows[i][3].ToString().ToUpper().Equals("THEO GIỜ"))
                                    cttp.InsertCTTP(true, txtMaCTT.Text.Trim(), dt.Rows[i][0].ToString().Trim(), DateTime.Parse(dt.Rows[i][4].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Parse(dt.Rows[i][5].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"), "1", dt.Rows[i][7].ToString());
                                else
                                    cttp.InsertCTTP(false, txtMaCTT.Text.Trim(), dt.Rows[i][0].ToString().Trim(), DateTime.Parse(dt.Rows[i][4].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Parse(dt.Rows[i][4].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"), "2", dt.Rows[i][7].ToString());
                            }
                            MessageBoxDialog messageSuccess = new MessageBoxDialog();
                            messageSuccess.ShowDialog("Thông báo", "Thành công", "Thêm phiếu thuê mới thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                            XuatFilePDF();
                        }
                    }
                }
                else
                {
                    textBox4.Focus();
                }
            }
            else
            {
                if (txtCMND.Text.Trim().Length == 0)
                {
                    lbErrorCMND.Visible = true;
                }
                if (txtTenKH.Text.Trim().Length == 0)
                {
                    lbErrorTenKH.Visible = true;
                }
                if (Years(dateNgaySinh.Value, DateTime.Now) >= 16)
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
                    if (dt.Rows.Count == 0)
                    {
                        MessageBoxDialog messageError = new MessageBoxDialog();
                        messageError.ShowDialog("Thông báo", "Thông báo lỗi chưa chọn phòng thuê", "Vui lòng chọn phòng khách muốn thuê", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                    }
                    else
                    {
                        string count = ctt.GetCountAll(DateTime.Now.ToString("yyyy-MM-dd")).ToString("D5");
                        txtMaCTT.Text = "CTT" + DateTime.Now.ToString("ddMMyy") + count;
                        //Thêm khách hàng mới
                        if (txtMaKH.Text.Trim().Length == 0)
                        {
                            if (rdNam.Checked)
                            {
                                txtMaKH.Text = "KH" + "0" + dateNgaySinh.Value.ToString("ddMMyy") + kh.GetCountAllKH().ToString("D6");
                                string diaChi = txtDuong.Text.Trim() + "," + txtPhuong.Text.Trim() + "," + txtQuan.Text.Trim() + "," + txtThanhPho.Text.Trim();
                                kh.InsertKhachHang(txtMaKH.Text.Trim(), txtTenKH.Text.Trim(), txtCMND.Text.Trim(), "0", txtSDT.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""), diaChi, txtQuocTich.Text, dateNgaySinh.Value.ToString("yyyy-MM-dd"));
                            }
                            else
                            {
                                txtMaKH.Text = "KH" + "1" + dateNgaySinh.Value.ToString("ddMMyy") + kh.GetCountAllKH().ToString("D6");
                                string diaChi = txtDuong.Text.Trim() + "," + txtPhuong.Text.Trim() + "," + txtQuan.Text.Trim() + "," + txtThanhPho.Text.Trim();
                                kh.InsertKhachHang(txtMaKH.Text.Trim(), txtTenKH.Text.Trim(), txtCMND.Text.Trim(), "1", txtSDT.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""), diaChi, txtQuocTich.Text, dateNgaySinh.Value.ToString("yyyy-MM-dd"));
                            }
                        }
                        timerClock.Stop();
                        if (textBox4.Text.Trim().Length == 0)
                        {
                            textBox4.Text = "0";
                        }
                        ctt.InsertCTT(txtMaCTT.Text.Trim(), txtMaKH.Text.Trim(), Program.nhanVien.MaNV, DateTime.ParseExact(txtNgayLap.Text, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss"), textBox4.Text);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i][3].ToString().ToUpper().Equals("THEO NGÀY"))
                                cttp.InsertCTTP(true, txtMaCTT.Text.Trim(), dt.Rows[i][0].ToString().Trim(), DateTime.Parse(dt.Rows[i][4].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Parse(dt.Rows[i][5].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"), "0", dt.Rows[i][7].ToString());
                            else if (dt.Rows[i][3].ToString().ToUpper().Equals("THEO GIỜ"))
                                cttp.InsertCTTP(true, txtMaCTT.Text.Trim(), dt.Rows[i][0].ToString().Trim(), DateTime.Parse(dt.Rows[i][4].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Parse(dt.Rows[i][5].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"), "1", dt.Rows[i][7].ToString());
                            else
                                cttp.InsertCTTP(false, txtMaCTT.Text.Trim(), dt.Rows[i][0].ToString().Trim(), DateTime.Parse(dt.Rows[i][4].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Parse(dt.Rows[i][4].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"), "2", dt.Rows[i][7].ToString());
                        }
                        MessageBoxDialog messageSuccess = new MessageBoxDialog();
                        messageSuccess.ShowDialog("Thông báo", "Thành công", "Thêm phiếu thuê mới thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                        XuatFilePDF();
                    }
                }
            }
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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
        private void XuatFilePDF()
        {
            Document document = new Document(PageSize.A4, 50, 50, 25, 25);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("CTT" + txtMaCTT.Text + ".pdf", FileMode.Create));
            document.Open();
            BaseFont bf = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bf, 13, iTextSharp.text.Font.BOLD | iTextSharp.text.Font.UNDERLINE, BaseColor.BLUE);
            Paragraph p = new Paragraph("KHÁCH SẠN LUXURY", fontTitle);
            p.Alignment = Element.ALIGN_CENTER;
            document.Add(p);
            Paragraph p2 = new Paragraph("Địa chỉ: 273 An Dương Vương, Phường 3, Quận 5, Tp Hồ Chí Minh", font);
            p2.Alignment = Element.ALIGN_CENTER;
            document.Add(p2);
            Paragraph p3 = new Paragraph("Hotline Booking: 0987654321", font);
            p3.Alignment = Element.ALIGN_CENTER;
            document.Add(p3);
            Paragraph p4 = new Paragraph("Fax: 0987654321", font);
            p4.Alignment = Element.ALIGN_CENTER;
            document.Add(p4);
            Paragraph pEmpty = new Paragraph("  ", fontTitle);
            document.Add(pEmpty);

            Paragraph p5 = new Paragraph("THÔNG TIN PHIẾU THUÊ", fontTitle);
            p5.Alignment = Element.ALIGN_LEFT;
            document.Add(p5);
            Paragraph pMaCTT = new Paragraph("Mã chi tiết thuê: " + txtMaCTT.Text, font);
            pMaCTT.Alignment = Element.ALIGN_LEFT;
            Paragraph pTenNV = new Paragraph("Nhân viên lập phiếu: " + txtNhanVien.Text, font);
            pTenNV.Alignment = Element.ALIGN_LEFT;
            Paragraph pNgayLapPhieu = new Paragraph("Ngày lâp phiếu: " + txtNgayLap.Text, font);
            pNgayLapPhieu.Alignment = Element.ALIGN_LEFT;
            Paragraph pTienDatCoc = new Paragraph("Tiền đặt cọc: " + textBox4.Text, font);
            pTienDatCoc.Alignment = Element.ALIGN_LEFT;
            document.Add(pMaCTT);
            document.Add(pTenNV);
            document.Add(pNgayLapPhieu);
            document.Add(pTienDatCoc);
            Paragraph pEmpty2 = new Paragraph("  ", fontTitle);
            document.Add(pEmpty2);

            Paragraph p6 = new Paragraph("THÔNG TIN KHÁCH HÀNG", fontTitle);
            p6.Alignment = Element.ALIGN_LEFT;
            document.Add(p6);
            Paragraph pTenKH = new Paragraph("Họ tên khách hàng: " + txtTenKH.Text, font);
            pTenKH.Alignment = Element.ALIGN_LEFT;
            Paragraph pCMND = new Paragraph("CMND/CCCD: " + txtCMND.Text, font);
            pCMND.Alignment = Element.ALIGN_LEFT;
            Paragraph pSDT = new Paragraph("Số điện thoại: " + txtSDT.Text, font);
            pSDT.Alignment = Element.ALIGN_LEFT;
            Paragraph pNgaySinh = new Paragraph("Ngày sinh: " + dateNgaySinh.Value.ToString("dd/MM/yyyy"), font);
            pNgaySinh.Alignment = Element.ALIGN_LEFT;
            Paragraph pGioiTinh = new Paragraph("Giới tính:" + (rdNam.Checked ? "Nam" : "Nữ"), font);
            pGioiTinh.Alignment = Element.ALIGN_LEFT;
            string diaChi = "";
            if (txtDuong.Text.Trim().Length != 0)
            {
                diaChi += "Đường: " + txtDuong.Text.Trim();
            }
            if (txtPhuong.Text.Trim().Length != 0)
            {
                if (diaChi != "")
                {
                    diaChi += ", ";
                }
                diaChi += "Phường/Thôn: " + txtPhuong.Text.Trim();
            }
            if (txtQuan.Text.Trim().Length != 0)
            {
                if (diaChi != "")
                {
                    diaChi += ", ";
                }
                diaChi += "Quận/Huyện: " + txtQuan.Text.Trim();
            }
            if (txtThanhPho.Text.Trim().Length != 0)
            {
                if (diaChi != "")
                {
                    diaChi += ", ";
                }
                diaChi += "Tỉnh/Thành phố: " + txtThanhPho.Text.Trim();
            }
            Paragraph pDiaChi = new Paragraph("Địa chỉ: " + diaChi, font);
            pDiaChi.Alignment = Element.ALIGN_LEFT;
            Paragraph pQuocTich = new Paragraph("Quốc tịch: " + txtQuocTich.Text, font);
            pQuocTich.Alignment = Element.ALIGN_LEFT;
            document.Add(pTenKH);
            document.Add(pCMND);
            document.Add(pSDT);
            document.Add(pNgaySinh);
            document.Add(pGioiTinh);
            document.Add(pDiaChi);
            document.Add(pQuocTich);
            Paragraph pEmpty3 = new Paragraph("  ", fontTitle);
            document.Add(pEmpty3);
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            string[,] data = {
                {"Khách hàng", "Nhân viên lập phiếu"},
                {"(Ký và ghi rõ họ tên)", "(Ký và ghi rõ họ tên)"},
            };
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(data[i, j], font));
                    cell.Border = 0;
                    table.AddCell(cell);
                }
            }
            document.Add(table);
            document.Close();
            System.Diagnostics.Process.Start("CTT" + txtMaCTT.Text + ".pdf");
        }
    }
}
