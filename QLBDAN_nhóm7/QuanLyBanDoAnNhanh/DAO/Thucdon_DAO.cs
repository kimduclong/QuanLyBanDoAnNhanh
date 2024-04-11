using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanDoAnNhanh.DAO
{
    public class Thucdon_DAO
    {
        private static Thucdon_DAO instance;

        public static Thucdon_DAO Instance
        {
            get { if (instance == null) instance = new Thucdon_DAO(); return Thucdon_DAO.instance; }
            private set { Thucdon_DAO.instance = value; }
        }
        private Thucdon_DAO() { }
        public List<QuanLyBanDoAnNhanh.DTO.Thucdon> GetListMenuByTable(int id)
        {
            List<QuanLyBanDoAnNhanh.DTO.Thucdon> listMenu = new List<QuanLyBanDoAnNhanh.DTO.Thucdon>();
            string query = "select f.name, bi.count, f.price, f.price*bi.count AS totalPrice from dbo.BillInfo as bi, dbo.Bill as b, dbo.Food as f where bi.idBill = b.id and bi.idFood = f.id and b.status = 0 and b.idTable = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                QuanLyBanDoAnNhanh.DTO.Thucdon menu = new QuanLyBanDoAnNhanh.DTO.Thucdon(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }


    }
    }
