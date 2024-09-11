using BUS;
using GUI.GUI_COMPONENT;
using GUI.GUI_CUSTOMER;
using GUI.GUI_STAFF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Excel = Microsoft.Office.Interop.Excel;

namespace GUI.GUI_CUSTOMER
{
    public partial class CustomerForm : Form
    {

        KhachHangBUS khachHangBUS = new KhachHangBUS();

        public CustomerForm()
        {
            InitializeComponent();
            onLoad();
        }

        private void onLoad()
        {
            dataKhachHang.Rows.Clear();
            dtpNgaySinhTu.Checked = false;
            dtpNgaySinhTu.CustomFormat = " ";
            dtpNgaySinhTu.Format = DateTimePickerFormat.Custom;
            dtpNgaySinhDen.Checked = false;
            dtpNgaySinhDen.CustomFormat = " ";
            dtpNgaySinhDen.Format = DateTimePickerFormat.Custom;
            var dt = khachHangBUS.getKhachHang();
            int stt = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var makh = dt.Rows[i][0].ToString();
                var tenkh = dt.Rows[i][1].ToString();
                var cmnd = dt.Rows[i][2].ToString();
                var gt = dt.Rows[i][3].ToString();
                string gioitinh;
                if (gt == "0")
                    gioitinh = "Nam";
                else
                    gioitinh = "Nữ";
                var sdt = dt.Rows[i][4].ToString();
                var ngaysinh = DateTime.Parse(dt.Rows[i][7].ToString()).ToString("dd/MM/yyyy");
                var quequan = dt.Rows[i][5].ToString();
                var quoctich = dt.Rows[i][6].ToString();
                dataKhachHang.Rows.Add(stt++, makh, tenkh, cmnd, ngaysinh, gioitinh, sdt, quequan, quoctich);
            }
            dataKhachHang.ClearSelection();
        }

