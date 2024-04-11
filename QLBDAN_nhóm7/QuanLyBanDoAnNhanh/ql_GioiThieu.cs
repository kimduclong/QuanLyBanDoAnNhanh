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
    public partial class ql_GioiThieu : MetroFramework.Forms.MetroForm
    {
        public ql_GioiThieu()
        {
            InitializeComponent();
        }

        private void btnChuyenDN_Click(object sender, EventArgs e)
        {
            
            Dangnhap f = new Dangnhap();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
    }
}
