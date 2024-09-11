namespace GUI.GUI_SERVICE
{
    partial class ItemService
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
            this.pnContainer = new System.Windows.Forms.Panel();
            this.pnContent = new System.Windows.Forms.Panel();
            this.imgDichVu = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbGiaDV = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbLoaiDV = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTenDV = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnContainer.SuspendLayout();
            this.pnContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDichVu)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnContainer
            // 
            this.pnContainer.BackColor = System.Drawing.Color.Gray;
            this.pnContainer.Controls.Add(this.pnContent);
            this.pnContainer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContainer.Location = new System.Drawing.Point(0, 0);
            this.pnContainer.Name = "pnContainer";
            this.pnContainer.Padding = new System.Windows.Forms.Padding(1);
            this.pnContainer.Size = new System.Drawing.Size(365, 274);
            this.pnContainer.TabIndex = 0;
            this.pnContainer.Click += new System.EventHandler(this.pnContainer_Click);
            this.pnContainer.MouseEnter += new System.EventHandler(this.itemService_MouseEnter);
            this.pnContainer.MouseLeave += new System.EventHandler(this.itemService_MouseLeave);
            // 
            // pnContent
            // 
            this.pnContent.BackColor = System.Drawing.Color.White;
            this.pnContent.Controls.Add(this.imgDichVu);
            this.pnContent.Controls.Add(this.tableLayoutPanel1);
            this.pnContent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(1, 1);
            this.pnContent.Name = "pnContent";
            this.pnContent.Padding = new System.Windows.Forms.Padding(7);
            this.pnContent.Size = new System.Drawing.Size(363, 272);
            this.pnContent.TabIndex = 0;
            this.pnContent.Click += new System.EventHandler(this.pnContainer_Click);
            this.pnContent.MouseEnter += new System.EventHandler(this.itemService_MouseEnter);
            this.pnContent.MouseLeave += new System.EventHandler(this.itemService_MouseLeave);
            // 
            // imgDichVu
            // 
            this.imgDichVu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgDichVu.Image = global::GUI.Properties.Resources.aaa;
            this.imgDichVu.Location = new System.Drawing.Point(7, 7);
            this.imgDichVu.Name = "imgDichVu";
            this.imgDichVu.Size = new System.Drawing.Size(349, 139);
            this.imgDichVu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgDichVu.TabIndex = 2;
            this.imgDichVu.TabStop = false;
            this.imgDichVu.Click += new System.EventHandler(this.pnContainer_Click);
            this.imgDichVu.MouseEnter += new System.EventHandler(this.itemService_MouseEnter);
            this.imgDichVu.MouseLeave += new System.EventHandler(this.itemService_MouseLeave);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 146);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(349, 119);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Click += new System.EventHandler(this.pnContainer_Click);
            this.tableLayoutPanel1.MouseEnter += new System.EventHandler(this.itemService_MouseEnter);
            this.tableLayoutPanel1.MouseLeave += new System.EventHandler(this.itemService_MouseLeave);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbGiaDV);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 81);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(343, 35);
            this.panel3.TabIndex = 2;
            this.panel3.Click += new System.EventHandler(this.pnContainer_Click);
            this.panel3.MouseEnter += new System.EventHandler(this.itemService_MouseEnter);
            this.panel3.MouseLeave += new System.EventHandler(this.itemService_MouseLeave);
            // 
            // lbGiaDV
            // 
            this.lbGiaDV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbGiaDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGiaDV.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGiaDV.ForeColor = System.Drawing.Color.Red;
            this.lbGiaDV.Location = new System.Drawing.Point(113, 0);
            this.lbGiaDV.Name = "lbGiaDV";
            this.lbGiaDV.Size = new System.Drawing.Size(230, 35);
            this.lbGiaDV.TabIndex = 1;
            this.lbGiaDV.Text = "100,000 VNĐ";
            this.lbGiaDV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbGiaDV.UseCompatibleTextRendering = true;
            this.lbGiaDV.Click += new System.EventHandler(this.pnContainer_Click);
            this.lbGiaDV.MouseEnter += new System.EventHandler(this.itemService_MouseEnter);
            this.lbGiaDV.MouseLeave += new System.EventHandler(this.itemService_MouseLeave);
            // 
            // label6
            // 
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 35);
            this.label6.TabIndex = 0;
            this.label6.Text = "Giá dịch vụ:  ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.UseCompatibleTextRendering = true;
            this.label6.Click += new System.EventHandler(this.pnContainer_Click);
            this.label6.MouseEnter += new System.EventHandler(this.itemService_MouseEnter);
            this.label6.MouseLeave += new System.EventHandler(this.itemService_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbLoaiDV);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(343, 33);
            this.panel2.TabIndex = 1;
            this.panel2.Click += new System.EventHandler(this.pnContainer_Click);
            this.panel2.MouseEnter += new System.EventHandler(this.itemService_MouseEnter);
            this.panel2.MouseLeave += new System.EventHandler(this.itemService_MouseLeave);
            // 
            // lbLoaiDV
            // 
            this.lbLoaiDV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbLoaiDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLoaiDV.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoaiDV.ForeColor = System.Drawing.Color.Black;
            this.lbLoaiDV.Location = new System.Drawing.Point(113, 0);
            this.lbLoaiDV.Name = "lbLoaiDV";
            this.lbLoaiDV.Size = new System.Drawing.Size(230, 33);
            this.lbLoaiDV.TabIndex = 1;
            this.lbLoaiDV.Text = "Thức ăn đồ uống";
            this.lbLoaiDV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbLoaiDV.UseCompatibleTextRendering = true;
            this.lbLoaiDV.Click += new System.EventHandler(this.pnContainer_Click);
            this.lbLoaiDV.MouseEnter += new System.EventHandler(this.itemService_MouseEnter);
            this.lbLoaiDV.MouseLeave += new System.EventHandler(this.itemService_MouseLeave);
            // 
            // label4
            // 
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 33);
            this.label4.TabIndex = 0;
            this.label4.Text = "Loại dịch vụ:  ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.UseCompatibleTextRendering = true;
            this.label4.Click += new System.EventHandler(this.pnContainer_Click);
            this.label4.MouseEnter += new System.EventHandler(this.itemService_MouseEnter);
            this.label4.MouseLeave += new System.EventHandler(this.itemService_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbTenDV);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 33);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.pnContainer_Click);
            this.panel1.MouseEnter += new System.EventHandler(this.itemService_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.itemService_MouseLeave);
            // 
            // lbTenDV
            // 
            this.lbTenDV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbTenDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTenDV.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenDV.ForeColor = System.Drawing.Color.Black;
            this.lbTenDV.Location = new System.Drawing.Point(113, 0);
            this.lbTenDV.Name = "lbTenDV";
            this.lbTenDV.Size = new System.Drawing.Size(230, 33);
            this.lbTenDV.TabIndex = 1;
            this.lbTenDV.Text = "Dịch vụ nước ngọt";
            this.lbTenDV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTenDV.UseCompatibleTextRendering = true;
            this.lbTenDV.Click += new System.EventHandler(this.pnContainer_Click);
            this.lbTenDV.MouseEnter += new System.EventHandler(this.itemService_MouseEnter);
            this.lbTenDV.MouseLeave += new System.EventHandler(this.itemService_MouseLeave);
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên dịch vụ:  ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.UseCompatibleTextRendering = true;
            this.label1.Click += new System.EventHandler(this.pnContainer_Click);
            this.label1.MouseEnter += new System.EventHandler(this.itemService_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.itemService_MouseLeave);
            // 
            // ItemService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 274);
            this.Controls.Add(this.pnContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ItemService";
            this.Text = "itemService";
            this.Load += new System.EventHandler(this.ItemService_Load);
            this.MouseEnter += new System.EventHandler(this.itemService_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.itemService_MouseLeave);
            this.pnContainer.ResumeLayout(false);
            this.pnContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgDichVu)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnContainer;
        private System.Windows.Forms.Panel pnContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTenDV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbGiaDV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbLoaiDV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox imgDichVu;
    }
}