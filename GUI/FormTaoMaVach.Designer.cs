namespace GUI
{
    partial class FormTaoMaVach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_CreateProductCode = new System.Windows.Forms.Button();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.dtgv_Products = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ProID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Products)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_CreateProductCode
            // 
            this.btn_CreateProductCode.Location = new System.Drawing.Point(293, 40);
            this.btn_CreateProductCode.Name = "btn_CreateProductCode";
            this.btn_CreateProductCode.Size = new System.Drawing.Size(108, 23);
            this.btn_CreateProductCode.TabIndex = 1;
            this.btn_CreateProductCode.Text = "Tạo mã vạch";
            this.btn_CreateProductCode.UseVisualStyleBackColor = true;
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(455, 12);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(252, 86);
            this.picBox.TabIndex = 2;
            this.picBox.TabStop = false;
            // 
            // dtgv_Products
            // 
            this.dtgv_Products.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_Products.Location = new System.Drawing.Point(35, 136);
            this.dtgv_Products.Name = "dtgv_Products";
            this.dtgv_Products.RowHeadersWidth = 51;
            this.dtgv_Products.RowTemplate.Height = 24;
            this.dtgv_Products.Size = new System.Drawing.Size(672, 268);
            this.dtgv_Products.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã sản phẩm";
            // 
            // txt_ProID
            // 
            this.txt_ProID.Location = new System.Drawing.Point(126, 41);
            this.txt_ProID.Name = "txt_ProID";
            this.txt_ProID.Size = new System.Drawing.Size(141, 22);
            this.txt_ProID.TabIndex = 5;
            // 
            // FormTaoMaVach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_ProID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgv_Products);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.btn_CreateProductCode);
            this.Name = "FormTaoMaVach";
            this.Text = "FormTaoMaVach";
            this.Load += new System.EventHandler(this.FormTaoMaVach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Products)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_CreateProductCode;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.DataGridView dtgv_Products;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ProID;
    }
}