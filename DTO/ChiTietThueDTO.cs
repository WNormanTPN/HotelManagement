using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietThueDTO
    {
        private string _maCTT;
        private string _maKH;
        private string _maNV;
        private DateTime _ngayLapPhieu;
        private int _tienDatCoc;
        private int _tinhTrangXuLy; //0 là Chưa xử lý 1 là Đã xử lý
        private int xuLy; // 0 là chưa xóa 1 là đã xóa

        public ChiTietThueDTO()
        {
        }
        public ChiTietThueDTO(string maCTT, string maKH, string maNV, DateTime ngayLapPhieu, int tienDatCoc, int tinhTrangXuLy, int xuLy)
        {
            _maCTT = maCTT;
            _maKH = maKH;
            _maNV = maNV;
            _ngayLapPhieu = ngayLapPhieu;
            _tienDatCoc = tienDatCoc;
            _tinhTrangXuLy = tinhTrangXuLy;
            this.xuLy = xuLy;
        }

        public string MaCTT { get => _maCTT; set => _maCTT = value; }
        public string MaKH { get => _maKH; set => _maKH = value; }
        public string MaNV { get => _maNV; set => _maNV = value; }
        public DateTime NgayLapPhieu { get => _ngayLapPhieu; set => _ngayLapPhieu = value; }
        public int TienDatCoc { get => _tienDatCoc; set => _tienDatCoc = value; }
        public int TinhTrangXuLy { get => _tinhTrangXuLy; set => _tinhTrangXuLy = value; }
        public int XuLy { get => xuLy; set => xuLy = value; }
    }
}
