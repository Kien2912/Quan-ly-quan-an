using QLQA.Reports;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQA.Model
{
    public partial class fBillList : SampleAdd
    {
        public fBillList()
        {
            InitializeComponent();
        }

        public int MainID = 0;

        private void fBillList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string query = @"select MainID, TableName, WaiterName, orderType, status, total from 
                            tblMain where status <> 'Chờ' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvtable);
            lb.Items.Add(dgvWaiter);
            lb.Items.Add(dgvType);
            lb.Items.Add(dgvStatus);
            lb.Items.Add(dgvTotal);


            MainClass.LoadData(query, guna2DataGridView1, lb);
        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // for searil no
            int count = 0;

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Edit 
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                string status = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvStatus"].Value);

                if(status == "Hoàn thành" || status == "Lưu")
                {
                    MainID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                    this.Close();
                }
                else if (status == "Đã thanh toán")
                {
                    guna2MessageDialog1.Show("Đơn hàng đã thanh toán");
                }
                else
                {
                    guna2MessageDialog1.Show("Đơn hàng chưa hoàn thành không thể xem");
                }

            }

            // Print
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvPrint")
            {

               string status = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvStatus"].Value);

                if(status == "Đã thanh toán")
                {
                    string MainID = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);


                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-Q2U43A9U;Initial Catalog=QLQA;Integrated Security=True");
                    SqlCommand command = new SqlCommand("select  * from tblMain as m , tblDetails as dt , products as pd " +
                        "where m.MainID = dt.MainID and dt.proID = pd.pID " +
                        "and m.MainID = '" + MainID + "'", con);

                    SqlDataAdapter sd = new SqlDataAdapter(command);
                    DataSet s = new DataSet();
                    sd.Fill(s);

                    rptBill sr = new rptBill();
                    sr.SetDataSource(s.Tables["table"]);
                    

                    fPrintBill f = new fPrintBill();
                    f.crystalReportViewerPrintBill.ReportSource = sr;
                    f.crystalReportViewerPrintBill.Refresh();
                    f.ShowDialog();


                }
                else
                {
                    guna2MessageDialog1.Show("Bạn chưa thanh toán");
                }


            }

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
