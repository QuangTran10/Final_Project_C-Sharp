using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmAdmin : Form
    {
        // Chuỗi kết nối
        string strConnectionString = "Data Source=DESKTOP-5KOS173;Initial Catalog=banhang;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daKhachHang = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtKhachHang = null;
        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daThanhPho = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtThanhPho = null;
        // Đối tượng đưa dữ liệu vào DataTable dtNhanVien
        SqlDataAdapter daNhanVien = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtNhanVien = null;
        // Đối tượng đưa dữ liệu vào DataTable dtLoaiSP
        SqlDataAdapter daLoaiSP = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtLoaiSP = null;
        // Đối tượng đưa dữ liệu vào DataTable dtSanPham
        SqlDataAdapter daSanPham = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtSanPham = null;
        // Đối tượng đưa dữ liệu vào DataTable dtHoaDon
        SqlDataAdapter daHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtHoaDon = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool ThemKH;
        bool ThemNV;
        bool ThemLoaiSP;
        bool ThemSP;
        public frmAdmin()
        {
            InitializeComponent();
        }

        void loadKhachHang()
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
                // Vận chuyển dữ liệu lên DataTable dtThanhPho
                daThanhPho = new SqlDataAdapter("SELECT * FROM ThanhPho", conn);
                dtThanhPho = new DataTable();
                dtThanhPho.Clear();
                daThanhPho.Fill(dtThanhPho);

                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvKhachHang.Columns["ThanhPho"] as
                DataGridViewComboBoxColumn).DataSource = dtThanhPho;
                (dgvKhachHang.Columns["ThanhPho"] as
                DataGridViewComboBoxColumn).DisplayMember ="TenThanhPho";
                (dgvKhachHang.Columns["ThanhPho"] as
                DataGridViewComboBoxColumn).ValueMember = "ThanhPho";

                // Đưa dữ liệu lên DataGridView
                dgvKhachHang.DataSource = dtKhachHang;
                // Thay đổi độ rộng cột
                //dgvKhachHang.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel
                this.txtMaKH.ResetText();
                this.txtTenKH.ResetText();
                this.txtDCKH.ResetText();
                this.txtSDTKH.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuuKH.Enabled = false;
                this.btnHuyKH.Enabled = false;
                this.panel4.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnThemKH.Enabled = true;
                this.btnSuaKH.Enabled = true;
                this.btnXoaKH.Enabled = true;
                this.btnThoatKH.Enabled = true;
                // Đưa dữ liệu lên ComboBox
                this.cmbTPKH.DataSource = dtThanhPho;
                this.cmbTPKH.DisplayMember = "TenThanhPho";
                this.cmbTPKH.ValueMember = "ThanhPho";
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table.Lỗi rồi!!!");
            }
        }
        void loadNhanVien()
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtKhachHang
                daNhanVien = new SqlDataAdapter("SELECT MaNV, HoTen, NgayLV, SoDienThoai, GioiTinh, DiaChi FROM NhanVien", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                // Đưa dữ liệu lên DataGridView
                dgvNhanVien.DataSource = dtNhanVien;
                // Thay đổi độ rộng cột
                //dgvNhanVien.AutoResizeColumns();
                dgvNhanVien.Columns["NgayLV"].DefaultCellStyle.Format = "dd-MM-yyyy";
                // Xóa trống các đối tượng trong Panel 2
                this.txtMaNV.ResetText();
                this.txtHoTen.ResetText();
                this.dtNgayLV.Value = DateTime.Now;
                this.txtSDT.ResetText();
                this.txtDiaChi.ResetText();
                this.rdNam.Checked = true;
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuuNV.Enabled = false;
                this.btnHuyNV.Enabled = false;
                this.panel2.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnThemNV.Enabled = true;
                this.btnSuaNV.Enabled = true;
                this.btnXoaNV.Enabled = true;
                this.btnThoatNV.Enabled = true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table.Lỗi rồi!!!");
            }
        }

        void loadLoaiSP()
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtKhachHang
                daLoaiSP = new SqlDataAdapter("SELECT * FROM LoaiSanPham", conn);
                dtLoaiSP = new DataTable();
                dtLoaiSP.Clear();
                daLoaiSP.Fill(dtLoaiSP);
                // Đưa dữ liệu lên DataGridView
                dgvLoaiSP.DataSource = dtLoaiSP;
                // Thay đổi độ rộng cột
                //dgvLoaiSP.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel 3
                this.txtMLSP.ResetText();
                this.txtLSP.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuuLSP.Enabled = false;
                this.btnHuyLSP.Enabled = false;
                this.panel3.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnThemLSP.Enabled = true;
                this.btnSuaLSP.Enabled = true;
                this.btnXoaLSP.Enabled = true;
                this.btnThoatLSP.Enabled = true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table.Lỗi rồi!!!");
            }
        }

        void loadSanPham()
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtKhachHang
                daSanPham = new SqlDataAdapter("SELECT * FROM SanPham", conn);
                dtSanPham = new DataTable();
                dtSanPham.Clear();
                daSanPham.Fill(dtSanPham);
                // Vận chuyển dữ liệu lên DataTable dtThanhPho
                daLoaiSP = new SqlDataAdapter("SELECT * FROM LoaiSanPham", conn);
                dtLoaiSP = new DataTable();
                dtLoaiSP.Clear();
                daLoaiSP.Fill(dtLoaiSP);

                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvSanPham.Columns["LoaiSanPham"] as
                DataGridViewComboBoxColumn).DataSource = dtLoaiSP;
                (dgvSanPham.Columns["LoaiSanPham"] as
                DataGridViewComboBoxColumn).DisplayMember = "TenLSP";
                (dgvSanPham.Columns["LoaiSanPham"] as
                DataGridViewComboBoxColumn).ValueMember = "MaLSP";

                // Đưa dữ liệu lên DataGridView
                dgvSanPham.DataSource = dtSanPham;
                // Thay đổi độ rộng cột
                //dgvKhachHang.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel
                this.txtMaSanPham.ResetText();
                this.txtTenSanPham.ResetText();
                this.txtSoLuong.ResetText();
                this.txtGia.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuuSP.Enabled = false;
                this.btnHuySP.Enabled = false;
                this.panel1.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnThemSP.Enabled = true;
                this.btnSuaSP.Enabled = true;
                this.btnXoaSP.Enabled = true;
                this.btnThoatSP.Enabled = true;
                // Đưa dữ liệu lên ComboBox
                this.cmbLoaiSanPham.DataSource = dtLoaiSP;
                this.cmbLoaiSanPham.DisplayMember = "TenLSP";
                this.cmbLoaiSanPham.ValueMember = "MaLSP";
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table.Lỗi rồi!!!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoatLSP_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoatNV_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoatKH_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            loadSanPham();
            loadKhachHang();
            loadNhanVien();
            loadLoaiSP();
        }

        //PHẦN TAB KHÁCH HÀNG
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            ThemKH = true;
            // Xóa trống các đối tượng trong Panel
            this.txtMaKH.ResetText();
            this.txtTenKH.ResetText();
            this.txtDCKH.ResetText();
            this.txtSDTKH.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuuKH.Enabled = true;
            this.btnHuyKH.Enabled = true;
            this.panel4.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThemKH.Enabled = false;
            this.btnSuaKH.Enabled = false;
            this.btnXoaKH.Enabled = false;
            this.btnThoatKH.Enabled = false;
            // Đưa dữ liệu lên ComboBox
            this.cmbTPKH.DataSource = dtThanhPho;
            this.cmbTPKH.DisplayMember = "TenThanhPho";
            this.cmbTPKH.ValueMember = "ThanhPho";
            // Đưa con trỏ đến TextField txtTenKH
            this.txtMaKH.Enabled = false;
            this.txtTenKH.Focus();
        }

        private void frmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Giải phóng tài nguyên
            dtThanhPho.Dispose();
            dtThanhPho = null;
            dtKhachHang.Dispose();
            dtKhachHang = null;
            dtNhanVien.Dispose();
            dtNhanVien = null;
            dtLoaiSP.Dispose();
            dtLoaiSP = null;
            dtSanPham.Dispose();
            dtSanPham = null;
            // Hủy kết nối
            conn = null;
            
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            ThemKH = false;
            // Đưa dữ liệu lên ComboBox
            this.cmbTPKH.DataSource = dtThanhPho;
            this.cmbTPKH.DisplayMember = "TenThanhPho";
            this.cmbTPKH.ValueMember = "ThanhPho";
            // Cho phép thao tác trên Panel
            this.panel4.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvKhachHang.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaKH.Text   = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
            this.txtTenKH.Text = dgvKhachHang.Rows[r].Cells[1].Value.ToString();
            String Gender = dgvKhachHang.Rows[r].Cells[2].Value.ToString();
            if (Gender == "Nam")
            {
                this.rdNamKH.Checked = true;
            }
            else
            {
                this.rdNuKH.Checked = true;
            }
            this.txtDCKH.Text = dgvKhachHang.Rows[r].Cells[3].Value.ToString();
            this.txtSDTKH.Text = dgvKhachHang.Rows[r].Cells[4].Value.ToString();
            this.cmbTPKH.SelectedValue = dgvKhachHang.Rows[r].Cells[5].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuuKH.Enabled = true;
            this.btnHuyKH.Enabled = true;
            this.panel4.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThemKH.Enabled = false;
            this.btnSuaKH.Enabled = false;
            this.btnXoaKH.Enabled = false;
            this.btnThoatKH.Enabled = false;
            // Đưa con trỏ đến TextField txtTenKH
            this.txtMaKH.Enabled = false;
            this.txtTenKH.Focus();
        }

        private void btnHuyKH_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtMaKH.ResetText();
            this.txtTenKH.ResetText();
            this.txtDCKH.ResetText();
            this.txtSDTKH.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnThemKH.Enabled = true;
            this.btnSuaKH.Enabled = true;
            this.btnXoaKH.Enabled = true;
            this.btnThoatKH.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuuKH.Enabled = false;
            this.btnHuyKH.Enabled = false;
            this.panel4.Enabled = false;
        }

        private void btnLuuKH_Click(object sender, EventArgs e)
        {
            // Mở kết nối
            conn.Open();
            // Thêm dữ liệu
            if (ThemKH)
            {
                try
                {
                    string gender;
                    if (rdNamKH.Checked){
                        gender = "Nam";
                    }
                    else{
                        gender = "Nữ";
                    }

                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lệnh Insert InTo
                    cmd.CommandText = System.String.Concat("Insert Into KhachHang Values(" + "N'" +
                    this.txtTenKH.Text.ToString() + "',N'" +
                    gender +"',N'"+
                    this.txtDCKH.Text.ToString() + "',N'" +
                    this.txtSDTKH.Text.ToString() + "',N'" +
                    this.cmbTPKH.SelectedValue.ToString() +
                    "')");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    loadKhachHang();
                    // Thông báo
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }

            if (!ThemKH)
            {
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Thứ tự dòng hiện hành
                    int r = dgvKhachHang.CurrentCell.RowIndex;
                    // MaKH hiện hành
                    string strMAKH = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
                    // Câu lệnh SQL
                    string gender;
                    if (rdNamKH.Checked){
                        gender = "Nam";
                    }
                    else{
                        gender = "Nữ";
                    }
                    cmd.CommandText = System.String.Concat("Update KhachHang Set TenKH = N'" +
                    this.txtTenKH.Text.ToString() + "', DiaChiKH=N'"+
                    this.txtDCKH.Text.ToString() + "', ThanhPho = N'" +
                    this.cmbTPKH.SelectedValue.ToString() + "', SDT = '" +
                    this.txtSDTKH.Text.ToString() + "', GioiTinh = N'" + gender +
                    "' Where MaKH = '" + strMAKH + "'");
                    // Cập nhật
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    loadKhachHang();
                    // Thông báo
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không sửa được. Lỗi rồi!");
                }
            }
            
            // Đóng kết nối
            conn.Close();
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                // Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Lấy thứ tự record hiện hành
                int r = dgvKhachHang.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strMAKH = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete From KhachHang Where MaKH = '" + strMAKH + "'");
                cmd.CommandType = CommandType.Text;
                // Thực hiện câu lệnh SQL
                cmd.ExecuteNonQuery();
                // Cập nhật lại DataGridView
                loadKhachHang();
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

        //TAB NHÂN VIÊN
        private void btnHuyNV_Click(object sender, EventArgs e)
        {
            //Xóa trống các đối tượng trong Panel
            this.txtMaNV.ResetText();
            this.txtHoTen.ResetText();
            this.dtNgayLV.Value = DateTime.Now;
            this.txtSDT.ResetText();
            this.txtDiaChi.ResetText();
            this.rdNam.Checked = true;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnThemNV.Enabled = true;
            this.btnSuaNV.Enabled = true;
            this.btnXoaNV.Enabled = true;
            this.btnThoatNV.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuuNV.Enabled = false;
            this.btnHuyNV.Enabled = false;
            this.panel2.Enabled = false;
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            ThemNV = true;
            // Xóa trống các đối tượng trong Panel
            this.txtMaNV.ResetText();
            this.txtHoTen.ResetText();
            this.dtNgayLV.Value = DateTime.Now;
            this.txtSDT.ResetText();
            this.txtDiaChi.ResetText();
            this.rdNam.Checked = true;
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuuNV.Enabled = true;
            this.btnHuyNV.Enabled = true;
            this.panel2.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThemNV.Enabled = false;
            this.btnSuaNV.Enabled = false;
            this.btnXoaNV.Enabled = false;
            this.btnThoatNV.Enabled = false;
            // Đưa con trỏ đến TextField txtHoTen
            this.txtMaNV.Enabled = false;
            this.txtHoTen.Focus();
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            ThemNV = false;
            // Cho phép thao tác trên Panel
            this.panel2.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvNhanVien.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaNV.Text = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
            this.txtHoTen.Text = dgvNhanVien.Rows[r].Cells[1].Value.ToString();
            this.dtNgayLV.Value = DateTime.Parse(dgvNhanVien.Rows[r].Cells[2].Value.ToString());
            this.txtSDT.Text = dgvNhanVien.Rows[r].Cells[3].Value.ToString();
            String Gender = dgvNhanVien.Rows[r].Cells[4].Value.ToString();
            if (Gender == "Nam")
            {
                this.rdNam.Checked = true;
            }
            else
            {
                this.rdNu.Checked = true;
            }
            this.txtDiaChi.Text = dgvNhanVien.Rows[r].Cells[5].Value.ToString();
            this.txtMatKhau.Enabled = false;
            this.txtTaiKhoan.Enabled = false;
            this.checkAdm.Enabled = false;
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuuNV.Enabled = true;
            this.btnHuyNV.Enabled = true;
            this.panel2.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThemNV.Enabled = false;
            this.btnSuaNV.Enabled = false;
            this.btnXoaNV.Enabled = false;
            this.btnThoatNV.Enabled = false;
            // Đưa con trỏ đến TextField txtHoTen
            this.txtMaNV.Enabled = false;
            this.txtHoTen.Focus();
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (ThemNV)
            {
                try
                {
                    string gender;
                    if (rdNam.Checked)
                    {
                        gender = "Nam";
                    }
                    else
                    {
                        gender = "Nữ";
                    }
                    int ad = 0;
                    if (checkAdm.Checked)
                    {
                        ad = 1;
                    }
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lệnh Insert InTo
                    cmd.CommandText = System.String.Concat("Insert Into NhanVien Values(N'"+
                        this.txtHoTen.Text.ToString()+ "','"+
                        this.dtNgayLV.Value + "','" +
                        this.txtSDT.Text.ToString() +"',N'" +
                        gender + "',N'" +
                        this.txtDiaChi.Text.ToString()  + "','"+
                        this.txtTaiKhoan.Text.ToString() + "','"+
                        this.txtMatKhau.Text.ToString() +  "'," +
                        ad + " )");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    loadNhanVien();
                    // Thông báo
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            if (!ThemNV)
            {
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Thứ tự dòng hiện hành
                    int r = dgvNhanVien.CurrentCell.RowIndex;
                    // MaKH hiện hành
                    string strMANV = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
                    // Câu lệnh SQL
                    string gender;
                    if (rdNam.Checked)
                    {
                        gender = "Nam";
                    }
                    else
                    {
                        gender = "Nữ";
                    }
                    cmd.CommandText = System.String.Concat("Update NhanVien Set HoTen = N'" +
                    this.txtHoTen.Text.ToString() + "', NgayLV='" +
                    this.dtNgayLV.Value + "', SoDienThoai = '" +
                    this.txtSDT.Text.ToString() + "', GioiTinh = N'" +
                    gender + "', DiaChi = N'" + 
                    this.txtDiaChi.Text.ToString()+
                    "' Where MaNV = '" + strMANV + "'");
                    // Cập nhật
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    loadNhanVien();
                    // Thông báo
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không sửa được. Lỗi rồi!");
                }
            }
            conn.Close();
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                // Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Lấy thứ tự record hiện hành
                int r = dgvNhanVien.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strMANV = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete From NhanVien Where MaNV = '" + strMANV + "'");
                cmd.CommandType = CommandType.Text;
                // Thực hiện câu lệnh SQL
                cmd.ExecuteNonQuery();
                // Cập nhật lại DataGridView
                loadNhanVien();
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

        //TAB LOAI SAN PHAM
        private void btnThemLSP_Click(object sender, EventArgs e)
        {
            ThemLoaiSP = true;
            // Xóa trống các đối tượng trong Panel
            this.txtMLSP.ResetText();
            this.txtLSP.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuuLSP.Enabled = true;
            this.btnHuyLSP.Enabled = true;
            this.panel3.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThemLSP.Enabled = false;
            this.btnSuaLSP.Enabled = false;
            this.btnXoaLSP.Enabled = false;
            this.btnThoatLSP.Enabled = false;
            // Đưa con trỏ đến TextField txtMLSP
            this.txtMLSP.Enabled = false;
            this.txtLSP.Focus();
        }

        private void btnSuaLSP_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            ThemLoaiSP = false;
            // Cho phép thao tác trên Panel
            this.panel3.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvLoaiSP.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMLSP.Text = dgvLoaiSP.Rows[r].Cells[0].Value.ToString();
            this.txtLSP.Text = dgvLoaiSP.Rows[r].Cells[1].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuuLSP.Enabled = true;
            this.btnHuyLSP.Enabled = true;
            this.panel3.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThemLSP.Enabled = false;
            this.btnSuaLSP.Enabled = false;
            this.btnXoaLSP.Enabled = false;
            this.btnThoatLSP.Enabled = false;
            // Đưa con trỏ đến TextField txtMLSP
            this.txtMLSP.Enabled = false;
            this.txtLSP.Focus();
        }

        private void btnHuyLSP_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel 3
            this.txtMLSP.ResetText();
            this.txtLSP.ResetText();
            // Không cho thao tác trên các nút Lưu / Hủy
            this.btnLuuLSP.Enabled = false;
            this.btnHuyLSP.Enabled = false;
            this.panel3.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnThemLSP.Enabled = true;
            this.btnSuaLSP.Enabled = true;
            this.btnXoaLSP.Enabled = true;
            this.btnThoatLSP.Enabled = true;
        }

        private void btnLuuLSP_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (ThemLoaiSP)
            {
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lệnh Insert InTo
                    cmd.CommandText = System.String.Concat("Insert Into LoaiSanPham Values(N'" +
                        this.txtLSP.Text.ToString() + " ')");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    loadLoaiSP();
                    // Thông báo
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            if (!ThemLoaiSP)
            {
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Thứ tự dòng hiện hành
                    int r = dgvLoaiSP.CurrentCell.RowIndex;
                    // MaKH hiện hành
                    string strMaLSP = dgvLoaiSP.Rows[r].Cells[0].Value.ToString();
                    // Câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Update LoaiSanPham Set TenLSP = N'" +
                    this.txtLSP.Text.ToString() + "'" +
                    " Where MaLSP = '" + strMaLSP + "'");
                    // Cập nhật
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    loadLoaiSP();
                    // Thông báo
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không sửa được. Lỗi rồi!");
                }
            }
            conn.Close();
        }

        private void btnXoaLSP_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                // Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Lấy thứ tự record hiện hành
                int r = dgvLoaiSP.CurrentCell.RowIndex;
                // Lấy MaLSP của record hiện hành
                string strMaLSP = dgvLoaiSP.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete From LoaiSanPham Where MaLSP = '" + strMaLSP + "'");
                cmd.CommandType = CommandType.Text;
                // Thực hiện câu lệnh SQL
                cmd.ExecuteNonQuery();
                // Cập nhật lại DataGridView
                loadLoaiSP();
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

        //TAB SẢN PHẨM
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            ThemSP = true;
            // Xóa trống các đối tượng trong Panel
            this.txtMaSanPham.ResetText();
            this.txtTenSanPham.ResetText();
            this.txtSoLuong.ResetText();
            this.txtGia.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuuSP.Enabled = true;
            this.btnHuySP.Enabled = true;
            this.panel1.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThemSP.Enabled = false;
            this.btnSuaSP.Enabled = false;
            this.btnXoaSP.Enabled = false;
            this.btnThoatSP.Enabled = false;

            this.txtMaSanPham.Enabled = false;
            this.txtTenSanPham.Focus();
        }

        private void btnLuuSP_Click(object sender, EventArgs e)
        {
            if (txtTenSanPham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSanPham.Focus();
                return;
            }
            if (txtSoLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return;
            }
            if (txtGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGia.Focus();
                return;
            }
            if (cmbLoaiSanPham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn loại sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbLoaiSanPham.Focus();
                return;
            }
            if (txtHinhAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpload.Focus();
                return;
            }
            

            // Mở kết nối
            conn.Open();
            // Thêm dữ liệu
            if (ThemSP)
            {
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lệnh Insert InTo
                    cmd.CommandText = System.String.Concat("Insert Into SanPham Values(" + "N'" +
                    this.txtTenSanPham.Text.ToString() + "'," +
                    Convert.ToInt32(this.txtSoLuong.Text) + "," +
                    Convert.ToInt32(this.txtGia.Text) + ",N'" +
                    this.cmbLoaiSanPham.SelectedValue.ToString() + "','"+
                    this.txtHinhAnh.Text.ToString() +
                    "')");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    loadSanPham();
                    // Thông báo
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }

            if (!ThemSP)
            {
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Thứ tự dòng hiện hành
                    int r = dgvSanPham.CurrentCell.RowIndex;
                    // MaSP hiện hành
                    string strMaSP = dgvSanPham.Rows[r].Cells[0].Value.ToString();
                    // Câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Update SanPham Set TenSanPham = N'" +
                    this.txtTenSanPham.Text.ToString() + "', SoLuong=" +
                    Convert.ToInt32(this.txtSoLuong.Text) + ", Gia = " +
                    Convert.ToInt32(this.txtGia.Text) + ", LoaiSanPham ='" +
                    this.cmbLoaiSanPham.SelectedValue.ToString() + "', HinhAnh='"+
                    this.txtHinhAnh.Text.ToString() +
                    "' Where MaSanPham = '" + strMaSP + "'");
                    // Cập nhật
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    loadSanPham();
                    // Thông báo
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không sửa được. Lỗi rồi!");
                }
            }

            // Đóng kết nối
            conn.Close();
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            ThemSP = false;
            // Đưa dữ liệu lên ComboBox
            this.cmbLoaiSanPham.DataSource = dtLoaiSP;
            this.cmbLoaiSanPham.DisplayMember = "TenLSP";
            this.cmbLoaiSanPham.ValueMember = "MaLSP";
            // Cho phép thao tác trên Panel
            this.panel1.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvSanPham.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaSanPham.Text = dgvSanPham.Rows[r].Cells[0].Value.ToString();
            this.txtTenSanPham.Text = dgvSanPham.Rows[r].Cells[1].Value.ToString();
            this.txtSoLuong.Text = dgvSanPham.Rows[r].Cells[2].Value.ToString();
            this.txtGia.Text = dgvSanPham.Rows[r].Cells[3].Value.ToString();
            this.cmbLoaiSanPham.SelectedValue = dgvSanPham.Rows[r].Cells[4].Value.ToString();
            this.txtHinhAnh.Text = dgvSanPham.Rows[r].Cells[5].Value.ToString();
            this.HinhAnh.Image = Image.FromFile(txtHinhAnh.Text);
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuuSP.Enabled = true;
            this.btnHuySP.Enabled = true;
            this.panel1.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThemSP.Enabled = false;
            this.btnSuaSP.Enabled = false;
            this.btnXoaSP.Enabled = false;
            this.btnThoatSP.Enabled = false;

            this.txtMaSanPham.Enabled = false;
            this.txtTenSanPham.Focus();
        }

        private void btnHuySP_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtMaSanPham.ResetText();
            this.txtTenSanPham.ResetText();
            this.txtSoLuong.ResetText();
            this.txtGia.ResetText();
            this.txtHinhAnh.ResetText();
            // Không cho thao tác trên các nút Lưu / Hủy
            this.btnLuuSP.Enabled = false;
            this.btnHuySP.Enabled = false;
            this.panel1.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnThemSP.Enabled = true;
            this.btnSuaSP.Enabled = true;
            this.btnXoaSP.Enabled = true;
            this.btnThoatSP.Enabled = true;
            // Đưa dữ liệu lên ComboBox
            this.cmbLoaiSanPham.DataSource = dtLoaiSP;
            this.cmbLoaiSanPham.DisplayMember = "TenLSP";
            this.cmbLoaiSanPham.ValueMember = "MaLSP";
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                // Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Lấy thứ tự record hiện hành
                int r = dgvSanPham.CurrentCell.RowIndex;
                // Lấy MaLSP của record hiện hành
                string strMaSP = dgvSanPham.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete From SanPham Where MaSanPham = '" + strMaSP + "'");
                cmd.CommandType = CommandType.Text;
                // Thực hiện câu lệnh SQL
                cmd.ExecuteNonQuery();
                // Cập nhật lại DataGridView
                loadSanPham();
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

        //TAB THỐNG KÊ
        private void btnThoatTK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime startDate = this.dateStart.Value;
            DateTime endDate = this.dateEnd.Value;
            //MessageBox.Show(startDate.ToString() + "---->" +endDate.ToString());
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtKhachHang
                string sql = "SELECT MaHD, NgayLapHD, NgayGiao, nv.HoTen, kh.TenKH from HoaDon hd join NhanVien nv on hd.MaNV = nv.MaNV" +
                    " join KhachHang kh on kh.MaKH = hd.MaKH Where NgayLapHD BETWEEN '" + startDate + "' AND '" + endDate + "'";
                daHoaDon = new SqlDataAdapter(sql, conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                // Đưa dữ liệu lên DataGridView
                dgvDonHang.DataSource = dtHoaDon;
                dgvDonHang.Columns["NgayLap"].DefaultCellStyle.Format = "dd-MM-yyyy";
                dgvDonHang.Columns["NgayGiao"].DefaultCellStyle.Format = "dd-MM-yyyy";
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table.Lỗi rồi!!!");
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                HinhAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtHinhAnh.Text = dlgOpen.FileName;
            }
        }
    }
}
