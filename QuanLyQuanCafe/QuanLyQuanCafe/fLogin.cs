using QuanLyQuanCafe.DAO;
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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có thật sự muốn thoát chương trình","Thông báo",MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string pass = txbPass.Text;
            if (login(userName, pass))
            {
                fAdmin fAdmin = new fAdmin();

                fTableManage fTableManage1 = new fTableManage();
                fTableManage1.LoadEvent(fAdmin);
                
                //fAdmin.ShowDialog();
               // fTableManage fTableManage = new fTableManage();
                this.Hide();
                fTableManage1.ShowDialog();
                //this.Show();
            }
            else
            {
                MessageBox.Show("Sai tai khoan hoac mat khau", "");
            }
        }

        bool login(string userName, string pass)
        {

            return AccountDAO.Instance.login(userName,pass);
        }
    }
}
