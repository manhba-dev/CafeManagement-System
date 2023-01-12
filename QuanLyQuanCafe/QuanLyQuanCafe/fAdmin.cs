using DGVPrinterHelper;
using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fAdmin : Form
    {
        BindingSource foodList = new BindingSource();
        public fAdmin()
        {
            
            InitializeComponent();
            dtgvFood.DataSource = foodList;
            LoadAccountList();
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            LoadDateTimePickerBill();
            LoadListFood();
            LoadCategoryIntoCombobox(cbFoodCat);
            AddFoodBinding();
            dtgvFood.Enabled = true;
        }

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadAccountList()
        {
            String query = "EXEC dbo.USP_GetAccountByUserName @userName";
            //DataProvider provider = new DataProvider();
            //dtgvAccount.DataSource = provider.ExecuteQuery(query);

            //dtgvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query,new object[] {"dung"});


        }
        private void fAdmin_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        #region methods
        void LoadListBillByDate(DateTime checkIn,DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetListBillByDate(checkIn,checkOut);
        }

        void AddFoodBinding() {
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Name",true,DataSourceUpdateMode.Never));
            txbFoodID.DataBindings.Add(new Binding("Text",dtgvFood.DataSource,"ID", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));

        }

        void LoadCategoryIntoCombobox(ComboBox comboBox)
        {
            comboBox.DataSource = CategoryDAO.Instance.GetListCategory();
            comboBox.DisplayMember = "Name";
        }

        #endregion

        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }

        #region events
        private void btnTke_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value,dtpkToDate.Value);
        }


        #endregion

        private void btnViewFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void txbFoodID_TextChanged(object sender, EventArgs e)
        {

            if (dtgvFood.SelectedCells.Count > 0)
            {
                int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);

                cbFoodCat.SelectedItem = cateogory;

                int index = -1;
                int i = 0;
                foreach (Category item in cbFoodCat.Items)
                {
                    if (item.ID == cateogory.ID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                cbFoodCat.SelectedIndex = index;

            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            dtgvFood.Enabled = false;
            txbFoodID.Text = "";
            txbFoodName.Text = "";
            cbFoodCat.Text = "";
            nmFoodPrice.Value = 0;
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCat.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn");
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txbFoodID.Text.Trim() == "")
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn thêm sản phẩm không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {

                    string name = txbFoodName.Text;
                    int categoryID = (cbFoodCat.SelectedItem as Category).ID;
                    float price = (float)nmFoodPrice.Value;

                    if (FoodDAO.Instance.InsertFood(name, categoryID, price))
                    {
                        MessageBox.Show("Thêm món thành công");
                        LoadListFood();
                        if (insertFood != null)
                            insertFood(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi thêm thức ăn");
                    }
                }
                else
                {

                }
                
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn sửa sản phẩm không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {

                    string name = txbFoodName.Text;
                    int categoryID = (cbFoodCat.SelectedItem as Category).ID;
                    float price = (float)nmFoodPrice.Value;
                    int id = Convert.ToInt32(txbFoodID.Text);

                    if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
                    {
                        MessageBox.Show("Sửa món thành công");
                        LoadListFood();
                        if (updateFood != null)
                            updateFood(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi sửa thức ăn");
                    }
                }
                else
                {

                }
                
            }
        }

        private void btnEditFood_Click_1(object sender, EventArgs e)
        {
            //string name = txbFoodName.Text;
            //int categoryID = (cbFoodCat.SelectedItem as Category).ID;
            //float price = (float)nmFoodPrice.Value;
            //int id = Convert.ToInt32(txbFoodID.Text);

            //if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            //{
            //    MessageBox.Show("Sửa món thành công");
            //    LoadListFood();
            //    if (updateFood != null)
            //        updateFood(this, new EventArgs());
            //}
            //else
            //{
            //    MessageBox.Show("Có lỗi khi sửa thức ăn");
            //}
            dtgvFood.Enabled = true;
        }

        private void btnDelFood_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa sản phẩm không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                int id = Convert.ToInt32(txbFoodID.Text);

                if (FoodDAO.Instance.DeleteFood(id))
                {
                    MessageBox.Show("Xóa món thành công");
                    LoadListFood();
                    if (deleteFood != null)
                        deleteFood(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa thức ăn");
                }
            }
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtgvFood.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Doanh Thu Theo Món";
            printer.SubTitle = "Từ ngày " + dtpkFromDate.Value.ToShortDateString() + " đến ngày "+ dtpkToDate.Value.ToShortDateString();
            // printer.SubTitle = String.Format("Ngày xuất: {0}", DateTime.Now.Date);
           // printer.Footer = String.Format("Ngày xuất: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.PrintDataGridView(dtgvBill);
            
            //printer.Footer = "Total : ";
            printer.FooterSpacing = 15;
            
        }

        private void dtgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

       
    }
}
