using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Bill
    {
        private int id;

        private DateTime? dateCheckIn;

        private DateTime? dateCheckOut;

        private int status;

        public Bill(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int status)
        {
            this.id = id;
            this.dateCheckIn = dateCheckIn;
            this.dateCheckOut = dateCheckOut;
            this.status = status;
        }
        public Bill(DataRow row)
        {
            this.id = (int)row["id"];
            this.dateCheckIn = (DateTime?)row["DateCheckIn"];
            var dateCheckOutTemp = row["DateCHeckOut"];
            if(dateCheckOutTemp.ToString() != "")
            this.dateCheckOut = (DateTime?)dateCheckOutTemp;
            this.status = (int)row["statusBill"];
        }
        public int Id { get => id; set => id = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
    }
}
