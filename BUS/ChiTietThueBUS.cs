using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiTietThueBUS
    {
        Database db;
        public ChiTietThueBUS()
        {
            db = new Database();
        }
        public List<ChiTietThueDTO> getDSChiTietThue()
        {
            string query = "Select * from CHITIETTHUE where xuLy = 0";
            return db.getListCTT_DTO(query);
        }
        public int GetCountAll(string dateNow)
        {
            string query = "Select COUNT(MaCTT)+1 from chiTietThue where cast(ngayLapPhieu as date) = '" + dateNow + "'";
            return db.ExecuteNonQuery_getInteger(query);
        }
        public void InsertCTT(string maCTT, string maKH, string maNV, string ngayLapPhieu, string tienDatCoc)
        {
            string query = string.Format("insert into CHITIETTHUE values('{0}','{1}','{2}','{3}',{4},0,0)", maCTT, maKH, maNV, ngayLapPhieu, tienDatCoc);
            db.ExecuteNonQuery(query);
        }
        public ChiTietThueDTO getChiTietThue(string mactt)
        {
            string query = "Select * from CHITIETTHUE where maCTT=" + mactt;
            return db.getCTT_DTO(query);
        }
        public void DeleteCTT(string maCTT)
        {
            string query = "Update ChiTietThue set xuLy = 1 where maCTT = '" + maCTT + "'";
            db.ExecuteNonQuery(query);
        }
        public void SuaTinhTrangXuLy(string maCTT)
        {
            string query = "Update ChiTietThue set tinhTrangXuLy = 1 where maCTT = '" + maCTT + "'";
            db.ExecuteNonQuery(query);
        }
    }
}
