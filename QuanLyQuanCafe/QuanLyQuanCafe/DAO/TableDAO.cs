using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static int tableWidth = 90;
        public static int tableHeight = 90;

        public static TableDAO Instance {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; } 
            private set => instance = value; }

        public TableDAO() { }

        public List<Table> loadTableList()
        {
            List<Table> tableList = new List<Table> ();
            DataTable data = DataProvider.Instance.ExecuteQuery("dbo.USP_GetTableList");

            foreach (DataRow row in data.Rows) {
                Table table = new Table(row);
                tableList.Add(table);
                
            }

            return tableList;
        }


    }
}
