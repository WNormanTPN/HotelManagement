using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HoaDonBUS
    {
        Database db;
        public HoaDonBUS()
        {
            db = new Database();
        }
        private DataTable GetAllHoaDon()
        {
            string query = "select * from HOADON";
            return db.getList(query);
        }
        public void ThemHoaDon(string maHD, string maCTT, string giamGia, string phuThu, string ngayThanhToan, string pttt)
        {
            string query = string.Format("insert into HOADON values('{0}','{1}',{2},{3},'{4}',{5},0)", maHD, maCTT, giamGia, phuThu, ngayThanhToan, pttt);
            db.ExecuteNonQuery(query);
        }
        public int SoLuongHD(string dateNow)
        {
            string query = "select COUNT(MaHD) + 1 from HOADON where cast(ngayThanhToan as date) = '" + dateNow + "'";
            return db.ExecuteNonQuery_getInteger(query);
        }

        public DataTable GetListHD()
        {
            string query = "select HOADON.maHD, HOADON.maCTT, tenNV, case when tienPhong is not null then tienPhong else 0 end as TongTienPhong, case when tienDichVu is not null then tienDichVu else 0 end as TongTienDV, giamGia, phuThu, \r\nSUM(case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end\r\n+ (case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end)*phuThu/100\r\n-(case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end)*giamGia/100) as TongTien,ngayThanhToan, phuongThucThanhToan \r\nfrom HOADON INNER JOIN CHITIETTHUE ON HOADON.maCTT = CHITIETTHUE.maCTT\r\nINNER JOIN NHANVIEN ON CHITIETTHUE.maNV = NHANVIEN.maNV left join \r\n(select maHD, sum(giaThue) as tienPhong from CHITIETTHUEPHONG, HOADON where HOADON.maCTT = CHITIETTHUEPHONG.maCTT\r\ngroup by HOADON.maHD) as TIENPHONG on HOADON.maHD = TIENPHONG.maHD left join \r\n(select maHD, sum(giaDV*SoLuong) as tienDichVu from CHITIETTHUEDICHVU, HOADON where HOADON.maCTT = CHITIETTHUEDICHVU.maCTT\r\ngroup by HOADON.maHD) as TIENDICHVU on HOADON.maHD = TIENDICHVU.maHD \r\ngroup by HOADON.maHD, HOADON.maCTT, tenNV, TIENPHONG.tienPhong, TIENDICHVU.tienDichVu, giamGia, phuThu, ngayThanhToan, phuongThucThanhToan";
            return db.getList(query);
        }


        public int TongTienPhong()
        {
            string query = "select SUM(giaThue) from HOADON, CHITIETTHUEPHONG\r\nwhere HOADON.maCTT = CHITIETTHUEPHONG.maCTT";
            return db.ExecuteNonQuery_getInteger(query);
        }
        public int TongTienDV()
        {
            string query = "select SUM(SoLuong*giaDV) from HOADON, CHITIETTHUEDICHVU\r\nwhere HOADON.maCTT = CHITIETTHUEDICHVU.maCTT";
            return db.ExecuteNonQuery_getInteger(query);
        }
        public int TongDoanhThu()
        {
            string query = "select SUM(TongTien) as TongTien from ( select HOADON.maHD, HOADON.maCTT, tenNV, \r\n\tcase when tienPhong is not null then tienPhong else 0 end as TongTienPhong,\t\r\n\tcase when tienDichVu is not null then tienDichVu else 0 end as TongTienDV, giamGia, phuThu,\r\n\tSUM(case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end + (case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end)*phuThu/100-(case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end)*giamGia/100) as TongTien,ngayThanhToan, phuongThucThanhToan \r\n\tfrom HOADON INNER JOIN CHITIETTHUE ON HOADON.maCTT = CHITIETTHUE.maCTT\r\nINNER JOIN NHANVIEN ON CHITIETTHUE.maNV = NHANVIEN.maNV left join (select maHD, sum(giaThue) as tienPhong from CHITIETTHUEPHONG, HOADON where HOADON.maCTT = CHITIETTHUEPHONG.maCTT \r\n\tgroup by HOADON.maHD) as TIENPHONG on HOADON.maHD = TIENPHONG.maHD left join \r\n\t(select maHD, sum(giaDV*SoLuong) as tienDichVu from CHITIETTHUEDICHVU, HOADON where HOADON.maCTT = CHITIETTHUEDICHVU.maCTT \r\n\tgroup by HOADON.maHD) as TIENDICHVU on HOADON.maHD = TIENDICHVU.maHD \r\n\tgroup by HOADON.maHD, HOADON.maCTT, tenNV, TIENPHONG.tienPhong, TIENDICHVU.tienDichVu, giamGia, phuThu, ngayThanhToan, phuongThucThanhToan ) as HoaDon";
            return db.ExecuteNonQuery_getInteger(query);
        }
        public int TongPhuThu()
        {
            string query = "select SUM((TongTienPhong+TongTienDV)*phuThu/100) as TongTien from ( select HOADON.maHD, HOADON.maCTT, tenNV, \r\n\tcase when tienPhong is not null then tienPhong else 0 end as TongTienPhong,\t\r\n\tcase when tienDichVu is not null then tienDichVu else 0 end as TongTienDV, giamGia, phuThu,\r\n\tSUM(case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end + (case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end)*phuThu/100-(case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end)*giamGia/100) as TongTien,ngayThanhToan, phuongThucThanhToan \r\n\tfrom HOADON INNER JOIN CHITIETTHUE ON HOADON.maCTT = CHITIETTHUE.maCTT\r\nINNER JOIN NHANVIEN ON CHITIETTHUE.maNV = NHANVIEN.maNV left join (select maHD, sum(giaThue) as tienPhong from CHITIETTHUEPHONG, HOADON where HOADON.maCTT = CHITIETTHUEPHONG.maCTT \r\n\tgroup by HOADON.maHD) as TIENPHONG on HOADON.maHD = TIENPHONG.maHD left join \r\n\t(select maHD, sum(giaDV*SoLuong) as tienDichVu from CHITIETTHUEDICHVU, HOADON where HOADON.maCTT = CHITIETTHUEDICHVU.maCTT \r\n\tgroup by HOADON.maHD) as TIENDICHVU on HOADON.maHD = TIENDICHVU.maHD \r\n\tgroup by HOADON.maHD, HOADON.maCTT, tenNV, TIENPHONG.tienPhong, TIENDICHVU.tienDichVu, giamGia, phuThu, ngayThanhToan, phuongThucThanhToan ) as HoaDon";
            return db.ExecuteNonQuery_getInteger(query);
        }
        public int TongGiamGia()
        {
            string query = "select SUM((TongTienPhong+TongTienDV)*giamGia/100) as TongTien from ( select HOADON.maHD, HOADON.maCTT, tenNV, \r\n\tcase when tienPhong is not null then tienPhong else 0 end as TongTienPhong,\t\r\n\tcase when tienDichVu is not null then tienDichVu else 0 end as TongTienDV, giamGia, phuThu,\r\n\tSUM(case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end + (case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end)*phuThu/100-(case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end)*giamGia/100) as TongTien,ngayThanhToan, phuongThucThanhToan \r\n\tfrom HOADON INNER JOIN CHITIETTHUE ON HOADON.maCTT = CHITIETTHUE.maCTT\r\nINNER JOIN NHANVIEN ON CHITIETTHUE.maNV = NHANVIEN.maNV left join (select maHD, sum(giaThue) as tienPhong from CHITIETTHUEPHONG, HOADON where HOADON.maCTT = CHITIETTHUEPHONG.maCTT \r\n\tgroup by HOADON.maHD) as TIENPHONG on HOADON.maHD = TIENPHONG.maHD left join \r\n\t(select maHD, sum(giaDV*SoLuong) as tienDichVu from CHITIETTHUEDICHVU, HOADON where HOADON.maCTT = CHITIETTHUEDICHVU.maCTT \r\n\tgroup by HOADON.maHD) as TIENDICHVU on HOADON.maHD = TIENDICHVU.maHD \r\n\tgroup by HOADON.maHD, HOADON.maCTT, tenNV, TIENPHONG.tienPhong, TIENDICHVU.tienDichVu, giamGia, phuThu, ngayThanhToan, phuongThucThanhToan ) as HoaDon";
            return db.ExecuteNonQuery_getInteger(query);
        }
        public int TongTienPhongTrongMotNgay(string day, string month, string year)
        {
            string query = "select case when SUM(TongTienPhong) is not null then SUM(TongTienPhong) else 0 end as TP from (select HOADON.maHD, HOADON.maCTT, tenNV, \r\n\tcase when tienPhong is not null then tienPhong else 0 end as TongTienPhong,\t\r\n\tcase when tienDichVu is not null then tienDichVu else 0 end as TongTienDV, giamGia, phuThu,\r\n\tSUM(case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end + (case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end)*phuThu/100-(case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end)*giamGia/100) as TongTien,ngayThanhToan, phuongThucThanhToan \r\n\tfrom HOADON INNER JOIN CHITIETTHUE ON HOADON.maCTT = CHITIETTHUE.maCTT\r\nINNER JOIN NHANVIEN ON CHITIETTHUE.maNV = NHANVIEN.maNV left join (select maHD, sum(giaThue) as tienPhong from CHITIETTHUEPHONG, HOADON where HOADON.maCTT = CHITIETTHUEPHONG.maCTT \r\n\tgroup by HOADON.maHD) as TIENPHONG on HOADON.maHD = TIENPHONG.maHD left join \r\n\t(select maHD, sum(giaDV*SoLuong) as tienDichVu from CHITIETTHUEDICHVU, HOADON where HOADON.maCTT = CHITIETTHUEDICHVU.maCTT \r\n\tgroup by HOADON.maHD) as TIENDICHVU on HOADON.maHD = TIENDICHVU.maHD \r\n\tgroup by HOADON.maHD, HOADON.maCTT, tenNV, TIENPHONG.tienPhong, TIENDICHVU.tienDichVu, giamGia, phuThu, ngayThanhToan, phuongThucThanhToan) as TBHoaDon\r\nwhere Year(ngayThanhToan) = " + year + " and Month(ngayThanhToan) = " + month + " and Day(ngayThanhToan) = " + day;
            return db.ExecuteNonQuery_getInteger(query);
        }
        public int TongTienDichVuTrongMotNgay(string day, string month, string year)
        {
            string query = "select case when SUM(TongTienDV) is not null then SUM(TongTienDV) else 0 end as TP from (select HOADON.maHD, HOADON.maCTT, tenNV, \r\n\tcase when tienPhong is not null then tienPhong else 0 end as TongTienPhong,\t\r\n\tcase when tienDichVu is not null then tienDichVu else 0 end as TongTienDV, giamGia, phuThu,\r\n\tSUM(case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end + (case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end)*phuThu/100-(case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end)*giamGia/100) as TongTien,ngayThanhToan, phuongThucThanhToan \r\n\tfrom HOADON INNER JOIN CHITIETTHUE ON HOADON.maCTT = CHITIETTHUE.maCTT\r\nINNER JOIN NHANVIEN ON CHITIETTHUE.maNV = NHANVIEN.maNV left join (select maHD, sum(giaThue) as tienPhong from CHITIETTHUEPHONG, HOADON where HOADON.maCTT = CHITIETTHUEPHONG.maCTT \r\n\tgroup by HOADON.maHD) as TIENPHONG on HOADON.maHD = TIENPHONG.maHD left join \r\n\t(select maHD, sum(giaDV*SoLuong) as tienDichVu from CHITIETTHUEDICHVU, HOADON where HOADON.maCTT = CHITIETTHUEDICHVU.maCTT \r\n\tgroup by HOADON.maHD) as TIENDICHVU on HOADON.maHD = TIENDICHVU.maHD \r\n\tgroup by HOADON.maHD, HOADON.maCTT, tenNV, TIENPHONG.tienPhong, TIENDICHVU.tienDichVu, giamGia, phuThu, ngayThanhToan, phuongThucThanhToan) as TBHoaDon\r\nwhere Year(ngayThanhToan) = " + year + " and Month(ngayThanhToan) = " + month + " and Day(ngayThanhToan) = " + day;
            return db.ExecuteNonQuery_getInteger(query);
        }
        public int TongTienPhongTrongMotThang(string month, string year)
        {
            string query = "select case when SUM(TongTienPhong) is not null then SUM(TongTienPhong) else 0 end as TP from (select HOADON.maHD, HOADON.maCTT, tenNV, \r\n\tcase when tienPhong is not null then tienPhong else 0 end as TongTienPhong,\t\r\n\tcase when tienDichVu is not null then tienDichVu else 0 end as TongTienDV, giamGia, phuThu,\r\n\tSUM(case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end + (case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end)*phuThu/100-(case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end)*giamGia/100) as TongTien,ngayThanhToan, phuongThucThanhToan \r\n\tfrom HOADON INNER JOIN CHITIETTHUE ON HOADON.maCTT = CHITIETTHUE.maCTT\r\nINNER JOIN NHANVIEN ON CHITIETTHUE.maNV = NHANVIEN.maNV left join (select maHD, sum(giaThue) as tienPhong from CHITIETTHUEPHONG, HOADON where HOADON.maCTT = CHITIETTHUEPHONG.maCTT \r\n\tgroup by HOADON.maHD) as TIENPHONG on HOADON.maHD = TIENPHONG.maHD left join \r\n\t(select maHD, sum(giaDV*SoLuong) as tienDichVu from CHITIETTHUEDICHVU, HOADON where HOADON.maCTT = CHITIETTHUEDICHVU.maCTT \r\n\tgroup by HOADON.maHD) as TIENDICHVU on HOADON.maHD = TIENDICHVU.maHD \r\n\tgroup by HOADON.maHD, HOADON.maCTT, tenNV, TIENPHONG.tienPhong, TIENDICHVU.tienDichVu, giamGia, phuThu, ngayThanhToan, phuongThucThanhToan) as TBHoaDon\r\nwhere Year(ngayThanhToan) = " + year + " and Month(ngayThanhToan) = " + month;
            return db.ExecuteNonQuery_getInteger(query);
        }
        public int TongTienDichVuTrongMotThang(string month, string year)
        {
            string query = "select case when SUM(TongTienDV) is not null then SUM(TongTienDV) else 0 end as TP from (select HOADON.maHD, HOADON.maCTT, tenNV, \r\n\tcase when tienPhong is not null then tienPhong else 0 end as TongTienPhong,\t\r\n\tcase when tienDichVu is not null then tienDichVu else 0 end as TongTienDV, giamGia, phuThu,\r\n\tSUM(case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end + (case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end)*phuThu/100-(case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end)*giamGia/100) as TongTien,ngayThanhToan, phuongThucThanhToan \r\n\tfrom HOADON INNER JOIN CHITIETTHUE ON HOADON.maCTT = CHITIETTHUE.maCTT\r\nINNER JOIN NHANVIEN ON CHITIETTHUE.maNV = NHANVIEN.maNV left join (select maHD, sum(giaThue) as tienPhong from CHITIETTHUEPHONG, HOADON where HOADON.maCTT = CHITIETTHUEPHONG.maCTT \r\n\tgroup by HOADON.maHD) as TIENPHONG on HOADON.maHD = TIENPHONG.maHD left join \r\n\t(select maHD, sum(giaDV*SoLuong) as tienDichVu from CHITIETTHUEDICHVU, HOADON where HOADON.maCTT = CHITIETTHUEDICHVU.maCTT \r\n\tgroup by HOADON.maHD) as TIENDICHVU on HOADON.maHD = TIENDICHVU.maHD \r\n\tgroup by HOADON.maHD, HOADON.maCTT, tenNV, TIENPHONG.tienPhong, TIENDICHVU.tienDichVu, giamGia, phuThu, ngayThanhToan, phuongThucThanhToan) as TBHoaDon\r\nwhere Year(ngayThanhToan) = " + year + " and Month(ngayThanhToan) = " + month;
            return db.ExecuteNonQuery_getInteger(query);
        }
        public int TongLoaiPhong(string fromNgay, string toNgay)
        {
            string query = "select count(maCTT) as TongPhong from CHITIETTHUEPHONG, PHONG where PHONG.maP = CHITIETTHUEPHONG.maP\r\nand cast(CHITIETTHUEPHONG.ngayThue as date) >= '" + fromNgay + "' and cast(CHITIETTHUEPHONG.ngayThue as date) <= '" + toNgay + "'";
            return db.ExecuteNonQuery_getInteger(query);
        }
        public int TongLoaiPhongVip(string fromNgay, string toNgay)
        {
            string query = "select count(maCTT) as TongPhong from CHITIETTHUEPHONG, PHONG where PHONG.maP = CHITIETTHUEPHONG.maP\r\nand cast(ngayThue as date) >= '" + fromNgay + "' and cast(ngayThue as date) <= '" + toNgay + "' and loaiP = 0";
            return db.ExecuteNonQuery_getInteger(query);
        }
        public int TongLoaiPhongThuong(string fromNgay, string toNgay)
        {
            string query = "select count(maCTT) as TongPhong from CHITIETTHUEPHONG, PHONG where PHONG.maP = CHITIETTHUEPHONG.maP\r\nand cast(ngayThue as date) >= '" + fromNgay + "' and cast(ngayThue as date) <= '" + toNgay + "' and loaiP = 1";
            return db.ExecuteNonQuery_getInteger(query);
        }
        public int TongLoaiPhongDon(string fromNgay, string toNgay)
        {
            string query = "select count(maCTT) as TongPhong from CHITIETTHUEPHONG, PHONG where PHONG.maP = CHITIETTHUEPHONG.maP\r\nand cast(ngayThue as date) >= '" + fromNgay + "' and cast(ngayThue as date) <= '" + toNgay + "' and chiTietLoaiP = 0";
            return db.ExecuteNonQuery_getInteger(query);
        }
        public int TongLoaiPhongDoi(string fromNgay, string toNgay)
        {
            string query = "select count(maCTT) as TongPhong from CHITIETTHUEPHONG, PHONG where PHONG.maP = CHITIETTHUEPHONG.maP\r\nand cast(ngayThue as date) >= '" + fromNgay + "' and cast(ngayThue as date) <= '" + toNgay + "' and chiTietLoaiP = 1";
            return db.ExecuteNonQuery_getInteger(query);
        }
        public int TongLoaiPhongGiaDinh(string fromNgay, string toNgay)
        {
            string query = "select count(maCTT) as TongPhong from CHITIETTHUEPHONG, PHONG where PHONG.maP = CHITIETTHUEPHONG.maP\r\nand cast(ngayThue as date) >= '" + fromNgay + "' and cast(ngayThue as date) <= '" + toNgay + "' and chiTietLoaiP = 2";
            return db.ExecuteNonQuery_getInteger(query);
        }
        public DataTable getHoaDon(string maHD)
        {
            string query = "select maHD, HOADON.maCTT, tenNV, ngayThanhToan \r\nfrom HoaDon\r\nINNER JOIN CHITIETTHUE ON HOADON.maCTT = CHITIETTHUE.maCTT\r\nINNER JOIN NHANVIEN ON CHITIETTHUE.maNV = NHANVIEN.maNV \r\nwhere maHD = '" + maHD + "'";
            return db.getList(query);
        }
        public DataTable getThuePhong(string maHD)
        {
            string query = "select tenP, loaiHinhThue, ngayThue, ngayCheckOut, giaThue from CHITIETTHUEPHONG, PHONG, HOADON \r\nwhere CHITIETTHUEPHONG.maCTT = HOADON.maCTT and CHITIETTHUEPHONG.maP = Phong.maP and maHD = '" + maHD + "'";
            return db.getList(query);
        }
        public DataTable getDichVu(string maHD)
        {
            string query = "select tenDV, loaiDV, ngaySuDung, SoLuong, ChiTietThueDichVu.giaDV, (SoLuong*ChiTietThueDichVu.giaDV) as Tong from CHITIETTHUEDICHVU, DICHVU, HOADON \r\nwhere CHITIETTHUEDICHVU.maCTT = HOADON.maCTT and CHITIETTHUEDICHVU.maDV = DICHVU.maDV and maHD = '" + maHD + "'";
            return db.getList(query);
        }
        public int TongTien(string maHD)
        {
            string query = "select TongTien from (select HOADON.maHD, HOADON.maCTT, tenNV, case when tienPhong is not null then tienPhong else 0 end as TongTienPhong, \r\ncase when tienDichVu is not null then tienDichVu else 0 end as TongTienDV, giamGia, phuThu, \r\nSUM(case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end\r\n + (case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end)*phuThu/100 \r\n -(case when tienPhong is not null then tienPhong else 0 end + case when tienDichVu is not null then tienDichVu else 0 end)*giamGia/100) as TongTien,ngayThanhToan, phuongThucThanhToan \r\n from HOADON INNER JOIN CHITIETTHUE ON HOADON.maCTT = CHITIETTHUE.maCTT\r\nINNER JOIN NHANVIEN ON CHITIETTHUE.maNV = NHANVIEN.maNV left join \r\n (select maHD, sum(giaThue) as tienPhong from CHITIETTHUEPHONG, HOADON where HOADON.maCTT = CHITIETTHUEPHONG.maCTT \r\n group by HOADON.maHD) as TIENPHONG on HOADON.maHD = TIENPHONG.maHD left join \r\n (select maHD, sum(giaDV*SoLuong) as tienDichVu from CHITIETTHUEDICHVU, HOADON where HOADON.maCTT = CHITIETTHUEDICHVU.maCTT \r\n group by HOADON.maHD) as TIENDICHVU on HOADON.maHD = TIENDICHVU.maHD \r\n group by HOADON.maHD, HOADON.maCTT, tenNV, TIENPHONG.tienPhong, TIENDICHVU.tienDichVu, giamGia, phuThu, ngayThanhToan, phuongThucThanhToan ) as TB\r\n where maHD = '" + maHD + "'";
            return db.ExecuteNonQuery_getInteger(query);
        }
    }
}
