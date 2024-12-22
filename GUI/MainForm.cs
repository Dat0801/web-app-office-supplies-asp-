using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        string tenDangNhap;
        string role;
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string Role { get => role; set => role = value; }
        public MainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.FormClosed += MainForm_FormClosed;
            this.DanhSáchNhàCungCấpToolStripMenuItem.Click += DanhSáchNhàCungCấpToolStripMenuItem_Click;
            this.QuảnLýBánHàngToolStripMenuItem.Click += QuảnLýBánHàngToolStripMenuItem_Click;            
        }

        private void QuảnLýBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.formQLBanHang == null || Program.formQLBanHang.IsDisposed)
            {
                Program.formQLBanHang = new FormQLBanHang
                {
                    MdiParent = this,
                    FormBorderStyle = FormBorderStyle.FixedSingle,
                    MaximizeBox = false
                };
                Program.formQLBanHang.Show();
            }
            else
            {
                Program.formQLBanHang.BringToFront();
            }
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
            lb_Role.Location = new Point(this.ClientSize.Width - lb_Role.Width - 150, 0);
            lb_Name.Location = new Point(this.ClientSize.Width - lb_Name.Width - 50, 0);
            lb_Role.Text = Role;
            lb_Name.Text = TenDangNhap;
        }

        private void tạoMãVạchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.formTaoMaVach == null || Program.formTaoMaVach.IsDisposed)
            {
                Program.formTaoMaVach = new FormTaoMaVach
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized,
                    Width = this.ClientSize.Width + 20,
                    Height = this.ClientSize.Height + 40
                };
                Program.formTaoMaVach.Show();
            }
            else
            {
                Program.formTaoMaVach.BringToFront();
            }
        }
    }
}
