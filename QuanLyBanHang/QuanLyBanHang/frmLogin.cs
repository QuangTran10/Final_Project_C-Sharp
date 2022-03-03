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
    public partial class frmLogin : Form
    {
        const string strConnectionString = "Data Source=DESKTOP-5KOS173;Initial Catalog=banhang;Integrated Security = True";
        // Đối tượng kết nối
        private static SqlConnection conn = null;
        public frmLogin()
        {
            InitializeComponent();
        }

        //Hàm kiểm tra Đăng Nhập
        public static bool CheckLogin(string username, string password)
        {
            // Khởi động connection
            conn = new SqlConnection(strConnectionString);
            string sql = "Select * from NhanVien Where TaiKhoan= '" + username + "' and Password ='" + password + "'";
            SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }

        //Hàm lấy quyền admin
        public static int getAdmin(string username, string password)
        {
            int admin = 0;
            // Khởi động connection
            conn = new SqlConnection(strConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Admin from NhanVien Where TaiKhoan= '" + username + "' and Password ='" + password + "'";

            cmd.Connection = conn;

            //Thực thi câu lệnh
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                admin = reader.GetByte(0);
            }
            reader.Close();
            conn.Close();
            return admin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string TaiKhoan = this.txtUsername.Text.Trim();
            string Password = this.txtPassword.Text.Trim();
            if(CheckLogin(TaiKhoan, Password)==true)
            {
                int ad = getAdmin(TaiKhoan, Password);
                this.Hide();
                Form frmMenu = new frmMenu(ad);
                frmMenu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tài khoản và Mật khẩu không đúng! Mời nhập lại");
                this.txtUsername.ResetText();
                this.txtPassword.ResetText();
                this.txtUsername.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }
    }
}
