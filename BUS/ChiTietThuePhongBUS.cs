using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiTietThuePhongBUS
    {
        Database db;
        public ChiTietThuePhongBUS()
        {
            db = new Database();
        }
        public List<ChiTietThuePhongDTO> GetDSListCTTP(string maCTT)
        {
            string query = "select * from CHITIETTHUEPHONG where maCTT = '" + maCTT + "'";
            return db.getListCTTP_DTO(query);
        }
        public List<ChiTietThuePhongDTO> GetDSListCTTP()
        {
            string query = "select * from CHITIETTHUEPHONG";
            return db.getListCTTP_DTO(query);
        }
        public void InsertCTTP(bool check, string maCTT, string maP, string ngayThue, string ngayTra, string loaiHinhThue, string giaThue)
        {
            if (check)
            {
                string query = string.Format("insert into CHITIETTHUEPHONG values ('{0}','{1}','{2}','{3}',null,{4},{5},0)", maCTT, maP, ngayThue, ngayTra, loaiHinhThue, giaThue);
                db.ExecuteNonQuery(query);
            }
            else
            {
                string query = string.Format("insert into CHITIETTHUEPHONG values ('{0}','{1}','{2}',null,null,{3},{4},0)", maCTT, maP, ngayThue, loaiHinhThue, giaThue);
                db.ExecuteNonQuery(query);
            }
        }
        public void DeleteCTTP(string maCTT, string maP, string ngayThue)
        {
            string query = "delete ChiTietThuePhong where maCTT = '" + maCTT + "' and maP = '" + maP + "' and ngayThue = '" + ngayThue + "'";
            db.ExecuteNonQuery(query);
        }
        public void UpdateTinhTrang(string maCTT, string maP, string ngayThue, string tinhTrang)
        {
            string query = string.Format("update ChiTietThuePhong set tinhTrang = {0} where maCTT = '{1}' and maP = '{2}' and ngayThue = '{3}'", tinhTrang, maCTT, maP, ngayThue);
            db.ExecuteNonQuery(query);
        }
        public void UpdateCheckOut(bool check, string maCTT, string maP, string ngayThue, string ngayCheckOut, string giaThue)
        {
            if (check)
            {
                string query = string.Format("update ChiTietThuePhong set ngayCheckOut = '{0}' where maCTT = '{1}' and maP = '{2}' and ngayThue = '{3}'", ngayCheckOut, maCTT, maP, ngayThue);
                db.ExecuteNonQuery(query);
            }
            else
            {
                string query = string.Format("update ChiTietThuePhong set ngayCheckOut = '{0}', ngayTra = '{1}', giaThue = {2} where maCTT = '{3}' and maP = '{4}' and ngayThue = '{5}'", ngayCheckOut, ngayCheckOut, giaThue, maCTT, maP, ngayThue);
                db.ExecuteNonQuery(query);
            }
        }
        public DataTable GetInfoRoom(string maP)
        {
            string query = "select TOP 1 CHITIETTHUE.maCTT, tenKH, ngayTra from KHACHHANG, CHITIETTHUE, CHITIETTHUEPHONG \r\nwhere KHACHHANG.maKH = CHITIETTHUE.maKH \r\nand CHITIETTHUE.maCTT = CHITIETTHUEPHONG.maCTT \r\nand CHITIETTHUE.tinhTrangXuLy = 0 and maP = '" + maP + "' and CHITIETTHUEPHONG.tinhTrang = 1\r\norder by ngayThue asc";
            return db.getList(query);
        }
    }
}
