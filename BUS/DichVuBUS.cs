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
    public class DichVuBUS
    {
        Database db;
        public DichVuBUS()
        {
            db = new Database();
        }
        public DataTable getListDichVu(string maDV, string tenDV, string loaiDV, string giaDV)
        {
            string query = "select maDV,tenDV,loaiDV,giaDV,hinhAnh from DichVu where XuLy = 0";
            if (maDV.Trim() != "")
            {
                query += " AND maDV LIKE '%" + maDV + "%'";
            }
            if (tenDV.Trim() != "")
            {
                query += " AND tenDV LIKE '%" + tenDV + "%'";
            }
            if (loaiDV.Trim() == "Ăn uống")
            {
                query += " AND loaiDV = N'Ăn uống'";
            }

            if (loaiDV.Trim() == "Chăm sóc sắc đẹp")
            {
                query += " AND loaiDV = N'Chăm sóc sắc đẹp'";
            }
            else if (loaiDV.Trim() == "Tổ chức tiệc")
            {
                query += " AND loaiDV = N'Tổ chức tiệc'";
            }
            else if (loaiDV.Trim() == "Giải trí")
            {
                query += " AND loaiDV = N'Giải trí'";
            }
            else
                query += " AND loaiDV LIKE N'%" + loaiDV + "%'";


            if (giaDV.Trim() == "Dưới 50,000 VNĐ")
            {
                query += " AND giaDV < 50000";
            }
            else if (giaDV.Trim() == "Từ 50,000 VNĐ đến 100,000 VNĐ")
            {
                query += " AND giaDV BETWEEN 50000 AND 100000";
            }
            else if (giaDV.Trim() == "Từ 100,000 VNĐ đến 200,000 VNĐ")
            {
                query += " AND giaDV BETWEEN 100000 AND 200000";
            }
            else if (giaDV.Trim() == "Từ 200,000 VNĐ đến 500,000 VNĐ")
            {
                query += " AND giaDV BETWEEN 200000 AND 500000";
            }
            else if (giaDV.Trim() == "Từ 500,000 VNĐ đến 1,000,000 VNĐ")
            {
                query += " AND giaDV BETWEEN 500000 AND 1000000";
            }
            else if (giaDV.Trim() == "Trên 1,000,000 VNĐ")
            {
                query += " AND giaDV > 1000000";
            }
            else
            {
                query += " AND giaDV like '%" + giaDV + "%'";
            }

            DataTable dt = db.getList(query);
            return dt;
        }
        /*hương thức này nhận các tham số để tìm kiếm dịch vụ dựa trên mã dịch vụ, tên dịch vụ, loại dịch vụ và giá dịch vụ.
        Nó xây dựng một truy vấn SQL bằng cách thêm các điều kiện nếu các tham số không rỗng.
        Cuối cùng, nó gọi phương thức getList trên đối tượng db để thực hiện truy vấn và trả về kết quả dưới dạng DataTable.
            */
        public DataTable getImageDichVubyMaDV(string maDV)
        {
            string query = "select hinhAnh from DichVu where maDV = '" + maDV + "' AND XuLy = 0";
            DataTable dt = db.getList(query);
            return dt;
        }
        /*Phương thức này lấy hình ảnh của dịch vụ dựa trên mã dịch vụ (maDV). Truy vấn SQL chỉ lấy cột hinhAnh.
         * */
        public DataTable IsMaDVExists(string maDV)
        {
            string query = "select * from DichVu where maDV = '" + maDV + "'";
            DataTable dt = db.getList(query);
            return dt;
        }
        public void Them(string maDV, string tenDV, string loaiDV, int giaDV, string hinhAnh)
        {
            string str = "INSERT INTO DichVu(maDV,tenDV,loaiDV,giaDV,hinhAnh,xuLy)  VALUES ( '" + maDV + "',N'" + tenDV + "',N'" + loaiDV + "'," + giaDV + ",N'" + hinhAnh + "',0)";
            db.ExecuteNonQuery(str);
        }
        public void Sua(string maDV, string maDV2, string tenDV, string loaiDV, int giaDV, string hinhAnh)
        {
            string str = "UPDATE DichVu SET maDV='" + maDV + "',tenDV = N'" + tenDV + "',loaiDV = N'" + loaiDV + "',giaDV =" + giaDV + ",hinhAnh = N'" + hinhAnh + "' WHERE maDV = '" + maDV2 + "'";
            db.ExecuteNonQuery(str);
        }
        public void Xoa(string maDV)
        {
            string str = "UPDATE DichVu set xuly = 1 WHERE maDV = '" + maDV + "'";
            db.ExecuteNonQuery(str);
        }

        public List<DichVuDTO> getListDTO()
        {
            string query = "Select * from DichVu where xuLy = 0";
            return db.getListDV_DTO(query);
        }
        public DataTable getListDichVuCTPhieuThue(string key, string loaiDV)
        {
            string query;
            if (key == "Nhập Mã/Tên dịch vụ cần tìm")
            {
                query = "select maDV,tenDV,loaiDV,giaDV,hinhAnh from DichVu where XuLy = 0";
                if (loaiDV.Trim() == "Ăn uống")
                {
                    query += " AND loaiDV = N'Ăn uống'";
                }

                if (loaiDV.Trim() == "Chăm sóc sắc đẹp")
                {
                    query += " AND loaiDV = N'Chăm sóc sắc đẹp'";
                }
                else if (loaiDV.Trim() == "Tổ chức tiệc")
                {
                    query += " AND loaiDV = N'Tổ chức tiệc'";
                }
                else if (loaiDV.Trim() == "Giải trí")
                {
                    query += " AND loaiDV = N'Giải trí'";
                }
            }
            else
            {
                query = "select maDV,tenDV,loaiDV,giaDV,hinhAnh from DichVu where XuLy = 0 AND ( maDV LIKE N'%" + key + "%' or tendv LIKE N'%" + key + "%')";
                if (loaiDV.Trim() == "Ăn uống")
                {
                    query += " AND loaiDV = N'Ăn uống'";
                }

                if (loaiDV.Trim() == "Chăm sóc sắc đẹp")
                {
                    query += " AND loaiDV = N'Chăm sóc sắc đẹp'";
                }
                else if (loaiDV.Trim() == "Tổ chức tiệc")
                {
                    query += " AND loaiDV = N'Tổ chức tiệc'";
                }
                else if (loaiDV.Trim() == "Giải trí")
                {
                    query += " AND loaiDV = N'Giải trí'";
                }
            }
            DataTable dt = db.getList(query);
            return dt;
            /*Phương thức này tìm kiếm dịch vụ dựa trên mã hoặc tên và loại dịch vụ. 
            Nếu người dùng không nhập mã hoặc tên, phương thức sẽ lấy tất cả dịch vụ còn hiệu lực.
            */
        }
    }
}
