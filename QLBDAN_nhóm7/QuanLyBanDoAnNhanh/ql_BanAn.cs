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
    public partial class ql_BanAn : MetroFramework.Forms.MetroForm
    {
        BindingSource tableList = new BindingSource();

        public ql_BanAn()
        {
            InitializeComponent();
            dtgvTable.DataSource = tableList;
            LoadListTable();
            AddTableBinding();
        }

        void AddTableBinding()
        {
           txbTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbTableStatus.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Status", true, DataSourceUpdateMode.Never));
        }
        void LoadListTable()
        {
           tableList.DataSource = Ban_DAO.Instance.GetListTable();
        }
        private void btnShowTable_Click(object sender, EventArgs e)
        {
            LoadListTable();
        }

      
        private void btnEditTable_Click(object sender, EventArgs e)
        {
            string name = txbTableName.Text;
            string status = txbTableStatus.Text;

            int idTable = Convert.ToInt32(txbTableID.Text);

            if (Ban_DAO.Instance.UpdateTable(idTable, name, status))
            {
                MessageBox.Show("Sửa bàn thành công!");
                LoadListTable();

                
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa bàn!");
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbTableID.Text);

            if (Ban_DAO.Instance.DeleteTable(id))
            {
                MessageBox.Show("Xóa bàn thành công!");
                LoadListTable();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa bàn!");
            }
        }

        private void btnADDTable_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ql_ThemBanAn f = new ql_ThemBanAn();
            f.ShowDialog();
            f.Close();
            LoadListTable();
            this.Show();
        }
    }

}