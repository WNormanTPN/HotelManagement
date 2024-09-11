using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietThueDichVuDTO
    {
        private string _maCTT;
        private string _maDV;
        private DateTime _ngaySuDung;
        private int _giaDV;
        private int _soLuong;

        public ChiTietThueDichVuDTO(){
        }
        public ChiTietThueDichVuDTO(string maCTT, string maDV, DateTime ngaySuDung, int giaDV, int soLuong)
        {
            _maCTT = maCTT;
            _maDV = maDV;
            _ngaySuDung = ngaySuDung;
            _giaDV = giaDV;
            _soLuong = soLuong;
        }
        public string MaCTT { get => _maCTT; set => _maCTT = value; }
        public string MaDV { get => _maDV; set => _maDV = value; }
        public DateTime NgaySuDung { get => _ngaySuDung; set => _ngaySuDung = value; }
        public int GiaDV { get => _giaDV; set => _giaDV = value; }
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
    }
}
