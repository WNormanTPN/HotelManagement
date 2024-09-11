namespace GUI.GUI_BOOKING
{
    partial class rpThongTinPhieuThue
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
            this.rpViewCTT = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpViewCTT
            // 
            this.rpViewCTT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpViewCTT.LocalReport.ReportEmbeddedResource = "GUI.GUI_BOOKING.ThongTinPhieuThue.rdlc";
            this.rpViewCTT.Location = new System.Drawing.Point(0, 0);
            this.rpViewCTT.Name = "rpViewCTT";
            this.rpViewCTT.ServerReport.BearerToken = null;
            this.rpViewCTT.Size = new System.Drawing.Size(860, 625);
            this.rpViewCTT.TabIndex = 0;
            // 
            // rpThongTinPhieuThue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 625);
            this.Controls.Add(this.rpViewCTT);
            this.Name = "rpThongTinPhieuThue";
            this.Text = "Thông tin phiếu thuê";
            this.Load += new System.EventHandler(this.rpThongTinPhieuThue_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpViewCTT;
    }
}