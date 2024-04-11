namespace QuanLyBanDoAnNhanh
{
    partial class ql_Report1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ql_Report1));
            this.uSPGetListBillByDateReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyBanDoAnNhanhDataSet = new QuanLyBanDoAnNhanh.QuanLyBanDoAnNhanhDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpkToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpkFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.uSP_GetListBillByDateReportTableAdapter = new QuanLyBanDoAnNhanh.QuanLyBanDoAnNhanhDataSetTableAdapters.USP_GetListBillByDateReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanDoAnNhanhDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // uSPGetListBillByDateReportBindingSource
            // 
            this.uSPGetListBillByDateReportBindingSource.DataMember = "USP_GetListBillByDateReport";
            this.uSPGetListBillByDateReportBindingSource.DataSource = this.quanLyBanDoAnNhanhDataSet;
            // 
            // quanLyBanDoAnNhanhDataSet
            // 
            this.quanLyBanDoAnNhanhDataSet.DataSetName = "QuanLyBanDoAnNhanhDataSet";
            this.quanLyBanDoAnNhanhDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uSPGetListBillByDateReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyBanDoAnNhanh.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(37, 121);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(999, 418);
            this.reportViewer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Đến ngày: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Từ ngày: ";
            // 
            // dtpkToDate
            // 
            this.dtpkToDate.Location = new System.Drawing.Point(393, 91);
            this.dtpkToDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpkToDate.Name = "dtpkToDate";
            this.dtpkToDate.Size = new System.Drawing.Size(319, 22);
            this.dtpkToDate.TabIndex = 5;
            // 
            // dtpkFromDate
            // 
            this.dtpkFromDate.Location = new System.Drawing.Point(37, 91);
            this.dtpkFromDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpkFromDate.Name = "dtpkFromDate";
            this.dtpkFromDate.Size = new System.Drawing.Size(328, 22);
            this.dtpkFromDate.TabIndex = 4;
            // 
            // btnViewReport
            // 
            this.btnViewReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnViewReport.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.Location = new System.Drawing.Point(777, 15);
            this.btnViewReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(205, 68);
            this.btnViewReport.TabIndex = 8;
            this.btnViewReport.Text = "Xuất";
            this.btnViewReport.UseVisualStyleBackColor = false;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // uSP_GetListBillByDateReportTableAdapter
            // 
            this.uSP_GetListBillByDateReportTableAdapter.ClearBeforeFill = true;
            // 
            // fReport1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpkToDate);
            this.Controls.Add(this.dtpkFromDate);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fReport1";
            this.Text = "Xuất Thống kê";
            this.Load += new System.EventHandler(this.fReport1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanDoAnNhanhDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpkToDate;
        private System.Windows.Forms.DateTimePicker dtpkFromDate;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.BindingSource uSPGetListBillByDateReportBindingSource;
        private QuanLyBanDoAnNhanhDataSet quanLyBanDoAnNhanhDataSet;
        private QuanLyBanDoAnNhanhDataSetTableAdapters.USP_GetListBillByDateReportTableAdapter uSP_GetListBillByDateReportTableAdapter;
    }
}