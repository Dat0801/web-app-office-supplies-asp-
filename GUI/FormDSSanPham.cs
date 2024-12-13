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
        }

        private void FormDSSanPham_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowIcon = false;
            dataGridViewDSSP.DataSource = productBLL.GetProducts();
            dataGridViewDSSP.ReadOnly = true;
            dataGridViewDSSP.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridViewDSSP.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            dataGridViewDSSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDSSP.Columns["price_coefficient"].Visible = false;
            dataGridViewDSSP.Columns["description"].Visible = false;
            dataGridViewDSSP.Columns["promotion_price"].Visible = false;
            dataGridViewDSSP.Columns["sold"].Visible = false;
            dataGridViewDSSP.Columns["avgRating"].Visible = false;
            dataGridViewDSSP.Columns["visited"].Visible = false;
            dataGridViewDSSP.Columns["status"].Visible = false;
            dataGridViewDSSP.Columns["created_at"].Visible = false;
            dataGridViewDSSP.Columns["updated_at"].Visible = false;
            dataGridViewDSSP.Columns["category"].Visible = false;
            dataGridViewDSSP.Columns["product_id"].HeaderText = "Mã sản phẩm";
            dataGridViewDSSP.Columns["category_id"].HeaderText = "Mã danh mục";
            dataGridViewDSSP.Columns["product_name"].HeaderText = "Tên sản phẩm";
            dataGridViewDSSP.Columns["purchase_price"].HeaderText = "Giá nhập";
            dataGridViewDSSP.Columns["price"].HeaderText = "Giá bán";
            dataGridViewDSSP.Columns["stock_quantity"].HeaderText = "Số lượng tồn";
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (Program.formThemSP == null || Program.formThemSP.IsDisposed)
            {
                Program.formThemSP = new FormThemSanPham();
                Program.formThemSP.MdiParent = Program.mainForm;
                Program.formThemSP.WindowState = FormWindowState.Maximized;
                Program.formThemSP.Width = this.ClientSize.Width + 20;
                Program.formThemSP.Height = this.ClientSize.Height + 40;
                Program.formThemSP.Show();
            }
            else
            {
                Program.formThemSP.BringToFront();
            }
        }
    }
}
