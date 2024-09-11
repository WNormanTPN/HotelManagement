using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChucNangDTO
    {
        private string _maChucNang;
        private string _tenChucNang;
        public ChucNangDTO() { }

        public ChucNangDTO(string maChucNang, string tenChucNang)
        {
            _maChucNang = maChucNang;
            _tenChucNang = tenChucNang;
        }
        public string MaChucNang { get => _maChucNang; set => _maChucNang = value; }
        public string TenChucNang { get => _tenChucNang; set => _tenChucNang = value; }
    }
}
