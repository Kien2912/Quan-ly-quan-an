using Guna.UI2.WinForms;
using QLQA.Model;
using QLQA.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace QLQA
{
    public partial class fMain : Form
    {
        public static class MainClass
        {
            public static string USER { get; set; } // Tên người dùng
            public static string ROLE { get; set; } // Quyền người dùng ("Admin" hoặc "Staff")
        }
        public fMain()
        {
            InitializeComponent();
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
  
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        // Để truy cập form Main
        static fMain _obj;
        public static fMain Instance
        {
            get { if (_obj == null) { _obj = new fMain(); } return _obj; } 

        }

        // Phương thức add Controls vào form Main
        public void AddControls(Form f)
        {
            ControlsPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            ControlsPanel.Controls.Add(f);
            f.Show();

        }

        private void fMain_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Form Main Loaded");
            lblUser.Text = MainClass.USER;
            _obj = this;

            // Đảm bảo phân quyền đúng dựa trên ROLE
            if (MainClass.ROLE.Trim() == "Staff")
            {
                btnStatis.Enabled = false;
                btnStaff.Enabled = false;
                btnAccount.Enabled = false;
               
            }
            else if (MainClass.ROLE.Trim() == "Admin")
            {
                btnStatis.Enabled = true;
                btnStaff.Enabled = true;
                btnAccount.Enabled = true;
            }
            else
            {
                MessageBox.Show("Quyền không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        private void btnHome_Click_1(object sender, EventArgs e)
        {
            MainTop.Visible = true;
            AddControls(new fHomeView());
        }

        private void btnCategory_Click_1(object sender, EventArgs e)
        {
            MainTop.Visible = true;
            AddControls(new fCategoryView());

        }

        private void btnProduct_Click_1(object sender, EventArgs e)
        {
            MainTop.Visible = true;
            AddControls(new fProductView());

        }

        private void btnTable_Click_1(object sender, EventArgs e)
        {
            MainTop.Visible = true;
            AddControls(new fTableView());
        }

        private void btnStaff_Click_1(object sender, EventArgs e)
        {
            MainTop.Visible = true;
            AddControls(new fStaffView());
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            MainTop.Visible = true;
            AddControls(new fAccountView());
        }

        private void btnPOS_Click_1(object sender, EventArgs e)
        {
            MainTop.Visible = false;
            AddControls(new fManage());
        }

        private void btnKetchen_Click_1(object sender, EventArgs e)
        {
            MainTop.Visible = true;
            AddControls(new fKitchenView());
        }


        private void btnStatis_Click(object sender, EventArgs e)
        {
            if (!btnStatis.Enabled)
            {
                MessageBox.Show("Bạn không có quyền sử dụng chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MainTop.Visible = true;
            AddControls(new fStatisView());
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            flogin f = new flogin();
            f.Show();
        }
       

        private void ControlsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
