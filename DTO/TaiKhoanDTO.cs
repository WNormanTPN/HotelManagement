using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoanDTO
    {
        private string _taiKhoan;
        private string _maNV;
        private string _maPQ;
        private string _matKhau;
        private int _tinhTrang;
        private int _xuLy;

        public TaiKhoanDTO()
        {
        }

        public TaiKhoanDTO(string taiKhoan, string maNV, string maPQ, string matKhau, int tinhTrang, int xuLy)
        {
            TaiKhoan = taiKhoan;
            MaNV = maNV;
            MaPQ = maPQ;
            MatKhau = matKhau;
            TinhTrang = tinhTrang;
            XuLy = xuLy;
        }
        public string TaiKhoan { get => _taiKhoan; set => _taiKhoan = value; }
        public string MaNV { get => _maNV; set => _maNV = value; }
        public string MaPQ { get => _maPQ; set => _maPQ = value; }
        public string MatKhau { get => _matKhau; set => _matKhau = value; }
        public int TinhTrang { get => _tinhTrang; set => _tinhTrang = value; }
        public int XuLy { get => _xuLy; set => _xuLy = value; }
    }
}
