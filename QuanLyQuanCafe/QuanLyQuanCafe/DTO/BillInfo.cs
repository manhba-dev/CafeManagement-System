using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class BillInfo
    {


        private int count;

        private int billID;

        private int foodID;

        private int id;

        public BillInfo(int count, int billID, int foodID, int id)
        {
            this.count = count;
            this.billID = billID;
            this.foodID = foodID;
            this.id = id;
        }
        public BillInfo(DataRow row)
        {
            this.id = (int)row["id"];
            this.billID = (int)row["idBill"];
            this.foodID = (int)row["idFood"];
            this.count = (int)row["count"];
        }

        public int Id { get => id; set => id = value; }
        public int FoodID { get => foodID; set => foodID = value; }
        public int BillID { get => billID; set => billID = value; }
        public int Count { get => count; set => count = value; }
    }
}
