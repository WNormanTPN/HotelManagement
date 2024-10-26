using BUS;
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
    public partial class BookingList : Form
    {
        KhachHangBUS khachHang = new KhachHangBUS();
        NhanVienBUS nhanVien = new NhanVienBUS();
        ChiTietThueBUS chiTietThue = new ChiTietThueBUS();
        public BookingList()
        {
            InitializeComponent();
            HienThiDSChiTietThue();
            dateTime_NgayLap.CustomFormat = " ";
        }
        public void HienThiDSChiTietThue()
        {
            var cttAll = from ctt in chiTietThue.getDSChiTietThue()
                         join kh in khachHang.GetDSKH() on ctt.MaKH equals kh.MaKH
                         join nv in nhanVien.getDSNhanVien() on ctt.MaNV equals nv.MaNV
                         where ctt.XuLy == 0
                         orderby ctt.TinhTrangXuLy ascending, ctt.NgayLapPhieu ascending
                         select new
                         {
                             maCTT = ctt.MaCTT,
                             maKH = ctt.MaKH,
                             tenKH = kh.TenKH,
                             maNV = ctt.MaNV,
                             tenNV = nv.TenNV,
                             ngayLapPhieu = ctt.NgayLapPhieu,
                             tienDatCoc = ctt.TienDatCoc,
                             tinhTrangXuLy = ctt.TinhTrangXuLy
                         };
            tbRoom.Rows.Clear();
            int stt = 0;
            foreach (var ctt in cttAll)
            {
                if (ctt.tinhTrangXuLy == 0)
                {
                    tbRoom.Rows.Add(++stt, ctt.maCTT, ctt.maKH, ctt.tenKH, ctt.maNV, ctt.tenNV, ctt.ngayLapPhieu.ToString("dd/MM/yyyy HH:mm:ss"), ctt.tienDatCoc.ToString("###,###0 VNĐ"), "Chưa xử lý");
                }
                else
                {
                    tbRoom.Rows.Add(++stt, ctt.maCTT, ctt.maKH, ctt.tenKH, ctt.maNV, ctt.tenNV, ctt.ngayLapPhieu.ToString("dd/MM/yyyy HH:mm:ss"), ctt.tienDatCoc.ToString("###,###0 VNĐ"), "Đã xử lý");
                }
            }
            tbRoom.ClearSelection();
        }

        private void BookingList_Load(object sender, EventArgs e)
        {
            tbRoom.ClearSelection();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (tbRoom.SelectedRows.Count > 0)
            {
                if (tbRoom.SelectedRows[0].Cells[8].Value.ToString().Equals("Chưa xử lý"))
                {
                    frmChiTietThue frmBookingNew = new frmChiTietThue(0, tbRoom.SelectedRows[0].Cells[1].Value.ToString());
                    frmBookingNew.TopLevel = false;
                    QLKS_Form form = (QLKS_Form)getParentForm(this);
                    Panel pnContent = form.pnContent;
                    pnContent.Controls.Clear();
                    pnContent.Controls.Add(frmBookingNew);
                    frmBookingNew.Dock = DockStyle.Fill;
                    frmBookingNew.Show();
                }
                else
                {
                    frmChiTietThue frmBookingNew = new frmChiTietThue(1, tbRoom.SelectedRows[0].Cells[1].Value.ToString());
                    frmBookingNew.TopLevel = false;
                    QLKS_Form form = (QLKS_Form)getParentForm(this);
                    Panel pnContent = form.pnContent;
                    pnContent.Controls.Clear();
                    pnContent.Controls.Add(frmBookingNew);
                    frmBookingNew.Dock = DockStyle.Fill;
                    frmBookingNew.Show();
                }
            }
            else
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Thông báo", "Vui lòng chọn phiếu thuê muốn xem chi tiết", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
            }
        }

        private Control getParentForm(Control a)
        {
            if (a is QLKS_Form)
            {
                return a;
            }
            return getParentForm(a.Parent);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txt_MaCTT.Text = "";
            txt_MaKH.Text = "";
            txt_MaNV.Text = "";
            txt_TenKH.Text = "";
            txt_TenNV.Text = "";
            cb_TienCoc.SelectedIndex = -1;
            cb_TinhTrangXuLy.SelectedIndex = -1;
            dateTime_NgayLap.CustomFormat = " ";
            HienThiDSChiTietThue();
            searchWithID(true);
            searchWithOther(true);
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

        private void tbRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = 9;
            if (e.ColumnIndex == index && e.RowIndex >= 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                int ans = message.ShowDialog("Thông báo", "Cảnh báo", "Bạn có muốn xóa phiếu thuê này", MessageBoxDialog.WARNING, MessageBoxDialog.YES_NO, "Đồng ý", "Không đồng ý", "");
                if (ans == MessageBoxDialog.YES_OPTION)
                {
                    if (tbRoom.SelectedRows[0].Cells[8].Value.ToString().Equals("Chưa xử lý"))
                    {
                        MessageBoxDialog messageError = new MessageBoxDialog();
                        messageError.ShowDialog("Thông báo", "Thông báo", "Xóa phiếu thuê này không thành công vì chưa xử lý", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                    }
                    else
                    {
                        chiTietThue.DeleteCTT(tbRoom.SelectedRows[0].Cells[1].Value.ToString());
                        MessageBoxDialog messageSuccess = new MessageBoxDialog();
                        messageSuccess.ShowDialog("Thông báo", "Thành công", "Xóa phiếu thuê này thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                        HienThiDSChiTietThue();
                    }
                }
                tbRoom.ClearSelection();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var list = from ctt in chiTietThue.getDSChiTietThue()
                         join kh in khachHang.GetDSKH() on ctt.MaKH equals kh.MaKH
                         join nv in nhanVien.getDSNhanVien() on ctt.MaNV equals nv.MaNV
                         where ctt.XuLy == 0
                         orderby ctt.TinhTrangXuLy ascending, ctt.NgayLapPhieu ascending
                         select new
                         {
                             maCTT = ctt.MaCTT,
                             maKH = ctt.MaKH,
                             tenKH = kh.TenKH,
                             maNV = ctt.MaNV,
                             tenNV = nv.TenNV,
                             ngayLapPhieu = ctt.NgayLapPhieu,
                             tienDatCoc = ctt.TienDatCoc,
                             tinhTrangXuLy = ctt.TinhTrangXuLy
                         };
            int start = 0, end = 0;
            if (cb_TienCoc.SelectedIndex == 0)
            {
                end = int.Parse(cb_TienCoc.SelectedItem.ToString().Split(' ')[1].Replace(",", ""));
            }
            else if (cb_TienCoc.SelectedIndex == 4)
            {
                start = int.Parse(cb_TienCoc.SelectedItem.ToString().Split(' ')[1].Replace(",", ""));
            }
            else if (cb_TienCoc.SelectedIndex == 1 || cb_TienCoc.SelectedIndex == 2 || cb_TienCoc.SelectedIndex == 3)
            {
                start = int.Parse(cb_TienCoc.SelectedItem.ToString().Split(' ')[1].Replace(",", ""));
                end = int.Parse(cb_TienCoc.SelectedItem.ToString().Split(' ')[4].Replace(",", ""));
            }
            var ctts = list.Where(room => txt_MaCTT.Text.Trim().Length == 0 || room.maCTT.ToUpper().Contains(txt_MaCTT.Text.Trim().ToUpper()))
                           .Where(room => txt_MaKH.Text.Trim().Length == 0 || room.maKH.ToUpper().Contains(txt_MaKH.Text.Trim().ToUpper()))
                           .Where(room => txt_TenKH.Text.Trim().Length == 0 || room.tenKH.ToUpper().Contains(txt_TenKH.Text.Trim().ToUpper()))
                           .Where(room => txt_MaNV.Text.Trim().Length == 0 || room.maNV.ToUpper().Contains(txt_MaNV.Text.Trim().ToUpper()))
                           .Where(room => txt_TenNV.Text.Trim().Length == 0 || room.tenNV.ToUpper().Contains(txt_TenNV.Text.Trim().ToUpper()))
                           .Where(room => cb_TinhTrangXuLy.SelectedIndex == -1 || room.tinhTrangXuLy == cb_TinhTrangXuLy.SelectedIndex)
                           .Where(room => room.ngayLapPhieu.ToString("yyyy-MM-dd") == dateTime_NgayLap.Value.ToString("yyyy-MM-dd"))
                           .Where(room => cb_TienCoc.SelectedIndex == -1 || (cb_TienCoc.SelectedIndex == 4 && room.tienDatCoc >= start)
                                 || (room.tienDatCoc >= start && room.tienDatCoc <= end));
            if (ctts.ToList().Count == 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Thông báo", "Không tìm thấy phòng phù hợp", MessageBoxDialog.INFO, MessageBoxDialog.YES, "Đóng", "", "");
                btnReset.PerformClick();
            }
            else
            {
                tbRoom.Rows.Clear();
                int stt = 0;
                foreach (var ctt in ctts)
                {
                    if (ctt.tinhTrangXuLy == 0)
                    {
                        tbRoom.Rows.Add(++stt, ctt.maCTT, ctt.maKH, ctt.tenKH, ctt.maNV, ctt.tenNV, ctt.ngayLapPhieu.ToString("dd/MM/yyyy HH:mm:ss"), ctt.tienDatCoc.ToString("###,###0 VNĐ"), "Chưa xử lý");
                    }
                    else
                    {
                        tbRoom.Rows.Add(++stt, ctt.maCTT, ctt.maKH, ctt.tenKH, ctt.maNV, ctt.tenNV, ctt.ngayLapPhieu.ToString("dd/MM/yyyy HH:mm:ss"), ctt.tienDatCoc.ToString("###,###0 VNĐ"), "Đã xử lý");
                    }
                }
                tbRoom.ClearSelection();
            }    
        }

        private void dateTime_NgayLap_ValueChanged(object sender, EventArgs e)
        {
            dateTime_NgayLap.CustomFormat = "dd/MM/yyyy";
            searchWithOther(true);
            searchWithID(false);
        }

        private void txt_MaCTT_TextChanged(object sender, EventArgs e)
        {
            if (txt_MaCTT.Text.Length == 0)
            {
                searchWithID(true);
                searchWithOther(true);
            }
            else
            {
                searchWithID(true);
                searchWithOther(false);
            }
        }

        private void triggerSearchWithOtherMode(object sender, EventArgs e)
        {
            if (txt_MaKH.Text.Length == 0 &&
                txt_MaNV.Text.Length == 0 &&
                txt_TenKH.Text.Length == 0 &&
                txt_TenNV.Text.Length == 0 &&
                cb_TienCoc.SelectedIndex == -1 &&
                cb_TinhTrangXuLy.SelectedIndex == -1 &&
                dateTime_NgayLap.CustomFormat == " ")
            {
                searchWithOther(true);
                searchWithID(true);
            }
            else
            {
                searchWithOther(true);
                searchWithID(false);
            }
        }

        private void searchWithID(bool enable)
        {
            if(!enable) txt_MaCTT.Text = "";
            txt_MaCTT.Enabled = enable;
        }

        private void searchWithOther(bool enable)
        {
            if (!enable)
            {
                txt_MaKH.Text = "";
                txt_TenKH.Text = "";
                txt_MaNV.Text = "";
                txt_TenNV.Text = "";
                cb_TienCoc.SelectedIndex = -1;
                cb_TinhTrangXuLy.SelectedIndex = -1;
                dateTime_NgayLap.CustomFormat = " ";
            }
            txt_MaKH.Enabled = enable;
            txt_TenKH.Enabled = enable;
            txt_MaNV.Enabled = enable;
            txt_TenNV.Enabled = enable;
            cb_TienCoc.Enabled = enable;
            cb_TinhTrangXuLy.Enabled = enable;
            dateTime_NgayLap.Enabled = enable;
        }

        private void turnOnSearchWithOtherMode(object sender, EventArgs e)
        {

        }
    }
}
