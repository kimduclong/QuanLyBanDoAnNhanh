using QuanLyBanDoAnNhanh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanDoAnNhanh.DAO
{
    public class Danhmuc_DAO
    {
        private static Danhmuc_DAO instance;
        public static Danhmuc_DAO Instance
        {
            get { if (instance == null) instance = new Danhmuc_DAO(); return Danhmuc_DAO.instance; }
            private set { Danhmuc_DAO.instance = value; }

        }
        private Danhmuc_DAO() {  }
        public List<Loai> GetListCategory()
        {
            List<Loai> list = new List<Loai>();
            string query = "select * from FoodCategory";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Loai category = new Loai(item);
                list.Add(category);
            }
            return list;
        }

       
        public bool InsertCategory(string name)
        {
            string query = string.Format("INSERT dbo.FoodCategory ( name )VALUES  ( N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateCategory(int idCategory, string name)
        {
            string query = string.Format("UPDATE dbo.FoodCategory SET name = N'{0}' WHERE id = {1}", name, idCategory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteCategory(int idCategory)
        {
            

            string query = string.Format("Delete FoodCategory where id = {0}", idCategory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public Loai GetCategoryByID(int id)
        {
            Loai category = null;
            string query = "select * from FoodCategory where id = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                 category = new Loai(item);
                return category;
            }
            return category;
        }
    }
}
