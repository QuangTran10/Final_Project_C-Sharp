
namespace QuanLyBanHang
{
    partial class frmMenu
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuDonHang = new System.Windows.Forms.ToolStripMenuItem();
            this.xemĐơnHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDM_NhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDM_KhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDM_SanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýDanhMụcTheoNhómToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KH_TP = new System.Windows.Forms.ToolStripMenuItem();
            this.HD_KH = new System.Windows.Forms.ToolStripMenuItem();
            this.HD_SP = new System.Windows.Forms.ToolStripMenuItem();
            this.HD_NV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.cmbKH = new System.Windows.Forms.ComboBox();
            this.cmbNV = new System.Windows.Forms.ComboBox();
            this.txtSDTKH = new System.Windows.Forms.TextBox();
            this.txtDiaChiKH = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThemDH = new System.Windows.Forms.Button();
            this.btnLuuDH = new System.Windows.Forms.Button();
            this.btnHuyDH = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.pnlSanPham = new System.Windows.Forms.Panel();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SoLuong = new System.Windows.Forms.NumericUpDown();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.cmbMaSP = new System.Windows.Forms.ComboBox();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.MaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiamGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDonHang,
            this.quảnLýDanhMụcTheoNhómToolStripMenuItem,
            this.menuAdmin});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(950, 38);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuDonHang
            // 
            this.menuDonHang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemĐơnHàngToolStripMenuItem,
            this.menuDM_NhanVien,
            this.menuDM_KhachHang,
            this.menuDM_SanPham});
            this.menuDonHang.Name = "menuDonHang";
            this.menuDonHang.Size = new System.Drawing.Size(140, 34);
            this.menuDonHang.Text = "Quản lý danh mục";
            this.menuDonHang.Click += new System.EventHandler(this.menuDonHang_Click);
            // 
            // xemĐơnHàngToolStripMenuItem
            // 
            this.xemĐơnHàngToolStripMenuItem.Name = "xemĐơnHàngToolStripMenuItem";
            this.xemĐơnHàngToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.xemĐơnHàngToolStripMenuItem.Text = "Đơn Hàng";
            this.xemĐơnHàngToolStripMenuItem.Click += new System.EventHandler(this.xemĐơnHàngToolStripMenuItem_Click);
            // 
            // menuDM_NhanVien
            // 
            this.menuDM_NhanVien.Name = "menuDM_NhanVien";
            this.menuDM_NhanVien.Size = new System.Drawing.Size(158, 24);
            this.menuDM_NhanVien.Text = "Nhân Viên";
            this.menuDM_NhanVien.Click += new System.EventHandler(this.menuDM_NhanVien_Click);
            // 
            // menuDM_KhachHang
            // 
            this.menuDM_KhachHang.Name = "menuDM_KhachHang";
            this.menuDM_KhachHang.Size = new System.Drawing.Size(158, 24);
            this.menuDM_KhachHang.Text = "Khách Hàng";
            this.menuDM_KhachHang.Click += new System.EventHandler(this.menuDM_KhachHang_Click);
            // 
            // menuDM_SanPham
            // 
            this.menuDM_SanPham.Name = "menuDM_SanPham";
            this.menuDM_SanPham.Size = new System.Drawing.Size(158, 24);
            this.menuDM_SanPham.Text = "Sản Phẩm";
            this.menuDM_SanPham.Click += new System.EventHandler(this.menuDM_SanPham_Click);
            // 
            // quảnLýDanhMụcTheoNhómToolStripMenuItem
            // 
            this.quảnLýDanhMụcTheoNhómToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.KH_TP,
            this.HD_KH,
            this.HD_SP,
            this.HD_NV});
            this.quảnLýDanhMụcTheoNhómToolStripMenuItem.Name = "quảnLýDanhMụcTheoNhómToolStripMenuItem";
            this.quảnLýDanhMụcTheoNhómToolStripMenuItem.Size = new System.Drawing.Size(216, 34);
            this.quảnLýDanhMụcTheoNhómToolStripMenuItem.Text = "Quản lý danh mục theo nhóm";
            // 
            // KH_TP
            // 
            this.KH_TP.Name = "KH_TP";
            this.KH_TP.Size = new System.Drawing.Size(265, 24);
            this.KH_TP.Text = "Khách Hàng theo Thành Phố";
            this.KH_TP.Click += new System.EventHandler(this.KH_TP_Click);
            // 
            // HD_KH
            // 
            this.HD_KH.Name = "HD_KH";
            this.HD_KH.Size = new System.Drawing.Size(265, 24);
            this.HD_KH.Text = "Hoá Đơn theo Khách Hàng";
            this.HD_KH.Click += new System.EventHandler(this.HD_KH_Click);
            // 
            // HD_SP
            // 
            this.HD_SP.Name = "HD_SP";
            this.HD_SP.Size = new System.Drawing.Size(265, 24);
            this.HD_SP.Text = "Hoá Đơn theo Sản Phẩm";
            this.HD_SP.Click += new System.EventHandler(this.HD_SP_Click);
            // 
            // HD_NV
            // 
            this.HD_NV.Name = "HD_NV";
            this.HD_NV.Size = new System.Drawing.Size(265, 24);
            this.HD_NV.Text = "Hoá Đơn theo Nhân Viên";
            this.HD_NV.Click += new System.EventHandler(this.HD_NV_Click);
            // 
            // menuAdmin
            // 
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Size = new System.Drawing.Size(65, 34);
            this.menuAdmin.Text = "Admin";
            this.menuAdmin.Click += new System.EventHandler(this.menuAdmin_Click);
            // 
            // pnlInfo
            // 
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Controls.Add(this.cmbKH);
            this.pnlInfo.Controls.Add(this.cmbNV);
            this.pnlInfo.Controls.Add(this.txtSDTKH);
            this.pnlInfo.Controls.Add(this.txtDiaChiKH);
            this.pnlInfo.Controls.Add(this.txtTenKH);
            this.pnlInfo.Controls.Add(this.txtMaHD);
            this.pnlInfo.Controls.Add(this.label8);
            this.pnlInfo.Controls.Add(this.label7);
            this.pnlInfo.Controls.Add(this.label6);
            this.pnlInfo.Controls.Add(this.label5);
            this.pnlInfo.Controls.Add(this.label3);
            this.pnlInfo.Controls.Add(this.label2);
            this.pnlInfo.Location = new System.Drawing.Point(12, 58);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(922, 161);
            this.pnlInfo.TabIndex = 1;
            // 
            // cmbKH
            // 
            this.cmbKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKH.FormattingEnabled = true;
            this.cmbKH.Items.AddRange(new object[] {
            "Chọn"});
            this.cmbKH.Location = new System.Drawing.Point(136, 114);
            this.cmbKH.Name = "cmbKH";
            this.cmbKH.Size = new System.Drawing.Size(231, 24);
            this.cmbKH.TabIndex = 13;
            this.cmbKH.SelectedIndexChanged += new System.EventHandler(this.cmbKH_SelectedIndexChanged);
            // 
            // cmbNV
            // 
            this.cmbNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNV.FormattingEnabled = true;
            this.cmbNV.Location = new System.Drawing.Point(136, 65);
            this.cmbNV.Name = "cmbNV";
            this.cmbNV.Size = new System.Drawing.Size(231, 24);
            this.cmbNV.TabIndex = 12;
            this.cmbNV.SelectedIndexChanged += new System.EventHandler(this.cmbNV_SelectedIndexChanged);
            // 
            // txtSDTKH
            // 
            this.txtSDTKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDTKH.Location = new System.Drawing.Point(602, 116);
            this.txtSDTKH.Name = "txtSDTKH";
            this.txtSDTKH.Size = new System.Drawing.Size(231, 22);
            this.txtSDTKH.TabIndex = 11;
            // 
            // txtDiaChiKH
            // 
            this.txtDiaChiKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChiKH.Location = new System.Drawing.Point(602, 68);
            this.txtDiaChiKH.Name = "txtDiaChiKH";
            this.txtDiaChiKH.Size = new System.Drawing.Size(231, 22);
            this.txtDiaChiKH.TabIndex = 10;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKH.Location = new System.Drawing.Point(602, 17);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(231, 22);
            this.txtTenKH.TabIndex = 9;
            // 
            // txtMaHD
            // 
            this.txtMaHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHD.Location = new System.Drawing.Point(136, 20);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(231, 22);
            this.txtMaHD.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(472, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 25);
            this.label8.TabIndex = 6;
            this.label8.Text = "Số Điện Thoại";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(472, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "Địa Chỉ";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(472, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tên Khách Hàng";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mã Khách Hàng";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã Nhân Viên";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Hoá Đơn";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông Tin Chung";
            // 
            // btnThemDH
            // 
            this.btnThemDH.BackColor = System.Drawing.Color.LightBlue;
            this.btnThemDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemDH.Location = new System.Drawing.Point(12, 612);
            this.btnThemDH.Name = "btnThemDH";
            this.btnThemDH.Size = new System.Drawing.Size(138, 37);
            this.btnThemDH.TabIndex = 2;
            this.btnThemDH.Text = "Thêm Hoá Đơn";
            this.btnThemDH.UseVisualStyleBackColor = false;
            this.btnThemDH.Click += new System.EventHandler(this.btnThemDH_Click);
            // 
            // btnLuuDH
            // 
            this.btnLuuDH.BackColor = System.Drawing.Color.LightBlue;
            this.btnLuuDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuDH.Location = new System.Drawing.Point(204, 612);
            this.btnLuuDH.Name = "btnLuuDH";
            this.btnLuuDH.Size = new System.Drawing.Size(138, 37);
            this.btnLuuDH.TabIndex = 3;
            this.btnLuuDH.Text = "Lưu";
            this.btnLuuDH.UseVisualStyleBackColor = false;
            this.btnLuuDH.Click += new System.EventHandler(this.btnLuuDH_Click);
            // 
            // btnHuyDH
            // 
            this.btnHuyDH.BackColor = System.Drawing.Color.LightBlue;
            this.btnHuyDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyDH.Location = new System.Drawing.Point(407, 612);
            this.btnHuyDH.Name = "btnHuyDH";
            this.btnHuyDH.Size = new System.Drawing.Size(138, 37);
            this.btnHuyDH.TabIndex = 4;
            this.btnHuyDH.Text = "Xác Nhận";
            this.btnHuyDH.UseVisualStyleBackColor = false;
            this.btnHuyDH.Click += new System.EventHandler(this.btnHuyDH_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.LightBlue;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(796, 612);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(138, 37);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // pnlSanPham
            // 
            this.pnlSanPham.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSanPham.Controls.Add(this.txtThanhTien);
            this.pnlSanPham.Controls.Add(this.txtDonGia);
            this.pnlSanPham.Controls.Add(this.label10);
            this.pnlSanPham.Controls.Add(this.label13);
            this.pnlSanPham.Controls.Add(this.SoLuong);
            this.pnlSanPham.Controls.Add(this.txtTenSP);
            this.pnlSanPham.Controls.Add(this.cmbMaSP);
            this.pnlSanPham.Controls.Add(this.txtGiamGia);
            this.pnlSanPham.Controls.Add(this.label4);
            this.pnlSanPham.Controls.Add(this.label9);
            this.pnlSanPham.Controls.Add(this.label11);
            this.pnlSanPham.Controls.Add(this.label12);
            this.pnlSanPham.Location = new System.Drawing.Point(12, 238);
            this.pnlSanPham.Name = "pnlSanPham";
            this.pnlSanPham.Size = new System.Drawing.Size(922, 114);
            this.pnlSanPham.TabIndex = 14;
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThanhTien.Location = new System.Drawing.Point(732, 67);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(162, 22);
            this.txtThanhTien.TabIndex = 18;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonGia.Location = new System.Drawing.Point(732, 16);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(162, 22);
            this.txtDonGia.TabIndex = 17;
            this.txtDonGia.TextChanged += new System.EventHandler(this.txtDonGia_TextChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(639, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 25);
            this.label10.TabIndex = 16;
            this.label10.Text = "Thành Tiền";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(641, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 25);
            this.label13.TabIndex = 15;
            this.label13.Text = "Đơn Giá";
            // 
            // SoLuong
            // 
            this.SoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoLuong.Location = new System.Drawing.Point(486, 19);
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Size = new System.Drawing.Size(120, 22);
            this.SoLuong.TabIndex = 14;
            this.SoLuong.ValueChanged += new System.EventHandler(this.SoLuong_ValueChanged);
            // 
            // txtTenSP
            // 
            this.txtTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSP.Location = new System.Drawing.Point(128, 67);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(239, 22);
            this.txtTenSP.TabIndex = 13;
            // 
            // cmbMaSP
            // 
            this.cmbMaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMaSP.FormattingEnabled = true;
            this.cmbMaSP.Location = new System.Drawing.Point(128, 19);
            this.cmbMaSP.Name = "cmbMaSP";
            this.cmbMaSP.Size = new System.Drawing.Size(239, 24);
            this.cmbMaSP.TabIndex = 12;
            this.cmbMaSP.SelectedIndexChanged += new System.EventHandler(this.cmbMaSP_SelectedIndexChanged);
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiamGia.Location = new System.Drawing.Point(486, 67);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(120, 22);
            this.txtGiamGia.TabIndex = 11;
            this.txtGiamGia.TextChanged += new System.EventHandler(this.txtGiamGia_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(393, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Giảm Giá (%)";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(393, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 25);
            this.label9.TabIndex = 5;
            this.label9.Text = "Số Lượng";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 25);
            this.label11.TabIndex = 3;
            this.label11.Text = "Tên Sản Phẩm";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 25);
            this.label12.TabIndex = 1;
            this.label12.Text = "Mã Sản Phẩm";
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.AllowUserToAddRows = false;
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSanPham,
            this.TenSanPham,
            this.SoLuongDH,
            this.GiamGia,
            this.DonGia});
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(12, 382);
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(922, 175);
            this.dgvChiTietHoaDon.TabIndex = 15;
            // 
            // MaSanPham
            // 
            this.MaSanPham.DataPropertyName = "MaSanPham";
            this.MaSanPham.HeaderText = "Mã Sản Phẩm";
            this.MaSanPham.Name = "MaSanPham";
            this.MaSanPham.Width = 175;
            // 
            // TenSanPham
            // 
            this.TenSanPham.DataPropertyName = "TenSanPham";
            this.TenSanPham.HeaderText = "Tên Sản Phẩm";
            this.TenSanPham.Name = "TenSanPham";
            this.TenSanPham.Width = 250;
            // 
            // SoLuongDH
            // 
            this.SoLuongDH.DataPropertyName = "SoLuong";
            this.SoLuongDH.HeaderText = "Số Lượng";
            this.SoLuongDH.Name = "SoLuongDH";
            this.SoLuongDH.Width = 150;
            // 
            // GiamGia
            // 
            this.GiamGia.DataPropertyName = "GiamGia";
            this.GiamGia.HeaderText = "Giảm Giá";
            this.GiamGia.Name = "GiamGia";
            this.GiamGia.Width = 150;
            // 
            // DonGia
            // 
            this.DonGia.DataPropertyName = "DonGia";
            this.DonGia.HeaderText = "Đơn Giá";
            this.DonGia.Name = "DonGia";
            this.DonGia.Width = 150;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(12, 576);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 23);
            this.label14.TabIndex = 16;
            this.label14.Text = "Thành Tiền";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Total
            // 
            this.Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total.Location = new System.Drawing.Point(100, 576);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(211, 23);
            this.Total.TabIndex = 17;
            this.Total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.LightBlue;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(603, 612);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(138, 37);
            this.btnXoa.TabIndex = 18;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 661);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dgvChiTietHoaDon);
            this.Controls.Add(this.pnlSanPham);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuyDH);
            this.Controls.Add(this.btnLuuDH);
            this.Controls.Add(this.btnThemDH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Bán Hàng";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMenu_FormClosed);
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlSanPham.ResumeLayout(false);
            this.pnlSanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuDonHang;
        private System.Windows.Forms.ToolStripMenuItem menuAdmin;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSDTKH;
        private System.Windows.Forms.TextBox txtDiaChiKH;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.ComboBox cmbKH;
        private System.Windows.Forms.ComboBox cmbNV;
        private System.Windows.Forms.Button btnThemDH;
        private System.Windows.Forms.Button btnLuuDH;
        private System.Windows.Forms.Button btnHuyDH;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Panel pnlSanPham;
        private System.Windows.Forms.NumericUpDown SoLuong;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.ComboBox cmbMaSP;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvChiTietHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiamGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label Total;
        private System.Windows.Forms.ToolStripMenuItem xemĐơnHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuDM_NhanVien;
        private System.Windows.Forms.ToolStripMenuItem menuDM_KhachHang;
        private System.Windows.Forms.ToolStripMenuItem menuDM_SanPham;
        private System.Windows.Forms.ToolStripMenuItem quảnLýDanhMụcTheoNhómToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KH_TP;
        private System.Windows.Forms.ToolStripMenuItem HD_KH;
        private System.Windows.Forms.ToolStripMenuItem HD_SP;
        private System.Windows.Forms.ToolStripMenuItem HD_NV;
        private System.Windows.Forms.Button btnXoa;
    }
}

