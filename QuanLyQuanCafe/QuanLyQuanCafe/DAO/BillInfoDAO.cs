using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance {
            get {  
                if (instance == null) instance = new BillInfoDAO();
                return instance;
            } 
            private set => instance = value; }

        public BillInfoDAO() { }

        public void DeleteBillInfoById(int id)
        {
            DataProvider.Instance.ExecuteQuery("delete dbo.BillInfo WHERE idFood = "+id);
        }

        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo> ();
            DataTable dataTable = DataProvider.Instance.ExecuteQuery("select * from dbo.BillInfo where idBill = " + id);

            foreach (DataRow row in dataTable.Rows)
            {
                BillInfo billInfo = new BillInfo(row);
                listBillInfo.Add(billInfo);
            }
            return listBillInfo;
        }
        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBillInfo @idBill , @idFood , @count", new object[] { idBill, idFood, count });
        }
    }
}
