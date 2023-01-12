using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance {
            get { if(instance == null) instance = new BillDAO(); return instance; }
            private set => instance = value; }

        public BillDAO() { }

        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data =  DataProvider.Instance.ExecuteQuery("select * from dbo.Bill where idTable = " + id + "AND statusBill = 0");
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id;
            }
            return -1;
        }

        public DataTable GetListBillByDate(DateTime checkIn,DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDate @checkIn , @checkOut ",new object[] {checkIn,checkOut});
        }

        public void CheckOut(int id, float totalPrice)
        {
            string query = "UPDATE dbo.Bill SET DateCHeckOut = GETDATE(), statusBill = 1, totalPrice = "+ totalPrice + " WHERE id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idTable", new object[] { id });
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }
    }
}
