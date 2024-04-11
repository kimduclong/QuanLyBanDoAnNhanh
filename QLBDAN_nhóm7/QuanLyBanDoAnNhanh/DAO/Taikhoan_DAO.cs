using QuanLyBanDoAnNhanh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanDoAnNhanh.DAO
{
    public class Taikhoan_DAO
    {
        private static Taikhoan_DAO instance;

        public static Taikhoan_DAO Instance
        {
            get { if (instance == null) instance = new Taikhoan_DAO(); return instance; }
            private set { instance = value; }
        }

        private Taikhoan_DAO() { }

        public bool Login(string userName, string passWord)
        {
            //ma hoa mat khau co ban 
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(passWord);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";
           
            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            string query = "USP_Login @userName , @passWord ";

            //DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, hasPass /*list*/});
              DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });
            return result.Rows.Count > 0;
        }

        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[] { userName, displayName, pass, newPass });

            return result > 0;
        }
        public bool InsertAccount(string name, string displayName, string passWord, int type)
        {
            string query = string.Format("INSERT dbo.Account (UserName, DisplayName, PassWord, Type) VALUES  ( N'{0}', N'{1}', {2}, N'{3}')", name, displayName, passWord, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateAccount(string name, string displayName, string passWord, int type)
        {
            string query = string.Format("UPDATE dbo.Account SET DisplayName = N'{1}',PassWord = {2}, Type = {3} WHERE UserName = N'{0}'", name, displayName, passWord, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string name)
        {
            string query = string.Format("Delete Account where UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool ResetPassword(string name)
        {
            string query = string.Format("update account set PassWord = N'1' where UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }


        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT UserName, DisplayName, PassWord, Type FROM dbo.Account");
        }

        public Taikhoan GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from account where userName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Taikhoan(item);
            }

            return null;
        }
    }
}
