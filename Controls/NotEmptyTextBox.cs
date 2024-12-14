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
    public partial class NotEmptyTextBox : TextBox
    {
        private readonly ErrorProvider errorProvider;
        public NotEmptyTextBox()
        {
            InitializeComponent();
            this.Validating += NotEmptyTextBox_Validating; ;
            errorProvider = new ErrorProvider
            {
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };
        }

        private void NotEmptyTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Text))
            {
                errorProvider.SetError(this, "Không được bỏ trống");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(this, string.Empty);  // Xóa lỗi nếu hợp lệ
            }
        }
    }
}
