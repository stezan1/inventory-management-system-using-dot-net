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
    public partial class User_Registration : Form
    {
        public User_Registration()
        {
            InitializeComponent();
        }
        public int ID;
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-L780H7UQ;Initial Catalog=Inventory_Management_System;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            Home h=new Home();
            h.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (type.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Type !");
                }
                else if (email.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Email Address !");
                }
                else if (user.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Enter Username or Employee Name !");
                }
                else if (pass.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Password !");
                }
                else if(pass.Text.Equals(cpass.Text))
                {
                    string query = @"INSERT INTO [dbo].[Login1]
           ([Username]
           ,[Password]
           ,[Type]
           ,[Email])
     VALUES('" + user.Text + "','" + pass.Text + "','" + type.Text + "','" + email.Text + "')";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Inseted Successfully");



                    SqlDataAdapter adapter = new SqlDataAdapter("select * from login1", con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Password Do Not Match !");
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from login1", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                type.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                email.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                user.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                pass.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch (System.InvalidCastException ex)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ID > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE dbo.login set Type=@type,Email=@email,Username=@user,Password=@pass  where ID=@ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.ID);
                cmd.Parameters.AddWithValue("@type", type.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@user", user.Text);
                cmd.Parameters.AddWithValue("@pass", pass.Text);
                cmd.ExecuteNonQuery();


                SqlDataAdapter sda = new SqlDataAdapter("select * from login", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();

                MessageBox.Show("data updated");
            }
            else
                MessageBox.Show("select user to update");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ID > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from login where ID=@ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.ID);
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter sda = new SqlDataAdapter("select * from login", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                MessageBox.Show("data deleted");
            }
            else
                MessageBox.Show("select user to delete");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ID= 0;
            type.Items.Clear();
            email.Clear();
            user.Clear();
            pass.Clear();
        }

        private void User_Registration_Load(object sender, EventArgs e)
        {

        }
    }
}
