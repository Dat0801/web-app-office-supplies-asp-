using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Controls;
using VanPhongPham.Models;
namespace GUI
{
    public partial class FormThemSanPham : Form
    {
        private readonly ProductBLL productBLL = new ProductBLL();
        public FormThemSanPham()
        {
            InitializeComponent();
            btnPrimaryImage.Click += BtnPrimaryImage_Click;
            btnSecondaryImage.Click += BtnSecondaryImage_Click;
            btnThemSP.Click += BtnThemSP_Click;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private Boolean ValidateTextBox()
        {
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Tên sản phẩm không để trống!");
                txtTenSP.Focus();
                return false;
            } 

            if (string.IsNullOrWhiteSpace(txtHeSo.Text))
            {
                MessageBox.Show("Hệ số không để trống!");
                txtHeSo.Focus();
                return false;
            }

            if (!decimal.TryParse(txtHeSo.Text, out decimal heSo) || heSo < 1 || heSo > 2)
            {
                MessageBox.Show("Hệ số phải nằm trong khoảng từ 1 đến 2!");
                txtHeSo.Focus();
                return false;
            }

            return true;
        }


        private void BtnThemSP_Click(object sender, EventArgs e)
        {
            if(ValidateTextBox())
            {

            }
        }

        private void BtnSecondaryImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select Images",
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        ImageWithButton imageControl = new ImageWithButton(filePath);
                        flowLayoutPanelImages.Controls.Add(imageControl);
                    }
                    flowLayoutPanelImages.WrapContents = false;
                    flowLayoutPanelImages.AutoScroll = true;
                    flowLayoutPanelImages.FlowDirection = FlowDirection.TopDown;
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("Kích thước file quá lớn để tải!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnPrimaryImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select an Image"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    Image img = Image.FromFile(filePath);

                    pictureBoxPrimaryImage.Image = img;
                    pictureBoxPrimaryImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("Kích thước file quá lớn để tải!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadThuocTinh()
        {
            var items = productBLL.GetAttributes();

            foreach (var item in items)
            {
                CheckBox checkBoxAttribute = new CheckBox
                {
                    Text = item.attribute_name,
                    AutoSize = true
                };

                checkBoxAttribute.CheckedChanged += (sender, e) => OnAttributeCheckedChanged(item, checkBoxAttribute);

                flowLayoutPanelThuocTinh.Controls.Add(checkBoxAttribute);
            }

            flowLayoutPanelThuocTinh.WrapContents = false;
            flowLayoutPanelThuocTinh.AutoScroll = true;
            flowLayoutPanelThuocTinh.FlowDirection = FlowDirection.TopDown;

            flowLayoutPanelGTThuocTinh.WrapContents = false;
            flowLayoutPanelGTThuocTinh.AutoScroll = true;
            flowLayoutPanelGTThuocTinh.FlowDirection = FlowDirection.TopDown;
        }

        private void OnAttributeCheckedChanged(attribute item, CheckBox checkBoxAttribute)
        {
            if (checkBoxAttribute.Checked)
            {
                AddAttributeValues(item.attribute_id);
            }
            else
            {
                RemoveAttributeValues(item.attribute_id);
            }
        }

        private void AddAttributeValues(string attributeId)
        {
            var attributeValues = productBLL.GetAttributeValues(attributeId);

            foreach (var value in attributeValues)
            {
                bool exists = flowLayoutPanelGTThuocTinh.Controls.OfType<CheckBox>().Any(c => c.Text == value.value);
                if (!exists)
                {
                    CheckBox checkBoxValue = new CheckBox
                    {
                        Text = value.value,
                        AutoSize = true
                    };

                    flowLayoutPanelGTThuocTinh.Controls.Add(checkBoxValue);
                }
            }
        }

        private void RemoveAttributeValues(string attributeId)
        {
            var attributeValues = productBLL.GetAttributeValues(attributeId);

            foreach (var value in attributeValues)
            {
                var checkBoxToRemove = flowLayoutPanelGTThuocTinh.Controls.OfType<CheckBox>()
                    .FirstOrDefault(c => c.Text == value.value);

                if (checkBoxToRemove != null)
                {
                    flowLayoutPanelGTThuocTinh.Controls.Remove(checkBoxToRemove);
                }
            }
        }

        private void LoadTrangThai()
        {
            List<KeyValuePair<string, int>> trangThaiList = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("Đang kinh doanh", 1),
                new KeyValuePair<string, int>("Ngừng kinh doanh", 0)
            };

            cboTrangThai.DataSource = trangThaiList;

            cboTrangThai.DisplayMember = "Key";   
            cboTrangThai.ValueMember = "Value";  

            cboTrangThai.SelectedValue = 1; 
        }

        private void LoadDanhMuc()
        {
            var categories = productBLL.GetCategories();
            cboDanhMuc.DataSource = categories;
            cboDanhMuc.DisplayMember = "category_name";
            cboDanhMuc.ValueMember = "category_id";
        }

        private void FormThemSanPham_Load(object sender, EventArgs e)
        {
            txtMaSP.Text = productBLL.GenerateProductId();
            LoadThuocTinh();
            LoadTrangThai();
            LoadDanhMuc();
        }
    }
}
