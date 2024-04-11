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
    public partial class ql_ThemThucAn : MetroFramework.Forms.MetroForm
    {
        public ql_ThemThucAn()
        {
            InitializeComponent();
            
            LoadCategoryIntoCombobox(cbFoodCategory);
           
        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = Danhmuc_DAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Loai).ID;
            float price = (float)nmFoodPrice.Value;

            if (Doan_DAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công!");
               
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm món!");
            }
        }
    }
}
