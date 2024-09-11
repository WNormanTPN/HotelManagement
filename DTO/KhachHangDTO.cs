using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        private string _maKH;
        private string _tenKH;
        private string _cMND;
        private int _gioiTinh; // 0 là nam 1 là nữ
        private string _sDT;
        private string _queQuan;
        private string _quocTich;
        private DateTime _ngaySinh;
        private int xuLy;

        public KhachHangDTO()
        {
        }
        public KhachHangDTO(string maKH, string tenKH, string cMND, int gioiTinh, string sDT, string queQuan, string quocTich, DateTime ngaySinh, int xuLy)
        {
            _maKH = maKH;
            _tenKH = tenKH;
            _cMND = cMND;
            _gioiTinh = gioiTinh;
            _sDT = sDT;
            _queQuan = queQuan;
            _quocTich = quocTich;
            _ngaySinh = ngaySinh;
            this.xuLy = xuLy;
        }
        public string MaKH { get => _maKH; set => _maKH = value; }
        public string TenKH { get => _tenKH; set => _tenKH = value; }
        public string CMND { get => _cMND; set => _cMND = value; }
        public int GioiTinh { get => _gioiTinh; set => _gioiTinh = value; }
        public string SDT { get => _sDT; set => _sDT = value; }
        public string QueQuan { get => _queQuan; set => _queQuan = value; }
        public string QuocTich { get => _quocTich; set => _quocTich = value; }
        public DateTime NgaySinh { get => _ngaySinh; set => _ngaySinh = value; }
        public int XuLy { get => xuLy; set => xuLy = value; }
    }
}
