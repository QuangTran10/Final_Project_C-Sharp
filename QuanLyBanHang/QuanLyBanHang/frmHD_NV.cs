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
    public partial class frmHD_NV : Form
    {
        // Chuỗi kết nối
        const string strConnectionString = "Data Source=DESKTOP-5KOS173;Initial Catalog=banhang;Integrated Security = True";
        // Đối tượng kết nối
        private static SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtNhanVien
        SqlDataAdapter daNhanVien = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtNhanVien = null;
        // Đối tượng đưa dữ liệu vào DataTable dtHoaDon
        SqlDataAdapter daHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtHoaDon = null;
        // Đối tượng đưa dữ liệu vào DataTable dtChiTietHoaDon
        SqlDataAdapter daChiTietHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtChiTietHoaDon = null;
        public frmHD_NV()
        {
            InitializeComponent();
        }

        public static double GetTotal(int MaHD)
        {
            double Tong = 0;
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

        void loadNhanVien()
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtKhachHang
                daNhanVien = new SqlDataAdapter("SELECT MaNV, HoTen, NgayLV, SoDienThoai, GioiTinh FROM NhanVien", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                // Đưa dữ liệu lên DataGridView
                dgvNhanVien.DataSource = dtNhanVien;
                dgvNhanVien.Columns["NgayLV"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table.Lỗi rồi!!!");
            }
        }

        void load_order(int MaNV)
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtKhachHang
                string sql = "SELECT MaHD, NgayLapHD, NgayGiao, kh.TenKH, kh.MaKH from HoaDon hd join KhachHang kh on hd.MaKH = kh.MaKH where hd.MaNV =" + MaNV;
                daHoaDon = new SqlDataAdapter(sql, conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                // Đưa dữ liệu lên DataGridView
                dgvHoaDon.DataSource = dtHoaDon;
                dgvHoaDon.Columns["NgayLapHD"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvHoaDon.Columns["NgayGiao"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void load_order_details(int MaHD)
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtKhachHang
                string sql = "SELECT ct.MaHD, ct.SoLuong, ct.GiamGia, ct.DonGia, sp.TenSanPham FROM ChiTietHoaDon ct join SanPham sp on ct.MaSanPham = sp.MaSanPham  Where MaHD = " + MaHD;
                daChiTietHoaDon = new SqlDataAdapter(sql, conn);
                dtChiTietHoaDon = new DataTable();
                dtChiTietHoaDon.Clear();
                daChiTietHoaDon.Fill(dtChiTietHoaDon);
                // Đưa dữ liệu lên DataGridView
                dgvChiTietDonHang.DataSource = dtChiTietHoaDon;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmHD_NV_Load(object sender, EventArgs e)
        {
            loadNhanVien();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = this.dgvHoaDon.CurrentCell.RowIndex;
            int MaHD = Convert.ToInt32(dgvHoaDon.Rows[row].Cells[0].Value);
            load_order_details(MaHD);
            this.labelTotal.Text = GetTotal(MaHD).ToString() + "đ";
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = this.dgvNhanVien.CurrentCell.RowIndex;
            int MaNV = Convert.ToInt32(dgvNhanVien.Rows[row].Cells[0].Value);
            string TenNV = dgvNhanVien.Rows[row].Cells[1].Value.ToString();
            this.lbTenNV.Text = TenNV;
            load_order(MaNV);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
