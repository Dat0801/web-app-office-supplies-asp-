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
            this.DanhSáchNhàCungCấpToolStripMenuItem.Click += DanhSáchNhàCungCấpToolStripMenuItem_Click;
        }

        private void DanhSáchNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.formDSNhaCungCap == null || Program.formDSNhaCungCap.IsDisposed)
            {
                Program.formDSNhaCungCap = new FormDSNhaCungCap
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized,
                    Width = this.ClientSize.Width + 20,
                    Height = this.ClientSize.Height + 40
                };
                Program.formDSNhaCungCap.Show();
            }
            else
            {
                Program.formDSNhaCungCap.BringToFront();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.loginForm.Show();
        }

        private void DanhSáchSảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            if (Program.formDSSanPham == null || Program.formDSSanPham.IsDisposed)
            {
                Program.formDSSanPham = new FormDSSanPham
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized,
                    Width = this.ClientSize.Width + 20,
                    Height = this.ClientSize.Height + 40
                };
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
