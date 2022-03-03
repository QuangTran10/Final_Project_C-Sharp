using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmMenu : Form
    {
        // Chuỗi kết nối
        string strConnectionString = "Data Source=DESKTOP-5KOS173;Initial Catalog=banhang;Integrated Security = True";
        // Đối tượng kết nối
        private static SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daKhachHang = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtKhachHang = null;
        // Đối tượng đưa dữ liệu vào DataTable dtNhanVien
        SqlDataAdapter daNhanVien = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtNhanVien = null;
        // Đối tượng đưa dữ liệu vào DataTable dtSanPham
        SqlDataAdapter daSanPham = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtSanPham = null;
        // Đối tượng đưa dữ liệu vào DataTable dtChiTietHoaDon
        SqlDataAdapter daChiTietHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtChiTietHoaDon = null;
        //Hàm nhận biết có phải là Admin
        int Admin;
        public frmMenu()
        {
            InitializeComponent();
        }

        public frmMenu(int admin) : this()
        {
            Admin = admin;
        }

        void XemDanhMuc(int option, string TenDM)
        {
            Form frmDanhMuc = new frmDanhMuc(option);
            frmDanhMuc.Text = TenDM;
            frmDanhMuc.StartPosition = FormStartPosition.CenterScreen;
            frmDanhMuc.ShowDialog();
        }

        private void menuAdmin_Click(object sender, EventArgs e)
        {
            Form frmAdmin = new frmAdmin();
            frmAdmin.StartPosition = FormStartPosition.CenterScreen;
            frmAdmin.Show();
           
        }

        //Hàm kiểm tra MaHD 
        public static bool CheckMaHD(int MaHD)
        {
            string strConnectionString = "Data Source=DESKTOP-5KOS173;Initial Catalog=banhang;Integrated Security = True";
            // Khởi động connection
            conn = new SqlConnection(strConnectionString);
            SqlDataAdapter dap = new SqlDataAdapter("Select * from HoaDon Where MaHD="+MaHD, conn);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
               return true;
            else return false;
        }


        //Hàm Tạo Mã hoá đơn
        public static int CreateMaDH()
        {
            int MaDH=0;
            DateTime now = DateTime.Now;
            MaDH = now.Day+now.Month+now.Year+now.Second+now.Millisecond;
            return MaDH;
        }

        //Hàm kiểm tra đã có sản phâm trong chitiethoadon
        public static bool CheckSP(int MaHD, int MaSP)
        {
            string strConnectionString = "Data Source=DESKTOP-5KOS173;Initial Catalog=banhang;Integrated Security = True";
            // Khởi động connection
            conn = new SqlConnection(strConnectionString);
            SqlDataAdapter dap = new SqlDataAdapter("Select * from ChiTietHoaDon Where MaHD=" + MaHD + " and MaSanPham="+MaSP, conn);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }

        //Hàm lấy số lượng của SP
        public static int getSoLuongSP(int MaSP)
        {
            int sl=0;
            // Khởi động connection
            string strConnectionString = "Data Source=DESKTOP-5KOS173;Initial Catalog=banhang;Integrated Security = True";
            conn = new SqlConnection(strConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select SoLuong from SanPham where MaSanPham = " + MaSP;

            cmd.Connection = conn;

            //Thực thi câu lệnh
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                sl = reader.GetInt32(0);
            }
            reader.Close();
            conn.Close();
            return sl;
        }
        //Hàm lấy số lượng của SP
        public static int getSoLuong(int MaHD, int MaSP)
        {
            int sl = 0;
            // Khởi động connection
            string strConnectionString = "Data Source=DESKTOP-5KOS173;Initial Catalog=banhang;Integrated Security = True";
            conn = new SqlConnection(strConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select SoLuong from ChiTietHoaDon where MaHD="+ MaHD +"and MaSanPham = " + MaSP;

            cmd.Connection = conn;

            //Thực thi câu lệnh
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                sl = reader.GetInt32(0);
            }
            reader.Close();
            conn.Close();
            return sl;
        }
        //Hàm cập nhật lại so luong trong chitiethoadon
        void Update_soluong(int MaHD, int MaSP, int soluong)
        {
            try
            {
                // Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandType = CommandType.Text;
                // Câu lệnh SQL
                cmd.CommandText = System.String.Concat("Update ChiTietHoaDon Set SoLuong = " +
                    soluong +" Where MaHD = " + MaHD + "and MaSanPham="+MaSP);
                
                // Cập nhật
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                // Load lại dữ liệu trên DataGridView
                Load_Order_Detail(MaHD);
                conn.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không sửa được. Lỗi rồi!");
            }
        }

        void Update_slsp(int MaSP, int soluongDH)
        {
            try
            {
                // Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandType = CommandType.Text;
                // Câu lệnh SQL
                cmd.CommandText = System.String.Concat("Update SanPham Set SoLuong = " +
                    soluongDH + " Where MaSanPham=" + MaSP);

                // Cập nhật
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không sửa được. Lỗi rồi!");
            }
        }

        //Hàm thêm Hoa Don
        void ThemDonHang(int MaDH, int MaKH, int MaNV)
        {
            // Mở kết nối
            conn.Open();
            // Thêm dữ liệu
            try
            {
                // Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Lệnh Insert InTo
                DateTime now = DateTime.Now;
                DateTime delivery = now.AddDays(3);

                //now = DateTime.Parse(now.ToString());
                cmd.CommandText = System.String.Concat("Insert Into HoaDon Values(" + MaDH + "," + MaNV + "," + MaKH + ",'" 
                    + now.ToShortDateString() + "','" + delivery.ToShortDateString() + "')");
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        //Hàm thêm Chi Tiet Hoa Don
        void ThemCTDonHang(int MaDH, int MaSP, int SoLuong, double GiamGia, int DonGia)
        {
            // Mở kết nối
            conn.Open();
            // Thêm dữ liệu
            try
            {
                // Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Lệnh Insert InTo
                cmd.CommandText = System.String.Concat("Insert Into ChiTietHoaDon Values(" + 
                    MaDH + "," + MaSP + "," + SoLuong + "," + GiamGia + "," + DonGia+")");
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                //Load lại DataGridView
                Load_Order_Detail(MaDH);
                // Thông báo
                MessageBox.Show("Đã thêm xong!");
            }
            catch (SqlException ex)
            {
            }
            conn.Close();
        }

        void ResetSanPham()
        {
            this.cmbMaSP.SelectedIndex = -1;
            this.txtTenSP.ResetText();
            this.txtDonGia.Text = "0";
            this.SoLuong.Value = 0;
            this.txtGiamGia.Text = "0";
            this.txtThanhTien.Text = "0";
        }

        void ResetHoaDon()
        {
            //Vô hiệu hoá panel
            this.txtMaHD.ResetText();
            this.pnlInfo.Enabled = false;
            this.pnlSanPham.Enabled = false;
            //Vo hieu hoa button
            this.btnThemDH.Enabled = true;
            this.btnHuyDH.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnLuuDH.Enabled = false;
        }

        public static double GetTotal(int MaHD)
        {
            double Tong = 0;
            string strConnectionString = "Data Source=DESKTOP-5KOS173;Initial Catalog=banhang;Integrated Security = True";
            // Khởi động connection
            conn = new SqlConnection(strConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from ChiTietHoaDon where MaHD = " + MaHD;
            cmd.Connection = conn;

            //Thực thi câu lệnh
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int soluong = reader.GetInt32(2);
                double giamgia = reader.GetDouble(3);
                int dongia = reader.GetInt32(4);
                Tong = Tong + dongia * soluong * (1 - giamgia);
            }
            reader.Close();
            conn.Close();

            return Tong;
        }

        void Load_Order_Detail(int MaHD)
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtKhachHang
                string sql = "SELECT ct.MaSanPham, ct.SoLuong, ct.GiamGia, ct.DonGia, sp.TenSanPham FROM ChiTietHoaDon ct join SanPham sp on ct.MaSanPham = sp.MaSanPham  Where MaHD=" + MaHD;
                daChiTietHoaDon = new SqlDataAdapter(sql, conn);
                dtChiTietHoaDon = new DataTable();
                dtChiTietHoaDon.Clear();
                daChiTietHoaDon.Fill(dtChiTietHoaDon);
                // Đưa dữ liệu lên DataGridView
                dgvChiTietHoaDon.DataSource = dtChiTietHoaDon;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table.Lỗi rồi!!!");
            }
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtKhachHang
                daKhachHang = new SqlDataAdapter("SELECT * FROM KhachHang", conn);
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);
                // Vận chuyển dữ liệu lên DataTable dtNhanVien
                daNhanVien = new SqlDataAdapter("SELECT * FROM NhanVien", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                // Vận chuyển dữ liệu lên DataTable dtNhanVien
                daSanPham = new SqlDataAdapter("SELECT * FROM SanPham", conn);
                dtSanPham = new DataTable();
                dtSanPham.Clear();
                daSanPham.Fill(dtSanPham);
                // Đưa dữ liệu lên ComboBox
                this.cmbKH.DataSource = dtKhachHang;
                this.cmbKH.DisplayMember = "TenKH";
                this.cmbKH.ValueMember = "MaKH";
                this.cmbKH.SelectedIndex = -1;

                this.cmbNV.DataSource = dtNhanVien;
                this.cmbNV.DisplayMember = "HoTen";
                this.cmbNV.ValueMember = "MaNV";
                this.cmbNV.SelectedIndex = -1;

                this.cmbMaSP.DataSource = dtSanPham;
                this.cmbMaSP.DisplayMember = "MaSanPham";
                this.cmbMaSP.ValueMember = "MaSanPham";
                this.cmbMaSP.SelectedIndex = -1;
                //Vô hiệu hoá panel
                this.pnlInfo.Enabled = false;
                this.pnlSanPham.Enabled = false;
                //Vo hieu hoa button
                this.btnHuyDH.Enabled = false;
                this.btnXoa.Enabled = false;
                this.btnLuuDH.Enabled = false;

                if(Admin == 0)
                {
                    this.menuAdmin.Enabled = false;
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table trong csdl.Lỗi rồi!!!");
            }
        }

        private void cmbKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbKH.SelectedIndex != -1)
            {
                try
                {
                    if (this.cmbKH.SelectedIndex != -1)
                    {
                        // Khởi động connection
                    conn = new SqlConnection(strConnectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from KhachHang where MaKH = " + this.cmbKH.SelectedValue;

                    cmd.Connection = conn;

                    //Thực thi câu lệnh
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string TenKH = reader.GetString(1);
                        string DiaChi = reader.GetString(3);
                        string SDT = reader.GetString(4);

                        this.txtTenKH.Text = TenKH;
                        this.txtDiaChiKH.Text = DiaChi;
                        this.txtSDTKH.Text = SDT;
                    }
                    reader.Close();
                    conn.Close();
                    }
                }
                catch (SqlException)
                {
                    
                }
            }
        }

        private void btnThemDH_Click(object sender, EventArgs e)
        {
            this.pnlInfo.Enabled = true;
            this.pnlSanPham.Enabled = true;
            this.btnThemDH.Enabled = false;
            this.btnHuyDH.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnLuuDH.Enabled = true;
            this.txtMaHD.Text = CreateMaDH().ToString();
        }

        private void cmbNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                this.Close();
                Form frmLogin = new frmLogin();
                frmLogin.StartPosition = FormStartPosition.CenterScreen;
                frmLogin.Show();
            }
        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Giải phóng tài nguyên
            dtKhachHang.Dispose();
            dtKhachHang = null;
            dtNhanVien.Dispose();
            dtNhanVien = null;
            dtSanPham.Dispose();
            dtSanPham = null;
            // Hủy kết nối
            conn = null;
        }


        private void cmbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbMaSP.SelectedIndex != -1)
            {
                try
                {
                    if (this.cmbMaSP.SelectedIndex != -1)
                    {
                        // Khởi động connection
                        conn = new SqlConnection(strConnectionString);
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select * from SanPham where MaSanPham = " + this.cmbMaSP.SelectedValue;

                        cmd.Connection = conn;

                        //Thực thi câu lệnh
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            double Gia = reader.GetDouble(3);
                            double ThanhTien = Gia * 1;
                            this.txtTenSP.Text = reader.GetString(1);
                            this.txtDonGia.Text = Gia.ToString();
                            this.txtGiamGia.Text = "0";
                            this.SoLuong.Value = 1;
                            this.txtThanhTien.Text = ThanhTien.ToString();
                            this.txtDonGia.Enabled = false;
                        }
                        reader.Close();
                        conn.Close();
                    }
                }
                catch (SqlException)
                {

                }
            }
        }

        private void SoLuong_ValueChanged(object sender, EventArgs e)
        {
            int Gia = Convert.ToInt32(this.txtDonGia.Text);
            int SoLuong = Convert.ToInt32(this.SoLuong.Value);
            double GiamGia = Convert.ToDouble(this.txtGiamGia.Text)/100;
            double ThanhTien = Gia * SoLuong*(1-GiamGia);
            this.txtThanhTien.Text = ThanhTien.ToString();
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            int Gia = Convert.ToInt32(this.txtDonGia.Text);
            int SoLuong = Convert.ToInt32(this.SoLuong.Value);
            
            if(this.txtGiamGia.Text != "")
            {
                double GiamGia = Convert.ToDouble(this.txtGiamGia.Text);
                if (GiamGia != 0)
                {
                    GiamGia = GiamGia / 100;
                    double ThanhTien = Gia * SoLuong * (1 - GiamGia);
                    this.txtThanhTien.Text = ThanhTien.ToString();
                }
                else
                {
                    double ThanhTien = Gia * SoLuong;
                    this.txtThanhTien.Text = ThanhTien.ToString();
                }
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnLuuDH_Click(object sender, EventArgs e)
        {
            int MaDH = Convert.ToInt32(this.txtMaHD.Text);
            if(this.cmbKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn Mã Khách Hàng");
                this.cmbKH.Focus();
                return;
            }
            if(this.cmbNV.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn Mã Nhân Viên");
                this.cmbNV.Focus();
                return;
            }
            if(this.cmbMaSP.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn Sản Phẩm");
                this.cmbMaSP.Focus();
                return;
            }
            
            if (!CheckMaHD(MaDH))
            {
                int MaNV = Convert.ToInt32(this.cmbNV.SelectedValue);
                int MaKH = Convert.ToInt32(this.cmbKH.SelectedValue);

                ThemDonHang(MaDH, MaKH, MaNV);
                int MaSP =Convert.ToInt32(this.cmbMaSP.SelectedValue);
                int SoLuong = Convert.ToInt32(this.SoLuong.Value);
                double GiamGia = Convert.ToDouble(this.txtGiamGia.Text) / 100;
                int DonGia = Convert.ToInt32(this.txtDonGia.Text);

                ThemCTDonHang(MaDH, MaSP, SoLuong, GiamGia, DonGia);
                int slton = getSoLuongSP(MaSP) - SoLuong;
                Update_slsp(MaSP, slton);

                this.Total.Text = GetTotal(MaDH).ToString();
                ResetSanPham();
            }
            if (CheckMaHD(MaDH))
            {
                int MaSP = Convert.ToInt32(this.cmbMaSP.SelectedValue);
                int SoLuong = Convert.ToInt32(this.SoLuong.Value);
                double GiamGia = Convert.ToDouble(this.txtGiamGia.Text) / 100;
                int DonGia = Convert.ToInt32(this.txtDonGia.Text);

                //Nếu trong chi tiet don hang chua co sp thi them vao
                if(!CheckSP(MaDH, MaSP))
                {
                    if(SoLuong < getSoLuongSP(MaSP))
                    {
                        ThemCTDonHang(MaDH, MaSP, SoLuong, GiamGia, DonGia);
                        int slton = getSoLuongSP(MaSP) - SoLuong;
                        Update_slsp(MaSP, slton);
                    }
                }
                else
                {
                    int SoLuongMoi = getSoLuong(MaDH, MaSP) + SoLuong;
                    if (SoLuong < getSoLuongSP(MaSP))
                    {
                        //Tiến hành cập nhật số lượng mới
                        Update_soluong(MaDH, MaSP, SoLuongMoi);
                        int slton = getSoLuongSP(MaSP) - SoLuong;
                        Update_slsp(MaSP, slton);
                    }
                }
                this.Total.Text = GetTotal(MaDH).ToString();
                ResetSanPham();
                
            }
        }

        private void btnHuyDH_Click(object sender, EventArgs e)
        {
            ResetHoaDon();
            ResetSanPham();
        }

        private void xemĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmOrder = new frmOrder();
            frmOrder.StartPosition = FormStartPosition.CenterScreen;
            frmOrder.Show();
        }

        
        private void menuDonHang_Click(object sender, EventArgs e)
        {
            
        }

        private void menuDM_NhanVien_Click(object sender, EventArgs e)
        {
            XemDanhMuc(1, "Danh Mục Nhân Viên");
        }

        private void menuDM_KhachHang_Click(object sender, EventArgs e)
        {
            XemDanhMuc(2, "Danh mục Khách Hàng");
        }

        private void menuDM_SanPham_Click(object sender, EventArgs e)
        {
            XemDanhMuc(3, "Danh mục Sản Phẩm");
        }

        private void HD_KH_Click(object sender, EventArgs e)
        {
            Form frmHD_KH = new frmHD_KH();
            frmHD_KH.StartPosition = FormStartPosition.CenterScreen;
            frmHD_KH.ShowDialog();
        }

        private void KH_TP_Click(object sender, EventArgs e)
        {
            Form frmKH_TP = new frmKH_TP();
            frmKH_TP.StartPosition = FormStartPosition.CenterScreen;
            frmKH_TP.ShowDialog();
        }

        private void HD_NV_Click(object sender, EventArgs e)
        {
            Form frmHD_NV = new frmHD_NV();
            frmHD_NV.StartPosition = FormStartPosition.CenterScreen;
            frmHD_NV.ShowDialog();
        }

        private void HD_SP_Click(object sender, EventArgs e)
        {
            Form frmHD_SP = new frmHD_SP();
            frmHD_SP.StartPosition = FormStartPosition.CenterScreen;
            frmHD_SP.ShowDialog();
        }

        public void XoaSP_CTDH(int MaSP, int MaDH)
        {
            conn.Open();
            try
            {
                // Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                
                // Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete From ChiTietHoaDon Where MaHD = " + MaDH + "and MaSanPham = '" + MaSP + "'");
                cmd.CommandType = CommandType.Text;
                // Thực hiện câu lệnh SQL
                cmd.ExecuteNonQuery();
                // Cập nhật lại DataGridView
                Load_Order_Detail(MaDH);
                // Thông báo
                MessageBox.Show("Đã xóa xong!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!!!");
            }
            // Đóng kết nối
            conn.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Lấy các dữ liệu cần
            int MaDH = Convert.ToInt32(this.txtMaHD.Text);
            int row = this.dgvChiTietHoaDon.CurrentCell.RowIndex;
            int MaSP = Convert.ToInt32(dgvChiTietHoaDon.Rows[row].Cells[0].Value);
            int SoLuong = Convert.ToInt32(dgvChiTietHoaDon.Rows[row].Cells["SoLuongDH"].Value);

            XoaSP_CTDH(MaSP, MaDH);
            int slton = getSoLuongSP(MaSP) + SoLuong;
            //MessageBox.Show(slton.ToString());
            Update_slsp(MaSP, slton);
        }
    }
}
