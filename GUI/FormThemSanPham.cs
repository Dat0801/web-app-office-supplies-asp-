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
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Net;

namespace GUI
{
    public partial class FormThemSanPham : Form
    {
        private readonly Account _cloudinaryAccount = new Account("dgvcrawly", "173992459599594", "F0N2oghE7dRuopEEVqmtRUf9mIQ");
        private readonly Cloudinary _cloudinary;
        private readonly ProductBLL productBLL = new ProductBLL();
        public FormThemSanPham()
        {
            InitializeComponent();
            _cloudinary = new Cloudinary(_cloudinaryAccount);
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

            if (string.IsNullOrEmpty(txtSoLuong.Text))
                txtSoLuong.Text = "0";

            if (string.IsNullOrEmpty(txtGiaNhap.Text))
                txtGiaNhap.Text = "0";

            return true;
        }

        private Boolean addPrimaryImage(string product_id)
        {
            if (!string.IsNullOrEmpty(selectedImageFileName) && !string.IsNullOrEmpty(selectedImageFilePath))
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(selectedImageFileName, selectedImageFilePath),
                    Folder = "user_avatars"
                };

                var uploadResult = _cloudinary.Upload(uploadParams);
                if (uploadResult.StatusCode == HttpStatusCode.OK)
                {
                    var result = uploadResult.SecureUrl.ToString();
                    image mainImage = new image
                    {
                        image_url = result,
                        is_primary = true,
                        product_id = product_id
                    };
                    productBLL.AddImages(mainImage);
                    return true;
                }
            }
            MessageBox.Show("Vui lòng chọn một hình ảnh chính trước khi thêm sản phẩm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private Boolean addSecondaryImages(string product_id)
        {
            if (flowLayoutPanelImages.Controls.Count > 0)
            {
                foreach (Control control in flowLayoutPanelImages.Controls)
                {
                    if (control is ImageWithButton imageControl)
                    {
                        string imagePath = imageControl.ImagePath;
                        string fileName = Path.GetFileName(imagePath);

                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(fileName, imagePath),
                            Folder = "user_avatars"
                        };

                        var uploadResult = _cloudinary.Upload(uploadParams);

                        if (uploadResult.StatusCode == HttpStatusCode.OK)
                        {
                            var result = uploadResult.SecureUrl.ToString();
                            image additionalImage = new image
                            {
                                image_url = result,
                                is_primary = false,
                                product_id = product_id
                            };
                            productBLL.AddImages(additionalImage);
                        }
                        else
                        {
                            MessageBox.Show($"Không thể tải lên hình ảnh phụ: {fileName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void BtnThemSP_Click(object sender, EventArgs e)
        {
            if (ValidateTextBox())
            {
                int selectedValue = (int)cboTrangThai.SelectedValue;
                product newProduct = new product()
                {
                    product_id = txtMaSP.Text,
                    product_name = txtTenSP.Text,
                    purchase_price = double.Parse(txtGiaNhap.Text),
                    price_coefficient = double.Parse(txtHeSo.Text),
                    stock_quantity = int.Parse(txtSoLuong.Text),
                    category_id = (string)cboDanhMuc.SelectedValue,
                    status = selectedValue == 1 ? (bool?)true : (bool?)false
                };

                if (addPrimaryImage(newProduct.product_id))
                {
                    addSecondaryImages(newProduct.product_id);
                    productBLL.AddProduct(newProduct);
                    foreach (var control in flowLayoutPanelGTThuocTinh.Controls)
                    {
                        if (control is CheckBox checkBox && checkBox.Checked)
                        {
                            product_attribute_value product_Attribute_Value = new product_attribute_value
                            {
                                product_id = newProduct.product_id,
                                attribute_value_id = (string)checkBox.Tag,
                            };
                            productBLL.AddProductAttributeValue(product_Attribute_Value);
                        }
                    }
                    MessageBox.Show("Thêm sản phẩm thành công!");
                    Program.formDSSanPham.LoadSanPham();
                }
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

        private string selectedImageFileName;
        private string selectedImageFilePath;
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
                    selectedImageFilePath = openFileDialog.FileName;
                    selectedImageFileName = Path.GetFileName(selectedImageFilePath);
                    Image img = Image.FromFile(selectedImageFilePath);
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
                        Tag = value.attribute_value_id,
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
