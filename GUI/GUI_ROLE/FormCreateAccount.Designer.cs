namespace GUI.GUI_ROLE
{
    partial class FormCreateAccount
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRounded2 = new GUI.GUI_COMPONENT.ButtonRounded();
            this.buttonRounded1 = new GUI.GUI_COMPONENT.ButtonRounded();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Green;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "TẠO TÀI KHOẢN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonRounded2);
            this.panel1.Controls.Add(this.buttonRounded1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 225);
            this.panel1.TabIndex = 1;
            // 
            // buttonRounded2
            // 
            this.buttonRounded2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonRounded2.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonRounded2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonRounded2.BorderRadius = 40;
            this.buttonRounded2.BorderSize = 0;
            this.buttonRounded2.FlatAppearance.BorderSize = 0;
            this.buttonRounded2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRounded2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRounded2.ForeColor = System.Drawing.Color.White;
            this.buttonRounded2.ForegroundColor = System.Drawing.Color.White;
            this.buttonRounded2.Location = new System.Drawing.Point(209, 151);
            this.buttonRounded2.Name = "buttonRounded2";
            this.buttonRounded2.Size = new System.Drawing.Size(176, 49);
            this.buttonRounded2.TabIndex = 5;
            this.buttonRounded2.Text = "Đóng";
            this.buttonRounded2.UseVisualStyleBackColor = false;
            this.buttonRounded2.Click += new System.EventHandler(this.buttonRounded2_Click);
            // 
            // buttonRounded1
            // 
            this.buttonRounded1.BackColor = System.Drawing.Color.Green;
            this.buttonRounded1.BackgroundColor = System.Drawing.Color.Green;
            this.buttonRounded1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonRounded1.BorderRadius = 40;
            this.buttonRounded1.BorderSize = 0;
            this.buttonRounded1.FlatAppearance.BorderSize = 0;
            this.buttonRounded1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRounded1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRounded1.ForeColor = System.Drawing.Color.White;
            this.buttonRounded1.ForegroundColor = System.Drawing.Color.White;
            this.buttonRounded1.Location = new System.Drawing.Point(22, 151);
            this.buttonRounded1.Name = "buttonRounded1";
            this.buttonRounded1.Size = new System.Drawing.Size(176, 49);
            this.buttonRounded1.TabIndex = 4;
            this.buttonRounded1.Text = "Tạo tài khoản";
            this.buttonRounded1.UseVisualStyleBackColor = false;
            this.buttonRounded1.Click += new System.EventHandler(this.buttonRounded1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(151, 81);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(247, 31);
            this.comboBox1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(151, 22);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5, 7, 5, 5);
            this.panel2.Size = new System.Drawing.Size(247, 37);
            this.panel2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(5, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(237, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Phân quyền: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên tài khoản:  ";
            // 
            // FormCreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(431, 294);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCreateAccount";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo tài khoản";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCreateAccount_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private GUI_COMPONENT.ButtonRounded buttonRounded1;
        private System.Windows.Forms.ComboBox comboBox1;
        private GUI_COMPONENT.ButtonRounded buttonRounded2;
    }
}