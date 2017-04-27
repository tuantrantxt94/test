namespace Ass
{
    partial class BangLoaiSanPham
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
            this.showLoaiSP = new System.Windows.Forms.DataGridView();
            this.themLoaiSp = new System.Windows.Forms.Button();
            this.SuaLoaiSP = new System.Windows.Forms.Button();
            this.XoaLoaiSp = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.showLoaiSP)).BeginInit();
            this.SuspendLayout();
            // 
            // showLoaiSP
            // 
            this.showLoaiSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.showLoaiSP.Location = new System.Drawing.Point(12, 44);
            this.showLoaiSP.Name = "showLoaiSP";
            this.showLoaiSP.Size = new System.Drawing.Size(368, 241);
            this.showLoaiSP.TabIndex = 0;
            this.showLoaiSP.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // themLoaiSp
            // 
            this.themLoaiSp.Location = new System.Drawing.Point(442, 66);
            this.themLoaiSp.Name = "themLoaiSp";
            this.themLoaiSp.Size = new System.Drawing.Size(75, 23);
            this.themLoaiSp.TabIndex = 1;
            this.themLoaiSp.Text = "Thêm ";
            this.themLoaiSp.UseVisualStyleBackColor = true;
            this.themLoaiSp.Click += new System.EventHandler(this.themLoaiSp_Click);
            // 
            // SuaLoaiSP
            // 
            this.SuaLoaiSP.Location = new System.Drawing.Point(577, 66);
            this.SuaLoaiSP.Name = "SuaLoaiSP";
            this.SuaLoaiSP.Size = new System.Drawing.Size(75, 23);
            this.SuaLoaiSP.TabIndex = 2;
            this.SuaLoaiSP.Text = "Sửa";
            this.SuaLoaiSP.UseVisualStyleBackColor = true;
            this.SuaLoaiSP.Click += new System.EventHandler(this.SuaLoaiSP_Click);
            // 
            // XoaLoaiSp
            // 
            this.XoaLoaiSp.Location = new System.Drawing.Point(442, 179);
            this.XoaLoaiSp.Name = "XoaLoaiSp";
            this.XoaLoaiSp.Size = new System.Drawing.Size(75, 23);
            this.XoaLoaiSp.TabIndex = 2;
            this.XoaLoaiSp.Text = "xóa";
            this.XoaLoaiSp.UseVisualStyleBackColor = true;
            this.XoaLoaiSp.Click += new System.EventHandler(this.XoaLoaiSp_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(577, 179);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "thoát";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // BangLoaiSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 310);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.XoaLoaiSp);
            this.Controls.Add(this.SuaLoaiSP);
            this.Controls.Add(this.themLoaiSp);
            this.Controls.Add(this.showLoaiSP);
            this.Name = "BangLoaiSanPham";
            this.Text = "BangLoaiSanPham";
            ((System.ComponentModel.ISupportInitialize)(this.showLoaiSP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView showLoaiSP;
        private System.Windows.Forms.Button themLoaiSp;
        private System.Windows.Forms.Button SuaLoaiSP;
        private System.Windows.Forms.Button XoaLoaiSp;
        private System.Windows.Forms.Button button4;
    }
}