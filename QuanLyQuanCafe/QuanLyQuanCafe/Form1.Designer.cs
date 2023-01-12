namespace QuanLyQuanCafe
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.uSPGetBillForPrintBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyQuanCaFeDataSet1 = new QuanLyQuanCafe.QuanLyQuanCaFeDataSet1();
            this.uSPGetBillForPrintBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.quanLyQuanCaFeDataSet = new QuanLyQuanCafe.QuanLyQuanCaFeDataSet();
            this.tableFoodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableFoodTableAdapter = new QuanLyQuanCafe.QuanLyQuanCaFeDataSetTableAdapters.TableFoodTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.uSP_GetBillForPrintTableAdapter = new QuanLyQuanCafe.QuanLyQuanCaFeDataSet1TableAdapters.USP_GetBillForPrintTableAdapter();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetBillForPrintBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyQuanCaFeDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetBillForPrintBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyQuanCaFeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableFoodBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // uSPGetBillForPrintBindingSource1
            // 
            this.uSPGetBillForPrintBindingSource1.DataMember = "USP_GetBillForPrint";
            this.uSPGetBillForPrintBindingSource1.DataSource = this.quanLyQuanCaFeDataSet1;
            // 
            // quanLyQuanCaFeDataSet1
            // 
            this.quanLyQuanCaFeDataSet1.DataSetName = "QuanLyQuanCaFeDataSet1";
            this.quanLyQuanCaFeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 535);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // quanLyQuanCaFeDataSet
            // 
            this.quanLyQuanCaFeDataSet.DataSetName = "QuanLyQuanCaFeDataSet";
            this.quanLyQuanCaFeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableFoodBindingSource
            // 
            this.tableFoodBindingSource.DataMember = "TableFood";
            this.tableFoodBindingSource.DataSource = this.quanLyQuanCaFeDataSet;
            // 
            // tableFoodTableAdapter
            // 
            this.tableFoodTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uSPGetBillForPrintBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyQuanCafe.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(586, 571);
            this.reportViewer1.TabIndex = 3;
            // 
            // uSP_GetBillForPrintTableAdapter
            // 
            this.uSP_GetBillForPrintTableAdapter.ClearBeforeFill = true;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.Location = new System.Drawing.Point(423, 589);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(178, 51);
            this.btnThanhToan.TabIndex = 4;
            this.btnThanhToan.Text = "In hóa đơn";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(12, 589);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 51);
            this.button3.TabIndex = 6;
            this.button3.Text = "Quay Lại";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 682);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetBillForPrintBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyQuanCaFeDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetBillForPrintBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyQuanCaFeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableFoodBindingSource)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.BindingSource uSPGetBillForPrintBindingSource;
        private System.Windows.Forms.Button button1;
        private QuanLyQuanCaFeDataSet quanLyQuanCaFeDataSet;
        private System.Windows.Forms.BindingSource tableFoodBindingSource;
        private QuanLyQuanCaFeDataSetTableAdapters.TableFoodTableAdapter tableFoodTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uSPGetBillForPrintBindingSource1;
        private QuanLyQuanCaFeDataSet1 quanLyQuanCaFeDataSet1;
        private QuanLyQuanCaFeDataSet1TableAdapters.USP_GetBillForPrintTableAdapter uSP_GetBillForPrintTableAdapter;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button button3;
    }
}