        private void onLoad(DataTable dt)
        {
            dataKhachHang.Rows.Clear();
            int stt = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var makh = dt.Rows[i][0].ToString();
                var tenkh = dt.Rows[i][1].ToString();
                var gt = dt.Rows[i][3].ToString();
                string gioitinh;
                if (gt == "0")
                    gioitinh = "Nam";
                else
                    gioitinh = "Nữ";
                var cmnd = dt.Rows[i][2].ToString();
                var ngaysinh = DateTime.Parse(dt.Rows[i][7].ToString()).ToString("dd/MM/yyyy");
                var sdt = dt.Rows[i][4].ToString();
                var quequan = dt.Rows[i][5].ToString();
                var quoctich = dt.Rows[i][6].ToString();
                dataKhachHang.Rows.Add(stt, makh, tenkh, cmnd, ngaysinh, gioitinh, sdt, quequan, quoctich);
            }
            dataKhachHang.ClearSelection();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            dataKhachHang.ClearSelection();
        }

        private void buttonRounded7_Click(object sender, EventArgs e)
        {
            if (dataKhachHang.SelectedRows.Count == 0)
            {
                MessageBoxDialog dl = new MessageBoxDialog();
                dl.ShowDialog("Thông báo", "Lỗi chọn khách hàng", "Vui lòng chọn khách hàng muốn sửa", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đồng ý", "", "");
                return;
            }
            frmUpdateCustomer addCustomer = new frmUpdateCustomer(dataKhachHang.SelectedRows[0].Cells[1].Value.ToString());
            addCustomer.ShowDialog();
            if (addCustomer.DialogResult == DialogResult.Yes)
            {
                dataKhachHang.ClearSelection();
                onLoad();
            }
            dataKhachHang.ClearSelection();
        }

        private void dtpNgaySinhTu_ValueChanged(object sender, EventArgs e)
        {
            dtpNgaySinhTu.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpNgaySinhDen_ValueChanged(object sender, EventArgs e)
        {
            dtpNgaySinhDen.CustomFormat = "dd/MM/yyyy";
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var makh = txtMaKH.Text;
            var tenkh = txtTenKH.Text;
            var gioitinh = cbGioiTinh.SelectedIndex;
            var cmnd = txtCMND.Text;
            var sdt = txtSDT.Text;
            var quequan = txtQueQuan.Text;
            var quoctich = txtQuocTich.Text;
            var ngaysinhtu = (dtpNgaySinhTu.CustomFormat.ToString().Length == 1) ? DateTime.MinValue : dtpNgaySinhTu.Value;
            var ngaysinhden = (dtpNgaySinhDen.CustomFormat.ToString().Length == 1) ? DateTime.MinValue : dtpNgaySinhDen.Value;

            var dt = khachHangBUS.findKhachHang(makh, tenkh, cmnd, gioitinh, sdt, quequan, quoctich, ngaysinhtu, ngaysinhden);
            onLoad(dt);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = String.Empty;
            txtTenKH.Text = String.Empty;
            cbGioiTinh.SelectedItem = null;
            cbGioiTinh.SelectedIndex = -1;
            cbGioiTinh.Text = String.Empty;
            dtpNgaySinhTu.Value = DateTime.Now;
            dtpNgaySinhDen.Value = DateTime.Now;
            txtCMND.Text = String.Empty;
            txtQueQuan.Text = String.Empty;
            txtQuocTich.Text = String.Empty;
            txtSDT.Text = String.Empty;
            dataKhachHang.ClearSelection();
            onLoad();
        }

        private void buttonRounded2_Click(object sender, EventArgs e)
        {
            {
                var message = new MessageBoxDialog();
                var result = message.ShowDialog("Thông báo", "Xuất file", "Bạn có muốn xuất file Excel không?", MessageBoxDialog.INFO, MessageBoxDialog.YES_NO, "Có", "Không", "");
                if (result == MessageBoxDialog.YES)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Excel Documents (*.xls)|*.xls";
                    sfd.FileName = "Inventory_Adjustment_Export.xls";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // Copy DataGridView results to clipboard
                        copyAlltoClipboard();

                        object misValue = System.Reflection.Missing.Value;
                        Excel.Application xlexcel = new Excel.Application();
                        xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
                        Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
                        Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                        // Format column D as text before pasting results, this was required for my data
                        Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
                        rng.NumberFormat = "@";

                        // Paste clipboard results to worksheet range
                        Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
                        CR.Select();
                        xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                        // For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
                        // Delete blank column A and select cell A1
                        Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
                        delRng.Delete(Type.Missing);
                        xlWorkSheet.get_Range("A1").Select();

                        // Save the excel file under the captured location from the SaveFileDialog
                        xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        xlexcel.DisplayAlerts = true;
                        xlWorkBook.Close(true, misValue, misValue);
                        xlexcel.Quit();

                        releaseObject(xlWorkSheet);
                        releaseObject(xlWorkBook);
                        releaseObject(xlexcel);

                        // Clear Clipboard and DataGridView selection
                        Clipboard.Clear();
                        dataKhachHang.ClearSelection();

                        // Open the newly saved excel file
                        if (File.Exists(sfd.FileName))
                            System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }

        private void copyAlltoClipboard()
        {
            dataKhachHang.SelectAll();
            DataObject dataObj = dataKhachHang.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        private void buttonRounded1_Click(object sender, EventArgs e)
        {
            {
                var message = new MessageBoxDialog();
                var result = message.ShowDialog("Thông báo", "Nhập file", "Bạn có muốn nhập file Excel không?", MessageBoxDialog.INFO, MessageBoxDialog.YES_NO, "Có", "Không", "");
                if (result == MessageBoxDialog.YES)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "Excel Documents (*.xls)|*.xls";
                    ofd.FileName = "Inventory_Adjustment_Export.xls";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }
        }

        private void dataKhachHang_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dataKhachHang.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dataKhachHang.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
                }
                else
                {
                    dataKhachHang.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
    }
}