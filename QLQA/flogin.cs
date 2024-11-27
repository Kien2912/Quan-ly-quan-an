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

namespace QLQA
{
    public partial class flogin : Form
    {
      
        public flogin()
        {
            InitializeComponent();
        }
        Guna.UI2.WinForms.Guna2MessageDialog successDialog = new Guna.UI2.WinForms.Guna2MessageDialog
        {
            Style = Guna.UI2.WinForms.MessageDialogStyle.Dark, // Giao diện sáng
            Icon = Guna.UI2.WinForms.MessageDialogIcon.Information, // Biểu tượng thông tin
            Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK
        };

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            string connectionString = "Data Source=LAPTOP-Q2U43A9U;Initial Catalog=QLQA;Integrated Security=True";

            string query = "SELECT uName, ROLE FROM Users WHERE username = @Username AND upass = @Password";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string fullName = reader["uName"].ToString().Trim(); // Loại bỏ khoảng trắng
                                string role = reader["ROLE"].ToString().Trim(); // Loại bỏ khoảng trắng

                                // Lưu thông tin người dùng vào biến tĩnh
                                fMain.MainClass.USER = fullName;
                                fMain.MainClass.ROLE = role;

                                // Kiểm tra vai trò
                                if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                                {
                                    successDialog.Show($"Đăng nhập thành công với vai trò quản lý ({fullName})!", "Xác nhận quyền");
                                }
                                else
                                {
                                    successDialog.Show($"Đăng nhập thành công với vai trò nhân viên ({fullName})!", "Xác nhận quyền");
                                }

                                // Ẩn form đăng nhập và hiển thị form chính
                                this.Hide();
                                fMain main = new fMain();
                                main.Show();
                            }
                            else
                            {
                                guna2MessageDialog1.Show("Sai tài khoản hoặc mật khẩu", "Lỗi");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi kết nối tới cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }







        private void guna2PictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            txtPass.UseSystemPasswordChar = false;
        }

        private void guna2PictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
                
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {
                
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
