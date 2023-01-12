    using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace QuanLyQuanCafe.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        private String connectionStr = @"Data Source=DESKTOP-LGGDLEO\SQLEXPRESS;Initial Catalog=QuanLyQuanCaFe;Integrated Security=True";

        public static DataProvider Instance {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
        private set { DataProvider.instance = value; }
        }

        public DataProvider() { }
        public DataTable ExecuteQuery(String query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                if(parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string para in listPara)
                    {
                        if (para.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(para, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                sqlConnection.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(String query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string para in listPara)
                    {
                        if (para.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(para, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            return data;

        }

        public object ExecuteScalar(String query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string para in listPara)
                    {
                        if (para.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(para, parameter[i]);
                            i++;
                        }
                    }
                }

                data=cmd.ExecuteScalar();
                sqlConnection.Close();
            }
            return data;
        }
    }
}
