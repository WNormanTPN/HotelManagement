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
    public class PhongBUS
    {
        Database db;
        public PhongBUS()
        {
            db = new Database();
        }
        public DataTable getListPhong()
        {
            string query = "select * from PHONG where XuLy = 0";
            DataTable dt = db.getList(query);
            return dt;
        }
        public List<PhongDTO> getListPhong_DTO()
        {
            string query = "select * from PHONG where xuLY = 0";
            return db.getListPhong_DTO(query);
        }
        public int getCountPhong()
        {
            string query = "select COUNT(MaP) from PHONG";
            return db.ExecuteNonQuery_getInteger(query);
        }
        public void ThemPhong(string maP, string tenP, string loaiP, string giaP, string chiTietLoaiP, string tinhTrang, string hienTrang)
        {
            string query = string.Format("insert into PHONG values ('{0}',N'{1}',{2},{3},{4},{5},{6},{7})", maP, tenP, loaiP, giaP, chiTietLoaiP, tinhTrang, hienTrang, 0);
            db.ExecuteNonQuery(query);
        }
        public void SuaPhong(string maP, string tenP, string loaiP, string giaP, string chiTietLoaiP, string hienTrang)
        {
            string query = string.Format("Update PHONG set tenP = N'{0}', loaiP = {1}, giaP  = {2}, chiTietLoaiP = {3}, hienTrang = {4} where maP = '{5}'", tenP, loaiP, giaP, chiTietLoaiP, hienTrang, maP);
            db.ExecuteNonQuery(query);
        }
        public void XoaPhong(string maP)
        {
            string query = "Update PHONG set xuLy = 1 where maP = '" + maP + "'";
            db.ExecuteNonQuery(query);
        }
        public void SuaTinhTrang(string maP, string tinhTrang)
        {
            string query = string.Format("Update PHONG set tinhTrang = {0} where maP = '{1}'", tinhTrang, maP);
            db.ExecuteNonQuery(query);
        }
    }
}
