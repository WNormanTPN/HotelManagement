using DAO;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BUS
{
    public class NhanVienBUS
    {
        Database db;
        public NhanVienBUS()
        {
            db = new Database();
        }

        public DataTable getNhanVien()
        {
            string query = "select * from NHANVIEN where XuLy = 0";
            DataTable dt = db.getList(query);
            return dt;
        }

        public int getNhanVienCount()
        {
            string query = "select count(*) from NHANVIEN";
            return db.ExecuteNonQuery_getInteger(query);
        }

        public void addNhanVien(string manv, string tennv, int gioitinh, int songayphep, int chucvu, DateTime ngaysinh, DateTime ngayvaolam, string email, int luong1ngay)
        {
            var ns = ngaysinh.ToString("yyyy-MM-dd");
            var nvl = ngayvaolam.ToString("yyyy-MM-dd");
            string query = string.Format("insert into NHANVIEN values ('{0}',N'{1}', {2}, {3}, {4}, '{5}', '{6}', '{7}', {8}, 0)", manv, tennv, gioitinh, songayphep, chucvu, ns, nvl, email, luong1ngay);
            db.ExecuteNonQuery(query);
        }

        public DataTable findNhanVien(string manv, string tennv, int gioitinh, int chucvu, string songayphep, string luong1ngay, DateTime ngaysinhtu, DateTime ngaysinhden, DateTime ngayvaolamtu, DateTime ngayvaolamden, string email)
        {
            var query = "select * from NHANVIEN where ";
            if (manv != String.Empty)
            {
                query += "maNV like '%" + manv + "%' and ";
            }
            if (tennv != String.Empty)
            {
                query += "tenNV like N'%" + tennv + "%' and ";
            }
            if (gioitinh != -1)
            {
                query += "gioiTinh = " + gioitinh + " and ";
            }
            if (chucvu != -1)//*****
            {
                query += "chucVu = " + chucvu + " and ";
            }
            if (songayphep != String.Empty)
            {
                String temp = "";
                if (songayphep.Substring(0, 4).ToUpper().Equals("DƯỚI"))
                {
                    temp = "soNgayPhep < " + songayphep.Split(' ')[1] + " and ";
                }
                else if (songayphep.Substring(0, 4).ToUpper().Equals("TRÊN"))
                {
                    temp = "soNgayPhep > " + songayphep.Split(' ')[1] + " and ";
                }
                else if (songayphep.Substring(0, 2).ToUpper().Equals("TỪ"))
                {
                    temp = "soNgayPhep >= " + songayphep.Split(' ')[1] + " and " + "soNgayPhep <= " + songayphep.Split(' ')[4] + " and ";
                }
                query += temp;
            }
            if (ngaysinhtu != DateTime.MinValue)
            {
                query += "ngaySinh >= '" + ngaysinhtu.ToString("yyyy-MM-dd") + "' and ";
            }
            if (ngaysinhden != DateTime.MinValue)
            {
                query += "ngaySinh <= '" + ngaysinhden.ToString("yyyy-MM-dd") + "' and  ";
            }
            if (ngayvaolamtu != DateTime.MinValue)
            {
                query += "ngayVaoLam >= '" + ngayvaolamtu.ToString("yyyy-MM-dd") + "' and ";
            }
            if (ngayvaolamden != DateTime.MinValue)
            {
                query += "ngayVaoLam <= '" + ngayvaolamden.ToString("yyyy-MM-dd") + "'  and ";
            }
            if (luong1ngay != String.Empty)
            {
                String temp = "";
                if (luong1ngay.Substring(0, 4).ToUpper().Equals("DƯỚI"))
                {
                    temp = "luong1Ngay < " + luong1ngay.Split(' ')[1].Replace(",", "") + " and ";
                }
                else if (luong1ngay.Substring(0, 4).ToUpper().Equals("TRÊN"))
                {
                    temp = "luong1Ngay > " + luong1ngay.Split(' ')[1].Replace(",", "") + " and ";
                }
                else if (luong1ngay.Substring(0, 2).ToUpper().Equals("TỪ"))
                {
                    temp = "luong1Ngay >= " + luong1ngay.Split(' ')[1].Replace(",", "") + " and " + "luong1Ngay <= " + luong1ngay.Split(' ')[4].Replace(",", "") + " and ";
                }
                query += temp;
            }
            if (email != String.Empty)
            {
                query += "email like '%" + email + "%' and ";
            }
            query += "xuLy = 0";
            return db.getList(query);
        }

        public void deleteNhanVien(string manv)
        {
            string query = string.Format("update NHANVIEN set xuLy = 1 where maNV = '{0}'", manv);
            db.ExecuteNonQuery(query);
        }

        public void updateNhanVien(string manv, string tennv, int gioitinh, int songayphep, int chucvu, DateTime ngaysinh, DateTime ngayvaolam, string email, int luong1ngay)
        {
            var ns = ngaysinh.Year + "-" + ngaysinh.Month + "-" + ngaysinh.Day;
            var nvl = ngayvaolam.Year + "-" + ngayvaolam.Month + "-" + ngayvaolam.Day;
            string query = string.Format("update NHANVIEN set maNV = '{0}', tenNV = N'{1}', gioiTinh = {2}, soNgayPhep = {3}, chucVu = {4}, ngaySinh = '{5}', ngayVaoLam = '{6}', email = '{7}', luong1Ngay = {8} where maNV = '{9}'", manv, tennv, gioitinh, songayphep, chucvu, ns, nvl, email, luong1ngay, manv);
            db.ExecuteNonQuery(query);
        }
        #region new
        public List<NhanVienDTO> getDSNhanVien()
        {
            string query = "select * from NhanVien where xuLy = 0";
            return db.getListNV_DTO(query);   
        }
        public List<NhanVienDTO> getAllDSNhanVien()
        {
            string query = "select * from NhanVien";
            return db.getListNV_DTO(query);
        }
        public NhanVienDTO GetNV(string maNV)
        {
            NhanVienDTO nhanVien = new NhanVienDTO();
            foreach(NhanVienDTO nv in getDSNhanVien())
            {
                if (nv.MaNV.Equals(maNV))
                {
                    nhanVien = nv;
                    break;
                }
            }
            return nhanVien;
        }
        #endregion
    }
}
