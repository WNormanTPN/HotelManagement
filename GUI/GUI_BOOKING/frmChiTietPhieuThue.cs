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

namespace GUI.GUI_BOOKING
{
    public partial class frmChiTietPhieuThue : Form
    {
        ChiTietThuePhongBUS cttP = new ChiTietThuePhongBUS();
        PhongBUS phong = new PhongBUS();
        ChiTietThueDichVuBUS cttDV = new ChiTietThueDichVuBUS();
        DichVuBUS dichVu = new DichVuBUS();
        frmChiTietThue frmChiTietThue;
        string maCTT;
        public frmChiTietPhieuThue(string maCTT, int option, frmChiTietThue frmChiTietThue)
        {
            this.frmChiTietThue = frmChiTietThue;
            this.maCTT = maCTT;
            InitializeComponent();
            HienThiChiTietThuePhong();
            HienThiChiTietThueDichVu();
            if (option == 0)
            {
                btnThanhToan.Visible = true;
                tbRoom.Columns[9].Visible = true;
                tbRoom.Columns[10].Visible = true;
                tbService.Columns[7].Visible = true;
                tbService.Columns[8].Visible = true;
            }
            else
            {
                btnThanhToan.Visible = false;
                tbRoom.Columns[9].Visible = false;
                tbRoom.Columns[10].Visible = false;
                tbService.Columns[7].Visible = false;
                tbService.Columns[8].Visible = false;
            }
        }
        private void renderTongTien()
        {
            int total = 0;
            for (int i = 0; i < tbRoom.Rows.Count; i++)
            {
                try
                {
                    total += int.Parse(tbRoom.Rows[i].Cells[8].Value.ToString().Replace(",", "").Split(' ')[0]);
                }
                catch (Exception) { }
            }
            for (int i = 0; i < tbService.Rows.Count; i++)
            {
                try
                {
                    total += int.Parse(tbService.Rows[i].Cells[6].Value.ToString().Replace(",", "").Split(' ')[0]);
                }
                catch (Exception) { }
            }
            lbTotal.Text = total.ToString("###,###0 VNĐ");
        }
        private void HienThiChiTietThuePhong()
        {
            tbRoom.Rows.Clear();
            List<ChiTietThuePhongDTO> cttps = cttP.GetDSListCTTP(maCTT);
            List<PhongDTO> phongs = phong.getListPhong_DTO();
            var items = from cttp in cttps
                        join phong in phongs on cttp.MaP equals phong.MaP
                        select new
                        {
                            maP = cttp.MaP,
                            tenP = phong.TenP,
                            tinhTrang = cttp.TinhTrang,
                            loaiHinhThue = cttp.LoaiHinhThue,
                            ngayThue = cttp.NgayThue,
                            ngayTra = cttp.NgayTra,
                            ngayCheckOut = cttp.NgayCheckOut,
                            giaThue = cttp.GiaThue
                        };
            int stt = 0;
            foreach (var item in items)
            {
                string tinhTrang = "";
                if (item.tinhTrang == 0)
                {
                    tinhTrang = "Đang xử lý";
                }
                else if (item.tinhTrang == 1)
                {
                    tinhTrang = "Đang được thuê";
                }
                else
                {
                    tinhTrang = "Đã trả phòng";
                }
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
                if (item.ngayCheckOut == null)
                {
                    if (item.ngayTra == null)
                    {
                        tbRoom.Rows.Add(++stt, item.maP, item.tenP, tinhTrang, loaiHinhThue, item.ngayThue.ToString("dd/MM/yyyy HH:mm:ss"), "", "", "Chưa tính");
                    }
                    else
                    {
                        tbRoom.Rows.Add(++stt, item.maP, item.tenP, tinhTrang, loaiHinhThue, item.ngayThue.ToString("dd/MM/yyyy HH:mm:ss"), item.ngayTra?.ToString("dd/MM/yyyy HH:mm:ss"), "", item.giaThue.ToString("###,###0 VNĐ"));
                    }
                }
                else
                {
                    tbRoom.Rows.Add(++stt, item.maP, item.tenP, tinhTrang, loaiHinhThue, item.ngayThue.ToString("dd/MM/yyyy HH:mm:ss"), item.ngayTra?.ToString("dd/MM/yyyy HH:mm:ss"), item.ngayCheckOut?.ToString("dd/MM/yyyy HH:mm:ss"), item.giaThue.ToString("###,###0 VNĐ"));
                }
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
                tbService.Rows.Add(++stt, item.maDV, item.tenDV, item.ngaySuDung.ToString("dd/MM/yyyy"), item.soLuong, item.donGia.ToString("###,###0 VNĐ"), item.thanhTien.ToString("###,###0 VNĐ"));
            }
            tbService.ClearSelection();
            renderTongTien();
        }

