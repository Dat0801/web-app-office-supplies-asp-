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
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace GUI
{
    public partial class FormQLBanHang : Form
    {
        private readonly ProductBLL productBLL;
        private readonly UserBLL userBLL;
        private FilterInfoCollection videoDevices; // Danh sách camera
        private VideoCaptureDevice videoSource;   // Camera đang sử dụng

        public FormQLBanHang()
        {
            InitializeComponent();
            productBLL = new ProductBLL();
            userBLL = new UserBLL();
            btnTimKiemSP.Click += BtnTimKiemSP_Click;
            btnTimKiemKH.Click += BtnTimKiemKH_Click;
            btn_ScanProduct.Click += Btn_ScanProduct_Click;
        }

        private void Btn_ScanProduct_Click(object sender, EventArgs e)
        {
            StartCamera();
        }

        private void StartCamera()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("Không tìm thấy camera.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString); // Sử dụng camera đầu tiên
            videoSource.NewFrame += VideoSource_NewFrame;
            videoSource.Start();
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Kiểm tra nếu đang ở trong UI thread, nếu không thì dùng Invoke
            if (picBoxCamera.InvokeRequired)
            {
                picBoxCamera.Invoke(new Action(() =>
                {
                    // Lấy khung hình gốc từ sự kiện NewFrame
                    Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();

                    // Cắt ảnh để chỉ lấy phần bên trong picBox
                    Bitmap croppedBitmap = CropImage(bitmap, picBoxCamera.Width, picBoxCamera.Height);

                    // Hiển thị khung hình cắt lên PictureBox
                    picBoxCamera.Image = croppedBitmap;

                    // Giải mã mã vạch từ khung hình cắt
                    DecodeBarcode(croppedBitmap);
                }));
            }
            else
            {
                // Nếu đã ở trong UI thread, thực hiện ngay
                Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();

                // Cắt ảnh để chỉ lấy phần bên trong picBox
                Bitmap croppedBitmap = CropImage(bitmap, picBoxCamera.Width, picBoxCamera.Height);

                // Hiển thị khung hình cắt lên PictureBox
                picBoxCamera.Image = croppedBitmap;

                // Giải mã mã vạch từ khung hình cắt
                DecodeBarcode(croppedBitmap);
            }
        }

        private Bitmap CropImage(Bitmap originalBitmap, int width, int height)
        {
            // Tạo vùng cắt (Rectangle) dựa trên kích thước của picBoxCamera
            Rectangle cropArea = new Rectangle(0, 0, width, height);

            // Cắt ảnh theo vùng đã định nghĩa
            Bitmap croppedBitmap = originalBitmap.Clone(cropArea, originalBitmap.PixelFormat);
            return croppedBitmap;
        }


        private void DecodeBarcode(Bitmap bitmap)
        {
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitmap);

            if (result != null)
            {
                txtMaSP.Text = result.Text;

                // Dừng camera sau khi quét thành công
                StopCamera();

                // Xử lý quét mã vạch (thêm sản phẩm vào giỏ hàng)
                ProcessBarcode(result.Text);
            }
        }
        private void ProcessBarcode(string barcode)
        {
            // 1. Kiểm tra mã vạch có tồn tại trong cơ sở dữ liệu hay không
            var product = productBLL.GetProductByBarcode(barcode);
            if (product == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm với mã vạch này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Thêm sản phẩm vào danh sách giỏ hàng
            AddToCart(barcode);

            // 3. Cập nhật giao diện giỏ hàng
            UpdateCartUI();
        }

        private void StopCamera()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                // Ngừng sự kiện NewFrame
                videoSource.NewFrame -= VideoSource_NewFrame;

                // Gửi tín hiệu dừng và chờ quá trình dừng hoàn tất
                videoSource.SignalToStop();
                videoSource.WaitForStop();

                // Đảm bảo videoSource được giải phóng
                videoSource = null;
            }
        }


        private void AddToCart(string barcode)
        {
            var product = productBLL.GetProductByBarcode(barcode);            
            if (product == null)
            {
                MessageBox.Show("Sản phẩm không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
            foreach (DataGridViewRow row in dataGridViewGioHang.Rows)
            {
                if (row.Cells["ProductID"].Value.ToString() == product.product_id)
                {
                    // Nếu đã tồn tại, tăng số lượng
                    int currentQuantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    row.Cells["Quantity"].Value = currentQuantity + 1;
                    row.Cells["Total"].Value = (currentQuantity + 1) * product.price;
                    return;
                }
            }

            // Nếu chưa tồn tại, thêm sản phẩm mới
            dataGridViewGioHang.Rows.Add(product.product_id, product.product_name, 1, product.price, product.price);
            UpdateCartUI();
        }

        private void UpdateCartUI()
        {
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in dataGridViewGioHang.Rows)
            {
                totalAmount += Convert.ToDecimal(row.Cells["Total"].Value);
            }

            txtTotalAmount.Text = totalAmount.ToString("C"); // Hiển thị tổng tiền
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
            // Cấu hình DataGridView
            dataGridViewGioHang.Columns.Add("ProductID", "Mã sản phẩm");
            dataGridViewGioHang.Columns.Add("ProductName", "Tên sản phẩm");
            dataGridViewGioHang.Columns.Add("Quantity", "Số lượng");
            dataGridViewGioHang.Columns.Add("Price", "Đơn giá");
            dataGridViewGioHang.Columns.Add("Total", "Thành tiền");

            // Căn chỉnh cột
            dataGridViewGioHang.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGioHang.Columns["Price"].DefaultCellStyle.Format = "C";
            dataGridViewGioHang.Columns["Total"].DefaultCellStyle.Format = "C";
        }
    }
}
