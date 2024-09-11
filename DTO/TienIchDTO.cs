using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TienIchDTO
    {
        private string _maTI;
        private string _tenTI;
        private int _xuLy;
        public TienIchDTO(){
        }
        public TienIchDTO(string maTI, string tenTI, int xuLy)
        {
            _maTI = maTI;
            _tenTI = tenTI;
            _xuLy = xuLy;
        }
        public string MaTI { get => _maTI; set => _maTI = value; }
        public string TenTI { get => _tenTI; set => _tenTI = value; }
        public int XuLy { get => _xuLy; set => _xuLy = value; }
    }
}
