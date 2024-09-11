using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiTietThueDichVuBUS
    {
        Database db;
        public ChiTietThueDichVuBUS()
        {
            db = new Database();
        }

        public List<ChiTietThueDichVuDTO> GetListChiTietDichVu(string maCTT)
        {
            string query = "select * from ChiTietThueDichVu where maCTT = '" + maCTT + "'";
            return db.getListCTTDV_DTO(query);
        }
        public void DeleteCTTDV(string maCTT, string maDV, string ngaySuDung)
        {
            string query = string.Format("delete CHITIETTHUEDICHVU where maCTT = '{0}' and maDV = '{1}' and ngaySuDung = '{2}'", maCTT, maDV, ngaySuDung);
            db.ExecuteNonQuery(query);
        }
        public void SuaSoLuongCTTDV(string maCTT, string maDV, string ngaySuDung, string soLuong)
        {
            string query = string.Format("update CHITIETTHUEDICHVU set soLuong = {0} where maCTT = '{1}' and maDV = '{2}' and ngaySuDung = '{3}'", soLuong, maCTT, maDV, ngaySuDung);
            db.ExecuteNonQuery(query);
        }
        public void ThemCTTDV(string maCTT, string maDV, string ngaySuDung, string soLuong, string giaDV)
        {
            string query = string.Format("insert into CHITIETTHUEDICHVU values ('{0}','{1}','{2}',{3},{4})", maCTT, maDV, ngaySuDung, soLuong, giaDV);
            db.ExecuteNonQuery(query);
        }
        public void SuaSoLuong(string maCTT, string maDV, string ngaySuDung, string soLuong)
        {
            string query = string.Format("update CHITIETTHUEDICHVU set soLuong = soLuong + {0} where maCTT = '{1}' and maDV = '{2}' and ngaySuDung = '{3}'", soLuong, maCTT, maDV, ngaySuDung);
            db.ExecuteNonQuery(query);
        }
    }
}
