using Microsoft.Reporting.WinForms;
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
    public partial class rpThongTinPhieuThue : Form
    {
        Object[] item = new object[12];
        public rpThongTinPhieuThue(Object[] item)
        {
            this.item = item;
            InitializeComponent();
        }
        public class CTT
        {
            public string MaCTT { get; set; }
            public string HoTenNhanVien { get; set; }
            public string TienDatCoc { get; set; }
            public string MaKH { get; set; }
            public string HoTenKhachHang { get; set; }
            public string CMND { get; set; }
            public string DiaChi { get; set; }
            public string SDT { get; set; }
            public string NgaySinh { get; set; }
            public string GioiTinh { get; set; }
            public string QuocTich { get; set; }
            public string NgayLapPhieu { get; set; }
        }
        private void rpThongTinPhieuThue_Load(object sender, EventArgs e)
        {
            var CTTitem = new CTT
            {
                MaCTT = this.item[0].ToString(),
                HoTenNhanVien = this.item[1].ToString(),
                TienDatCoc = this.item[2].ToString(),
                MaKH = this.item[3].ToString(),
                HoTenKhachHang = this.item[4].ToString(),
                CMND = this.item[5].ToString()  ,
                DiaChi = this.item[6].ToString(),
                SDT = this.item[7].ToString(),
                NgaySinh = this.item[8].ToString(),
                GioiTinh = this.item[9].ToString(),
                QuocTich = this.item[10].ToString(),
                NgayLapPhieu = this.item[11].ToString()
            };
            List<CTT> list = new List<CTT>();
            list.Add(CTTitem);
            var source = new ReportDataSource("DataSet1",list);
            this.rpViewCTT.LocalReport.DataSources.Clear();
            this.rpViewCTT.LocalReport.DataSources.Add(source);
            this.rpViewCTT.RefreshReport();
        }
    }
}
