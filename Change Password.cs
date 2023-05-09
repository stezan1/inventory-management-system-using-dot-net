using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INVENTORY_MANAGEMENT
{
    public partial class Change_Password : Form
    {
        public Change_Password()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-L780H7UQ;Initial Catalog=Inventory_Management_System;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)

        {
            if (oldpass.Text.Equals(string.Empty))
            {
                MessageBox.Show("Enter old password !");
            }
            else if (newpass.Text.Equals(string.Empty))
            {
                MessageBox.Show("Enter new password !");
            }
            else if (cnewpass.Text.Equals(string.Empty))
            {
                MessageBox.Show("Enter new password !");
            }
            else
            {
                if (oldpass.Text == role.password)
                {

                    if (newpass.Text == cnewpass.Text)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("update employee1 set Password='" + newpass.Text + "' where Username='" + role.uname + "' ", con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Password Changed Successfully\n Login Again");
                        this.Hide();
                        Form1 form1 = new Form1();
                        form1.Show();
                        con.Close();

                    }
                    else
                    {
                        MessageBox.Show("Password Do not matched");
                    }
                }
                else
                {
                    MessageBox.Show("Old Password is wrong !");
                }
            }
        
    }   

        private void button2_Click(object sender, EventArgs e)
        {
            oldpass.Clear();
            newpass.Clear();
            cnewpass.Clear();
        }

        private void oldpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void oldpass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                newpass.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                newpass.UseSystemPasswordChar = false;
                cnewpass.UseSystemPasswordChar=false;
            }
            else
            {
                newpass.UseSystemPasswordChar = true;
                cnewpass.UseSystemPasswordChar = true;
            }
        }

        private void Change_Password_Load(object sender, EventArgs e)
        {
            newpass.UseSystemPasswordChar=true;
            cnewpass.UseSystemPasswordChar = true;
        }

        private void newpass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                cnewpass.Focus();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
