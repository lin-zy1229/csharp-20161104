using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_La_Rosa
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {

            this.repViewer1.RefreshReport();
        }

        #region Methods
        public void prepareDailyReport(DataTable pSource,DateTime pDateSelected, int reportType)
        {
            repViewer1.ProcessingMode = ProcessingMode.Local;

            LocalReport localReport = repViewer1.LocalReport;

            localReport.ReportPath = Application.StartupPath + "\\dailyRep.rdlc";

            
            repViewer1.LocalReport.DataSources.Add(
               new ReportDataSource("DataSetCompletedDailyOrders", pSource));


            List<ReportParameter> parms = new List<ReportParameter>();
            

            String reportDate = pDateSelected.ToString("MM/d/yyyy");
            
            String reportFor = "";
            switch (reportType){
                case 0:
                    reportFor = "DAILY";
                    break;
                case 1:
                    reportFor = "MONTHLY";
                    break;
                case 2:
                    reportFor = "YEARLY";
                    break;
            }

            parms.Add(new ReportParameter("repDateParam", reportDate));
            //parms.Add(new ReportParameter("paramRepType", reportFor));

            try
            {
                repViewer1.LocalReport.SetParameters(parms);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in parsing report parmas: "+ ex.Message);
            }

            // Refresh the report  
            repViewer1.RefreshReport(); 
        }
        /// <summary>
        /// Report Monthly, Yeayly
        /// </summary>
        /// <param name="pSource"></param>
        /// <param name="pDateSelected"></param>
        /// <param name="reportType"></param>
        /// <author>Gert.heine@aol.com</author>
        public void prepareMonthlyYearlyReport(DataTable pSource, DateTime pDateSelected, int reportType)
        {
            repViewer1.ProcessingMode = ProcessingMode.Local;

            LocalReport localReport = repViewer1.LocalReport;

            localReport.ReportPath = Application.StartupPath + "\\monthYearReport.rdlc";


            repViewer1.LocalReport.DataSources.Add(
               new ReportDataSource("DataSetComletedOrderMonthYear", pSource));


            List<ReportParameter> parms = new List<ReportParameter>();


            String reportDate = pDateSelected.ToString("MM/d/yyyy");

            String reportFor = "";
            switch (reportType)
            {
                case 0:
                    reportFor = "DAILY";
                    break;
                case 1:
                    reportFor = "MONTHLY";
                    break;
                case 2:
                    reportFor = "YEARLY";
                    break;
            }

            parms.Add(new ReportParameter("repDateParam", reportDate));
            //parms.Add(new ReportParameter("paramRepType", reportFor));

            try
            {
                //repViewer1.LocalReport.SetParameters(parms);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in parsing report parmas: " + ex.Message);
            }

            // Refresh the report  
            repViewer1.RefreshReport();
        }
        #endregion
    }
}
