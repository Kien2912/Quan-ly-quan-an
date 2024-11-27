using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQA.Model
{
    public partial class fAccountAdd : SampleAdd
    {
        public fAccountAdd()
        {
            InitializeComponent();
        }

        public int id = 0;
        internal object txtRole;

        private void fAccountAdd_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.Items.Add("Staff");
            guna2ComboBox1.Items.Add("Admin");
            guna2ComboBox1.SelectedIndex = 0;
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string query = "";

            if (txtName.Text.Equals("") || guna2ComboBox1.SelectedIndex == -1)
            {
                guna2MessageDialog1.Show("Yêu cầu nhập đầy đủ thông tin và chọn phân quyền");
                return;
            }
            else
            {
                if (id == 0) // Insert
                {
                    query = "INSERT INTO users (username, upass, uName, uPhone, role) VALUES (@Username, @Pass, @Name, @Phone, @Role)";
                }
                else // Update
                {
                    query = "UPDATE users SET username = @Username, upass = @Pass, uName = @Name, uPhone = @Phone, role = @Role WHERE userID = @id";
                }
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Username", txtUsername.Text);
            ht.Add("@Pass", txtPass.Text);
            ht.Add("@Name", txtName.Text);
            ht.Add("@Phone", txtPhone.Text);
            ht.Add("@Role", guna2ComboBox1.SelectedItem.ToString()); // Lấy giá trị từ ComboBox

            if (MainClass.SQL(query, ht) > 0)
            {
                guna2MessageDialog1.Show("Lưu thành công");
                id = 0;
                txtUsername.Text = "";
                txtPass.Text = "";
                txtName.Text = "";
                txtPhone.Text = "";
                guna2ComboBox1.SelectedIndex = 0; // Reset về "Staff"

                txtName.Focus();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
