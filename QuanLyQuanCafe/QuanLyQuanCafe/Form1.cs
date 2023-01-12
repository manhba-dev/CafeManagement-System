using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using QuanLyQuanCafe.DAO;
using DGVPrinterHelper;

namespace QuanLyQuanCafe
{
	public partial class Form1 : Form
	{
		string sql = @"Data Source=DESKTOP-LGGDLEO\SQLEXPRESS;Initial Catalog=QuanLyQuanCaFe;Integrated Security=True";
		SqlConnection con = null;


		int idTableTag;
		float tongTienHD;
		float tongTienKhachTra;
		public Form1(int idTableTag, float tongTienHD, float tongTienKhachTra)
		{
			InitializeComponent();
			this.idTableTag = idTableTag;
			this.tongTienHD = tongTienHD;
			this.tongTienKhachTra = tongTienKhachTra;
		}


		private void Form1_Load(object sender, EventArgs e)
		{
            // TODO: This line of code loads data into the 'quanLyQuanCaFeDataSet.TableFood' table. You can move, or remove it, as needed.
            this.tableFoodTableAdapter.Fill(this.quanLyQuanCaFeDataSet.TableFood);
            // TODO: This line of code loads data into the 'quanLyQuanCaFeDataSet1.USP_GetTableList' table. You can move, or remove it, as needed.

            if (con == null)
			{
				con = new SqlConnection(sql);

			}
			
			//MessageBox.Show(idTableTag+"");
			//string query = "EXEC dbo.USP_GetBillForPrint @billID = "+idTableTag;
			//DataProvider dataProvider = new DataProvider();
			//dataGridView1.DataSource =  dataProvider.ExecuteQuery(query);
			
			//DataTable dataTable = dataProvider.ExecuteQuery(query);
			//if (dataTable.Rows.Count > 2) {
			//	MessageBox.Show("CÓ");
			//}
			//DataSet ds = new DataSet();
			//ds.Tables.Add(dataProvider.ExecuteQuery(query));
			////adapter.Fill(ds, "FoodCategory");
			//this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyQuanCafe.Report1.rdlc";
			//ReportDataSource ds2 = new ReportDataSource();
			//ds2.Name = "DataSet1";
			//ds2.Value = ds.Tables["HoaDon"];
		
			//this.reportViewer1.LocalReport.DataSources.Add(ds2);
			this.uSP_GetBillForPrintTableAdapter.Fill(this.quanLyQuanCaFeDataSet1.USP_GetBillForPrint,idTableTag);
			Microsoft.Reporting.WinForms.ReportParameter[] reportParameters = new Microsoft.Reporting.WinForms.ReportParameter[]
			{
				new Microsoft.Reporting.WinForms.ReportParameter("tongTienHD",tongTienHD.ToString()),
				new Microsoft.Reporting.WinForms.ReportParameter("tongTienKhachTra",tongTienKhachTra.ToString())
			};
			this.reportViewer1.LocalReport.SetParameters(reportParameters);

            this.reportViewer1.RefreshReport();
			
        }

        private void button1_Click(object sender, EventArgs e)
		{
			DGVPrinter printer = new DGVPrinter();
			printer.Title = "Customer Bill";
			printer.SubTitle = String.Format("Date: {0}", DateTime.Now.Date);
			printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
			printer.PageNumbers = true;
			printer.PageNumberInHeader = false;
			printer.PorportionalColumns = true;
			printer.HeaderCellAlignment = StringAlignment.Near;
			printer.Footer = "Total : ";
			printer.FooterSpacing = 15;


			//dataGridView1.Rows.Clear();

		}



        private void button3_Click(object sender, EventArgs e)
        {
			
			this.Close();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
			
			this.reportViewer1.PrintDialog();
        }
    }
}
