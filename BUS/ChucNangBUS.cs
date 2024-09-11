using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChucNangBUS
    {
        Database db;
        public ChucNangBUS()
        {
            db = new Database();
        }
        public DataTable GetTBChucNang(string maPQ)
        {
            string query = "select ChucNang.maChucNang, tenChucNang, case when TB.maChucNang is not null then 'true' else 'false' end as [Action]\r\nfrom CHUCNANG left join (select PHANQUYEN.maPQ, PHANQUYEN.tenPQ, CHITIETCHUCNANG.maChucNang from CHITIETCHUCNANG, PHANQUYEN\r\nwhere CHITIETCHUCNANG.maPQ = PHANQUYEN.maPQ and PhanQuyen.maPQ = '" + maPQ + "') as TB on CHUCNANG.maChucNang = TB.maChucNang";
            return db.getList(query);
        }
        public void XoaChucNang(string maPQ, string maChucNang)
        {
            string query = "delete CHITIETCHUCNANG where maPQ = '" + maPQ + "' and maChucNang = '" + maChucNang + "'";
            db.ExecuteNonQuery(query);
        }
        public void ThemChucNang(string maPQ, string maChucNang)
        {
            string query = "insert into CHITIETCHUCNANG values ('" + maPQ + "','" + maChucNang + "')";
            db.ExecuteNonQuery(query);
        }
    }
}
