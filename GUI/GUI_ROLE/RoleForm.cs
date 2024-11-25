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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI.GUI_ROLE
{
    public partial class RoleForm : Form
    {
        NhanVienBUS nv = new NhanVienBUS();
        TaiKhoanBUS tk = new TaiKhoanBUS();
        public RoleForm()
        {
            InitializeComponent();
            HienThiAccount("");
            HienThiDataPQ();
            HienThiChucNang();
        }
        private void HienThiDataPQ()
        {
            PhanQuyenBUS pq = new PhanQuyenBUS();
            DataTable dt = pq.GetListPQ();
            cbRole.DataSource = dt;
            cbRole.DisplayMember = "TenPQ";
            cbRole.ValueMember = "MaPQ";
        }
        private void HienThiAccount(string search)
        {
            tbAccount.Rows.Clear();
            List<NhanVienDTO> listNV = nv.getDSNhanVien();
            List<TaiKhoanDTO> listTK = tk.GetListTaiKhoan();
            var item = from nv in listNV
                       join tk in listTK on nv.MaNV equals tk.MaNV into gj
                       from subtk in gj.DefaultIfEmpty()
                       select new
                       {
                           maNV = nv.MaNV,
                           tenNV = nv.TenNV,
                           taiKhoan = (subtk == null) ? "Chưa có" : subtk.TaiKhoan,
                           tinhTrang = (subtk == null) ? -1 : subtk.TinhTrang
                       };
            int stt = 0;
            foreach(var it in item)
            {
                if(it.maNV.ToUpper().Contains(search.ToUpper()) ||
                    it.tenNV.ToUpper().Contains(search.ToUpper())) {
                    string tinhTrang = "";
                    if (it.tinhTrang == -1)
                    {
                        tinhTrang = "Chưa thiết lập";
                    }
                    else if (it.tinhTrang == 0)
                    {
                        tinhTrang = "Đang hoạt động";
                    }
                    else
                    {
                        tinhTrang = "Đang bị khóa";
                    }
                    tbAccount.Rows.Add(++stt, it.maNV, it.tenNV, it.taiKhoan, tinhTrang);
                } 
            }
            tbAccount.ClearSelection();
        }

        private void RoleForm_Load(object sender, EventArgs e)
        {
            tbAccount.ClearSelection();
        }

        private void tbAccount_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < tbAccount.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    tbAccount.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
                }
                else
                {
                    tbAccount.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void tbAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = 5;
            if (e.ColumnIndex == index && e.RowIndex >= 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                int ans = message.ShowDialog("Thông báo", "Thông báo", "Bạn có muốn tạo tài khoản cho nhân viên này", MessageBoxDialog.WARNING, MessageBoxDialog.YES_NO, "Đồng ý", "Không đồng ý", "");
                if (ans == MessageBoxDialog.YES_OPTION)
                {
                    if (tbAccount.SelectedRows[0].Cells[3].Value.ToString().Equals("Chưa có"))
                    {
                        FormCreateAccount crtAccount = new FormCreateAccount(tbAccount.SelectedRows[0].Cells[1].Value.ToString());
                        crtAccount.ShowDialog();
                        if (crtAccount.DialogResult == DialogResult.Yes)
                        {
                            MessageBoxDialog messageSuccess = new MessageBoxDialog();
                            messageSuccess.ShowDialog("Thông báo", "Thành công", "Tạo tài khoản mới thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                            HienThiAccount("");
                        }
                        tbAccount.ClearSelection();
                    }
                    else
                    {
                        MessageBoxDialog messageError = new MessageBoxDialog();
                        messageError.ShowDialog("Thông báo", "Thông báo", "Nhân viên này đã có tài khoản không thể tạo", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                    }
                }
                else
                {
                    tbAccount.ClearSelection();
                }
            }
            int indexUpdate = 6;
            if (e.ColumnIndex == indexUpdate && e.RowIndex >= 0)
            {
                if (tbAccount.SelectedRows[0].Cells[4].Value.ToString().Equals("Đang bị khóa"))
                {
                    mởKhóaTàiKhoảnToolStripMenuItem.Visible = true;
                    khóaTàiKhoảnToolStripMenuItem.Visible = false;
                } else
                {
                    mởKhóaTàiKhoảnToolStripMenuItem.Visible = false;
                    khóaTàiKhoảnToolStripMenuItem.Visible = true;
                }
                ctmnUpdate.Show(MousePosition);
            }
            int indexDelete = 7;
            if (e.ColumnIndex == indexDelete && e.RowIndex >= 0)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                int ans = message.ShowDialog("Thông báo", "Cảnh báo", "Bạn có muốn xóa tài khoản cho nhân viên này", MessageBoxDialog.WARNING, MessageBoxDialog.YES_NO, "Đồng ý", "Không đồng ý", "");
                if (ans == MessageBoxDialog.YES_OPTION)
                {
                    if (!tbAccount.SelectedRows[0].Cells[3].Value.ToString().Equals("Chưa có"))
                    {
                        TaiKhoanBUS tk = new TaiKhoanBUS();
                        tk.XoaTaiKhoan(tbAccount.SelectedRows[0].Cells[3].Value.ToString());
                        MessageBoxDialog messageSuccess = new MessageBoxDialog();
                        messageSuccess.ShowDialog("Thông báo", "Thành công", "Xóa tài khoản này thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                        HienThiAccount("");
                    }
                    else
                    {
                        MessageBoxDialog messageError = new MessageBoxDialog();
                        messageError.ShowDialog("Thông báo", "Thông báo", "Nhân viên này chưa có tài khoản không thể xóa", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                        tbAccount.ClearSelection();
                    }
                }
                else
                {
                    tbAccount.ClearSelection();
                }
            }
        }

        private void khóaTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(tbAccount.SelectedRows.Count > 0)
            {
                TaiKhoanBUS tk = new TaiKhoanBUS();
                var tenTK = tbAccount.SelectedRows[0].Cells[3].Value.ToString();
                if (!tenTK.Equals("Chưa có"))
                {
                    tk.KhoaTaiKhoan(tenTK);
                    MessageBoxDialog messageSuccess = new MessageBoxDialog();
                    messageSuccess.ShowDialog("Thông báo", "Thành công", "Khóa tài khoản này thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                    HienThiAccount("");
                }
                else
                {
                    MessageBoxDialog messageSuccess = new MessageBoxDialog();
                    messageSuccess.ShowDialog("Thông báo", "Thất bại", "Chưa có tài khoản, không thể khóa", MessageBoxDialog.ERROR, MessageBoxDialog.YES, "Đóng", "", "");
                }
            }
            tbAccount.ClearSelection();
        }

        private void phânQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbAccount.SelectedRows.Count > 0)
            {
                FormCreateAccount frm = new FormCreateAccount(tbAccount.SelectedRows[0].Cells[3].Value.ToString(), 1);
                frm.ShowDialog();
                if(frm.DialogResult == DialogResult.Yes)
                {
                    MessageBoxDialog messageSuccess = new MessageBoxDialog();
                    messageSuccess.ShowDialog("Thông báo", "Thành công", "Đổi phân quyền cho tài khoản này thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                    HienThiAccount("");
                }
            }
            tbAccount.ClearSelection();
        }

        private void mởKhóaTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbAccount.SelectedRows.Count > 0)
            {
                TaiKhoanBUS tk = new TaiKhoanBUS();
                tk.MoKhoaTaiKhoan(tbAccount.SelectedRows[0].Cells[3].Value.ToString());
                MessageBoxDialog messageSuccess = new MessageBoxDialog();
                messageSuccess.ShowDialog("Thông báo", "Thành công", "Mở khóa tài khoản này thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                HienThiAccount("");
            }
            tbAccount.ClearSelection();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim().Length == 0)
            {
                HienThiAccount(""); 
            } else
            {
                HienThiAccount(textBox1.Text.Trim());
            }
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(textBox1.Text.Trim().Equals("Vui lòng nhập mã/tên nhân viên cần tìm..."))
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim().Length == 0)
            {
                textBox1.Text = "Vui lòng nhập mã/tên nhân viên cần tìm...";
                HienThiAccount("");
            }
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiChucNang();
        }
        private void HienThiChucNang()
        {
            ChucNangBUS cn = new ChucNangBUS();
            DataTable dt = cn.GetTBChucNang(cbRole.SelectedValue.ToString());
            tbChucNang.Rows.Clear();
            int stt = 0;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                tbChucNang.Rows.Add(++stt, dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), bool.Parse(dt.Rows[i][2].ToString()));
            }
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            FormAddNewRole frm = new FormAddNewRole();
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.Yes)
            {
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Thành công", "Thêm vị trí vai trò mới thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                HienThiDataPQ();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBoxDialog messageQuestion = new MessageBoxDialog();
            int ans = messageQuestion.ShowDialog("Thông báo", "Thông báo", "Bạn có muốn lưu trạng thái này không?", MessageBoxDialog.INFO, MessageBoxDialog.YES_NO, "Đồng ý", "Không đồng ý", "");
            if(ans == MessageBoxDialog.YES_OPTION)
            {
                for(int i = 0; i < tbChucNang.Rows.Count; i++)
                {
                    try
                    {
                        if (bool.Parse(tbChucNang.Rows[i].Cells[3].Value.ToString()))
                        {
                            ChucNangBUS cn = new ChucNangBUS();
                            cn.ThemChucNang(cbRole.SelectedValue.ToString(), tbChucNang.Rows[i].Cells[1].Value.ToString());
                        }  
                        else if(!bool.Parse(tbChucNang.Rows[i].Cells[3].Value.ToString()))
                        {
                            ChucNangBUS cn = new ChucNangBUS();
                            cn.XoaChucNang(cbRole.SelectedValue.ToString(), tbChucNang.Rows[i].Cells[1].Value.ToString());
                        }
                    }
                    catch (Exception) { }
                }
                MessageBoxDialog message = new MessageBoxDialog();
                message.ShowDialog("Thông báo", "Thông báo", "Lưu trạng thái thành công", MessageBoxDialog.SUCCESS, MessageBoxDialog.YES, "Đóng", "", "");
                tbChucNang.ClearSelection();
            }
        }
    }
}
