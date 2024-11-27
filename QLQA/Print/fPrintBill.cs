using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQA
{
    public partial class fPrintBill : Form
    {

        public fPrintBill()
        {
            InitializeComponent();
        }

       
        public void SetReportSource(CrystalDecisions.CrystalReports.Engine.ReportDocument report)
        {
            crystalReportViewerPrintBill.ReportSource = report;
        }

        private void crystalReportViewerPrintBill_Load(object sender, EventArgs e)
        {

        }
    }
}
