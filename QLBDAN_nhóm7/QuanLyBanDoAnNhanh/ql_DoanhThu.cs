using QuanLyBanDoAnNhanh.DAO;
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
    public partial class fDoanhThu : MetroFramework.Forms.MetroForm
    {
        public fDoanhThu()
        {
            InitializeComponent();
            LoadDateTimePickerBill();
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }
         void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = Hoadon_DAO.Instance.GetBillListByDate(checkIn, checkOut);
        }
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }

        private void fDoanhThu_Load(object sender, EventArgs e)
        {

        }

        private void btnReport1_Click(object sender, EventArgs e)
        {
            ql_Report1 f = new ql_Report1();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
