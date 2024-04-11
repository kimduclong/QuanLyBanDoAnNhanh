using QuanLyBanDoAnNhanh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanDoAnNhanh.DAO
{
    public class Doan_DAO
    {
        private static Doan_DAO instance;

        public static Doan_DAO Instance
        {
            get { if (instance == null) instance = new Doan_DAO(); return Doan_DAO.instance; }
            private set { Doan_DAO.instance = value; }

        }

        private Doan_DAO() { }

        public List<Doan> GetFoodByCategoryID(int id)
        {
            List<Doan> list = new List<Doan>();
            string query = "select * from Food where idCategory = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Doan food = new Doan(item);
                list.Add(food);
            }
            return list;

        }
        public List<Doan> GetListFood()
        {
            List<Doan> list = new List<Doan>();
            string query = "select * from Food ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Doan food = new Doan(item);
                list.Add(food);
            }
            return list;
        }

        public List<Doan> SearchFoodByName(string name)
        {

            List<Doan> list = new List<Doan>();

            string query = string.Format("SELECT * FROM dbo.Food WHERE dbo.fuConvertToUnsign1(name) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Doan food = new Doan(item);
                list.Add(food);
            }

            return list;
        }
        public bool InsertFood (string name, int id, float price)
        {
            string query = string.Format("insert dbo.Food ( name, idCategory, price ) values (N'{0}', {1}, {2})", name, id, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateFood(int idFood, string name, int id, float price)
        {
            string query = string.Format("update dbo.Food set name = N'{0}', idCategory = {1}, price = {2} where id = {3}", name, id, price, idFood );
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteFood(int idFood)
        {
            TTHoadon_DAO.Instance.DeleteBillInfoByFoodID(idFood);
            string query = string.Format("Delete Food where id = {0}", idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }

}
