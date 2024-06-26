﻿using QuanLyBanDoAnNhanh.DAO;
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
    public partial class ql_ThemDanhMuc : MetroFramework.Forms.MetroForm
    {
        public ql_ThemDanhMuc()
        {
            InitializeComponent();
        }

        private void btnADDCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;

            if (Danhmuc_DAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm danh mục thành công");
                

            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm danh mục");
            }
        }
    }
}
