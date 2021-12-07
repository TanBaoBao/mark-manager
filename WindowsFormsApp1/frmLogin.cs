using GradeManager.DAOs;
using GradeManager.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace GradeManager
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        //public void OpenCoffeeShopForm()
        //{
        //    fr coffeeShop = new frmCoffeeShop();
        //    this.Hide();
        //    coffeeShop.ShowDialog();
        //    txtPassword.Text = "";
        //    this.Show();
        //}

        private void btnLogin_Click(object sender, EventArgs e)
        {

            UserDAO dao = new UserDAO();
            UserDTO dto = dao.GetAccount(txtAccountID.Text, txtPassword.Text);
            if (dto == null)
                MessageBox.Show("Login failed, please try again!");
            else
            {
                if (dto.RoleID.Equals("ad"))
                {
                    frmAdmin frm = new frmAdmin();
                    this.Hide();
                    frm.ShowDialog();
                    txtPassword.Text = "";
                    this.Show();
                }
                else
                {
                    frmUser frm = new frmUser();
                    frm.UserID = txtAccountID.Text;
                    this.Hide();
                    frm.ShowDialog();
                    txtPassword.Text = "";
                    this.Show();
                }
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtAccountID.Text = "";
            txtPassword.Text = "";
        }
    }
}
