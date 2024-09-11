using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        private string _maNV;
        private string _tenNV;
        private int _gioiTinh; // 0 là nam 1 là nữ
        private int _soNgayPhep;
        private int _chucVu; // 0 là Quản lý, 1 là lễ tân    
        private DateTime _ngaySinh;
        private DateTime _ngayVaoLam;
        private string _email;
        private int _luong1Ngay;
        private int _xuLy; // 0 là chưa xóa, 1 là đã xóa

        public NhanVienDTO()
        {
        }
        public NhanVienDTO(string maNV, string tenNV, int gioiTinh, int soNgayPhep, int chucVu, DateTime ngaySinh, DateTime ngayVaoLam, string email, int luong1Ngay, int xuLy)
        {
            _maNV = maNV;
            _tenNV = tenNV;
            _gioiTinh = gioiTinh;
            _soNgayPhep = soNgayPhep;
            _chucVu = chucVu;
            _ngaySinh = ngaySinh;
            _ngayVaoLam = ngayVaoLam;
            _email = email;
            _luong1Ngay = luong1Ngay;
            _xuLy = xuLy;
        }

        public string MaNV { get => _maNV; set => _maNV = value; }
        public string TenNV { get => _tenNV; set => _tenNV = value; }
        public int GioiTinh { get => _gioiTinh; set => _gioiTinh = value; }
        public int SoNgayPhep { get => _soNgayPhep; set => _soNgayPhep = value; }
        public int ChucVu { get => _chucVu; set => _chucVu = value; }
        public DateTime NgaySinh { get => _ngaySinh; set => _ngaySinh = value; }
        public DateTime NgayVaoLam { get => _ngayVaoLam; set => _ngayVaoLam = value; }
        public string Email { get => _email; set => _email = value; }
        public int Luong1Ngay { get => _luong1Ngay; set => _luong1Ngay = value; }
        public int XuLy { get => _xuLy; set => _xuLy = value; }
    }
}
