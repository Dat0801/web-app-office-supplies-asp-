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
using ZXing;
using ZXing.Common;
namespace GUI
{
    public partial class FormTaoMaVach : Form
    {
        ProductBLL productBLL = new ProductBLL();
        public FormTaoMaVach()
        {
            InitializeComponent();
            dtgv_Products.CellClick += Dtgv_Products_CellClick;
            btn_CreateProductCode.Click += btnGenerateBarcode_Click;

        }
        public Bitmap GenerateBarcode(string productCode)
        {
            BarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    Width = 300,
                    Height = 100,
                    Margin = 10
                }
            };
            return writer.Write(productCode);
        }
        private void btnGenerateBarcode_Click(object sender, EventArgs e)
        {
            string productCode = txt_ProID.Text;
            if (!string.IsNullOrEmpty(productCode))
            {
                // Tạo mã vạch và hiển thị trong PictureBox
                Bitmap barcode = GenerateBarcode(productCode);
                picBox.Image = barcode;
                // Lưu mã vạch vào db
                bool rs = productBLL.AddBarcode(productCode, productCode);
                if(rs)
                {
                    MessageBox.Show("Tạo mã vạch thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tạo mã vạch thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                FormTaoMaVach_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormTaoMaVach_Load(object sender, EventArgs e)
        {
            dtgv_Products.DataSource = productBLL.GetProducts();
            
        }
        private void Dtgv_Products_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {                
                string productId = dtgv_Products.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_ProID.Text = productId;
            }
        }

        
    }
}
