using QuanLyBanDoAnNhanh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanDoAnNhanh.DAO
{
    public class TTHoadon_DAO
    {
        private static TTHoadon_DAO instance;

        public static TTHoadon_DAO Instance
        {
            get { if (instance == null) instance = new TTHoadon_DAO(); return TTHoadon_DAO.instance; }
            private set { TTHoadon_DAO.instance = value; }
        }
        private TTHoadon_DAO() { }

        public void DeleteBillInfoByFoodID(int id)
        {
            DataProvider.Instance.ExecuteQuery("delete dbo.BillInfo where idFood = " + id);
        }

        public List<TtHoadon> GetListBillInfo(int id)
        {
            List<TtHoadon> listBillInfo = new List<TtHoadon>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BillInfo WHERE idBill = " + id);

            foreach(DataRow item in data.Rows)
            {
                TtHoadon info = new TtHoadon(item);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }

        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_InsertBillInfo @idBill , @idFood , @count", new object[] { idBill, idFood, count });
        }
    }
}
