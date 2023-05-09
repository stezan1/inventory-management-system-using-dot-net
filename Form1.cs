using System.Data.SqlClient;

namespace INVENTORY_MANAGEMENT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-L780H7UQ;Initial Catalog=Inventory_Management_System;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string query = @"SELECT
       [Username]
      ,[Password]
      ,[Type]
  FROM [dbo].[employee1] Where  Username='" + username.Text + "'AND Password='" + password.Text + "' ";

            con.Open();




            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rd;
            rd = cmd.ExecuteReader();


            if (rd.HasRows)
            {
                rd.Read();
                if (rd[2].ToString() == "Admin")
                {
                    MyConnection.Type = "A";
                }
                else if (rd[2].ToString() == "User")
                {
                    MyConnection.Type = "U";

                }
                role.uname=username.Text;
                role.password=password.Text;
                con.Close();
                this.Hide();
                Home h = new Home();
                h.Show(); ;
            }
            else if (role.password == "userpass")
            {
                this.Hide();
                Change_Password ch = new Change_Password();
                this.Parent.Controls.Add(ch);
            }
            else
            {
                MessageBox.Show("invalid username or password ");
            }
            con.Close();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            string a = password.Text;
            if (checkBox1.Checked)
            {
                password.PasswordChar = '\0';
            }
            else
            {
                password.PasswordChar = '*';
            }
        }

        private void password_TextChanged_1(object sender, EventArgs e)
        {
            password.PasswordChar = '*';
        }

        private void label6_Click(object sender, EventArgs e)
        {
 
            Application.Exit();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            username.Clear();
            password.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            forget forg=new forget();
            forg.Show();
            this.Hide();

        }

        private void username_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                password.Focus();
            }
        }
    }
}