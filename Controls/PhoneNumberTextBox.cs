using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controls
{
    public partial class PhoneNumberTextBox : TextBox
    {
        private ErrorProvider errorProvider;
        public PhoneNumberTextBox()
        {
            InitializeComponent();
            this.KeyPress += PhoneNumberTextBox_KeyPress;
            this.TextChanged += PhoneNumberTextBox_TextChanged;
            errorProvider = new ErrorProvider();
        }

        private void PhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!IsValidPhoneNumber(this.Text))
            {
                errorProvider.SetError(this, "Số điện thoại không hợp lệ.");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void PhoneNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^(0[1-9]{1}[0-9]{8}|0[1-9]{1}[0-9]{2}[0-9]{7})$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
    }
}
