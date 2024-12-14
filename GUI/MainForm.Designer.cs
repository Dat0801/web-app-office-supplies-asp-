
namespace GUI
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuảnLýSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DanhSáchSảnPhẩmToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DanhMụcSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThuộcTínhSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuảnLýNhậpHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DanhSáchNhàCungCấpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lb_Role = new System.Windows.Forms.Label();
            this.lb_Name = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QuảnLýSảnPhẩmToolStripMenuItem,
            this.QuảnLýNhậpHàngToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // QuảnLýSảnPhẩmToolStripMenuItem
            // 
            this.QuảnLýSảnPhẩmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DanhSáchSảnPhẩmToolStripMenuItem1,
            this.DanhMụcSảnPhẩmToolStripMenuItem,
            this.ThuộcTínhSảnPhẩmToolStripMenuItem});
            this.QuảnLýSảnPhẩmToolStripMenuItem.Name = "QuảnLýSảnPhẩmToolStripMenuItem";
            this.QuảnLýSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.QuảnLýSảnPhẩmToolStripMenuItem.Text = "Quản lý sản phẩm";
            // 
            // DanhSáchSảnPhẩmToolStripMenuItem1
            // 
            this.DanhSáchSảnPhẩmToolStripMenuItem1.Name = "DanhSáchSảnPhẩmToolStripMenuItem1";
            this.DanhSáchSảnPhẩmToolStripMenuItem1.Size = new System.Drawing.Size(229, 26);
            this.DanhSáchSảnPhẩmToolStripMenuItem1.Text = "Danh sách sản phẩm";
            this.DanhSáchSảnPhẩmToolStripMenuItem1.Click += new System.EventHandler(this.DanhSáchSảnPhẩmToolStripMenuItem1_Click);
            // 
            // DanhMụcSảnPhẩmToolStripMenuItem
            // 
            this.DanhMụcSảnPhẩmToolStripMenuItem.Name = "DanhMụcSảnPhẩmToolStripMenuItem";
            this.DanhMụcSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.DanhMụcSảnPhẩmToolStripMenuItem.Text = "Danh mục sản phẩm";
            // 
            // ThuộcTínhSảnPhẩmToolStripMenuItem
            // 
            this.ThuộcTínhSảnPhẩmToolStripMenuItem.Name = "ThuộcTínhSảnPhẩmToolStripMenuItem";
            this.ThuộcTínhSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.ThuộcTínhSảnPhẩmToolStripMenuItem.Text = "Thuộc tính sản phẩm";
            // 
            // QuảnLýNhậpHàngToolStripMenuItem
            // 
            this.QuảnLýNhậpHàngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DanhSáchNhàCungCấpToolStripMenuItem});
            this.QuảnLýNhậpHàngToolStripMenuItem.Name = "QuảnLýNhậpHàngToolStripMenuItem";
            this.QuảnLýNhậpHàngToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.QuảnLýNhậpHàngToolStripMenuItem.Text = "Quản lý nhập hàng";
            // 
            // DanhSáchNhàCungCấpToolStripMenuItem
            // 
            this.DanhSáchNhàCungCấpToolStripMenuItem.Name = "DanhSáchNhàCungCấpToolStripMenuItem";
            this.DanhSáchNhàCungCấpToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.DanhSáchNhàCungCấpToolStripMenuItem.Text = "Danh sách nhà cung cấp";
            // 
            // lb_Role
            // 
            this.lb_Role.AutoSize = true;
            this.lb_Role.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Role.Location = new System.Drawing.Point(655, 9);
            this.lb_Role.Name = "lb_Role";
            this.lb_Role.Size = new System.Drawing.Size(0, 22);
            this.lb_Role.TabIndex = 1;
            // 
            // lb_Name
            // 
            this.lb_Name.AutoSize = true;
            this.lb_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Name.Location = new System.Drawing.Point(744, 9);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(0, 22);
            this.lb_Name.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lb_Name);
            this.Controls.Add(this.lb_Role);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Quản trị";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuảnLýSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DanhSáchSảnPhẩmToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem DanhMụcSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThuộcTínhSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuảnLýNhậpHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DanhSáchNhàCungCấpToolStripMenuItem;
        private System.Windows.Forms.Label lb_Role;
        private System.Windows.Forms.Label lb_Name;
    }
}