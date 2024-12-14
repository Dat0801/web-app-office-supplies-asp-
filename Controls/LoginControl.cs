using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VanPhongPham.Models;
using BLL;
namespace Controls
{
    public partial class LoginControl : UserControl
    {
        public event EventHandler LoginSuccess;
        private readonly UserBLL userBLL;
        public IButtonControl buttonLogin;
        string tenDangNhap;
        string role;

        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string Role { get => role; set => role = value; }
        public LoginControl()
        {
            InitializeComponent();
            userBLL = new UserBLL();
            btnLogin.Click += BtnLogin_Click;
            buttonLogin = btnLogin;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lblUsername.Text.ToLower());
                this.txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                MessageBox.Show("Không được bỏ trống " + lblPassword.Text.ToLower());
                this.txtPassword.Focus();
                return;
            }
            ProcessLogin();
        }

        public void ProcessLogin()
        {
             var user = userBLL.CheckLoginAdmin(txtUsername.Text, txtPassword.Text);

            if (user == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                return;
            }
            tenDangNhap = user.full_name;
            role = user.user_roles.FirstOrDefault().role.role_name;
            if (LoginSuccess != null)
            {
                LoginSuccess(this, EventArgs.Empty);
            }
        }
    }
}
