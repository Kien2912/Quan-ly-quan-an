using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace QLQA
{
    public partial class fExportOrder : Form
    {
        public fExportOrder()
        {
            InitializeComponent();
        }

        private void fExportOrder_Load(object sender, EventArgs e)
        {
        
            // TODO: This line of code loads data into the 'qLQADataSet.tblMain' table. You can move, or remove it, as needed.
            this.tblMainTableAdapter.Fill(this.qLQADataSet.tblMain);

        }

        private void export2Excel(DataGridView g, string duongDan, string tenTap)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;

            // Header Text
            for (int i = 1; i < g.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }

            // Content 
            for(int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }

            obj.ActiveWorkbook.SaveCopyAs(duongDan + tenTap + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            export2Excel(OrderDatagridview, @"D:\", "xuatfileExcel");
            guna2MessageDialog1.Show("Xuát excel thành công");
        }

        private void daThanhToanToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tblMainTableAdapter.DaThanhToan(this.qLQADataSet.tblMain);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
