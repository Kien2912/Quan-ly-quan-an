using QLQA.Reports;
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
    public partial class fPrintProduct : Form
    {
        public fPrintProduct()
        {
            InitializeComponent();
        }

        private void btnPrintProduct_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-Q2U43A9U;Initial Catalog=QLQA;Integrated Security=True");
            SqlCommand command = new SqlCommand("select * from products", con);

            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataSet s = new DataSet();
            sd.Fill(s);

            rptListProduct sr = new rptListProduct();
            sr.SetDatabaseLogon("sa", "123456");
            sr.SetDataSource(s.Tables["table"]);
            crystalReportViewer1.ReportSource = sr;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
