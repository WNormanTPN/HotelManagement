namespace GUI.GUI_ROOM
{
    partial class ItemSelectRoom
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
            this.components = new System.ComponentModel.Container();
            this.lbTenP = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbRealTime = new System.Windows.Forms.Label();
            this.lbRealDay = new System.Windows.Forms.Label();
            this.lbLoaiP = new System.Windows.Forms.Label();
            this.lbGiaP = new System.Windows.Forms.Label();
            this.lbCTLP = new System.Windows.Forms.Label();
            this.lbTT = new System.Windows.Forms.Label();
            this.lbHienTrang = new System.Windows.Forms.Label();
            this.timerRealTime = new System.Windows.Forms.Timer(this.components);
            this.pMAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemBooking = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.pMAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTenP
            // 
            this.lbTenP.BackColor = System.Drawing.Color.Green;
            this.lbTenP.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTenP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenP.ForeColor = System.Drawing.Color.White;
            this.lbTenP.Location = new System.Drawing.Point(0, 0);
            this.lbTenP.Name = "lbTenP";
            this.lbTenP.Size = new System.Drawing.Size(393, 41);
            this.lbTenP.TabIndex = 1;
            this.lbTenP.Text = "PHÒNG THƯỜNG 101";
            this.lbTenP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbRealTime, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbRealDay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbLoaiP, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbGiaP, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbCTLP, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbTT, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbHienTrang, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(393, 144);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lbRealTime
            // 
            this.lbRealTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRealTime.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRealTime.ForeColor = System.Drawing.Color.White;
            this.lbRealTime.Location = new System.Drawing.Point(199, 72);
            this.lbRealTime.Name = "lbRealTime";
            this.lbRealTime.Size = new System.Drawing.Size(191, 36);
            this.lbRealTime.TabIndex = 5;
            this.lbRealTime.Text = "Phòng thường";
            this.lbRealTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbRealDay
            // 
            this.lbRealDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRealDay.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRealDay.ForeColor = System.Drawing.Color.White;
            this.lbRealDay.Location = new System.Drawing.Point(199, 36);
            this.lbRealDay.Name = "lbRealDay";
            this.lbRealDay.Size = new System.Drawing.Size(191, 36);
            this.lbRealDay.TabIndex = 4;
            this.lbRealDay.Text = "Phòng thường";
            this.lbRealDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbLoaiP
            // 
            this.lbLoaiP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLoaiP.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoaiP.ForeColor = System.Drawing.Color.White;
            this.lbLoaiP.Location = new System.Drawing.Point(199, 0);
            this.lbLoaiP.Name = "lbLoaiP";
            this.lbLoaiP.Size = new System.Drawing.Size(191, 36);
            this.lbLoaiP.TabIndex = 3;
            this.lbLoaiP.Text = "Phòng thường";
            this.lbLoaiP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGiaP
            // 
            this.lbGiaP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGiaP.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGiaP.ForeColor = System.Drawing.Color.White;
            this.lbGiaP.Location = new System.Drawing.Point(3, 108);
            this.lbGiaP.Name = "lbGiaP";
            this.lbGiaP.Size = new System.Drawing.Size(190, 36);
            this.lbGiaP.TabIndex = 2;
            this.lbGiaP.Text = "500,000/ngày";
            this.lbGiaP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCTLP
            // 
            this.lbCTLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCTLP.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCTLP.ForeColor = System.Drawing.Color.White;
            this.lbCTLP.Location = new System.Drawing.Point(3, 36);
            this.lbCTLP.Name = "lbCTLP";
            this.lbCTLP.Size = new System.Drawing.Size(190, 36);
            this.lbCTLP.TabIndex = 1;
            this.lbCTLP.Text = "Phòng đơn";
            this.lbCTLP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTT
            // 
            this.lbTT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTT.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTT.ForeColor = System.Drawing.Color.White;
            this.lbTT.Location = new System.Drawing.Point(3, 0);
            this.lbTT.Name = "lbTT";
            this.lbTT.Size = new System.Drawing.Size(190, 36);
            this.lbTT.TabIndex = 0;
            this.lbTT.Text = "Phòng trống\r\n";
            this.lbTT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbHienTrang
            // 
            this.lbHienTrang.AutoSize = true;
            this.lbHienTrang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbHienTrang.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHienTrang.ForeColor = System.Drawing.Color.White;
            this.lbHienTrang.Location = new System.Drawing.Point(3, 72);
            this.lbHienTrang.Name = "lbHienTrang";
            this.lbHienTrang.Size = new System.Drawing.Size(190, 36);
            this.lbHienTrang.TabIndex = 6;
            this.lbHienTrang.Text = "Phòng mới";
            this.lbHienTrang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerRealTime
            // 
            this.timerRealTime.Interval = 1000;
            this.timerRealTime.Tick += new System.EventHandler(this.timerRealTime_Tick);
            // 
            // pMAction
            // 
            this.pMAction.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.pMAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemView,
            this.mItemBooking});
            this.pMAction.Name = "pMAction";
            this.pMAction.Size = new System.Drawing.Size(305, 88);
            // 
            // mItemView
            // 
            this.mItemView.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mItemView.Name = "mItemView";
            this.mItemView.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mItemView.Size = new System.Drawing.Size(304, 28);
            this.mItemView.Text = "Xem thông tin phòng";
            // 
            // mItemBooking
            // 
            this.mItemBooking.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mItemBooking.Name = "mItemBooking";
            this.mItemBooking.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.mItemBooking.Size = new System.Drawing.Size(304, 28);
            this.mItemBooking.Text = "Đặt phòng";
            this.mItemBooking.Click += new System.EventHandler(this.Booking_Click);
            // 
            // ItemSelectRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(393, 185);
            this.ContextMenuStrip = this.pMAction;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lbTenP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ItemSelectRoom";
            this.Text = "ItemSelectRoom";
            this.MouseEnter += new System.EventHandler(this.ItemSelectRoom_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ItemSelectRoom_MouseLeave);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pMAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTenP;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbRealTime;
        private System.Windows.Forms.Label lbRealDay;
        private System.Windows.Forms.Label lbLoaiP;
        private System.Windows.Forms.Label lbGiaP;
        private System.Windows.Forms.Label lbCTLP;
        private System.Windows.Forms.Label lbTT;
        private System.Windows.Forms.Timer timerRealTime;
        private System.Windows.Forms.ContextMenuStrip pMAction;
        private System.Windows.Forms.ToolStripMenuItem mItemView;
        private System.Windows.Forms.ToolStripMenuItem mItemBooking;
        private System.Windows.Forms.Label lbHienTrang;
    }
}