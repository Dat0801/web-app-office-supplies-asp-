
namespace GUI
{
    partial class FormDSNhaCungCap
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
            this.button1 = new System.Windows.Forms.Button();
            this.dtgv_dsncc = new System.Windows.Forms.DataGridView();
            this.btn_Search = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_dsncc)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(896, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Nhà cung cấp đã xóa";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dtgv_dsncc
            // 
            this.dtgv_dsncc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_dsncc.Location = new System.Drawing.Point(32, 82);
            this.dtgv_dsncc.Name = "dtgv_dsncc";
            this.dtgv_dsncc.RowHeadersWidth = 51;
            this.dtgv_dsncc.RowTemplate.Height = 24;
            this.dtgv_dsncc.Size = new System.Drawing.Size(1045, 290);
            this.dtgv_dsncc.TabIndex = 4;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(364, 48);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 28;
            this.btn_Search.Text = "Tìm kiếm";
            this.btn_Search.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(199, 48);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(145, 22);
            this.textBox4.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "Tìm kiếm nhà cung cấp";
            // 
            // FormDSNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 540);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtgv_dsncc);
            this.Controls.Add(this.button1);
            this.Name = "FormDSNhaCungCap";
            this.Text = "Quản lý nhà cung cấp";
            this.Load += new System.EventHandler(this.FormDSNhaCungCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_dsncc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dtgv_dsncc;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
    }
}