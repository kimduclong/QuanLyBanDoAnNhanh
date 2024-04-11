using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanDoAnNhanh
{
    public partial class hoadon : MetroFramework.Forms.MetroForm
    {
        public hoadon()
        {
            InitializeComponent();
            LoadDateTimePickerReport();
        }

        private void fReport1_Load(object sender, EventArgs e)
        {
            this.uSP_GetListBillByDateReportTableAdapter.Fill(this.quanLyBanDoAnNhanhDataSet.USP_GetListBillByDateReport, dtpkFromDate1.Value, dtpkToDate1.Value);
            this.reportViewer2.RefreshReport();
        }


        void LoadDateTimePickerReport()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate1.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate1.Value = dtpkFromDate1.Value.AddMonths(1).AddDays(-1);
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            this.uSP_GetListBillByDateReportTableAdapter.Fill(this.quanLyBanDoAnNhanhDataSet.USP_GetListBillByDateReport, dtpkFromDate1.Value, dtpkToDate1.Value);
            this.reportViewer2.RefreshReport();
        }
    }
}
