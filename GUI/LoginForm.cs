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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            loginControl1.LoginSuccess += LoginControl1_LoginSuccess;
            this.AcceptButton = loginControl1.buttonLogin;
        }

        private void LoginControl1_LoginSuccess(object sender, EventArgs e)
        {
            if (Program.mainForm == null || Program.mainForm.IsDisposed)
            {
                Program.mainForm = new MainForm();
            }
            this.Visible = false;
            Program.mainForm.TenDangNhap = loginControl1.TenDangNhap;
            Program.mainForm.Role = loginControl1.Role;
            Program.mainForm.Show();
        }
    }
}
