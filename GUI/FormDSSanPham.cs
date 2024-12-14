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
namespace GUI
{
    public partial class FormDSSanPham : Form
    {
        private readonly ProductBLL productBLL;

        public FormDSSanPham()
        {
            InitializeComponent();
            productBLL = new ProductBLL();
            dataGridViewDSSP.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BtnThemSP.Click += BtnThemSP_Click;
        }

        private void BtnThemSP_Click(object sender, EventArgs e)
        {
            if(Program.formThemSP == null)
            {
                Program.formThemSP = new FormThemSanPham();
                Program.formThemSP.ShowDialog();
            } else
            {
                Program.formThemSP.ShowDialog();
            }
        }

        public void LoadSanPham()
        {
            var products = productBLL.GetProducts();
            var productWithCategory = from p in products
                                      select new
                                      {
                                          p.product_id,
                                          p.product_name,
                                          p.purchase_price,
                                          p.price,
                                          p.stock_quantity,
                                          p.category.category_name
                                      };
            dataGridViewDSSP.DataSource = productWithCategory.ToList();
            dataGridViewDSSP.ReadOnly = true;
            dataGridViewDSSP.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridViewDSSP.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            dataGridViewDSSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDSSP.Columns["product_id"].HeaderText = "Mã sản phẩm";
            dataGridViewDSSP.Columns["category_name"].HeaderText = "Danh mục";
            dataGridViewDSSP.Columns["product_name"].HeaderText = "Tên sản phẩm";
            dataGridViewDSSP.Columns["purchase_price"].HeaderText = "Giá nhập";
            dataGridViewDSSP.Columns["price"].HeaderText = "Giá bán";
            dataGridViewDSSP.Columns["stock_quantity"].HeaderText = "Số lượng tồn";
        }

        private void FormDSSanPham_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowIcon = false;
            LoadSanPham();
        }
    }
}
