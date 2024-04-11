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
    public partial class ql_ThemBanAn : MetroFramework.Forms.MetroForm
    {
        public ql_ThemBanAn()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string name = txbTableName.Text;
            


            if (Ban_DAO.Instance.InsertTable(name))
            {
                MessageBox.Show("Thêm bàn thành công");

            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm bàn");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
