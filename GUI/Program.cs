﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    static class Program
    {
        public static MainForm mainForm = null;
        public static LoginForm loginForm = null;
        public static FormDSSanPham formDSSanPham = null;
        public static FormThemSanPham formThemSP = null;
        public static FormDSNhaCungCap formDSNhaCungCap = null;
        public static FormQLBanHang formQLBanHang = null;
        public static FormTaoMaVach formTaoMaVach = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            loginForm = new LoginForm();
            Application.Run(loginForm);
        }
    }
}
