using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TaiKhoanBUS
    {
        private Database db;
        public TaiKhoanBUS()
        {
            db = new Database();
        }

        public List<TaiKhoanDTO> GetListTaiKhoan()
        {
            string query = "SELECT * FROM TAIKHOAN";
            return db.GetListTK_DTO(query);
        }
        public TaiKhoanDTO GetTK(string taiKhoan)
        {
            TaiKhoanDTO tk = new TaiKhoanDTO();
            foreach (TaiKhoanDTO x in GetListTaiKhoan())
            {
                if (x.TaiKhoan.Equals(taiKhoan))
                {
                    tk = x;
                    return x;
                }
            }
            return tk;
        }
        public TaiKhoanDTO GetTKNV(string maNV)
        {
            TaiKhoanDTO tk = new TaiKhoanDTO();
            foreach (TaiKhoanDTO x in GetListTaiKhoan())
            {
                if (x.MaNV.Equals(maNV))
                {
                    tk = x;
                    return x;
                }
            }
            return tk;
        }
        public void ThemTaiKhoan(string taiKhoan, string maNV, string maPQ, string matKhau, string tinhTrang)
        {
            string query = string.Format("insert into taikhoan values ('{0}','{1}','{2}','{3}',{4},0)", taiKhoan, maNV, matKhau, tinhTrang, maPQ);
            db.ExecuteNonQuery(query);
        }
        public void XoaTaiKhoan(string taiKhoan)
        {
            string query = "delete TaiKhoan where taiKhoan = '" + taiKhoan + "'";
            db.ExecuteNonQuery(query);
        }
        public void SuaPhanQuyen(string taiKhoan, string phanQuyen)
        {
            string query = "update TaiKhoan set maPQ = '" + phanQuyen + "' where taiKhoan = '" + taiKhoan + "'";
            db.ExecuteNonQuery(query);
        }
        public void KhoaTaiKhoan(string taiKhoan)
        {
            string query = "update TaiKhoan set tinhTrang = 1 where taiKhoan = '" + taiKhoan + "'";
            db.ExecuteNonQuery(query);
        }
        public void MoKhoaTaiKhoan(string taiKhoan)
        {
            string query = "update TaiKhoan set tinhTrang = 0 where taiKhoan = '" + taiKhoan + "'";
            db.ExecuteNonQuery(query);
        }
        public void SuaMatKhau(string taiKhoan, string matKhau)
        {
            string query = "update TaiKhoan set matKhau = '" + matKhau + "' where taiKhoan = '" + taiKhoan + "'";
            db.ExecuteNonQuery(query);
        }
    }
}
