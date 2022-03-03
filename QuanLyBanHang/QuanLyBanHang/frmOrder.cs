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
    public partial class frmOrder : Form
    {
        // Chuỗi kết nối
        string strConnectionString = "Data Source=DESKTOP-5KOS173;Initial Catalog=banhang;Integrated Security = True";
        // Đối tượng kết nối
        private static SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtHoaDon
        SqlDataAdapter daHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtHoaDon = null;
        // Đối tượng đưa dữ liệu vào DataTable dtChiTietHoaDon
        SqlDataAdapter daChiTietHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtChiTietHoaDon = null;
        public frmOrder()
        {
            InitializeComponent();
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
        void load_order()
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtKhachHang
                string sql = "SELECT MaHD, NgayLapHD, NgayGiao, nv.HoTen, kh.TenKH from HoaDon hd join NhanVien nv on hd.MaNV = nv.MaNV join KhachHang kh on kh.MaKH = hd.MaKH";
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
                dgvOrder_details.DataSource = dtChiTietHoaDon;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            load_order();
            this.dgvOrder_details.Enabled = false;
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvOrder_details.Enabled = true;
            int row = this.dgvHoaDon.CurrentCell.RowIndex;
            int MaHD = Convert.ToInt32(dgvHoaDon.Rows[row].Cells[0].Value);
            load_order_details(MaHD);
            this.lblTotal.Text = GetTotal(MaHD).ToString()+"đ";
            //MessageBox.Show(MaHD.ToString());
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            
        }
    }
}