        private void frmChiTietPhieuThue_Load(object sender, EventArgs e)
        {
            tbRoom.ClearSelection();
            tbService.ClearSelection();
        }

        private void tbRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = 10;
            if (e.ColumnIndex == index && e.RowIndex >= 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                int ans = message.ShowDialog("Thông báo", "Cảnh báo", "Bạn có muốn xóa phòng thuê này", MessageBoxDialog.WARNING, MessageBoxDialog.YES_NO, "Đồng ý", "Không đồng ý", "");
                if (ans == MessageBoxDialog.YES_OPTION)
                {
                    if (tbRoom.SelectedRows[0].Cells[3].Value.ToString().Equals("Đang xử lý"))
                    {
                        cttP.DeleteCTTP(maCTT, tbRoom.SelectedRows[0].Cells[1].Value.ToString(), DateTime.Parse(tbRoom.SelectedRows[0].Cells[5].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss"));
                        MessageBoxDialog messageError = new MessageBoxDialog();
                        messageError.ShowDialog("Thông báo", "Thông báo", "Xóa phòng này thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                        HienThiChiTietThuePhong();
                    }
                    else
                    {
                        MessageBoxDialog messageError = new MessageBoxDialog();
                        messageError.ShowDialog("Thông báo", "Thông báo", "Phòng này " + tbRoom.SelectedRows[0].Cells[3].Value.ToString() + " không thể xóa", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                    }
                }
                else
                {
                    tbRoom.ClearSelection();
                }
            }
            int indexUpdate = 9;
            if (e.ColumnIndex == indexUpdate && e.RowIndex >= 0)
            {
                ctmnRoom.Show(MousePosition);
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

        private void lấyPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbRoom.SelectedRows.Count > 0)
            {
                if (tbRoom.SelectedRows[0].Cells[3].Value.ToString().Equals("Đang xử lý"))
                {
                    string maP = tbRoom.SelectedRows[0].Cells[1].Value.ToString();
                    string ngayThue = DateTime.ParseExact(tbRoom.SelectedRows[0].Cells[5].Value.ToString().Trim(), "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                    cttP.UpdateTinhTrang(maCTT, maP, ngayThue, "1");
                    phong.SuaTinhTrang(maP, "1");
                    MessageBoxDialog messageError = new MessageBoxDialog();
                    messageError.ShowDialog("Thông báo", "Thành công", "Lấy phòng cho khách thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                    HienThiChiTietThuePhong();
                }
                else
                {
                    MessageBoxDialog messageError = new MessageBoxDialog();
                    messageError.ShowDialog("Thông báo", "Thông báo", "Phòng này " + tbRoom.SelectedRows[0].Cells[3].Value.ToString() + " không thể lấy", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                }
            }
        }

        private void trảPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbRoom.SelectedRows.Count > 0)
            {
                if (tbRoom.SelectedRows[0].Cells[3].Value.ToString().Equals("Đang được thuê"))
                {
                    string maP = tbRoom.SelectedRows[0].Cells[1].Value.ToString();
                    string ngayThue = DateTime.ParseExact(tbRoom.SelectedRows[0].Cells[5].Value.ToString().Trim(), "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                    cttP.UpdateTinhTrang(maCTT, maP, ngayThue, "2");
                    if (!tbRoom.SelectedRows[0].Cells[4].Value.ToString().Equals("Khác"))
                    {
                        cttP.UpdateCheckOut(true, maCTT, maP, ngayThue, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "0");
                    }
                    else
                    {
                        var item = from cttPhong in cttP.GetDSListCTTP()
                                   where cttPhong.MaCTT == maCTT && cttPhong.MaP == maP && cttPhong.NgayThue.ToString("yyyy-MM-dd HH:mm:ss") == ngayThue
                                   select cttPhong;
                        var it = item.First();
                        DateTime dateTimeTra = DateTime.Now;
                        TimeSpan sub2Day = dateTimeTra.Subtract(it.NgayThue);
                        int gia = 0;
                        switch (sub2Day.Hours)
                        {
                            case 1:
                                gia = int.Parse((it.GiaThue * 0.15).ToString()) + it.GiaThue * sub2Day.Days;
                                break;
                            case 2:
                                gia = int.Parse((it.GiaThue * 0.2).ToString()) + it.GiaThue * sub2Day.Days;
                                break;
                            case 3:
                                gia = int.Parse((it.GiaThue * 0.25).ToString()) + it.GiaThue * sub2Day.Days;
                                break;
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                                gia = int.Parse((it.GiaThue * 0.5).ToString()) + it.GiaThue * sub2Day.Days;
                                break;
                            default:
                                gia = it.GiaThue + it.GiaThue * sub2Day.Days;
                                break;
                        }
                        cttP.UpdateCheckOut(false, maCTT, maP, ngayThue, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), gia.ToString());
                    }
                    phong.SuaTinhTrang(maP, "2");
                    MessageBoxDialog messageError = new MessageBoxDialog();
                    messageError.ShowDialog("Thông báo", "Thành công", "Trả phòng cho khách thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                    HienThiChiTietThuePhong();
                }
                else
                {
                    MessageBoxDialog messageError = new MessageBoxDialog();
                    messageError.ShowDialog("Thông báo", "Thông báo", "Phòng này " + tbRoom.SelectedRows[0].Cells[3].Value.ToString() + " không trả lấy", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                }
            }
        }

        private void đổiPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            MessageBoxDialog message = new MessageBoxDialog();
            int ans = message.ShowDialog("Thông báo", "Thông báo", "Bạn có muốn thanh toán phiếu thuê này không?", MessageBoxDialog.INFO, MessageBoxDialog.YES_NO, "Đồng ý", "Không đồng ý", "");
            if (ans == MessageBoxDialog.YES_OPTION)
            {
                for (int i = 0; i < tbRoom.Rows.Count; i++)
                {
                    if (tbRoom.Rows[i].Cells[3].Value.ToString().Equals("Đang được thuê"))
                    {
                        MessageBoxDialog messageError = new MessageBoxDialog();
                        messageError.ShowDialog("Thông báo", "Thông báo", "Thanh toán không thành công vì còn phòng đang được thuê", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                        return;
                    }
                }
                if (tbRoom.Rows.Count == 0 && tbService.Rows.Count == 0)
                {
                    MessageBoxDialog messageError = new MessageBoxDialog();
                    messageError.ShowDialog("Thông báo", "Thông báo", "Thanh toán không thành công vì phiếu thuê không thuê gì hết", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                    return;
                }
                if (tbService.Rows.Count == 0)
                {
                    int countRow = 0;
                    for (int i = 0; i < tbRoom.Rows.Count; i++)
                    {
                        if (tbRoom.Rows[i].Cells[3].Value.ToString().Equals("Đang xử lý"))
                        {
                            countRow++;
                        }
                    }
                    if (countRow == tbRoom.Rows.Count)
                    {
                        MessageBoxDialog messageError = new MessageBoxDialog();
                        messageError.ShowDialog("Thông báo", "Thông báo", "Thanh toán không thành công vì còn phòng chưa được thuê", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                        return;
                    }
                }
                ThanhToan thanhToan = new ThanhToan(maCTT);
                thanhToan.ShowDialog();
                if (thanhToan.DialogResult == DialogResult.Yes)
                {
                    int select = frmChiTietThue.cbMaCTT.SelectedIndex;
                    frmChiTietThue.cbMaCTT.SelectedIndex = -1;
                    frmChiTietThue.cbMaCTT.SelectedIndex = select;
                }
            }
        }

        private void tbService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = 8;
            if (e.ColumnIndex == index && e.RowIndex >= 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                int ans = message.ShowDialog("Thông báo", "Cảnh báo", "Bạn có muốn xóa dịch vụ thuê này", MessageBoxDialog.WARNING, MessageBoxDialog.YES_NO, "Đồng ý", "Không đồng ý", "");
                if (ans == MessageBoxDialog.YES_OPTION)
                {
                    cttDV.DeleteCTTDV(maCTT, tbService.SelectedRows[0].Cells[1].Value.ToString(), DateTime.Parse(tbService.SelectedRows[0].Cells[3].Value.ToString()).ToString("yyyy-MM-dd"));
                    MessageBoxDialog messageError = new MessageBoxDialog();
                    messageError.ShowDialog("Thông báo", "Thông báo", "Xóa dịch vụ này thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                    HienThiChiTietThueDichVu();
                }
                else
                {
                    tbService.ClearSelection();
                }
            }
            int indexUpdate = 7;
            if (e.ColumnIndex == indexUpdate && e.RowIndex >= 0)
            {
                formInput frmInput = new formInput();
                frmInput.ShowDialog();
                if(frmInput.DialogResult == DialogResult.Yes)
                {
                    int soLuong = frmInput.number;
                    cttDV.SuaSoLuongCTTDV(maCTT, tbService.SelectedRows[0].Cells[1].Value.ToString(), DateTime.Parse(tbService.SelectedRows[0].Cells[3].Value.ToString()).ToString("yyyy-MM-dd"), soLuong.ToString());
                    HienThiChiTietThueDichVu();
                    MessageBoxDialog messageError = new MessageBoxDialog();
                    messageError.ShowDialog("Thông báo", "Thông báo", "Sửa dịch vụ này thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                } else
                {
                    tbService.ClearSelection();
                }
            }
        }
    }
}
