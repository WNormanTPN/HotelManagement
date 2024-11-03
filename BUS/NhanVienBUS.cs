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

        /// <summary>
        /// Initializes a new instance of the NhanVienBUS class and sets up the database connection.
        /// </summary>
        public NhanVienBUS()
        {
            db = new Database();
        }

        /// <summary>
        /// Retrieves a list of active employees from the database
        /// </summary>
        /// <returns>A DataTable containing the list of active employee</returns>
        public DataTable getNhanVien()
        {
            string query = "select * from NHANVIEN where XuLy = 0";
            DataTable dt = db.getList(query);
            return dt;
        }

        /// <summary>
        /// Retrieves a total count of employees from the database
        /// </summary>
        /// <returns>The total number of employees as an integer</returns>
        public int getNhanVienCount()
        {
            string query = "select count(*) from NHANVIEN";
            return db.ExecuteNonQuery_getInteger(query);
        }

        /// <summary>
        /// Add a new employee to the database
        /// </summary>
        /// <param name="manv">Employee ID</param>
        /// <param name="tennv">Employee name</param>
        /// <param name="gioitinh">Gender (0 for male, 1 for female)</param>
        /// <param name="songayphep">Number of leave days</param>
        /// <param name="chucvu">Position index</param>
        /// <param name="ngaysinh">Date of birth</param>
        /// <param name="ngayvaolam">Date of joining</param>
        /// <param name="email">Email address</param>
        /// <param name="luong1ngay">Daily salary</param>
        public void addNhanVien(string manv, string tennv, int gioitinh, int songayphep, int chucvu, DateTime ngaysinh, DateTime ngayvaolam, string email, int luong1ngay)
        {
            var ns = ngaysinh.ToString("yyyy-MM-dd");
            var nvl = ngayvaolam.ToString("yyyy-MM-dd");
            string query = string.Format("insert into NHANVIEN values ('{0}',N'{1}', {2}, {3}, {4}, '{5}', '{6}', '{7}', {8}, 0)", manv, tennv, gioitinh, songayphep, chucvu, ns, nvl, email, luong1ngay);
            db.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Find employees based on the search criteria
        /// </summary>
        /// <param name="manv">Employee ID</param>
        /// <param name="tennv">Employee name</param>
        /// <param name="gioitinh">Gender (0 for male, 1 for female, -1 for any)</param>
        /// <param name="chucvu">Position index (-1 for any)</param>
        /// <param name="songayphep">Leave days criteria ("DƯỚI 10", "TRÊN 5", "TỪ 5 ĐẾN 10")</param>
        /// <param name="luong1ngay">Daily salary criteria ("DƯỚI 1000", "TRÊN 500", "TỪ 500 ĐẾN 1000")</param>
        /// <param name="ngaysinhtu">Date of birth from</param>
        /// <param name="ngaysinhden">Date of birth to</param>
        /// <param name="ngayvaolamtu">Date of joining from</param>
        /// <param name="ngayvaolamden">Date of joining to</param>
        /// <param name="email">Email address</param>
        /// <returns>A DataTable containing the list of employees that match the search criteria</returns>
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

        /// <summary>
        /// Marks an employee as deleted in the database by setting the xuly = 1
        /// </summary>
        /// <param name="manv">Employee ID</param>
        public void deleteNhanVien(string manv)
        {
            string query = string.Format("update NHANVIEN set xuLy = 1 where maNV = '{0}'", manv);
            db.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Updates an employee's information in the database
        /// </summary>
        /// <param name="manv">Employee ID</param>
        /// <param name="tennv">Employee name</param>
        /// <param name="gioitinh">Gender (0 for male, 1 for famale)</param>
        /// <param name="songayphep">Number of leave days</param>
        /// <param name="chucvu">Position index</param>
        /// <param name="ngaysinh">Date of birth</param>
        /// <param name="ngayvaolam">Date of joining</param>
        /// <param name="email">Email address</param>
        /// <param name="luong1ngay">Daily salary</param>
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
