using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BUS
{
    public class TienIchBUS
    {
        Database db;
        public TienIchBUS()
        {
            db = new Database();
        }
        public DataTable getListTienIch()
        {
            string query = "select MaTI, TenTI from TIENICH where XuLy = 0";
            DataTable dt = db.getList(query);
            return dt;
        }
        public DataTable getListTienIch_Phong(string maP)
        {
            string query = "select TIENICH.MaTI, TenTI, SoLuong from CHITIETTIENICH, TIENICH where TIENICH.MaTI = CHITIETTIENICH.MaTI and MaP = '" + maP + "' and TIENICH.XuLy = 0";
            DataTable dt = db.getList(query);
            return dt;
        }
        public int GetSoLuongTienIch()
        {
            string query = "select count(maTI) from TIENICH";
            return db.ExecuteNonQuery_getInteger(query);
        }

        public void ThemTienIch(string maTI, string tenTI)
        {
            string query = string.Format("insert into TIENICH values ('{0}',N'{1}',0)", maTI, tenTI);
            db.ExecuteNonQuery(query);
        }
        public void ThemTienIchPhong(string maP, string maTi, string SL)
        {
            string query = string.Format("insert into CHITIETTIENICH values ('{0}','{1}',{2})", maP, maTi, SL);
            db.ExecuteNonQuery(query);
        }

        public void SuaTienIch(string maTI, string tenTI)
        {
            string query = string.Format("update TIENICH set TenTI = N'{0}' where MaTI = '{1}'", tenTI, maTI);
            db.ExecuteNonQuery(query);
        }
        public void SuaTienIch_Phong(string maP, string maTI, string SL)
        {
            string query = string.Format("update CHITIETTIENICH set SoLuong = {0} where MaTI = '{1}' and MaP = '{2}'", SL, maTI, maP);
            db.ExecuteNonQuery(query);
        }
        public void SuaTienIch_Phong_CoTienIch(string maP, string maTI, string SL)
        {
            string query = string.Format("update CHITIETTIENICH set SoLuong = SoLuong + {0} where MaTI = '{1}' and MaP = '{2}'", SL, maTI, maP);
            db.ExecuteNonQuery(query);
        }
        public void XoaTienIch(string maTI)
        {
            string query = string.Format("update TIENICH set xuLy = 1 where MaTI = '{0}'", maTI);
            db.ExecuteNonQuery(query);
        }
        public void XoaTienIch_Phong(string maTI, string maP)
        {
            string query = string.Format("delete CHITIETTIENICH where MaP = '{0}' and MaTI = '{1}'", maP, maTI);
            db.ExecuteNonQuery(query);
        }
    }
}
