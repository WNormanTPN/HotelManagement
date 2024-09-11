namespace GUI.GUI_ROOM
{
    partial class ItemRoom
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
            this.pMAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemBooking = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemCleanRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.timerRealTime = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtNgayTra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtMaCTT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.pMAction.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.lbTenP.TabIndex = 0;
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
            this.tableLayoutPanel1.Controls.Add(this.lbGiaP, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbCTLP, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbTT, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(393, 105);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lbRealTime
            // 
            this.lbRealTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRealTime.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRealTime.ForeColor = System.Drawing.Color.White;
            this.lbRealTime.Location = new System.Drawing.Point(199, 70);
            this.lbRealTime.Name = "lbRealTime";
            this.lbRealTime.Size = new System.Drawing.Size(191, 35);
            this.lbRealTime.TabIndex = 5;
            this.lbRealTime.Text = "Phòng thường";
            this.lbRealTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbRealDay
            // 
            this.lbRealDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRealDay.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRealDay.ForeColor = System.Drawing.Color.White;
            this.lbRealDay.Location = new System.Drawing.Point(199, 35);
            this.lbRealDay.Name = "lbRealDay";
            this.lbRealDay.Size = new System.Drawing.Size(191, 35);
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
            this.lbLoaiP.Size = new System.Drawing.Size(191, 35);
            this.lbLoaiP.TabIndex = 3;
            this.lbLoaiP.Text = "Phòng thường";
            this.lbLoaiP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGiaP
            // 
            this.lbGiaP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGiaP.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGiaP.ForeColor = System.Drawing.Color.White;
            this.lbGiaP.Location = new System.Drawing.Point(3, 70);
            this.lbGiaP.Name = "lbGiaP";
            this.lbGiaP.Size = new System.Drawing.Size(190, 35);
            this.lbGiaP.TabIndex = 2;
            this.lbGiaP.Text = "500,000/ngày";
            this.lbGiaP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCTLP
            // 
            this.lbCTLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCTLP.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCTLP.ForeColor = System.Drawing.Color.White;
            this.lbCTLP.Location = new System.Drawing.Point(3, 35);
            this.lbCTLP.Name = "lbCTLP";
            this.lbCTLP.Size = new System.Drawing.Size(190, 35);
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
            this.lbTT.Size = new System.Drawing.Size(190, 35);
            this.lbTT.TabIndex = 0;
            this.lbTT.Text = "Phòng trống\r\n";
            this.lbTT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pMAction
            // 
            this.pMAction.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.pMAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemView,
            this.mItemBooking,
            this.toolStripSeparator1,
            this.mItemCleanRoom});
            this.pMAction.Name = "pMAction";
            this.pMAction.Size = new System.Drawing.Size(305, 94);
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
            this.mItemBooking.Click += new System.EventHandler(this.mItemBooking_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(301, 6);
            // 
            // mItemCleanRoom
            // 
            this.mItemCleanRoom.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mItemCleanRoom.Name = "mItemCleanRoom";
            this.mItemCleanRoom.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mItemCleanRoom.Size = new System.Drawing.Size(304, 28);
            this.mItemCleanRoom.Text = "Dọn phòng";
            this.mItemCleanRoom.Click += new System.EventHandler(this.mItemCleanRoom_Click);
            // 
            // timerRealTime
            // 
            this.timerRealTime.Interval = 1000;
            this.timerRealTime.Tick += new System.EventHandler(this.timerRealTime_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 146);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(393, 143);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(1);
            this.panel2.Size = new System.Drawing.Size(383, 133);
            this.panel2.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 28);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(381, 104);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtNgayTra);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 71);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(375, 30);
            this.panel5.TabIndex = 2;
            // 
            // txtNgayTra
            // 
            this.txtNgayTra.BackColor = System.Drawing.Color.White;
            this.txtNgayTra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgayTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNgayTra.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayTra.Location = new System.Drawing.Point(184, 0);
            this.txtNgayTra.Name = "txtNgayTra";
            this.txtNgayTra.ReadOnly = true;
            this.txtNgayTra.Size = new System.Drawing.Size(191, 30);
            this.txtNgayTra.TabIndex = 1;
            this.txtNgayTra.Text = "20/11/2023 07:00:00";
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày trả:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtMaCTT);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 37);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(375, 28);
            this.panel4.TabIndex = 1;
            // 
            // txtMaCTT
            // 
            this.txtMaCTT.BackColor = System.Drawing.Color.White;
            this.txtMaCTT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaCTT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaCTT.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaCTT.Location = new System.Drawing.Point(184, 0);
            this.txtMaCTT.Name = "txtMaCTT";
            this.txtMaCTT.ReadOnly = true;
            this.txtMaCTT.Size = new System.Drawing.Size(191, 30);
            this.txtMaCTT.TabIndex = 1;
            this.txtMaCTT.Text = "CTT1010230001";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã phiếu thuê:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtTenKH);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(375, 28);
            this.panel3.TabIndex = 0;
            // 
            // txtTenKH
            // 
            this.txtTenKH.BackColor = System.Drawing.Color.White;
            this.txtTenKH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenKH.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKH.Location = new System.Drawing.Point(184, 0);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.ReadOnly = true;
            this.txtTenKH.Size = new System.Drawing.Size(191, 30);
            this.txtTenKH.TabIndex = 1;
            this.txtTenKH.Text = "Trần Văn Bánh";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ tên khách thuê:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "THÔNG TIN KHÁCH THUÊ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ItemRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(393, 289);
            this.ContextMenuStrip = this.pMAction;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lbTenP);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ItemRoom";
            this.MouseEnter += new System.EventHandler(this.ItemRoom_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ItemRoom_MouseLeave);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pMAction.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTenP;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbTT;
        private System.Windows.Forms.Label lbGiaP;
        private System.Windows.Forms.Label lbCTLP;
        private System.Windows.Forms.ContextMenuStrip pMAction;
        private System.Windows.Forms.ToolStripMenuItem mItemView;
        private System.Windows.Forms.ToolStripMenuItem mItemBooking;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mItemCleanRoom;
        private System.Windows.Forms.Label lbLoaiP;
        private System.Windows.Forms.Label lbRealTime;
        private System.Windows.Forms.Label lbRealDay;
        private System.Windows.Forms.Timer timerRealTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtMaCTT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtNgayTra;
        private System.Windows.Forms.Label label4;
    }
}