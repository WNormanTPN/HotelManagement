namespace GUI
{
    partial class QLKS_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLKS_Form));
            this.pnTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbLogo = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.picMenu = new System.Windows.Forms.PictureBox();
            this.pnMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.pnHome = new System.Windows.Forms.Panel();
            this.btnHome = new GUI.GUI_COMPONENT.ButtonRounded();
            this.pnRoom = new System.Windows.Forms.Panel();
            this.btnRoom = new GUI.GUI_COMPONENT.ButtonRounded();
            this.pnService = new System.Windows.Forms.Panel();
            this.btnService = new GUI.GUI_COMPONENT.ButtonRounded();
            this.pnCustomer = new System.Windows.Forms.Panel();
            this.btnCustomer = new GUI.GUI_COMPONENT.ButtonRounded();
            this.pnStaff = new System.Windows.Forms.Panel();
            this.btnStaff = new GUI.GUI_COMPONENT.ButtonRounded();
            this.pnRole = new System.Windows.Forms.Panel();
            this.btnRole = new GUI.GUI_COMPONENT.ButtonRounded();
            this.pnBooking = new System.Windows.Forms.FlowLayoutPanel();
            this.pnBooking_Menu = new System.Windows.Forms.Panel();
            this.btnBooking = new GUI.GUI_COMPONENT.ButtonRounded();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnBookingNew = new GUI.GUI_COMPONENT.ButtonRounded();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnListBooking = new GUI.GUI_COMPONENT.ButtonRounded();
            this.pnBill = new System.Windows.Forms.Panel();
            this.btnBill = new GUI.GUI_COMPONENT.ButtonRounded();
            this.pnStatistic = new System.Windows.Forms.Panel();
            this.btnStatistic = new GUI.GUI_COMPONENT.ButtonRounded();
            this.timerMenuTransition = new System.Windows.Forms.Timer(this.components);
            this.timerSliderBar = new System.Windows.Forms.Timer(this.components);
            this.pnContent = new System.Windows.Forms.Panel();
            this.pnTop.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMenu)).BeginInit();
            this.pnMenu.SuspendLayout();
            this.pnHome.SuspendLayout();
            this.pnRoom.SuspendLayout();
            this.pnService.SuspendLayout();
            this.pnCustomer.SuspendLayout();
            this.pnStaff.SuspendLayout();
            this.pnRole.SuspendLayout();
            this.pnBooking.SuspendLayout();
            this.pnBooking_Menu.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.pnBill.SuspendLayout();
            this.pnStatistic.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.White;
            this.pnTop.Controls.Add(this.panel1);
            this.pnTop.Controls.Add(this.lbLogo);
            this.pnTop.Controls.Add(this.picLogo);
            this.pnTop.Controls.Add(this.picMenu);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1782, 53);
            this.pnTop.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1061, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(721, 53);
            this.panel1.TabIndex = 2;
            // 
            // lbName
            // 
            this.lbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(5, 5);
            this.lbName.Name = "lbName";
            this.lbName.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lbName.Size = new System.Drawing.Size(659, 43);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "label1";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::GUI.Properties.Resources.icons8_avatar_48__1_;
            this.pictureBox1.Location = new System.Drawing.Point(664, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbLogo
            // 
            this.lbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbLogo.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogo.Location = new System.Drawing.Point(128, 0);
            this.lbLogo.Margin = new System.Windows.Forms.Padding(0);
            this.lbLogo.Name = "lbLogo";
            this.lbLogo.Size = new System.Drawing.Size(299, 53);
            this.lbLogo.TabIndex = 1;
            this.lbLogo.Text = "LUXURY HOTEL";
            this.lbLogo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLogo.Image = global::GUI.Properties.Resources.hotel;
            this.picLogo.Location = new System.Drawing.Point(57, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(71, 53);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // picMenu
            // 
            this.picMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.picMenu.Image = global::GUI.Properties.Resources.icons8_menu_24;
            this.picMenu.Location = new System.Drawing.Point(0, 0);
            this.picMenu.Name = "picMenu";
            this.picMenu.Size = new System.Drawing.Size(57, 53);
            this.picMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMenu.TabIndex = 0;
            this.picMenu.TabStop = false;
            this.picMenu.Click += new System.EventHandler(this.picMenu_Click);
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.White;
            this.pnMenu.Controls.Add(this.pnHome);
            this.pnMenu.Controls.Add(this.pnRoom);
            this.pnMenu.Controls.Add(this.pnService);
            this.pnMenu.Controls.Add(this.pnCustomer);
            this.pnMenu.Controls.Add(this.pnStaff);
            this.pnMenu.Controls.Add(this.pnRole);
            this.pnMenu.Controls.Add(this.pnBooking);
            this.pnMenu.Controls.Add(this.pnBill);
            this.pnMenu.Controls.Add(this.pnStatistic);
            this.pnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnMenu.Location = new System.Drawing.Point(0, 53);
            this.pnMenu.Margin = new System.Windows.Forms.Padding(0);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Padding = new System.Windows.Forms.Padding(8);
            this.pnMenu.Size = new System.Drawing.Size(320, 789);
            this.pnMenu.TabIndex = 1;
            // 
            // pnHome
            // 
            this.pnHome.Controls.Add(this.btnHome);
            this.pnHome.Location = new System.Drawing.Point(8, 8);
            this.pnHome.Margin = new System.Windows.Forms.Padding(0);
            this.pnHome.Name = "pnHome";
            this.pnHome.Size = new System.Drawing.Size(304, 48);
            this.pnHome.TabIndex = 2;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnHome.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.btnHome.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnHome.BorderRadius = 40;
            this.btnHome.BorderSize = 0;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.ForegroundColor = System.Drawing.Color.White;
            this.btnHome.Image = global::GUI.Properties.Resources.icons8_home_office_24;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Margin = new System.Windows.Forms.Padding(0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnHome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnHome.Size = new System.Drawing.Size(304, 48);
            this.btnHome.TabIndex = 3;
            this.btnHome.Text = "        Màn hình chính";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pnRoom
            // 
            this.pnRoom.Controls.Add(this.btnRoom);
            this.pnRoom.Location = new System.Drawing.Point(8, 56);
            this.pnRoom.Margin = new System.Windows.Forms.Padding(0);
            this.pnRoom.Name = "pnRoom";
            this.pnRoom.Size = new System.Drawing.Size(304, 48);
            this.pnRoom.TabIndex = 5;
            // 
            // btnRoom
            // 
            this.btnRoom.BackColor = System.Drawing.Color.White;
            this.btnRoom.BackgroundColor = System.Drawing.Color.White;
            this.btnRoom.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnRoom.BorderRadius = 40;
            this.btnRoom.BorderSize = 0;
            this.btnRoom.FlatAppearance.BorderSize = 0;
            this.btnRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoom.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoom.ForeColor = System.Drawing.Color.Black;
            this.btnRoom.ForegroundColor = System.Drawing.Color.Black;
            this.btnRoom.Image = global::GUI.Properties.Resources.icons8_room_24__1_;
            this.btnRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoom.Location = new System.Drawing.Point(0, 0);
            this.btnRoom.Margin = new System.Windows.Forms.Padding(0);
            this.btnRoom.Name = "btnRoom";
            this.btnRoom.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnRoom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnRoom.Size = new System.Drawing.Size(304, 48);
            this.btnRoom.TabIndex = 3;
            this.btnRoom.Text = "        Quản lý phòng";
            this.btnRoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoom.UseVisualStyleBackColor = false;
            this.btnRoom.Click += new System.EventHandler(this.btnRoom_Click);
            // 
            // pnService
            // 
            this.pnService.Controls.Add(this.btnService);
            this.pnService.Location = new System.Drawing.Point(8, 104);
            this.pnService.Margin = new System.Windows.Forms.Padding(0);
            this.pnService.Name = "pnService";
            this.pnService.Size = new System.Drawing.Size(304, 48);
            this.pnService.TabIndex = 6;
            // 
            // btnService
            // 
            this.btnService.BackColor = System.Drawing.Color.White;
            this.btnService.BackgroundColor = System.Drawing.Color.White;
            this.btnService.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnService.BorderRadius = 40;
            this.btnService.BorderSize = 0;
            this.btnService.FlatAppearance.BorderSize = 0;
            this.btnService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnService.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnService.ForeColor = System.Drawing.Color.Black;
            this.btnService.ForegroundColor = System.Drawing.Color.Black;
            this.btnService.Image = global::GUI.Properties.Resources.icons8_food_and_wine_24;
            this.btnService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnService.Location = new System.Drawing.Point(0, 0);
            this.btnService.Margin = new System.Windows.Forms.Padding(0);
            this.btnService.Name = "btnService";
            this.btnService.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnService.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnService.Size = new System.Drawing.Size(304, 48);
            this.btnService.TabIndex = 3;
            this.btnService.Text = "        Quản lý dịch vụ";
            this.btnService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnService.UseVisualStyleBackColor = false;
            this.btnService.Click += new System.EventHandler(this.btnService_Click);
            // 
            // pnCustomer
            // 
            this.pnCustomer.Controls.Add(this.btnCustomer);
            this.pnCustomer.Location = new System.Drawing.Point(8, 152);
            this.pnCustomer.Margin = new System.Windows.Forms.Padding(0);
            this.pnCustomer.Name = "pnCustomer";
            this.pnCustomer.Size = new System.Drawing.Size(304, 48);
            this.pnCustomer.TabIndex = 5;
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.White;
            this.btnCustomer.BackgroundColor = System.Drawing.Color.White;
            this.btnCustomer.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCustomer.BorderRadius = 40;
            this.btnCustomer.BorderSize = 0;
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnCustomer.ForegroundColor = System.Drawing.Color.Black;
            this.btnCustomer.Image = global::GUI.Properties.Resources.icons8_group_24;
            this.btnCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.Location = new System.Drawing.Point(0, 0);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(0);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnCustomer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCustomer.Size = new System.Drawing.Size(304, 48);
            this.btnCustomer.TabIndex = 3;
            this.btnCustomer.Text = "        Quản lý khách hàng";
            this.btnCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // pnStaff
            // 
            this.pnStaff.Controls.Add(this.btnStaff);
            this.pnStaff.Location = new System.Drawing.Point(8, 200);
            this.pnStaff.Margin = new System.Windows.Forms.Padding(0);
            this.pnStaff.Name = "pnStaff";
            this.pnStaff.Size = new System.Drawing.Size(304, 48);
            this.pnStaff.TabIndex = 4;
            // 
            // btnStaff
            // 
            this.btnStaff.BackColor = System.Drawing.Color.White;
            this.btnStaff.BackgroundColor = System.Drawing.Color.White;
            this.btnStaff.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnStaff.BorderRadius = 40;
            this.btnStaff.BorderSize = 0;
            this.btnStaff.FlatAppearance.BorderSize = 0;
            this.btnStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaff.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaff.ForeColor = System.Drawing.Color.Black;
            this.btnStaff.ForegroundColor = System.Drawing.Color.Black;
            this.btnStaff.Image = global::GUI.Properties.Resources.icons8_admin_24;
            this.btnStaff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff.Location = new System.Drawing.Point(0, 0);
            this.btnStaff.Margin = new System.Windows.Forms.Padding(0);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnStaff.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnStaff.Size = new System.Drawing.Size(304, 48);
            this.btnStaff.TabIndex = 3;
            this.btnStaff.Text = "        Quản lý nhân viên";
            this.btnStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff.UseVisualStyleBackColor = false;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // pnRole
            // 
            this.pnRole.Controls.Add(this.btnRole);
            this.pnRole.Location = new System.Drawing.Point(8, 248);
            this.pnRole.Margin = new System.Windows.Forms.Padding(0);
            this.pnRole.Name = "pnRole";
            this.pnRole.Size = new System.Drawing.Size(304, 48);
            this.pnRole.TabIndex = 8;
            // 
            // btnRole
            // 
            this.btnRole.BackColor = System.Drawing.Color.White;
            this.btnRole.BackgroundColor = System.Drawing.Color.White;
            this.btnRole.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnRole.BorderRadius = 40;
            this.btnRole.BorderSize = 0;
            this.btnRole.FlatAppearance.BorderSize = 0;
            this.btnRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRole.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRole.ForeColor = System.Drawing.Color.Black;
            this.btnRole.ForegroundColor = System.Drawing.Color.Black;
            this.btnRole.Image = global::GUI.Properties.Resources.icons8_lock_24;
            this.btnRole.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRole.Location = new System.Drawing.Point(0, 0);
            this.btnRole.Margin = new System.Windows.Forms.Padding(0);
            this.btnRole.Name = "btnRole";
            this.btnRole.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnRole.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnRole.Size = new System.Drawing.Size(304, 48);
            this.btnRole.TabIndex = 3;
            this.btnRole.Text = "        Quản lý phân quyền";
            this.btnRole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRole.UseVisualStyleBackColor = false;
            this.btnRole.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // pnBooking
            // 
            this.pnBooking.Controls.Add(this.pnBooking_Menu);
            this.pnBooking.Controls.Add(this.panel11);
            this.pnBooking.Controls.Add(this.panel12);
            this.pnBooking.Location = new System.Drawing.Point(8, 296);
            this.pnBooking.Margin = new System.Windows.Forms.Padding(0);
            this.pnBooking.Name = "pnBooking";
            this.pnBooking.Size = new System.Drawing.Size(304, 48);
            this.pnBooking.TabIndex = 8;
            // 
            // pnBooking_Menu
            // 
            this.pnBooking_Menu.Controls.Add(this.btnBooking);
            this.pnBooking_Menu.Location = new System.Drawing.Point(0, 0);
            this.pnBooking_Menu.Margin = new System.Windows.Forms.Padding(0);
            this.pnBooking_Menu.Name = "pnBooking_Menu";
            this.pnBooking_Menu.Size = new System.Drawing.Size(304, 48);
            this.pnBooking_Menu.TabIndex = 5;
            // 
            // btnBooking
            // 
            this.btnBooking.BackColor = System.Drawing.Color.White;
            this.btnBooking.BackgroundColor = System.Drawing.Color.White;
            this.btnBooking.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnBooking.BorderRadius = 40;
            this.btnBooking.BorderSize = 0;
            this.btnBooking.FlatAppearance.BorderSize = 0;
            this.btnBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBooking.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBooking.ForeColor = System.Drawing.Color.Black;
            this.btnBooking.ForegroundColor = System.Drawing.Color.Black;
            this.btnBooking.Image = global::GUI.Properties.Resources.icons8_new_ticket_24;
            this.btnBooking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBooking.Location = new System.Drawing.Point(0, 0);
            this.btnBooking.Margin = new System.Windows.Forms.Padding(0);
            this.btnBooking.Name = "btnBooking";
            this.btnBooking.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnBooking.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBooking.Size = new System.Drawing.Size(304, 48);
            this.btnBooking.TabIndex = 3;
            this.btnBooking.Text = "        Quản lý đặt phòng";
            this.btnBooking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBooking.UseVisualStyleBackColor = false;
            this.btnBooking.Click += new System.EventHandler(this.btnBooking_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btnBookingNew);
            this.panel11.Location = new System.Drawing.Point(0, 48);
            this.panel11.Margin = new System.Windows.Forms.Padding(0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(304, 48);
            this.panel11.TabIndex = 8;
            // 
            // btnBookingNew
            // 
            this.btnBookingNew.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBookingNew.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnBookingNew.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnBookingNew.BorderRadius = 40;
            this.btnBookingNew.BorderSize = 0;
            this.btnBookingNew.FlatAppearance.BorderSize = 0;
            this.btnBookingNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookingNew.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookingNew.ForeColor = System.Drawing.Color.Black;
            this.btnBookingNew.ForegroundColor = System.Drawing.Color.Black;
            this.btnBookingNew.Image = global::GUI.Properties.Resources.icons8_add_24;
            this.btnBookingNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBookingNew.Location = new System.Drawing.Point(0, 0);
            this.btnBookingNew.Margin = new System.Windows.Forms.Padding(0);
            this.btnBookingNew.Name = "btnBookingNew";
            this.btnBookingNew.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnBookingNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBookingNew.Size = new System.Drawing.Size(304, 48);
            this.btnBookingNew.TabIndex = 3;
            this.btnBookingNew.Text = "        Đặt phòng mới";
            this.btnBookingNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBookingNew.UseVisualStyleBackColor = false;
            this.btnBookingNew.Click += new System.EventHandler(this.btnBookingNew_Click);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnListBooking);
            this.panel12.Location = new System.Drawing.Point(0, 96);
            this.panel12.Margin = new System.Windows.Forms.Padding(0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(304, 48);
            this.panel12.TabIndex = 9;
            // 
            // btnListBooking
            // 
            this.btnListBooking.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnListBooking.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnListBooking.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnListBooking.BorderRadius = 40;
            this.btnListBooking.BorderSize = 0;
            this.btnListBooking.FlatAppearance.BorderSize = 0;
            this.btnListBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListBooking.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListBooking.ForeColor = System.Drawing.Color.Black;
            this.btnListBooking.ForegroundColor = System.Drawing.Color.Black;
            this.btnListBooking.Image = global::GUI.Properties.Resources.icons8_search_in_list_24;
            this.btnListBooking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListBooking.Location = new System.Drawing.Point(0, 0);
            this.btnListBooking.Margin = new System.Windows.Forms.Padding(0);
            this.btnListBooking.Name = "btnListBooking";
            this.btnListBooking.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnListBooking.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnListBooking.Size = new System.Drawing.Size(304, 48);
            this.btnListBooking.TabIndex = 3;
            this.btnListBooking.Text = "        Danh sách đặt phòng";
            this.btnListBooking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListBooking.UseVisualStyleBackColor = false;
            this.btnListBooking.Click += new System.EventHandler(this.btnListBooking_Click);
            // 
            // pnBill
            // 
            this.pnBill.Controls.Add(this.btnBill);
            this.pnBill.Location = new System.Drawing.Point(8, 344);
            this.pnBill.Margin = new System.Windows.Forms.Padding(0);
            this.pnBill.Name = "pnBill";
            this.pnBill.Size = new System.Drawing.Size(304, 48);
            this.pnBill.TabIndex = 7;
            // 
            // btnBill
            // 
            this.btnBill.BackColor = System.Drawing.Color.White;
            this.btnBill.BackgroundColor = System.Drawing.Color.White;
            this.btnBill.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnBill.BorderRadius = 40;
            this.btnBill.BorderSize = 0;
            this.btnBill.FlatAppearance.BorderSize = 0;
            this.btnBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBill.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBill.ForeColor = System.Drawing.Color.Black;
            this.btnBill.ForegroundColor = System.Drawing.Color.Black;
            this.btnBill.Image = global::GUI.Properties.Resources.icons8_bill_24;
            this.btnBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBill.Location = new System.Drawing.Point(0, 0);
            this.btnBill.Margin = new System.Windows.Forms.Padding(0);
            this.btnBill.Name = "btnBill";
            this.btnBill.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnBill.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBill.Size = new System.Drawing.Size(304, 48);
            this.btnBill.TabIndex = 3;
            this.btnBill.Text = "        Quản lý hóa đơn";
            this.btnBill.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBill.UseVisualStyleBackColor = false;
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // pnStatistic
            // 
            this.pnStatistic.Controls.Add(this.btnStatistic);
            this.pnStatistic.Location = new System.Drawing.Point(8, 392);
            this.pnStatistic.Margin = new System.Windows.Forms.Padding(0);
            this.pnStatistic.Name = "pnStatistic";
            this.pnStatistic.Size = new System.Drawing.Size(304, 48);
            this.pnStatistic.TabIndex = 6;
            // 
            // btnStatistic
            // 
            this.btnStatistic.BackColor = System.Drawing.Color.White;
            this.btnStatistic.BackgroundColor = System.Drawing.Color.White;
            this.btnStatistic.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnStatistic.BorderRadius = 40;
            this.btnStatistic.BorderSize = 0;
            this.btnStatistic.FlatAppearance.BorderSize = 0;
            this.btnStatistic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistic.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistic.ForeColor = System.Drawing.Color.Black;
            this.btnStatistic.ForegroundColor = System.Drawing.Color.Black;
            this.btnStatistic.Image = global::GUI.Properties.Resources.icons8_circle_chart_24;
            this.btnStatistic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatistic.Location = new System.Drawing.Point(0, 0);
            this.btnStatistic.Margin = new System.Windows.Forms.Padding(0);
            this.btnStatistic.Name = "btnStatistic";
            this.btnStatistic.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnStatistic.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnStatistic.Size = new System.Drawing.Size(304, 48);
            this.btnStatistic.TabIndex = 3;
            this.btnStatistic.Text = "        Xem thống kê";
            this.btnStatistic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatistic.UseVisualStyleBackColor = false;
            this.btnStatistic.Click += new System.EventHandler(this.btnStatistic_Click);
            // 
            // timerMenuTransition
            // 
            this.timerMenuTransition.Interval = 15;
            this.timerMenuTransition.Tick += new System.EventHandler(this.timerMenuTransition_Tick);
            // 
            // timerSliderBar
            // 
            this.timerSliderBar.Interval = 1;
            this.timerSliderBar.Tick += new System.EventHandler(this.timerSliderBar_Tick);
            // 
            // pnContent
            // 
            this.pnContent.BackColor = System.Drawing.Color.White;
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(320, 53);
            this.pnContent.Name = "pnContent";
            this.pnContent.Size = new System.Drawing.Size(1462, 789);
            this.pnContent.TabIndex = 2;
            // 
            // QLKS_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 842);
            this.Controls.Add(this.pnContent);
            this.Controls.Add(this.pnMenu);
            this.Controls.Add(this.pnTop);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QLKS_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý khách sạn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QLKS_Form_FormClosing);
            this.Load += new System.EventHandler(this.QLKS_Form_Load);
            this.pnTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMenu)).EndInit();
            this.pnMenu.ResumeLayout(false);
            this.pnHome.ResumeLayout(false);
            this.pnRoom.ResumeLayout(false);
            this.pnService.ResumeLayout(false);
            this.pnCustomer.ResumeLayout(false);
            this.pnStaff.ResumeLayout(false);
            this.pnRole.ResumeLayout(false);
            this.pnBooking.ResumeLayout(false);
            this.pnBooking_Menu.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.pnBill.ResumeLayout(false);
            this.pnStatistic.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.PictureBox picMenu;
        private System.Windows.Forms.Label lbLogo;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.FlowLayoutPanel pnMenu;
        private GUI_COMPONENT.ButtonRounded btnHome;
        private System.Windows.Forms.Panel pnHome;
        private System.Windows.Forms.Panel pnStaff;
        private GUI_COMPONENT.ButtonRounded btnStaff;
        private System.Windows.Forms.Panel pnService;
        private GUI_COMPONENT.ButtonRounded btnService;
        private System.Windows.Forms.Panel pnRoom;
        private GUI_COMPONENT.ButtonRounded btnRoom;
        private System.Windows.Forms.Panel pnCustomer;
        private GUI_COMPONENT.ButtonRounded btnCustomer;
        private System.Windows.Forms.Panel pnBooking_Menu;
        private GUI_COMPONENT.ButtonRounded btnBooking;
        private System.Windows.Forms.Panel pnRole;
        private GUI_COMPONENT.ButtonRounded btnRole;
        private System.Windows.Forms.Panel pnStatistic;
        private GUI_COMPONENT.ButtonRounded btnStatistic;
        private System.Windows.Forms.Panel pnBill;
        private GUI_COMPONENT.ButtonRounded btnBill;
        private System.Windows.Forms.FlowLayoutPanel pnBooking;
        private System.Windows.Forms.Panel panel11;
        private GUI_COMPONENT.ButtonRounded btnBookingNew;
        private System.Windows.Forms.Panel panel12;
        private GUI_COMPONENT.ButtonRounded btnListBooking;
        private System.Windows.Forms.Timer timerMenuTransition;
        private System.Windows.Forms.Timer timerSliderBar;
        public System.Windows.Forms.Panel pnContent;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lbName;
        public System.Windows.Forms.PictureBox pictureBox1;
    }
}