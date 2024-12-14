using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using VanPhongPham.Models;
namespace GUI
{
    public partial class FormQLBanHang : Form
    {
        private readonly ProductBLL productBLL;
        private readonly UserBLL userBLL;
        public FormQLBanHang()
        {
            InitializeComponent();
            productBLL = new ProductBLL();
            userBLL = new UserBLL();
            btnTimKiemSP.Click += BtnTimKiemSP_Click;
            btnTimKiemKH.Click += BtnTimKiemKH_Click;
        }

        private void BtnTimKiemKH_Click(object sender, EventArgs e)
        {
            string phone_number = txtSDT.Text;
            var user = userBLL.GetUserByPhone(phone_number);
            if(user != null)
            {
                txtTenKH.Text = user.full_name;
            } else
            {
                MessageBox.Show("Khách hàng không tồn tại trong hệ thống!");
            }
        }

        private void BtnTimKiemSP_Click(object sender, EventArgs e)
        {
            string product_id = txtMaSP.Text;
            var product = productBLL.GetProduct(product_id);
            txtTenSP.Text = product.product_name;
        }

        private void FormQLBanHang_Load(object sender, EventArgs e)
        {
            txtTenNV.Text = Program.mainForm.TenDangNhap;
        }
    }
}
