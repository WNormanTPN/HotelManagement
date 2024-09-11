namespace GUI
{
    partial class frmForgotPassword
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
            this.pnTop = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.btnClose = new GUI.GUI_COMPONENT.ButtonRounded();
            this.panelRounded1 = new GUI.GUI_COMPONENT.PanelRounded();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.buttonRounded4 = new GUI.GUI_COMPONENT.ButtonRounded();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonRounded2 = new GUI.GUI_COMPONENT.ButtonRounded();
            this.buttonRounded1 = new GUI.GUI_COMPONENT.ButtonRounded();
            this.btnLogin = new GUI.GUI_COMPONENT.ButtonRounded();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonRounded3 = new GUI.GUI_COMPONENT.ButtonRounded();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnTop.SuspendLayout();
            this.panelRounded1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnTop.Controls.Add(this.Title);
            this.pnTop.Controls.Add(this.btnClose);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(2, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1134, 40);
            this.pnTop.TabIndex = 4;
            this.pnTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseDown);
            this.pnTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseMove);
            // 
            // Title
            // 
            this.Title.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(3, 7);
            this.Title.Margin = new System.Windows.Forms.Padding(3);
            this.Title.Name = "Title";
            this.Title.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.Title.Size = new System.Drawing.Size(164, 23);
            this.Title.TabIndex = 1;
            this.Title.Text = "QUÊN MẬT KHẨU";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClose.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClose.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnClose.BorderRadius = 0;
            this.btnClose.BorderSize = 0;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.ForegroundColor = System.Drawing.Color.White;
            this.btnClose.Image = global::GUI.Properties.Resources.icons8_close_24;
            this.btnClose.Location = new System.Drawing.Point(1088, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(46, 40);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelRounded1
            // 
            this.panelRounded1.BackColor = System.Drawing.Color.White;
            this.panelRounded1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.panelRounded1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.panelRounded1.BorderRadius = 0;
            this.panelRounded1.BorderSize = 2;
            this.panelRounded1.Controls.Add(this.panel2);
            this.panelRounded1.Controls.Add(this.pictureBox2);
            this.panelRounded1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRounded1.Location = new System.Drawing.Point(2, 40);
            this.panelRounded1.Name = "panelRounded1";
            this.panelRounded1.Size = new System.Drawing.Size(1134, 568);
            this.panelRounded1.TabIndex = 5;
            this.panelRounded1.UnderlinedStyle = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.btnLogin);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(675, 28);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(405, 501);
            this.panel2.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.textBox3);
            this.panel5.Controls.Add(this.buttonRounded4);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(10, 193);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(385, 32);
            this.panel5.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(142, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(196, 30);
            this.textBox3.TabIndex = 2;
            this.textBox3.UseSystemPasswordChar = true;
            // 
            // buttonRounded4
            // 
            this.buttonRounded4.BackColor = System.Drawing.Color.Transparent;
            this.buttonRounded4.BackgroundColor = System.Drawing.Color.Transparent;
            this.buttonRounded4.BackgroundImage = global::GUI.Properties.Resources.hien;
            this.buttonRounded4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRounded4.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonRounded4.BorderRadius = 40;
            this.buttonRounded4.BorderSize = 0;
            this.buttonRounded4.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonRounded4.FlatAppearance.BorderSize = 0;
            this.buttonRounded4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRounded4.ForeColor = System.Drawing.Color.White;
            this.buttonRounded4.ForegroundColor = System.Drawing.Color.White;
            this.buttonRounded4.Location = new System.Drawing.Point(338, 0);
            this.buttonRounded4.Name = "buttonRounded4";
            this.buttonRounded4.Size = new System.Drawing.Size(47, 32);
            this.buttonRounded4.TabIndex = 1;
            this.buttonRounded4.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mật khẩu mới";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonRounded2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonRounded1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 345);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(385, 45);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // buttonRounded2
            // 
            this.buttonRounded2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonRounded2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonRounded2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonRounded2.BorderRadius = 40;
            this.buttonRounded2.BorderSize = 0;
            this.buttonRounded2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRounded2.FlatAppearance.BorderSize = 0;
            this.buttonRounded2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRounded2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRounded2.ForeColor = System.Drawing.Color.Black;
            this.buttonRounded2.ForegroundColor = System.Drawing.Color.Black;
            this.buttonRounded2.Location = new System.Drawing.Point(195, 0);
            this.buttonRounded2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.buttonRounded2.Name = "buttonRounded2";
            this.buttonRounded2.Size = new System.Drawing.Size(190, 45);
            this.buttonRounded2.TabIndex = 1;
            this.buttonRounded2.Text = "Đổi mật khẩu";
            this.buttonRounded2.UseVisualStyleBackColor = false;
            this.buttonRounded2.Click += new System.EventHandler(this.buttonRounded2_Click);
            // 
            // buttonRounded1
            // 
            this.buttonRounded1.BackColor = System.Drawing.Color.Gold;
            this.buttonRounded1.BackgroundColor = System.Drawing.Color.Gold;
            this.buttonRounded1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonRounded1.BorderRadius = 40;
            this.buttonRounded1.BorderSize = 0;
            this.buttonRounded1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRounded1.FlatAppearance.BorderSize = 0;
            this.buttonRounded1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRounded1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRounded1.ForeColor = System.Drawing.Color.Black;
            this.buttonRounded1.ForegroundColor = System.Drawing.Color.Black;
            this.buttonRounded1.Location = new System.Drawing.Point(0, 0);
            this.buttonRounded1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.buttonRounded1.Name = "buttonRounded1";
            this.buttonRounded1.Size = new System.Drawing.Size(189, 45);
            this.buttonRounded1.TabIndex = 0;
            this.buttonRounded1.Text = "Đăng nhập";
            this.buttonRounded1.UseVisualStyleBackColor = false;
            this.buttonRounded1.Click += new System.EventHandler(this.buttonRounded1_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLogin.BackColor = System.Drawing.Color.Teal;
            this.btnLogin.BackgroundColor = System.Drawing.Color.Teal;
            this.btnLogin.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLogin.BorderRadius = 40;
            this.btnLogin.BorderSize = 0;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.ForegroundColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(10, 274);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(385, 45);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Xác nhận";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.textBox2);
            this.panel4.Controls.Add(this.buttonRounded3);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(10, 142);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(385, 32);
            this.panel4.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(194, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 30);
            this.textBox2.TabIndex = 3;
            // 
            // buttonRounded3
            // 
            this.buttonRounded3.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonRounded3.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonRounded3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonRounded3.BorderRadius = 10;
            this.buttonRounded3.BorderSize = 0;
            this.buttonRounded3.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonRounded3.FlatAppearance.BorderSize = 0;
            this.buttonRounded3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRounded3.ForeColor = System.Drawing.Color.White;
            this.buttonRounded3.ForegroundColor = System.Drawing.Color.White;
            this.buttonRounded3.Location = new System.Drawing.Point(306, 0);
            this.buttonRounded3.Name = "buttonRounded3";
            this.buttonRounded3.Size = new System.Drawing.Size(79, 32);
            this.buttonRounded3.TabIndex = 2;
            this.buttonRounded3.Text = "Gửi mã";
            this.buttonRounded3.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nhập mã xác nhận";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(10, 92);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(385, 32);
            this.panel3.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(142, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(243, 30);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên tài khoản";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUÊN MẬT KHẨU";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GUI.Properties.Resources.forgotpassword;
            this.pictureBox2.Location = new System.Drawing.Point(46, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(609, 501);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // frmForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 610);
            this.Controls.Add(this.panelRounded1);
            this.Controls.Add(this.pnTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmForgotPassword";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quên mật khẩu";
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            this.panelRounded1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Label Title;
        private GUI_COMPONENT.ButtonRounded btnClose;
        private GUI_COMPONENT.PanelRounded panelRounded1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private GUI_COMPONENT.ButtonRounded buttonRounded2;
        private GUI_COMPONENT.ButtonRounded buttonRounded1;
        private GUI_COMPONENT.ButtonRounded btnLogin;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private GUI_COMPONENT.ButtonRounded buttonRounded3;
        private System.Windows.Forms.TextBox textBox3;
        private GUI_COMPONENT.ButtonRounded buttonRounded4;
    }
}