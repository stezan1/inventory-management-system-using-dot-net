using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INVENTORY_MANAGEMENT
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        Form3 f3;
        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f3 == null)
            {
                f3 = new Form3();
                f3.MdiParent = this;
                f3.FormClosed += new FormClosedEventHandler(F3_FormClosed);
                f3.Show();
            }
            else
                f3.Activate();
        }
        void F3_FormClosed(object sender, FormClosedEventArgs e)
        {
            f3 = null;
            //throw new NotImplementedException();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4=new Form4();
            f4.MdiParent = this;
            f4.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase purchase = new Purchase(); 
            purchase.MdiParent = this;
            purchase.Show();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sales s=new sales();
            s.MdiParent = this;
            s.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock();
            stock.MdiParent = this;
            stock.Show();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About_Us about = new About_Us();
            about.MdiParent = this;
            about.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_Password changePassword = new Change_Password();
            changePassword.MdiParent = this;
            changePassword.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           this.Close();
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void userRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User_Registration user_Registration = new User_Registration();
            user_Registration.MdiParent = this;
            user_Registration.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (MyConnection.Type == "A")
            {
                employeeToolStripMenuItem.Visible = true;
                productToolStripMenuItem.Visible = true;
                purchaseToolStripMenuItem.Visible = true;
                salesToolStripMenuItem.Visible = true;
                stockToolStripMenuItem.Visible = true;
                aboutUsToolStripMenuItem.Visible = true;
                changePasswordToolStripMenuItem.Visible = true;
                logOutToolStripMenuItem.Visible = true;
                
            }
            else if (MyConnection.Type == "U")
            {
                employeeToolStripMenuItem.Visible = false;
                productToolStripMenuItem.Visible = true;
                purchaseToolStripMenuItem.Visible = true;
                salesToolStripMenuItem.Visible = true;
                stockToolStripMenuItem.Visible = true;
                aboutUsToolStripMenuItem.Visible = true;
                changePasswordToolStripMenuItem.Visible = true;
                logOutToolStripMenuItem.Visible = true;
                
            }
        }
    }
}
    

