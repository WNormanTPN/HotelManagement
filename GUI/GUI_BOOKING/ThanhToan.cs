using BUS;
using DTO;
using GUI.GUI_COMPONENT;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.GUI_BOOKING
{
    public partial class ThanhToan : Form
    {
        string maCTT;
        ChiTietThuePhongBUS cttP = new ChiTietThuePhongBUS();
        PhongBUS phong = new PhongBUS();
        ChiTietThueDichVuBUS cttDV = new ChiTietThueDichVuBUS();
        DichVuBUS dichVu = new DichVuBUS();
        KhachHangBUS kh = new KhachHangBUS();
        ChiTietThueBUS ctt = new ChiTietThueBUS();
        public ThanhToan(string maCTT)
        {
            InitializeComponent();
            this.maCTT = maCTT;
            HienThiChiTietThueDichVu();
            HienThiChiTietThuePhong();
            this.DialogResult = DialogResult.Cancel;
            List<ChiTietThueDTO> listCTT = ctt.getDSChiTietThue();
            List<KhachHangDTO> listKH = kh.GetDSKH();
            var item = from ctt in listCTT
                       join kh in listKH on ctt.MaKH equals kh.MaKH
                       where ctt.MaCTT == maCTT
                       select new
                       {
                           maKH = kh.MaKH,
                           tenKH = kh.TenKH,
                           cMND = kh.CMND,
                           tienDatCoc = ctt.TienDatCoc.ToString("###,###0 VNĐ"),
                       };
            var it = item.First();
            txtCMND.Text = it.cMND.ToString();
            txtDatCoc.Text = it.tienDatCoc;
            txtTenKH.Text = it.tenKH;
            int soLan = kh.SoLanThue(it.maKH);
            txtSL.Text = soLan.ToString();
            txtGiamGia.Text = "0%";
            if (soLan >= 5 && soLan < 10)
            {
                txtGiamGia.Text = "5%";
            }
            else if (soLan >= 10 && soLan < 15)
            {
                txtGiamGia.Text = "10%";
            }
            else if (soLan >= 15 && soLan < 20)
            {
                txtGiamGia.Text = "15%";
            }
            else if (soLan >= 20)
            {
                txtGiamGia.Text = "20%";
            }
            else
            {
                txtGiamGia.Text = "0%";
            }
        }
        private void renderTongTien()
        {
            int total = 0;
            for (int i = 0; i < tbRoom.Rows.Count; i++)
            {
                try
                {
                    total += int.Parse(tbRoom.Rows[i].Cells[6].Value.ToString().Replace(",", "").Split(' ')[0]);
                }
                catch (Exception) { }
            }
            txtTotalRoom.Text = total.ToString("###,###0 VNĐ");
            total = 0;
            for (int i = 0; i < tbService.Rows.Count; i++)
            {
                try
                {
                    total += int.Parse(tbService.Rows[i].Cells[6].Value.ToString().Replace(",", "").Split(' ')[0]);
                }
                catch (Exception) { }
            }
            if (total > 0)
                txtTotalService.Text = total.ToString("###,###0 VNĐ");
            else txtTotalService.Text = total.ToString("0 VNĐ");
        }
        private void HienThiChiTietThuePhong()
        {
            tbRoom.Rows.Clear();
            List<ChiTietThuePhongDTO> cttps = cttP.GetDSListCTTP(maCTT);
            List<PhongDTO> phongs = phong.getListPhong_DTO();
            var items = from cttp in cttps
                        join phong in phongs on cttp.MaP equals phong.MaP
                        where cttp.TinhTrang == 2
                        select new
                        {
                            tenP = phong.TenP,
                            loaiHinhThue = cttp.LoaiHinhThue,
                            ngayThue = cttp.NgayThue,
                            ngayTra = cttp.NgayTra,
                            ngayCheckOut = cttp.NgayCheckOut,
                            giaThue = cttp.GiaThue
                        };
            int stt = 0;
            foreach (var item in items)
            {
                string loaiHinhThue = "";
                if (item.loaiHinhThue == 0)
                {
                    loaiHinhThue = "Theo Ngày";
                }
                else if (item.loaiHinhThue == 1)
                {
                    loaiHinhThue = "Theo giờ";
                }
                else
                {
                    loaiHinhThue = "Khác";
                }
                tbRoom.Rows.Add(++stt, item.tenP, loaiHinhThue, item.ngayThue.ToString("dd/MM/yyyy HH:mm:ss"), item.ngayTra?.ToString("dd/MM/yyyy HH:mm:ss"), item.ngayCheckOut?.ToString("dd/MM/yyyy HH:mm:ss"), item.giaThue.ToString("###,###0 VNĐ"));
                tbRoom.ClearSelection();
            }
            renderTongTien();
        }

        private void HienThiChiTietThueDichVu()
        {
            tbService.Rows.Clear();
            List<ChiTietThueDichVuDTO> cttdvs = cttDV.GetListChiTietDichVu(maCTT);
            List<DichVuDTO> dvs = dichVu.getListDTO();
            var items = from cttdv in cttdvs
                        join dv in dvs on cttdv.MaDV equals dv.MaDV
                        select new
                        {
                            maDV = cttdv.MaDV,
                            tenDV = dv.TenDV,
                            ngaySuDung = cttdv.NgaySuDung,
                            soLuong = cttdv.SoLuong,
                            donGia = cttdv.GiaDV,
                            thanhTien = cttdv.GiaDV * cttdv.SoLuong,
                        };
            int stt = 0;
            foreach (var item in items)
            {
                tbService.Rows.Add(++stt, item.maDV, item.tenDV, item.ngaySuDung.ToString("dd/MM/yyyy HH:mm:ss"), item.soLuong, item.donGia.ToString("###,###0 VNĐ"), item.thanhTien.ToString("###,###0 VNĐ"));
            }
            tbService.ClearSelection();
            renderTongTien();
        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {
            tbRoom.ClearSelection();
            tbService.ClearSelection();
            CbPhuThu.SelectedIndex = 0;
            cbPTTT.SelectedIndex = 0;
        }
        private void HienThiThongTin()
        {
            int totalPhong = 0;
            try
            {
                totalPhong = int.Parse(txtTotalRoom.Text.Replace(",", "").Split(' ')[0]);
            }
            catch { }

            int totalDichVu = 0;
            try
            {
                totalDichVu = int.Parse(txtTotalService.Text.Replace(",", "").Split(' ')[0]);
            }
            catch { }

            int tienDatCoc = int.Parse(txtDatCoc.Text.Replace(",", "").Split(' ')[0]);
            int phuThuPercent = int.Parse(CbPhuThu.SelectedItem.ToString().Replace("%", ""));
            int phuThu = (totalPhong + totalDichVu) * phuThuPercent / 100;
            int giamGiaPercent = int.Parse(txtGiamGia.Text.Replace("%", ""));
            int giamGia = (totalPhong + totalDichVu) * giamGiaPercent / 100;
            TongThanhTien.Text = (totalPhong + totalDichVu - tienDatCoc - giamGia + phuThu).ToString();
            txtTienThoiLai.Text = TongThanhTien.Text;
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

        private void tbService_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < tbService.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    tbService.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
                }
                else
                {
                    tbService.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
        private void XuatFilePDF(string maHD)
        {
            Document document = new Document(PageSize.A4, 50, 50, 25, 25);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(maHD + ".pdf", FileMode.Create));
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

            HoaDonBUS hd = new HoaDonBUS();
            DataTable dt = hd.getHoaDon(maHD);

            Paragraph p5 = new Paragraph("THÔNG TIN HÓA ĐƠN", fontTitle);
            p5.Alignment = Element.ALIGN_LEFT;
            document.Add(p5);
            Paragraph pMaCTT = new Paragraph("Mã chi tiết thuê: " + dt.Rows[0][1].ToString(), font);
            pMaCTT.Alignment = Element.ALIGN_LEFT;
            Paragraph pTenNV = new Paragraph("Nhân viên lập hóa đơn: " + dt.Rows[0][2].ToString(), font);
            pTenNV.Alignment = Element.ALIGN_LEFT;
            Paragraph pNgayLapPhieu = new Paragraph("Ngày lâp hóa đơn: " + DateTime.Parse(dt.Rows[0][3].ToString()).ToString("HH:mm:ss dd/MM/yyyy"), font);
            pNgayLapPhieu.Alignment = Element.ALIGN_LEFT;
            document.Add(pMaCTT);
            document.Add(pTenNV);
            document.Add(pNgayLapPhieu);
            Paragraph pEmpty2 = new Paragraph("  ", fontTitle);
            document.Add(pEmpty2);

            Paragraph p6 = new Paragraph("THÔNG TIN PHÒNG THUÊ", fontTitle);
            p6.Alignment = Element.ALIGN_LEFT;
            document.Add(p6);
            Paragraph pEmpty5 = new Paragraph("  ", fontTitle);
            document.Add(pEmpty5);
            DataTable dt2 = hd.getThuePhong(maHD);
            PdfPTable table = new PdfPTable(dt2.Columns.Count);
            table.DefaultCell.Padding = 3;
            table.WidthPercentage = 100;
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPCell cell = new PdfPCell(new Phrase("TÊN PHÒNG", font));
            cell.BackgroundColor = new BaseColor(240, 240, 240);
            table.AddCell(cell);

            PdfPCell cell2 = new PdfPCell(new Phrase("LOẠI HÌNH THUÊ", font));
            cell2.BackgroundColor = new BaseColor(240, 240, 240);
            table.AddCell(cell2);

            PdfPCell cell3 = new PdfPCell(new Phrase("NGÀY THUÊ", font));
            cell3.BackgroundColor = new BaseColor(240, 240, 240);
            table.AddCell(cell3);

            PdfPCell cell4 = new PdfPCell(new Phrase("NGÀY CHECKOUT", font));
            cell4.BackgroundColor = new BaseColor(240, 240, 240);
            table.AddCell(cell4);

            PdfPCell cell5 = new PdfPCell(new Phrase("GIÁ THUÊ", font));
            cell5.BackgroundColor = new BaseColor(240, 240, 240);
            table.AddCell(cell5);

            // Thêm dữ liệu từ DataTable vào bảng
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                PdfPCell cell11 = new PdfPCell(new Phrase(dt2.Rows[i][0].ToString(), font));
                cell11.BackgroundColor = new BaseColor(255, 255, 255);
                table.AddCell(cell11);
                string loaiHT = "";
                if (dt2.Rows[i][1].ToString().Equals("0"))
                {
                    loaiHT = "Theo ngày";
                }
                else if (dt2.Rows[i][1].ToString().Equals("1"))
                {
                    loaiHT = "Theo giờ";
                }
                else
                {
                    loaiHT = "Khác";
                }
                PdfPCell cell12 = new PdfPCell(new Phrase(loaiHT, font));
                cell12.BackgroundColor = new BaseColor(255, 255, 255);
                table.AddCell(cell12);

                PdfPCell cell13 = new PdfPCell(new Phrase(DateTime.Parse(dt2.Rows[i][2].ToString()).ToString("HH:mm:ss dd/MM/yyyy"), font));
                cell13.BackgroundColor = new BaseColor(255, 255, 255);
                table.AddCell(cell13);

                PdfPCell cell14 = new PdfPCell(new Phrase(DateTime.Parse(dt2.Rows[i][3].ToString()).ToString("HH:mm:ss dd/MM/yyyy"), font));
                cell14.BackgroundColor = new BaseColor(255, 255, 255);
                table.AddCell(cell14);

                PdfPCell cell15 = new PdfPCell(new Phrase(int.Parse(dt2.Rows[i][4].ToString()).ToString("###,###0 VNĐ"), font));
                cell15.BackgroundColor = new BaseColor(255, 255, 255);
                table.AddCell(cell15);
            }

            // Thêm bảng vào tài liệu
            document.Add(table);
            Paragraph pEmpty11 = new Paragraph("  ", fontTitle);
            document.Add(pEmpty11);

            Paragraph p10 = new Paragraph("THÔNG TIN DỊCH VỤ THUÊ", fontTitle);
            p10.Alignment = Element.ALIGN_LEFT;
            document.Add(p10);
            Paragraph pEmpty10 = new Paragraph("  ", fontTitle);
            document.Add(pEmpty10);
            DataTable dt3 = hd.getDichVu(maHD);
            PdfPTable table1 = new PdfPTable(dt3.Columns.Count);
            table1.DefaultCell.Padding = 3;
            table1.WidthPercentage = 100;
            table1.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPCell cellDV1 = new PdfPCell(new Phrase("TÊN DỊCH VỤ", font));
            cellDV1.BackgroundColor = new BaseColor(240, 240, 240);
            table1.AddCell(cellDV1);

            PdfPCell cellDV2 = new PdfPCell(new Phrase("LOẠI DỊCH VỤ", font));
            cellDV2.BackgroundColor = new BaseColor(240, 240, 240);
            table1.AddCell(cellDV2);

            PdfPCell cellDV3 = new PdfPCell(new Phrase("NGÀY SỬ DỤNG", font));
            cellDV3.BackgroundColor = new BaseColor(240, 240, 240);
            table1.AddCell(cellDV3);

            PdfPCell cellDV4 = new PdfPCell(new Phrase("SỐ LƯỢNG", font));
            cellDV4.BackgroundColor = new BaseColor(240, 240, 240);
            table1.AddCell(cellDV4);

            PdfPCell cellDV5 = new PdfPCell(new Phrase("ĐƠN GIÁ", font));
            cellDV5.BackgroundColor = new BaseColor(240, 240, 240);
            table1.AddCell(cellDV5);

            PdfPCell cellDV6 = new PdfPCell(new Phrase("THÀNH TIỀN", font));
            cellDV2.BackgroundColor = new BaseColor(240, 240, 240);
            table1.AddCell(cellDV6);

            // Thêm dữ liệu từ DataTable vào bảng
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                PdfPCell cell11 = new PdfPCell(new Phrase(dt3.Rows[i][0].ToString(), font));
                cell11.BackgroundColor = new BaseColor(255, 255, 255);
                table1.AddCell(cell11);

                PdfPCell cell12 = new PdfPCell(new Phrase(dt3.Rows[i][1].ToString(), font));
                cell12.BackgroundColor = new BaseColor(255, 255, 255);
                table1.AddCell(cell12);

                PdfPCell cell13 = new PdfPCell(new Phrase(DateTime.Parse(dt3.Rows[i][2].ToString()).ToString("dd/MM/yyyy"), font));
                cell13.BackgroundColor = new BaseColor(255, 255, 255);
                table1.AddCell(cell13);

                PdfPCell cell14 = new PdfPCell(new Phrase(int.Parse(dt3.Rows[i][3].ToString()).ToString(), font));
                cell14.BackgroundColor = new BaseColor(255, 255, 255);
                table1.AddCell(cell14);

                PdfPCell cell15 = new PdfPCell(new Phrase(int.Parse(dt3.Rows[i][4].ToString()).ToString("###,###0 VNĐ"), font));
                cell15.BackgroundColor = new BaseColor(255, 255, 255);
                table1.AddCell(cell15);

                PdfPCell cell16 = new PdfPCell(new Phrase(int.Parse(dt3.Rows[i][5].ToString()).ToString("###,###0 VNĐ"), font));
                cell16.BackgroundColor = new BaseColor(255, 255, 255);
                table1.AddCell(cell16);
            }

            // Thêm bảng vào tài liệu
            document.Add(table1);
            document.Close();
            System.Diagnostics.Process.Start(maHD + ".pdf");
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int total = int.Parse(TongThanhTien.Text);
            if (txtTienKhachDua.Text.Trim().Length == 0)
            {
                MessageBoxDialog messageError = new MessageBoxDialog();
                messageError.ShowDialog("Thông báo", "Thông báo", "Vui lòng nhập tiền khách đưa", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                txtTienKhachDua.Focus();
                return;
            }
            int tienKhachDua = int.Parse(txtTienKhachDua.Text);
            if (total > tienKhachDua)
            {
                MessageBoxDialog messageError = new MessageBoxDialog();
                messageError.ShowDialog("Thông báo", "Thông báo", "Vui lòng nhập tiền khách đưa phải lớn hơn hoặc bằng tổng thành tiền", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                txtTienKhachDua.Focus();
                return;
            }
            MessageBoxDialog messageQuestion = new MessageBoxDialog();
            int ans = messageQuestion.ShowDialog("Thông báo", "Thanh toán", "Bạn có muốn thanh toán hóa đơn này không?", MessageBoxDialog.INFO, MessageBoxDialog.YES_NO, "Đồng ý", "Không đồng ý", "");
            if (ans == MessageBoxDialog.YES_OPTION)
            {
                #region Thêm hóa đơn mới
                HoaDonBUS hd = new HoaDonBUS();
                string maHD = "HD" + DateTime.Now.ToString("ddMMyy") + hd.SoLuongHD(DateTime.Now.ToString("yyyy-MM-dd")).ToString("D5");
                string GiamGia = txtGiamGia.Text.Replace("%", "");
                string phuThu = CbPhuThu.SelectedItem.ToString().Replace("%", "");
                string ngayThanhToan = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                hd.ThemHoaDon(maHD, maCTT, GiamGia, phuThu, ngayThanhToan, cbPTTT.SelectedIndex.ToString());
                #endregion

                #region Sửa tình trạng xử lý của phiếu thuê
                ChiTietThueBUS ctt = new ChiTietThueBUS();
                ctt.SuaTinhTrangXuLy(maCTT);
                #endregion

                #region Xóa các phòng không thuê
                List<ChiTietThuePhongDTO> cttTP = cttP.GetDSListCTTP(maCTT);
                ChiTietThuePhongBUS cttPhongBus = new ChiTietThuePhongBUS();
                foreach (ChiTietThuePhongDTO ct in cttTP)
                {
                    if (ct.TinhTrang == 0)
                    {
                        cttPhongBus.DeleteCTTP(maCTT, ct.MaP, ct.NgayThue.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                }
                #endregion

                XuatFilePDF(maHD);
                MessageBoxDialog messageSuccess = new MessageBoxDialog();
                messageSuccess.ShowDialog("Thông báo", "Thành công", "Thêm hóa đơn mới thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void CbPhuThu_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiThongTin();
        }

        private void txtTienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            if (txtTienKhachDua.Text.Trim().Length == 0)
            {
                txtTienThoiLai.Text = TongThanhTien.Text;
            }
            else
            {
                int total = int.Parse(TongThanhTien.Text);
                int tienKhachDua = int.Parse(txtTienKhachDua.Text);
                txtTienThoiLai.Text = (tienKhachDua - total).ToString();
            }
        }

        private void ThanhToan_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
