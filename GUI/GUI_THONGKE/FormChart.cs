﻿using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI.GUI_THONGKE
{
    public partial class FormChart : Form
    {
        Font fontTitle = new Font("Segoe UI", 10f, FontStyle.Bold);
        Font font = new Font("Segoe UI", 9f);
        HoaDonBUS hd = new HoaDonBUS();
        public FormChart()
        {
            InitializeComponent();
            lbTongDoanhThuDichVu.Text = hd.TongTienDV().ToString("###,###0 VNĐ");
            lbTongTienDichVuPhanTich.Text = hd.TongTienDV().ToString("###,###0 VNĐ");
            lbTongDoanhThuPhong.Text = hd.TongTienPhong().ToString("###,###0 VNĐ");
            lbTongTienPhongPhanTich.Text = hd.TongTienPhong().ToString("###,###0 VNĐ");

            lbTongDoanhThu.Text = hd.TongDoanhThu().ToString("###,###0 VNĐ");
            lbTongDoanhThuPhanTich.Text = hd.TongDoanhThu().ToString("###,###0 VNĐ");

            lbTongPhuThuPhanTich.Text = hd.TongPhuThu().ToString("###,###0 VNĐ");
            lbTongGiamGiaThanhToan.Text = hd.TongGiamGia().ToString("###,###0 VNĐ");
            BieuDoPhongLoad(DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
            BieuDoLoaiPhongLoad(DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
            BieuDoThongKeThangLoad(int.Parse(DateTime.Now.ToString("MM")), int.Parse(DateTime.Now.ToString("yyyy")));
            BieuDoThongKeNamLoad(int.Parse(DateTime.Now.ToString("yyyy")));
        }
        void BieuDoPhongLoad(string tungay, string denngay)
        {
            Title title1 = new Title();
            title1.Font = fontTitle;
            title1.Text = "Biểu đồ thống kê tương quan phòng Vip và Thường";
            chart1.Titles.Add(title1);
            try
            {
                chart1.Titles.RemoveAt(0);
            }
            catch (Exception) { }
            int total = hd.TongLoaiPhong(tungay, denngay);
            int totalVip = hd.TongLoaiPhongVip(tungay, denngay);
            int totalThuong = hd.TongLoaiPhongThuong(tungay, denngay);
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            chart1.Series["Series1"].ChartType = SeriesChartType.Doughnut;
            if (total != 0)
            {
                DataPoint point1 = new DataPoint();
                point1.SetValueXY("Phòng Thường",  totalThuong * 100 / total);
                point1.LegendText = "Phòng Thường";
                DataPoint point2 = new DataPoint();
                point2.SetValueXY("Phòng VIP", totalVip * 100 / total);
                point2.LegendText = "Phòng VIP";

                chart1.Series["Series1"].Points.Add(point1);
                chart1.Series["Series1"].Points.Add(point2);

                chart1.Series["Series1"].Label = "#PERCENT{P0}";
            }
        }
        void BieuDoLoaiPhongLoad(string tungay, string denngay)
        {
            Title title2 = new Title();
            title2.Font = fontTitle;
            title2.Text = "Biểu đồ thống kê tương quan Chi tiết loại phòng";
            chart2.Titles.Add(title2);
            try
            {
                chart2.Titles.RemoveAt(0);
            }
            catch (Exception) { }
            int total = hd.TongLoaiPhong(tungay, denngay);
            int totalDon = hd.TongLoaiPhongDon(tungay, denngay);
            int totalDoi = hd.TongLoaiPhongDoi(tungay, denngay);
            int totalGiaDinh = hd.TongLoaiPhongGiaDinh(tungay, denngay);
            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            chart2.Series["Series1"].ChartType = SeriesChartType.Doughnut;
            if (total != 0)
            {
                DataPoint point1 = new DataPoint();
                point1.SetValueXY("Phòng Đơn", totalDon * 100 / total);
                point1.LegendText = "Phòng Đơn";
                DataPoint point2 = new DataPoint();
                point2.SetValueXY("Phòng Đôi", totalDoi * 100 / total);
                point2.LegendText = "Phòng Đôi";
                DataPoint point3 = new DataPoint();
                point3.SetValueXY("Phòng Gia đình", totalGiaDinh * 100 / total);
                point3.LegendText = "Phòng Gia đình";

                chart2.Series["Series1"].Points.Add(point1);
                chart2.Series["Series1"].Points.Add(point2);
                chart2.Series["Series1"].Points.Add(point3);

                chart2.Series["Series1"].Label = "#PERCENT{P0}";
            }
        }

        void BieuDoThongKeThangLoad(int thang, int nam)
        {
            Title title3 = new Title();
            title3.Font = fontTitle;
            title3.Text = "Biểu đồ thống kê tiền phòng và dịch vụ theo tháng " + thang + " năm " + nam;
            try
            {
                chart3.Titles.RemoveAt(0);
            }
            catch (Exception) { }
            chart3.Titles.Add(title3);
            chart3.Series["Series1"].LegendText = "Tiền phòng";
            chart3.Series["Series2"].LegendText = "Tiền dịch vụ";
            chart3.Series["Series1"].Font = font;
            chart3.Series["Series2"].Font = font;
            chart3.ChartAreas[0].AxisX.LabelStyle.Font = font;
            chart3.ChartAreas[0].AxisY.LabelStyle.Font = font;
            chart3.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart3.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.WhiteSmoke;
            chart3.ChartAreas[0].AxisX.LineColor = Color.Transparent;
            chart3.ChartAreas[0].AxisY.LineColor = Color.Transparent;

            foreach (var series in chart3.Series)
            {
                series.Points.Clear();
            }
            if (DateTime.IsLeapYear(nam))
            {
                var roomRevenue = hd.TongTienPhongTrongMotNgay(i.ToString(), thang.ToString(), nam.ToString());
                var serviceRevenue = hd.TongTienDichVuTrongMotNgay(i.ToString(), thang.ToString(), nam.ToString());

                chart3.Series["Series1"].Points.AddXY(i, roomRevenue);
                chart3.Series["Series2"].Points.AddXY(i, serviceRevenue);

                if (roomRevenue != 0)
                    chart3.Series["Series1"].Points[i - 1].Label = roomRevenue.ToString();
                if (serviceRevenue != 0)
                    chart3.Series["Series2"].Points[i - 1].Label = serviceRevenue.ToString();
                        }
                        }

        void BieuDoThongKeNamLoad(int nam)
        {
            Title title4 = new Title { Font = fontTitle, Text = $"Biểu đồ thống kê tiền phòng và dịch vụ trong năm {nam}" };
            try { chart4.Titles.RemoveAt(0); } catch (Exception) { }
            chart4.Titles.Add(title4);
            chart4.Series["Series1"].LegendText = "Tiền phòng";
            chart4.Series["Series2"].LegendText = "Tiền dịch vụ";
            chart4.ChartAreas[0].AxisX.LabelStyle.Font = font;
            chart4.ChartAreas[0].AxisY.LabelStyle.Font = font;
            chart4.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart4.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.WhiteSmoke;
            chart4.ChartAreas[0].AxisX.LineColor = Color.Transparent;
            chart4.ChartAreas[0].AxisY.LineColor = Color.Transparent;

            foreach (var series in chart4.Series)
            {
                series.Points.Clear();
            }

            for (int i = 1; i <= 12; i++)
            {
                var roomRevenue = hd.TongTienPhongTrongMotThang(i.ToString(), nam.ToString());
                var serviceRevenue = hd.TongTienDichVuTrongMotThang(i.ToString(), nam.ToString());

                chart4.Series["Series1"].Points.AddXY(i, roomRevenue);
                chart4.Series["Series2"].Points.AddXY(i, serviceRevenue);

                if (roomRevenue != 0)
                    chart4.Series["Series1"].Points[i - 1].Label = roomRevenue.ToString();
                if (serviceRevenue != 0)
                    chart4.Series["Series2"].Points[i - 1].Label = serviceRevenue.ToString();
            }
        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
            BieuDoThongKeThangLoad(int.Parse(dateTimePicker5.Value.ToString("MM")), int.Parse(dateTimePicker5.Value.ToString("yyyy")));
        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {
            BieuDoThongKeNamLoad(int.Parse(dateTimePicker6.Value.ToString("yyyy")));
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            BieuDoPhongLoad(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"));
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            BieuDoPhongLoad(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"));
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            BieuDoLoaiPhongLoad(dateTimePicker4.Value.ToString("yyyy-MM-dd"), dateTimePicker3.Value.ToString("yyyy-MM-dd"));
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            BieuDoLoaiPhongLoad(dateTimePicker4.Value.ToString("yyyy-MM-dd"), dateTimePicker3.Value.ToString("yyyy-MM-dd"));
        }
    }
}
