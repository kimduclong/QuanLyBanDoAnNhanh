using QuanLyBanDoAnNhanh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanDoAnNhanh.DAO
{
    public class Hoadon_DAO
    {
        private static Hoadon_DAO instance;

        public static Hoadon_DAO Instance
        {
            get { if (instance == null) instance = new Hoadon_DAO(); return Hoadon_DAO.instance; }
            private set { Hoadon_DAO.instance = value; }
        }

        private Hoadon_DAO() { }
        // thành công " bill ID
        // thất bại :-1
        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE idTable = " + id + " AND status = 0");
        if(data.Rows.Count > 0)
            {
                Hoadon bill = new Hoadon(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }

        public void CheckOut(int id, int discount, float totalPrice)
        {
            string query = "Update dbo.Bill set dateCheckOut = getdate(), status = 1, " + "discount = " + discount + ", totalPrice = " + totalPrice + " where id =  " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_InsertBill @idTable", new object[] { id });
        }
        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDate @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("select max(id) from dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }
    }
}
