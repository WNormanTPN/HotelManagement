namespace GUI.GUI_HOME
{
    partial class HomeForm
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
            this.panelRounded1 = new GUI.GUI_COMPONENT.PanelRounded();
            this.panelRounded2 = new GUI.GUI_COMPONENT.PanelRounded();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ChangeImage = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelRounded3 = new GUI.GUI_COMPONENT.PanelRounded();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.panelRounded1.SuspendLayout();
            this.panelRounded2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelRounded3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRounded1
            // 
            this.panelRounded1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.panelRounded1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.panelRounded1.BorderRadius = 0;
            this.panelRounded1.BorderSize = 2;
            this.panelRounded1.Controls.Add(this.panelRounded2);
            this.panelRounded1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRounded1.Location = new System.Drawing.Point(15, 15);
            this.panelRounded1.Name = "panelRounded1";
            this.panelRounded1.Size = new System.Drawing.Size(1206, 272);
            this.panelRounded1.TabIndex = 0;
            this.panelRounded1.UnderlinedStyle = false;
            // 
            // panelRounded2
            // 
            this.panelRounded2.BackColor = System.Drawing.Color.White;
            this.panelRounded2.BorderColor = System.Drawing.Color.White;
            this.panelRounded2.BorderFocusColor = System.Drawing.Color.HotPink;
            this.panelRounded2.BorderRadius = 10;
            this.panelRounded2.BorderSize = 2;
            this.panelRounded2.Controls.Add(this.tableLayoutPanel1);
            this.panelRounded2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRounded2.Location = new System.Drawing.Point(0, 0);
            this.panelRounded2.Name = "panelRounded2";
            this.panelRounded2.Padding = new System.Windows.Forms.Padding(10);
            this.panelRounded2.Size = new System.Drawing.Size(1206, 272);
            this.panelRounded2.TabIndex = 0;
            this.panelRounded2.UnderlinedStyle = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1186, 252);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox4.Image = global::GUI.Properties.Resources.ks2;
            this.pictureBox4.Location = new System.Drawing.Point(893, 5);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(288, 242);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = global::GUI.Properties.Resources.abc;
            this.pictureBox3.Location = new System.Drawing.Point(597, 5);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(286, 242);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::GUI.Properties.Resources.background1;
            this.pictureBox2.Location = new System.Drawing.Point(301, 5);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(286, 242);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::GUI.Properties.Resources.ks;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 242);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ChangeImage
            // 
            this.ChangeImage.Interval = 1000;
            this.ChangeImage.Tick += new System.EventHandler(this.ChangeImage_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelRounded3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(15, 287);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel1.Size = new System.Drawing.Size(1206, 475);
            this.panel1.TabIndex = 1;
            // 
            // panelRounded3
            // 
            this.panelRounded3.BackColor = System.Drawing.Color.White;
            this.panelRounded3.BorderColor = System.Drawing.Color.White;
            this.panelRounded3.BorderFocusColor = System.Drawing.Color.HotPink;
            this.panelRounded3.BorderRadius = 10;
            this.panelRounded3.BorderSize = 2;
            this.panelRounded3.Controls.Add(this.webView21);
            this.panelRounded3.Controls.Add(this.monthCalendar1);
            this.panelRounded3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRounded3.Location = new System.Drawing.Point(0, 10);
            this.panelRounded3.Name = "panelRounded3";
            this.panelRounded3.Padding = new System.Windows.Forms.Padding(10);
            this.panelRounded3.Size = new System.Drawing.Size(1206, 465);
            this.panelRounded3.TabIndex = 0;
            this.panelRounded3.UnderlinedStyle = false;
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView21.Location = new System.Drawing.Point(272, 10);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(924, 445);
            this.webView21.Source = new System.Uri("https://maps.app.goo.gl/XHHvsur3nux8gfB66", System.UriKind.Absolute);
            this.webView21.TabIndex = 1;
            this.webView21.ZoomFactor = 1D;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(1, 2);
            this.monthCalendar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.monthCalendar1.Location = new System.Drawing.Point(10, 10);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 777);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelRounded1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeForm";
            this.Opacity = 0D;
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Màn hình chính";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.panelRounded1.ResumeLayout(false);
            this.panelRounded2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelRounded3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GUI_COMPONENT.PanelRounded panelRounded1;
        private GUI_COMPONENT.PanelRounded panelRounded2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer ChangeImage;
        private System.Windows.Forms.Panel panel1;
        private GUI_COMPONENT.PanelRounded panelRounded3;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}