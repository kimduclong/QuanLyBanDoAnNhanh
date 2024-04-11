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
    public partial class ql_DanhMuc : MetroFramework.Forms.MetroForm
    {
        BindingSource categoryList = new BindingSource();

        public ql_DanhMuc()
        {
           

            InitializeComponent();
            dtgvCategory.DataSource = categoryList;
            LoadListCategory();
            AddCategoryBinding();
            
        }

        void AddCategoryBinding()
        {
            txbCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
            
           
        }
        void LoadListCategory()
        {
           

            categoryList.DataSource = Danhmuc_DAO.Instance.GetListCategory();
           
        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadListCategory();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {

            this.Hide();
            ql_ThemDanhMuc f = new ql_ThemDanhMuc();
            f.ShowDialog();
            f.Close();
            LoadListCategory();
            this.Show();
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            
            string name = txbCategoryName.Text;
            int idCategory = Convert.ToInt32(txbCategoryID.Text);

            if (Danhmuc_DAO.Instance.UpdateCategory( idCategory, name))
            {
                MessageBox.Show("Sửa danh mục thành công");
                LoadListCategory();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa danh mục");
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbCategoryID.Text);

            if (Danhmuc_DAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xóa danh mục thành công");
                LoadListCategory();
                
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa danh mục");
            }
        }
    }
}
