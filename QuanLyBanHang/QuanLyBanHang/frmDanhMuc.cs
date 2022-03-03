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
    public partial class frmDanhMuc : Form
    {
        // Chuỗi kết nối
        string strConnectionString = "Data Source=DESKTOP-5KOS173;Initial Catalog=banhang;Integrated Security = True";
        // Đối tượng kết nối
        private static SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtTable
        SqlDataAdapter daTable = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtTable = null;
        //Mã lựa chọn
        private int option;

        public frmDanhMuc()
        {
            InitializeComponent();
        }

        public frmDanhMuc(int Ma) :this()
        {
            option = Ma;
        }

        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                switch (option)
                {
                    case 1:
                        daTable = new SqlDataAdapter("SELECT MaNV, HoTen, NgayLV, SoDienThoai, GioiTinh FROM NhanVien",conn);
                        break;
                    case 2:
                        daTable = new SqlDataAdapter("SELECT MaKH, TenKH, GioiTinh, DiaChiKH, SDT FROM KhachHang", conn);
                        break;
                    case 3:
                        daTable = new SqlDataAdapter("SELECT MaSanPham, TenSanPham, SoLuong, Gia FROM SanPham", conn);
                        break;
                    default:
                        break;
                }
                // Vận chuyển dữ liệu lên DataTable dtTable
                dtTable = new DataTable();
                dtTable.Clear();
                daTable.Fill(dtTable);
                // Đưa dữ liệu lên DataGridView
                dgvDanhMuc.DataSource = dtTable;
                switch (option)
                {
                    case 1:
                        dgvDanhMuc.Columns[0].HeaderText = "Mã Nhân Viên";
                        dgvDanhMuc.Columns[1].HeaderText = "Họ Tên Nhân Viên";
                        dgvDanhMuc.Columns[2].HeaderText = "Ngày Làm Việc";
                        dgvDanhMuc.Columns[3].HeaderText = "Số Điện Thoại";
                        dgvDanhMuc.Columns[4].HeaderText = "Giới Tính";
                        break;
                    case 2:
                        dgvDanhMuc.Columns[0].HeaderText = "Mã Khách Hàng";
                        dgvDanhMuc.Columns[1].HeaderText = "Họ Tên Khách Hàng";
                        dgvDanhMuc.Columns[2].HeaderText = "Giới Tính";
                        dgvDanhMuc.Columns[3].HeaderText = "Địa Chỉ";
                        dgvDanhMuc.Columns[4].HeaderText = "Số Điện Thoại";
                        break;
                    case 3:
                        dgvDanhMuc.Columns[0].HeaderText = "Mã Sản Phẩm";
                        dgvDanhMuc.Columns[1].HeaderText = "Tên Sản Phẩm";
                        dgvDanhMuc.Columns[2].HeaderText = "Số Lượng";
                        dgvDanhMuc.Columns[3].HeaderText = "Giá";
                        break;
                    default:
                        break;
                }
                // Thay đổi độ rộng cột
                //dgvDanhMuc.AutoResizeColumns();
            }
            catch (SqlException)
            {

            }
        }
    }
}
