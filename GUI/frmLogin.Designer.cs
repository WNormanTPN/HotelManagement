namespace GUI
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.pnTop = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.btnClose = new GUI.GUI_COMPONENT.ButtonRounded();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonRounded2 = new GUI.GUI_COMPONENT.ButtonRounded();
            this.buttonRounded1 = new GUI.GUI_COMPONENT.ButtonRounded();
            this.btnLogin = new GUI.GUI_COMPONENT.ButtonRounded();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.buttonRounded3 = new GUI.GUI_COMPONENT.ButtonRounded();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerOpacity = new System.Windows.Forms.Timer(this.components);
            this.pnTop.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.pnTop.TabIndex = 3;
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
            this.Title.Size = new System.Drawing.Size(318, 23);
            this.Title.TabIndex = 1;
            this.Title.Text = "ĐĂNG NHẬP HỆ THỐNG KHÁCH SẠN";
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1134, 568);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GUI.Properties.Resources._new;
            this.pictureBox2.Location = new System.Drawing.Point(46, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(609, 501);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.btnLogin);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(675, 28);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(405, 501);
            this.panel2.TabIndex = 0;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(390, 45);
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
            this.buttonRounded2.Location = new System.Drawing.Point(198, 0);
            this.buttonRounded2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.buttonRounded2.Name = "buttonRounded2";
            this.buttonRounded2.Size = new System.Drawing.Size(192, 45);
            this.buttonRounded2.TabIndex = 1;
            this.buttonRounded2.Text = "Quên mật khẩu";
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
            this.buttonRounded1.Size = new System.Drawing.Size(192, 45);
            this.buttonRounded1.TabIndex = 0;
            this.buttonRounded1.Text = "Đổi mật khẩu";
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
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.txtPass);
            this.panel4.Controls.Add(this.buttonRounded3);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(10, 209);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(385, 32);
            this.panel4.TabIndex = 2;
            // 
            // txtPass
            // 
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPass.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(128, 0);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(216, 30);
            this.txtPass.TabIndex = 2;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // buttonRounded3
            // 
            this.buttonRounded3.BackColor = System.Drawing.Color.White;
            this.buttonRounded3.BackgroundColor = System.Drawing.Color.White;
            this.buttonRounded3.BackgroundImage = global::GUI.Properties.Resources.hien;
            this.buttonRounded3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRounded3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonRounded3.BorderRadius = 40;
            this.buttonRounded3.BorderSize = 0;
            this.buttonRounded3.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonRounded3.FlatAppearance.BorderSize = 0;
            this.buttonRounded3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRounded3.ForeColor = System.Drawing.Color.White;
            this.buttonRounded3.ForegroundColor = System.Drawing.Color.White;
            this.buttonRounded3.Location = new System.Drawing.Point(344, 0);
            this.buttonRounded3.Name = "buttonRounded3";
            this.buttonRounded3.Size = new System.Drawing.Size(41, 32);
            this.buttonRounded3.TabIndex = 3;
            this.buttonRounded3.UseVisualStyleBackColor = false;
            this.buttonRounded3.Click += new System.EventHandler(this.buttonRounded3_Click);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.txtTK);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(10, 143);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(385, 32);
            this.panel3.TabIndex = 1;
            // 
            // txtTK
            // 
            this.txtTK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTK.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTK.Location = new System.Drawing.Point(128, 0);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(257, 30);
            this.txtTK.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 32);
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
            this.label1.Text = "Thông tin đăng nhập";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1134, 568);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // timerOpacity
            // 
            this.timerOpacity.Tick += new System.EventHandler(this.timerOpacity_Tick);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1138, 610);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogin_FormClosed);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Label Title;
        private GUI_COMPONENT.ButtonRounded btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private GUI_COMPONENT.ButtonRounded btnLogin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private GUI_COMPONENT.ButtonRounded buttonRounded2;
        private GUI_COMPONENT.ButtonRounded buttonRounded1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtPass;
        private GUI_COMPONENT.ButtonRounded buttonRounded3;
        private System.Windows.Forms.Timer timerOpacity;
        public System.Windows.Forms.TextBox txtTK;
    }
}