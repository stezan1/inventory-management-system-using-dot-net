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
    public partial class Purchase : Form
    {
        public Purchase()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-L780H7UQ;Initial Catalog=Inventory_Management_System;Integrated Security=True");
        int PId;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (name.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Product Name!");
                }
                else if (quantity.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Quantity ! ");
                }
                else if (category.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter category !");
                }
                else if (dealer.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Dealer Name !");
                }
                else if (dealcontact.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Dealer Contact !");
                }
                else if (date.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Date !");
                }
                else if (cost.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Cost !");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into dbo.purchase values('" + name.Text + "','" + quantity.Text + "','" + category.Text + "','" + dealer.Text + "','" + dealcontact.Text + "','" + date.Text + "','" + cost.Text + "' )", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Inserted");

                    SqlDataAdapter adapter = new SqlDataAdapter("select * from purchase", con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Exception unhandled" + ex);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from purchase", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                PId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                quantity.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                category.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                dealer.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                dealcontact.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                date.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                cost.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            }
            catch (System.InvalidCastException ex)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (PId > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE dbo.purchase set Item_Name=@name,Quantity=@quantity,Dealer_Name=@dealer,Dealer_Contact=@dealcontact,Date=@date,Cost_Per_Item=@cost  where PID=@PID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@PId", this.PId);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@quantity", quantity.Text);
                cmd.Parameters.AddWithValue("@category", category.Text);
                cmd.Parameters.AddWithValue("@dealer", dealer.Text);
                cmd.Parameters.AddWithValue("@dealcontact", dealcontact.Text);
                cmd.Parameters.AddWithValue("@date", date.Text);
                cmd.Parameters.AddWithValue("@cost", cost.Text);
                cmd.ExecuteNonQuery();


                SqlDataAdapter sda = new SqlDataAdapter("select * from purchase", con);
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
            if (PId > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from purchase where PId=@PId", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@PId", this.PId);
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
            PId = 0;
          
            quantity.Clear();
            
            dealer.Clear();
            dealcontact.Clear();
            date.Clear();

        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            string s = search.Text + "%";
            SqlDataAdapter sda = new SqlDataAdapter("select * from purchase where Item_Name like ('" + s + "')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
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
                cost.ValueMember = "Cost";
                name.DataSource = dt;
                category.DataSource = dt;
                cost.DataSource = dt;
                con.Close();

            }
            catch
            {

            }
        }
        private void Purchase_Load(object sender, EventArgs e)
        {
            fillCategory();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                PId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                quantity.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                category.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                dealer.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                dealcontact.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                date.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                cost.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            }
            catch (System.InvalidCastException ex)
            {

            }
        }

        private void name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                category.Focus();
            }
        }

        private void quantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dealer.Focus();
            }
        }

        private void category_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                quantity.Focus();
            }
        }

        private void dealer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dealcontact.Focus();
            }
        }

        private void dealcontact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                date.Focus();
            }
        }

        private void date_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cost_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void quantity_TextChanged(object sender, EventArgs e)
        {
            long c;
            if (!long.TryParse(quantity.Text, out c))
            {
                quantity.Text = "";
            }
            else if (quantity.Text.Equals(string.Empty))
            {
                total.Text = "0";
            }
            else
            {
                string a = quantity.Text;
                string b = cost.Text;
                float t = Convert.ToInt32(a) * Convert.ToInt32(b);
                total.Text = t.ToString();
            }
        }

        private void cost_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (quantity.Text.Equals(string.Empty))
            {
                total.Text = "0";
            }
            else
            {
                string a = quantity.Text;
                string b = cost.Text;
                float t = Convert.ToInt32(a) * Convert.ToInt32(b);
                total.Text = t.ToString();
        }   }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Welcome to sudur Paschim Enterprises", new Font("Arial", 35, FontStyle.Regular), Brushes.Black, new Point(0, 0));
            e.Graphics.DrawString("Item_Name : " + name.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 50));
            e.Graphics.DrawString("Dealer_Name : " + dealer.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 100));
            e.Graphics.DrawString("Dealer_Contact : " +dealcontact.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 150));
            e.Graphics.DrawString("Category : " + category.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 200));
            e.Graphics.DrawString("Quantity : " + quantity.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 250));
            e.Graphics.DrawString("Date : " + date.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 300));
            e.Graphics.DrawString("Total_Cost : " + total.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 350));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
