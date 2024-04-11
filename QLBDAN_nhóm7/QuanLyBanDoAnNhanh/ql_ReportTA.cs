using QuanLyBanDoAnNhanh.DAO;
using QuanLyBanDoAnNhanh.DTO;
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
    public partial class ql_ReportTA : MetroFramework.Forms.MetroForm
    {
        public ql_ReportTA()
        {
            InitializeComponent();
            LoadCategory();
        }

        private void fReportTA_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        void LoadCategory()
        {
            List<Loai> listCategory = Danhmuc_DAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";

        }
        
  

        private void cbFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cate;

            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Loai selected = cb.SelectedItem as Loai;
            cate = selected.Name;
            
            this.uSP_GetListFoodByCategoryTableAdapter.Fill(this.quanLyBanDoAnNhanhDataSet1.USP_GetListFoodByCategory, cate);
            this.reportViewer1.RefreshReport();
        }
    }
}
