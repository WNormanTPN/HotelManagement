using BUS;
using DTO;
using GUI.GUI_BOOKING;
using GUI.GUI_COMPONENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GUI
{
    public static class Program
    {
        static NhanVienBUS nvBus = new NhanVienBUS();
        public static NhanVienDTO nhanVien;
        public static GMailer gmailer = GMailer.Instance;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLoading());
        }
    }
}
