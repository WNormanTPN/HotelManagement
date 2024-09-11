using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietThuePhongDTO
    {
        private string _maCTT;
        private string _maP;
        private DateTime _ngayThue;
        private DateTime? _ngayTra;
        private DateTime? _ngayCheckOut;
        private int _giaThue;
        private int _loaiHinhThue; // 0 là thuê theo ngày, 1 là thuê theo giờ, 2 là khác (Chưa xác định ngày trả)
        private int _tinhTrang; // 0 là chưa xử lý, 1 là đã lấy phòng, 2 là đã trả phòng

        public ChiTietThuePhongDTO()
        {
        }
        public ChiTietThuePhongDTO(string maCTT, string maP, DateTime ngayThue, DateTime ngayTra, DateTime ngayCheckOut, int giaThue, int loaiHinhThue, int tinhTrang)
        {
            _maCTT = maCTT;
            _maP = maP;
            _ngayThue = ngayThue;
            _ngayTra = ngayTra;
            _ngayCheckOut = ngayCheckOut;
            _giaThue = giaThue;
            _loaiHinhThue = loaiHinhThue;
            _tinhTrang = tinhTrang;
        }

        public string MaCTT { get => _maCTT; set => _maCTT = value; }
        public string MaP { get => _maP; set => _maP = value; }
        public DateTime NgayThue { get => _ngayThue; set => _ngayThue = value; }
        public DateTime? NgayTra { get => _ngayTra; set => _ngayTra = value; }
        public DateTime? NgayCheckOut { get => _ngayCheckOut; set => _ngayCheckOut = value; }
        public int LoaiHinhThue { get => _loaiHinhThue; set => _loaiHinhThue = value; }
        public int TinhTrang { get => _tinhTrang; set => _tinhTrang = value; }
        public int GiaThue { get => _giaThue; set => _giaThue = value; }
    }
}
