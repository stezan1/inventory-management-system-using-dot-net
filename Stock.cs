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
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-L780H7UQ;Initial Catalog=Inventory_Management_System;Integrated Security=True");
        int SId;
        private void button1_Click(object sender, EventArgs e)
        {   try
            {
                if (name.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter product name !");
                }
                else if (category.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter category !");
                }
                else if (quantity.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Quantity !");
                }
                else if (description.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter description !");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into dbo.stock values('" + name.Text + "','" + category.Text + "','" + quantity.Text + "','" + description.Text + "' )", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Inserted");

                    SqlDataAdapter adapter = new SqlDataAdapter("select * from stock", con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from stock", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                category.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                quantity.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                description.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch (System.InvalidCastException ex)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (SId > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE dbo.stock set Product_Name=@name,Category=@category,Quantity=@quantity,Description=@description  where SId=@SId", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@SId", this.SId);
                cmd.Parameters.AddWithValue("@name",name.Text);
                cmd.Parameters.AddWithValue("@category", category.Text);
                cmd.Parameters.AddWithValue("@quantity", quantity.Text);
                cmd.Parameters.AddWithValue("@description", description.Text);
                cmd.ExecuteNonQuery();


                SqlDataAdapter sda = new SqlDataAdapter("select * from stock", con);
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
            try
            {

            
            if (SId > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from stock where SId=@SId", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@SId", this.SId);
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter sda = new SqlDataAdapter("select * from stock", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
               MessageBox.Show("data deleted");
            }
            else
                MessageBox.Show("select product to delete");
          
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SId = 0;
            name.Items.Clear();
            category.Items.Clear();
            quantity.Clear();
            description.Clear();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            string s = search.Text + "%";
            SqlDataAdapter sda = new SqlDataAdapter("select * from stock where Product_Name like ('" + s + "')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                SId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                category.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                quantity.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                description.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch (System.InvalidCastException ex)
            {

            }
        }
        void fillCategory()
        {
            string query = "select * from product";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr;
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("Product_Name", typeof(string));

                rdr = cmd.ExecuteReader();
                dt.Load(rdr);
                name.ValueMember = "Product_Name";
                category.ValueMember = "Product_Type";
                name.DataSource = dt;
                category.DataSource = dt;
                con.Close();

            }
            catch
            {

            }
        }
            private void Stock_Load(object sender, EventArgs e)
        {
            fillCategory();
        }

        private void name_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                category.Focus();
            }
        }

        private void category_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                quantity.Focus();
            }
        }

        private void quantity_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                description.Focus();
            }
        }
    }
}
