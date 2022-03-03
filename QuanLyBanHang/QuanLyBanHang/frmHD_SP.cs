﻿using System;
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
    public partial class frmHD_SP : Form
    {
        // Chuỗi kết nối
        const string strConnectionString = "Data Source=DESKTOP-5KOS173;Initial Catalog=banhang;Integrated Security = True";
        // Đối tượng kết nối
        private static SqlConnection conn = null;
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
        // Đối tượng đưa dữ liệu vào DataTable dtChiTietHoaDon
        SqlDataAdapter daChiTietHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtChiTietHoaDon = null;

        public frmHD_SP()
        {
            InitializeComponent();
        }

        void loadSanPham()
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtKhachHang
                daSanPham = new SqlDataAdapter("SELECT MaSanPham, TenSanPham, SoLuong, Gia, LoaiSanPham FROM SanPham", conn);
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
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table.Lỗi rồi!!!");
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

        private void frmHD_SP_Load(object sender, EventArgs e)
        {
            loadSanPham();
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

        void load_order(int MaSP)
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtKhachHang
                string sql = "SELECT DISTINCT hd.* from HoaDon hd join ChiTietHoaDon ct on ct.MaHD = hd.MaHD where MaSanPham=" + MaSP;
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

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = this.dgvSanPham.CurrentCell.RowIndex;
            int MaSanPham = Convert.ToInt32(dgvSanPham.Rows[row].Cells[0].Value);
            string TenNV = dgvSanPham.Rows[row].Cells[1].Value.ToString();
            load_order(MaSanPham);
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = this.dgvHoaDon.CurrentCell.RowIndex;
            int MaHD = Convert.ToInt32(dgvHoaDon.Rows[row].Cells[0].Value);
            load_order_details(MaHD);
            this.labelTotal.Text = GetTotal(MaHD).ToString() + "đ";
        }
    }
}
