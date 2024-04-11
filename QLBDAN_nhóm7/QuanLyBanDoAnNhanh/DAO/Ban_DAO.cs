using QuanLyBanDoAnNhanh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanDoAnNhanh.DAO
{
    public class Ban_DAO
    {
        private static Ban_DAO instance;
        public static Ban_DAO Instance
        {
            get { if (instance == null) instance = new Ban_DAO(); return Ban_DAO.instance; }   
            private set {Ban_DAO.instance = value; }
        }
        public static int TableWidth = 90;
        public static int TableHeight = 90;

        private Ban_DAO() { }
        public List<Ban> LoadTableList()
        {
            List<Ban> tableList = new List<Ban>();

            DataTable data = DataProvider.Instance.ExecuteQuery("exec dbo.USP_GetTableList");
            foreach (DataRow item in data.Rows)
            {
                Ban table = new Ban(item);
                tableList.Add(table);
               
            }
            return tableList;


        }

        public List<Ban> GetListTable()
        {
            List<Ban> list = new List<Ban>();
            string query = "select * from TableFood ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Ban table = new Ban(item);
                list.Add(table);
            }
            return list;
        }

        /* public bool InsertTable( string name, string status)
         {
             status = "Trống";
             string query = string.Format("insert dbo.TableFood (name , status)  values (N'{0}' ,N'{1}')",  name, status);
             int result = DataProvider.Instance.ExecuteNonQuery(query);

             return result > 0;
         }*/
        public bool InsertTable(string name)
        {
            
            string query = string.Format("insert dbo.TableFood (name , status)  values (N'{0}' ,N' ')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateTable(int idTable, string name, string status)
        {
            status = " ";
            string query = string.Format("update dbo.TableFood set name = N'{0}', status = N'{1}' where id = {2}", name, status, idTable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteTable(int idTable)
        {
           
            string query = string.Format("Delete TableFood where id = {0}", idTable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
