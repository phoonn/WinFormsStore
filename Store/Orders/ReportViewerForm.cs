using CrystalDecisions.CrystalReports.Engine;
using DataModel.Entities;
using ErrorAndValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Store.Orders
{
    public partial class ReportViewerForm : Form
    {
        private Order order;
        ReportDocument StockObjectsReport = new ReportDocument();
        public ReportViewerForm(Order order)
        {
            this.order = order;
            InitializeComponent();
            this.Icon = Store.Properties.Resources.StoreIcon;
            //ReportDocument cryRpt = new ReportDocument();
            //cryRpt.Load(@"C:\Users\user\Desktop\C#\Store\CrystalReport1.rpt");
            try
            {
                List<Order> source = new List<Order>();
                source.Add(order);
                string reportpath = Directory.GetCurrentDirectory() + "\\Reports\\RomitReport.rpt";
                StockObjectsReport.Load(reportpath);
                StockObjectsReport.SetDataSource(source);
                crystalReportViewer1.ReportSource = StockObjectsReport;
                crystalReportViewer1.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load report, check log file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorLogger.Log(ex);
                this.Close();
            }
            
        }

        private void ReportViewerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StockObjectsReport.Dispose();
            crystalReportViewer1.Dispose();
        }
    }
}
