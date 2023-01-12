using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu = QuanLyQuanCafe.DTO.Menu;
using DGVPrinterHelper;

namespace QuanLyQuanCafe
{
    public partial class fTableManage : Form
    {
        public int idTableTag;
        public float tongTienDu;
        public float tongTienHD;
        public DataTable table = new DataTable();
        public DataGrid dataGrid;
        public fTableManage()
        {
            InitializeComponent();

            loadTable();
            LoadCategory();
        }



        #region Method

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbFoodCat.DataSource = listCategory;
            cbFoodCat.DisplayMember = "Name";
        }

        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "Name";
        }

        void loadTable() {
            flpTable.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.loadTableList();

            foreach (Table table in tableList)
            {
                Button btn = new Button() { Width = TableDAO.tableWidth, Height = TableDAO.tableHeight };

                btn.Text = table.Name + Environment.NewLine + table.Status;
                btn.Click += btn_Click;
                btn.Tag = table;
                switch (table.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }

                flpTable.Controls.Add(btn); 
            }
        }
        void showBill(int id)
        {
            tongTienDu = 0;
            txbTongTienKT.Text = "0";
            txbTienDu.Text = "0";
            tongTienHD = 0;
            lsvBill.Items.Clear();
            List<QuanLyQuanCafe.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);

            float totalPrice = 0;
            foreach (QuanLyQuanCafe.DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());


                tongTienHD += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }

            CultureInfo cultureInfo = new CultureInfo("vi-VN");
            txbTotalPrice.Text = tongTienHD.ToString("c",cultureInfo);
        }

        #endregion


        #region Events

        private void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            showBill(tableID);
            idTableTag = tableID;
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public void LoadEvent(fAdmin fAdmin)
        {

            fAdmin.InsertFood += fAdmin_InsertFood;
            fAdmin.DeleteFood += fAdmin_DeleteFood;
            fAdmin.UpdateFood += fAdmin_UpdateFood;

        }
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin fAdmin = new fAdmin();

            fAdmin.InsertFood += fAdmin_InsertFood;
            fAdmin.DeleteFood += fAdmin_DeleteFood;
            fAdmin.UpdateFood += fAdmin_UpdateFood;

            fAdmin.ShowDialog();
            //fLogin fLogin = new fLogin();
            //fLogin.ShowDialog();
        }

        private void fAdmin_UpdateFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbFoodCat.SelectedItem as Category).ID);
            if(lsvBill.Tag != null)
            showBill((lsvBill.Tag as Table).ID);
        }

        private void fAdmin_DeleteFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbFoodCat.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                showBill((lsvBill.Tag as Table).ID);
            loadTable();
        }

        private void fAdmin_InsertFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbFoodCat.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                showBill((lsvBill.Tag as Table).ID);
        }

        #endregion

        private void fTableManage_Load(object sender, EventArgs e)
        {
                txbTotalPrice.ReadOnly = true;
        }

        private void cbFoodCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            id = selected.ID;

            LoadFoodListByCategoryID(id);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            if (table == null)
                MessageBox.Show("Hãy chọn bàn");

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int foodID = (cbFood.SelectedItem as Food).ID;
            int count = (int)nmFoodCount.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
            }

            showBill(table.ID);

            loadTable();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);

            if (idBill != -1)
            {
                if (MessageBox.Show("Bạn có chắc thanh toán hóa đơn cho bàn " + table.Name, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill,tongTienHD);
                    showBill(table.ID);

                    loadTable();
                }
            }
        }

        private void lsvBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flpTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            //Table table = lsvBill.Tag as Table;

            //int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);

            //if (idBill != -1)
            //{
            //    if (MessageBox.Show("Bạn có chắc thanh toán hóa đơn cho bàn " + table.Name, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            //    {
            //        BillDAO.Instance.CheckOut(idBill, tongTienHD);
            //        showBill(table.ID);

            //        loadTable();
            //    }
            //}
            Form1 form1 = new Form1(idTableTag,tongTienHD , float.Parse(txbTongTienKT.Text, CultureInfo.InvariantCulture.NumberFormat)); 
            form1.Show();
            Table table = lsvBill.Tag as Table;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);

            if (idBill != -1)
            {
                if (MessageBox.Show("Bạn có chắc thanh toán hóa đơn cho bàn " + table.Name, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, tongTienHD);
                    showBill(table.ID);

                    loadTable();
                }
            }
            //DGVPrinter printer = new DGVPrinter();
            //         printer.Title = "Customer Bill";
            //         printer.SubTitle = String.Format("Date: {0}",DateTime.Now.Date);
            //         printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            //         printer.PageNumbers = true;
            //         printer.PageNumberInHeader = false;
            //         printer.PorportionalColumns = true;
            //         printer.HeaderCellAlignment = StringAlignment.Near;
            //         printer.Footer = "Total : ";
            //         printer.FooterSpacing = 15;
        }

        private void nmDiscount_ValueChanged(object sender, EventArgs e)
        {
            //if (nmDiscount.Value > 0)
            //{
            //    int temp = Convert.ToInt32(nmDiscount.Value);
            //    float temp2 = temp / 100;
            //    tongTienDu = float.Parse(txbTongTienKT.Text) - (tongTienHD - (tongTienHD * (temp2)  ) );
            //}
            //else
            //{
            //    tongTienDu = tongTienHD;
            //}
            //txbTienDu.Text = tongTienDu.ToString();
        }

        private void txbTotalPrice_TextChanged(object sender, EventArgs e)
        {
            tongTienDu = tongTienDu + tongTienHD + float.Parse((tongTienHD*0.08).ToString());
            txbTienDu.Text = tongTienDu.ToString();
            txbTotalVAT.Text = (tongTienHD + float.Parse((tongTienHD * 0.08).ToString())).ToString();
        }

        private void txbTongTienKT_TextChanged(object sender, EventArgs e)
        {
            tongTienDu =  float.Parse(txbTongTienKT.Text) - float.Parse(txbTotalVAT.Text);
            txbTienDu.Text = tongTienDu.ToString();
        }
    }
}
