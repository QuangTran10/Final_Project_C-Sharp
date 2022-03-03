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
    public partial class frmKH_TP : Form
    {
        // Chuỗi kết nối
        const string strConnectionString = "Data Source=DESKTOP-5KOS173;Initial Catalog=banhang;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daThanhPho = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtThanhPho = null;
        // Đối tượng đưa dữ liệu vào DataTable dtKhachHang
        SqlDataAdapter daKhachHang = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtKhachHang = null;

        public frmKH_TP()
        {
            InitializeComponent();
        }

        void loadThanhPho()
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtThanhPho
                daThanhPho = new SqlDataAdapter("SELECT * FROM ThanhPho", conn);
                dtThanhPho = new DataTable();
                dtThanhPho.Clear();
                daThanhPho.Fill(dtThanhPho);

                // Đưa dữ liệu lên DataGridView
                dgvThanhPho.DataSource = dtThanhPho;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table.Lỗi rồi!!!");

            }
        }

        void load_KhachHang(int MaTP)
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtKhachHang
                string sql = "SELECT MaKH, TenKH, GioiTinh, DiaChiKH, SDT FROM KhachHang Where ThanhPho = " + MaTP;
                daKhachHang = new SqlDataAdapter(sql, conn);
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);
                // Đưa dữ liệu lên DataGridView
                dgvKhachHang.DataSource = dtKhachHang;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmKH_TP_Load(object sender, EventArgs e)
        {
            loadThanhPho();
        }

        private void dgvThanhPho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = this.dgvThanhPho.CurrentCell.RowIndex;
            int MaTP = Convert.ToInt32(dgvThanhPho.Rows[row].Cells[0].Value);
            load_KhachHang(MaTP);
            //MessageBox.Show(MaTP.ToString());
        }

        private void frmKH_TP_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void frmKH_TP_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Giải phóng tài nguyên
            dtThanhPho.Dispose();
            dtThanhPho = null;
            dtKhachHang.Dispose();
            dtKhachHang = null;
            // Hủy kết nối
            conn = null;
        }
    }
}
