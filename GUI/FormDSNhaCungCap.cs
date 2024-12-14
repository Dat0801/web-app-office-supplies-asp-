using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormDSNhaCungCap : Form
    {
        private readonly SupplierBLL supplierBLL;
        public FormDSNhaCungCap()
        {
            InitializeComponent();
            supplierBLL = new SupplierBLL();
            dtgv_dsncc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void FormDSNhaCungCap_Load(object sender, EventArgs e)
        {
            dtgv_dsncc.DataSource = supplierBLL.GetSuppliers();
        }
    }
}
