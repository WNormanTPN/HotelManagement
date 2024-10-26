using BUS;
using GUI.GUI_COMPONENT;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Org.BouncyCastle.Asn1.X500;
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

namespace GUI.GUI_BILL
{
    public partial class BillForm : Form
    {
        HoaDonBUS hd = new HoaDonBUS();
        DataTable dt;
        public BillForm()
        {
            dt = hd.GetListHD();
            InitializeComponent();
            HienThiHoaDon();
            dtpNgayBatDau.CustomFormat = " ";
            dtpNgayKetThuc.CustomFormat = " ";
        }

        private void BillForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            tbHoaDon.ClearSelection();
        }
        private void HienThiHoaDon()
        {
            tbHoaDon.Rows.Clear();
            int stt = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string pttt = "";
                if (dt.Rows[i][9].ToString() == "0")
                {
                    pttt = "Tiền mặt";
                }
                else
                {
                    pttt = "Chuyển khoản";
                }
                tbHoaDon.Rows.Add(++stt, dt.Rows[i][0].ToString(),
                    dt.Rows[i][1].ToString(),
                    dt.Rows[i][2].ToString(),
                    int.Parse(dt.Rows[i][3].ToString()).ToString("###,###0 VNĐ"),
                    int.Parse(dt.Rows[i][4].ToString()).ToString("###,###0 VNĐ"),
                    int.Parse(dt.Rows[i][5].ToString()) + "%",
                    int.Parse(dt.Rows[i][6].ToString()) + "%",
                    int.Parse(dt.Rows[i][7].ToString()).ToString("###,###0 VNĐ"),
                    DateTime.Parse(dt.Rows[i][8].ToString()).ToString("dd-MM-yyyy HH:mm:ss"),
                    pttt);
            }
            tbHoaDon.ClearSelection();
        }

        private void tbHoaDon_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < tbHoaDon.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    tbHoaDon.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
                }
                else
                {
                    tbHoaDon.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void buttonRounded2_Click(object sender, EventArgs e)
        {
            txtMaHoaDon.Text = "";
            txtMaChiTietThue.Text = "";
            txtTenNhanVien.Text = "";
            txtGiamGia.Text = "";
            txtPhuThu.Text = "";
            cbPhuongThucTT.SelectedIndex = -1;
            cbTongTien.SelectedIndex = -1;
            cbTienDichVu.SelectedIndex = -1;
            cbTienPhong.SelectedIndex = -1;
            dtpNgayBatDau.CustomFormat = " ";
            dtpNgayKetThuc.CustomFormat = " ";
            HienThiHoaDon();
            searchWithIDCTT(true);
            searchWithIDHD(true);
            searchWithOther(true);
        }

        private void buttonRounded1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = dt;
            string search = "";
            if (txtMaHoaDon.Text.Trim().Length != 0)
            {
                search += "[maHD] like '%" + txtMaHoaDon.Text.Trim() + "%'";
            }

            if (txtMaChiTietThue.Text.Trim().Length != 0)
            {
                if (search != "")
                {
                    search += " AND ";
                }
                search += "[maCTT] like '%" + txtMaChiTietThue.Text.Trim() + "%'";
            }

            if (txtTenNhanVien.Text.Trim().Length != 0)
            {
                if (search != "")
                {
                    search += " AND ";
                }
                search += "[tenNV] like '%" + txtTenNhanVien.Text.Trim() + "%'";
            }

            if (txtPhuThu.Text.Trim().Length != 0)
            {
                if (search != "")
                {
                    search += " AND ";
                }
                search += "[phuThu] = " + txtPhuThu.Text.Trim();
            }

            if (txtGiamGia.Text.Trim().Length != 0)
            {
                if (search != "")
                {
                    search += " AND ";
                }
                search += "[giamGia] = " + txtGiamGia.Text.Trim();
            }
            if (cbPhuongThucTT.SelectedIndex != -1)
            {
                if (search != "")
                {
                    search += " AND ";
                }
                search += "[phuongThucThanhToan] = " + cbPhuongThucTT.SelectedIndex;
            }
            if (cbTongTien.SelectedIndex != -1)
            {
                if (search != "")
                {
                    search += " AND ";
                }
                if (cbTongTien.SelectedIndex == 0)
                {
                    search += "[TongTien] <= " + cbTongTien.SelectedItem.ToString().Split(' ')[1].Replace(",", "");
                }
                else if (cbTongTien.SelectedIndex == 5)
                {
                    search += "[TongTien] >= " + cbTongTien.SelectedItem.ToString().Split(' ')[1].Replace(",", "");
                }
                else
                {
                    search += "[TongTien] >= " + cbTongTien.SelectedItem.ToString().Split(' ')[1].Replace(",", "");
                    search += " AND ";
                    search += "[TongTien] <= " + cbTongTien.SelectedItem.ToString().Split(' ')[4].Replace(",", "");
                }
            }
            if (cbTienPhong.SelectedIndex != -1)
            {
                if (search != "")
                {
                    search += " AND ";
                }
                if (cbTienPhong.SelectedIndex == 0)
                {
                    search += "[TongTienPhong] <= " + cbTienPhong.SelectedItem.ToString().Split(' ')[1].Replace(",", "");
                }
                else if (cbTienPhong.SelectedIndex == 5)
                {
                    search += "[TongTienPhong] >= " + cbTienPhong.SelectedItem.ToString().Split(' ')[1].Replace(",", "");
                }
                else
                {
                    search += "[TongTienPhong] >= " + cbTienPhong.SelectedItem.ToString().Split(' ')[1].Replace(",", "");
                    search += " AND ";
                    search += "[TongTienPhong] <= " + cbTienPhong.SelectedItem.ToString().Split(' ')[4].Replace(",", "");
                }
            }
            if (cbTienDichVu.SelectedIndex != -1)
            {
                if (search != "")
                {
                    search += " AND ";
                }
                if (cbTienDichVu.SelectedIndex == 0)
                {
                    search += "[TongTienDV] <= " + cbTienDichVu.SelectedItem.ToString().Split(' ')[1].Replace(",", "");
                }
                else if (cbTienDichVu.SelectedIndex == 5)
                {
                    search += "[TongTienDV] >= " + cbTienDichVu.SelectedItem.ToString().Split(' ')[1].Replace(",", "");
                }
                else
                {
                    search += "[TongTienDV] >= " + cbTienDichVu.SelectedItem.ToString().Split(' ')[1].Replace(",", "");
                    search += " AND ";
                    search += "[TongTienDV] <= " + cbTienDichVu.SelectedItem.ToString().Split(' ')[4].Replace(",", "");
                }
            }
            if (dtpNgayBatDau.CustomFormat.ToString().Length != 1)
            {
                if (search != "")
                {
                    search += " AND ";
                }
                search += "[ngayThanhToan] >= '" + dtpNgayBatDau.Value.ToString("yyyy-MM-dd") + " 00:00:00" + "'";
            }
            if (dtpNgayKetThuc.CustomFormat.ToString().Length != 1)
            {
                if (search != "")
                {
                    search += " AND ";
                }
                search += "[ngayThanhToan] <= '" + dtpNgayKetThuc.Value.ToString("yyyy-MM-dd") + " 00:00:00" + "'";
            }

            dataTable.DefaultView.RowFilter = search;
            if (dt.DefaultView.Count == 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Thông báo", "Không tìm thấy hóa đơn theo yêu cầu", MessageBoxDialog.INFO, MessageBoxDialog.YES, "Đóng", "", "");
                buttonRounded2.PerformClick();
            }
            else
            {
                tbHoaDon.Rows.Clear();
                int stt = 0;
                for (int i = 0; i < dataTable.DefaultView.Count; i++)
                {
                    string pttt = "";
                    if (dataTable.DefaultView[i][9].ToString() == "0")
                    {
                        pttt = "Tiền mặt";
                    }
                    else
                    {
                        pttt = "Chuyển khoản";
                    }
                    tbHoaDon.Rows.Add(++stt, dataTable.Rows[i][0].ToString(),
                        dataTable.DefaultView[i][1].ToString(),
                        dataTable.DefaultView[i][2].ToString(),
                        int.Parse(dataTable.DefaultView[i][3].ToString()).ToString("###,###0 VNĐ"),
                        int.Parse(dataTable.DefaultView[i][4].ToString()).ToString("###,###0 VNĐ"),
                        int.Parse(dataTable.DefaultView[i][5].ToString()) + "%",
                        int.Parse(dataTable.DefaultView[i][6].ToString()) + "%",
                        int.Parse(dataTable.DefaultView[i][7].ToString()).ToString("###,###0 VNĐ"),
                        DateTime.Parse(dataTable.DefaultView[i][8].ToString()).ToString("dd-MM-yyyy HH:mm:ss"),
                        pttt);
                }
                tbHoaDon.ClearSelection();
            }
        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPhuThu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dtpNgayBatDau_ValueChanged(object sender, EventArgs e)
        {
            dtpNgayBatDau.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpNgayKetThuc_ValueChanged(object sender, EventArgs e)
        {
            dtpNgayKetThuc.CustomFormat = "dd/MM/yyyy";
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (tbHoaDon.SelectedRows.Count > 0)
            {
                XuatFilePDF(tbHoaDon.SelectedRows[0].Cells[1].Value.ToString());
            }
            else
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Thông báo", "Vui lòng chọn hóa đơn muốn in", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                return;
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

            PdfPCell cell = new PdfPCell(new Phrase("TÊN PHÒNG",font));
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

        private void txtMaHoaDon_TextChanged(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text.Length == 0)
            {
                searchWithIDHD(true);
                searchWithIDCTT(true);
                searchWithOther(true);
            }
            else
            {
                searchWithIDHD(true);
                searchWithIDCTT(false);
                searchWithOther(false);
            }
        }

        private void searchWithIDHD(bool enable)
        {
            if (!enable) txtMaHoaDon.Text = "";
            txtMaHoaDon.Enabled = enable;
        }

        private void searchWithIDCTT(bool enable)
        {
            if (!enable) txtMaChiTietThue.Text = "";
            txtMaChiTietThue.Enabled = enable;
        }

        private void searchWithOther(bool enable)
        {
            if (!enable)
            {
                dtpNgayBatDau.CustomFormat = " ";
                dtpNgayKetThuc.CustomFormat = " ";
                txtTenNhanVien.Text = "";
                txtGiamGia.Text = "";
                txtPhuThu.Text = "";
                cbPhuongThucTT.SelectedIndex = -1;
                cbTongTien.SelectedIndex = -1;
                cbTienDichVu.SelectedIndex = -1;
                cbTienPhong.SelectedIndex = -1;
            }
            dtpNgayBatDau.Enabled = enable;
            dtpNgayKetThuc.Enabled = enable;
            txtTenNhanVien.Enabled = enable;
            txtGiamGia.Enabled = enable;
            txtPhuThu.Enabled = enable;
            cbPhuongThucTT.Enabled = enable;
            cbTongTien.Enabled = enable;
            cbTienDichVu.Enabled = enable;
            cbTienPhong.Enabled = enable;
        }

        private void txtMaChiTietThue_TextChanged(object sender, EventArgs e)
        {
            if (txtMaChiTietThue.Text.Length == 0)
            {
                searchWithIDHD(true);
                searchWithIDCTT(true);
                searchWithOther(true);
            }
            else
            {
                searchWithIDHD(false);
                searchWithIDCTT(true);
                searchWithOther(false);
            }
        }

        private void triggerOtherSearch(object sender, EventArgs e)
        {
            if (txtTenNhanVien.Text.Length == 0 && txtGiamGia.Text.Length == 0 && txtPhuThu.Text.Length == 0 && cbPhuongThucTT.SelectedIndex == -1 && cbTongTien.SelectedIndex == -1 && cbTienDichVu.SelectedIndex == -1 && cbTienPhong.SelectedIndex == -1 && dtpNgayBatDau.CustomFormat.ToString().Length == 1 && dtpNgayKetThuc.CustomFormat.ToString().Length == 1)
            {
                searchWithIDHD(true);
                searchWithIDCTT(true);
                searchWithOther(true);
            }
            else
            {
                searchWithIDHD(false);
                searchWithIDCTT(false);
                searchWithOther(true);
            }
        }
    }
}
