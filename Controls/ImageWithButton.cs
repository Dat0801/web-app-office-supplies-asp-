using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controls
{
    public partial class ImageWithButton : UserControl
    {
        public PictureBox PictureBox { get; private set; }
        private readonly Button btnDelete;
        public string ImagePath { get; private set; }
        public ImageWithButton(string imagePath)
        {
            InitializeComponent();
            ImagePath = imagePath;
            PictureBox = new PictureBox
            {
                Image = Image.FromFile(imagePath),
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = 150, 
                Height = 150
            };

            btnDelete = new Button
            {
                Text = "Xóa",
                Width = 40,
                Height = 20
            };
            btnDelete.Click += BtnDelete_Click;

            this.Width = PictureBox.Width;
            this.Height = PictureBox.Height;

            this.Controls.Add(PictureBox);
            this.Controls.Add(btnDelete);

            btnDelete.Location = new Point(PictureBox.Width - btnDelete.Width, 0);
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right; 

            btnDelete.BringToFront();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);  // Xóa UserControl ra khỏi FlowLayoutPanel
            PictureBox.Dispose(); // Giải phóng bộ nhớ của ảnh
        }
    }
}
