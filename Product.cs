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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-L780H7UQ;Initial Catalog=Inventory_Management_System;Integrated Security=True");
        int PID;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (name.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Product Name !");
                }
                else if(type.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Product type !");
                }
                else if(cost.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Cost !");
                }
                else if(description.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter description !");
                }
                else
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("insert into dbo.product values('" + name.Text + "','" + type.Text + "','" + cost.Text + "','" + description.Text + "' )", con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data Inserted");

                            SqlDataAdapter adapter = new SqlDataAdapter("select * from product", con);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                PID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                type.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                cost.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                description.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch (System.InvalidCastException ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from product", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (PID > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE dbo.product set Product_Name=@name,Product_Type=@type,Cost=@cost,Description=@description  where PID=@PID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@PID", this.PID);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@type", type.Text);
                cmd.Parameters.AddWithValue("@cost", cost.Text);
                cmd.Parameters.AddWithValue("@description", description.Text);
                cmd.ExecuteNonQuery();


                SqlDataAdapter sda = new SqlDataAdapter("select * from product", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();

                MessageBox.Show("data updated");
            }
            else
                MessageBox.Show("select product to update");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (PID > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from product where PID=@PID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@PID", this.PID);
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter sda = new SqlDataAdapter("select * from product", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                MessageBox.Show("data deleted");
            }
            else
                MessageBox.Show("select product to delete");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PID = 0;
            name.Clear();
            type.Clear();
            cost.Clear();
            description.Clear();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            string s = search.Text + "%";
            SqlDataAdapter sda = new SqlDataAdapter("select * from product where Product_Name like ('" + s + "')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                PID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                type.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                cost.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                description.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch (System.InvalidCastException ex)
            {

            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void type_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                type.Focus();
            }
        }

        private void type_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cost.Focus();
            }
        }

        private void cost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                description.Focus();
            }
        }

        private void description_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
