using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DichVuDTO
    {
        private string _maDV;
        private string _tenDV;
        private string _loaiDV; //0 là Dịch vụ ăn uống 1 là Dịch vụ chăm sóc sắc đẹp 2 là Dịch vụ giải trí, 3 là Dịch vụ tổ chức tiệc
        private int _giaDV;
        private string _hinhAnh;
        private int xuLy;

        public DichVuDTO()
        {
        }
        public DichVuDTO(string maDV, string tenDV, string loaiDV, int giaDV, string hinhAnh, int xuLy)
        {
            _maDV = maDV;
            _tenDV = tenDV;
            _loaiDV = loaiDV;
            _giaDV = giaDV;
            _hinhAnh = hinhAnh;
            this.xuLy = xuLy;
        }
        public string MaDV { get => _maDV; set => _maDV = value; }
        public string TenDV { get => _tenDV; set => _tenDV = value; }
        public string LoaiDV { get => _loaiDV; set => _loaiDV = value; }
        public int GiaDV { get => _giaDV; set => _giaDV = value; }
        public string HinhAnh { get => _hinhAnh; set => _hinhAnh = value; }
        public int XuLy { get => xuLy; set => xuLy = value; }
    }
}
