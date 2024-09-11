using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PhanQuyenBUS
    {
        Database db;
        public PhanQuyenBUS() {
            db = new Database();
        }   
        public DataTable GetListPQ()
        {
            string query = "select * from PhanQuyen";
            return db.getList(query);
        }
        public void ThemPhanQuyen(string maPQ, string tenPQ)
        {
            string query = "insert into PhanQuyen values ('" + maPQ + "',N'" + tenPQ + "')";
            db.ExecuteNonQuery(query);
        }
        public int GetCountPQ()
        {
            string query = "select count(MaPQ) + 1 from PhanQuyen";
            return db.ExecuteNonQuery_getInteger(query);
        }
    }
}
