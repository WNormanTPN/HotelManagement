using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using DTO;

namespace BUS
{
    public class KhachHangBUS
    {
        Database db;
        public KhachHangBUS()
        {
            db = new Database();
        }

        public DataTable getKhachHang()
        {
            string query = "select * from KHACHHANG where XuLy = 0";
            DataTable dt = db.getList(query);
            return dt;
        }

        public int GetKhachHangCount()
        {
            string query = "select count(*) from KHACHHANG";
            return db.ExecuteNonQuery_getInteger(query);
        }

        public void addKhachHang(string makh, string tenkh, string cmnd, int gioitinh, string sdt, string quequan, string quoctich, DateTime ngaysinh)
        {
            var ns = ngaysinh.ToString("yyyy-MM-dd");
            //string query = string.Format("insert into KHACHHANG values ('{0}',N'{1}', {2},N {3}, {4}, N'{5}', N'{6}', '{7}', 0)", makh, tenkh, cmnd, gioitinh, sdt, quequan, quoctich, ns);
            string temp = "INSERT INTO KHACHHANG values maKH = \'" + makh + "\', tenKH = N\'" + tenkh + "\', CMND = \'" + cmnd + "\', gioiTinh = " + gioitinh + ", sDT = \'" + sdt + "\', queQuan = N\'" + quequan + "\', quocTich = N\'" + quoctich + "\', ngaySinh = \'" + ngaysinh + "\' ";
            string query = string.Format(temp);
            db.ExecuteNonQuery(query);
        }

        public DataTable findKhachHang(string makh, string tenkh, string cmnd, int gioitinh, string sdt, string quequan, string quoctich, DateTime ngaysinhtu, DateTime ngaysinhden)
        {
            var query = "select * from KHACHHANG where ";
            if (makh != String.Empty)
            {
                query += "maKH like '%" + makh + "%' and ";
            }
            if (tenkh != String.Empty)
            {
                query += "tenKH like N'%" + tenkh + "%' and ";
            }
            if (cmnd != String.Empty)
            {
                query += "cMND like N'%" + cmnd + "%' and ";
            }
            if (gioitinh != -1)
            {
                query += "gioiTinh = " + gioitinh + " and ";
            }
            if (sdt != String.Empty)
            {
                query += "sDT like N'%" + sdt + "%' and ";
            }
            if (quequan != String.Empty)
            {
                query += "queQuan like N'%" + quequan + "%' and ";
            }
            if (quoctich != String.Empty)
            {
                query += "quocTich like N'%" + quoctich + "%' and ";
            }

            if (ngaysinhtu != DateTime.MinValue)
            {
                query += "ngaySinh >= '" + ngaysinhtu.ToString("yyyy-MM-dd") + "' and ";
            }
            if (ngaysinhden != DateTime.MinValue)
            {
                query += "ngaySinh <= '" + ngaysinhden.ToString("yyyy-MM-dd") + "' and  ";
            }
            query += "xuLy = 0";
            return db.getList(query);
        }

        public void deleteKhachHang(string makh)
        {
            string query = string.Format("update KHACHHANG set xuLy = 1 where maKH = '{0}'", makh);
            db.ExecuteNonQuery(query);
        }
        public void UpdateKhachHang(string maKH, string tenKH, string cmnd, string gioiTinh, string sdt, string queQuan, string quocTich, string ngaySinh)
        {
            string query = string.Format("update KHACHHANG set tenKH = N'{0}', CMND = '{1}', gioiTinh = {2}, sDT = '{3}', queQuan = N'{4}', quocTich = N'{5}', ngaySinh = '{6}' where maKH = '{7}'", tenKH, cmnd, gioiTinh, sdt, queQuan, quocTich, ngaySinh, maKH);
            db.ExecuteNonQuery(query);
        }

        public List<KhachHangDTO> GetDSKH()
        {
            string query = "select * from khachHang";
            return db.getListKH_DTO(query);
        }

        public int GetCountAllKH()
        {
            string query = "Select Count(maKH)+1 from KhachHang";
            return db.ExecuteNonQuery_getInteger(query);
        }

        public void InsertKhachHang(string maKH, string tenKh, string CMND, string gioiTinh, string sDT, string queQuan, string quocTich, string ngaySinh)
        {
            string query = string.Format("insert into KhachHang values ('{0}',N'{1}','{2}',{3},'{4}',N'{5}',N'{6}','{7}',0)", maKH, tenKh, CMND, gioiTinh, sDT, queQuan, quocTich, ngaySinh);
            db.ExecuteNonQuery(query);
        }
        public int SoLanThue(string maKH)
        {
            string query = "select count(chiTietthue.maKH) from CHITIETTHUE, KHACHHANG \r\nwhere CHITIETTHUE.maKH = KHACHHANG.maKH and Chitietthue.maKH = '" + maKH + "'";
            return db.ExecuteNonQuery_getInteger(query);
        }
    }
}
