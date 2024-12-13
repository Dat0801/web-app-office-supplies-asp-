using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        string tenDangNhap;
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }

        public MainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.FormClosed += MainForm_FormClosed;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.loginForm.Show();
        }

        private void thêmSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchSảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            if (Program.formDSSanPham == null || Program.formDSSanPham.IsDisposed)
            {
                Program.formDSSanPham = new FormDSSanPham();
                Program.formDSSanPham.MdiParent = this;
                Program.formDSSanPham.WindowState = FormWindowState.Maximized;
                Program.formDSSanPham.Width = this.ClientSize.Width + 20;
                Program.formDSSanPham.Height = this.ClientSize.Height + 40;

                Program.formDSSanPham.Show();
            }
            else
            {
                Program.formDSSanPham.BringToFront();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
