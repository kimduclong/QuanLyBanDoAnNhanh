using QuanLyBanDoAnNhanh.DAO;
using QuanLyBanDoAnNhanh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanDoAnNhanh
{
    public partial class ql_TaiKhoan : MetroFramework.Forms.MetroForm
    {
        private Taikhoan loginAccount;

        BindingSource accountList = new BindingSource();
        public ql_TaiKhoan(Taikhoan acc)
        {
            InitializeComponent();
            loginAccount = acc;
            dtgvAccount.DataSource = accountList;
            LoadAccount();
            AddAccountBinding();
        }


        void AddAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            txbPassword.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "PassWord", true, DataSourceUpdateMode.Never));
            numericUpDown1.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }


        void LoadAccount()
        {
            accountList.DataSource = Taikhoan_DAO.Instance.GetListAccount();
        }

        void AddAccount(string userName, string displayName, string passWord,int type)
        {
            if (Taikhoan_DAO.Instance.InsertAccount(userName, displayName, passWord, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }

            LoadAccount();
        }


        void EditAccount(string userName, string displayName, string passWord, int type)
        {
            if (Taikhoan_DAO.Instance.UpdateAccount(userName, displayName, passWord, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }

            LoadAccount();
        }

        void DeleteAccount(string userName)
        {
          if ( loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Vui lòng đừng xóa chính bạn chứ");
                return;
            }
            if (Taikhoan_DAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

            LoadAccount();
        }

        void ResetPass(string userName)
        {
            if (Taikhoan_DAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại");
            }
            LoadAccount();
        }





            private void btnAddAccount_Click_1(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            string passWord = txbPassword.Text;
            int type = (int)numericUpDown1.Value;

            AddAccount(userName, displayName, passWord, type);
        }

        private void btnDeleteAccount_Click_1(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            DeleteAccount(userName);
        }

        private void btnEditAccount_Click_1(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            string passWord = txbPassword.Text;
            int type = (int)numericUpDown1.Value;

            EditAccount(userName, displayName, passWord, type);
        }

        private void btnResetPassWord_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            ResetPass(userName);
        }

        private void txbPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
