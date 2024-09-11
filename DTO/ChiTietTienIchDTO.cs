using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietTienIchDTO
    {
        private string _maP;
        private string _maTI;
        private int _soLuong;

        public ChiTietTienIchDTO()
        {
        }
        public ChiTietTienIchDTO(string maP, string maTI, int soLuong)
        {
            _maP = maP;
            _maTI = maTI;
            _soLuong = soLuong;
        }
        public string MaP { get => _maP; set => _maP = value; }
        public string MaTI { get => _maTI; set => _maTI = value; }
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
    }
}
