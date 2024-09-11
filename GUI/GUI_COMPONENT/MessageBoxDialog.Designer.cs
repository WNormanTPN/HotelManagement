namespace GUI.GUI_COMPONENT
{
    partial class MessageBoxDialog
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
            this.pnTop = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.btnClose = new GUI.GUI_COMPONENT.ButtonRounded();
            this.Icon = new System.Windows.Forms.PictureBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbContent = new System.Windows.Forms.Label();
            this.pnButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new GUI.GUI_COMPONENT.ButtonRounded();
            this.btnNo = new GUI.GUI_COMPONENT.ButtonRounded();
            this.btnYes = new GUI.GUI_COMPONENT.ButtonRounded();
            this.timerOpacity = new System.Windows.Forms.Timer(this.components);
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).BeginInit();
            this.pnButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.White;
            this.pnTop.Controls.Add(this.Title);
            this.pnTop.Controls.Add(this.btnClose);
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(550, 40);
            this.pnTop.TabIndex = 1;
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
            this.Title.Size = new System.Drawing.Size(108, 23);
            this.Title.TabIndex = 1;
            this.Title.Text = "Thông báo";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BackgroundColor = System.Drawing.Color.White;
            this.btnClose.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnClose.BorderRadius = 0;
            this.btnClose.BorderSize = 0;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.ForegroundColor = System.Drawing.Color.White;
            this.btnClose.Image = global::GUI.Properties.Resources.icons8_close_24;
            this.btnClose.Location = new System.Drawing.Point(500, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(46, 33);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Icon
            // 
            this.Icon.Image = global::GUI.Properties.Resources.icons8_checkmark_70px;
            this.Icon.Location = new System.Drawing.Point(0, 55);
            this.Icon.Name = "Icon";
            this.Icon.Size = new System.Drawing.Size(550, 70);
            this.Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Icon.TabIndex = 2;
            this.Icon.TabStop = false;
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Green;
            this.lbTitle.Location = new System.Drawing.Point(0, 140);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(550, 40);
            this.lbTitle.TabIndex = 3;
            this.lbTitle.Text = "THÔNG BÁO";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbContent
            // 
            this.lbContent.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbContent.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContent.Location = new System.Drawing.Point(1, 199);
            this.lbContent.Name = "lbContent";
            this.lbContent.Size = new System.Drawing.Size(549, 57);
            this.lbContent.TabIndex = 4;
            this.lbContent.Text = "Vui lòng nhập tài khoản và mật khẩu";
            this.lbContent.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnButton
            // 
            this.pnButton.ColumnCount = 3;
            this.pnButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnButton.Controls.Add(this.btnCancel, 2, 0);
            this.pnButton.Controls.Add(this.btnNo, 1, 0);
            this.pnButton.Controls.Add(this.btnYes, 0, 0);
            this.pnButton.Location = new System.Drawing.Point(0, 256);
            this.pnButton.Margin = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.pnButton.Name = "pnButton";
            this.pnButton.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.pnButton.RowCount = 1;
            this.pnButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnButton.Size = new System.Drawing.Size(550, 61);
            this.pnButton.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnCancel.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnCancel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancel.BorderRadius = 40;
            this.btnCancel.BorderSize = 0;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ForegroundColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(376, 7);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(15, 7, 15, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(144, 47);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.Crimson;
            this.btnNo.BackgroundColor = System.Drawing.Color.Crimson;
            this.btnNo.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnNo.BorderRadius = 40;
            this.btnNo.BorderSize = 0;
            this.btnNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNo.FlatAppearance.BorderSize = 0;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.ForeColor = System.Drawing.Color.White;
            this.btnNo.ForegroundColor = System.Drawing.Color.White;
            this.btnNo.Location = new System.Drawing.Point(203, 7);
            this.btnNo.Margin = new System.Windows.Forms.Padding(15, 7, 15, 7);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(143, 47);
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "Không đồng ý";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.ForestGreen;
            this.btnYes.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.btnYes.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnYes.BorderRadius = 40;
            this.btnYes.BorderSize = 0;
            this.btnYes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnYes.FlatAppearance.BorderSize = 0;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.ForeColor = System.Drawing.Color.White;
            this.btnYes.ForegroundColor = System.Drawing.Color.White;
            this.btnYes.Location = new System.Drawing.Point(30, 7);
            this.btnYes.Margin = new System.Windows.Forms.Padding(15, 7, 15, 7);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(143, 47);
            this.btnYes.TabIndex = 0;
            this.btnYes.Text = "Đồng ý";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // timerOpacity
            // 
            this.timerOpacity.Interval = 1;
            this.timerOpacity.Tick += new System.EventHandler(this.timerOpacity_Tick);
            // 
            // MessageBoxDialog
            // 
            this.AcceptButton = this.btnYes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(550, 319);
            this.Controls.Add(this.pnButton);
            this.Controls.Add(this.lbContent);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.Icon);
            this.Controls.Add(this.pnTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageBoxDialog";
            this.Opacity = 0D;
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông báo";
            this.Load += new System.EventHandler(this.MessageBoxDialog_Load);
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).EndInit();
            this.pnButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonRounded btnClose;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.PictureBox Icon;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbContent;
        private System.Windows.Forms.TableLayoutPanel pnButton;
        private ButtonRounded btnCancel;
        private ButtonRounded btnNo;
        private ButtonRounded btnYes;
        private System.Windows.Forms.Timer timerOpacity;
    }
}