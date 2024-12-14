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
    public partial class NumbericTextbox : TextBox
    {
        public NumbericTextbox()
        {
            InitializeComponent();
            this.KeyPress += NumbericTextbox_KeyPress;
        }

        private void NumbericTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' || (e.KeyChar == '.' && this.Text.Contains(".")))
            {
                e.Handled = true;
            }
        }
    }
}
