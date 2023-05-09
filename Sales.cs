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
    public partial class sales : Form
    {
        public sales()
        {
            InitializeComponent();
            
        }
        public int SID;
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-L780H7UQ;Initial Catalog=Inventory_Management_System;Integrated Security=True");
        
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
                item.DataSource = dt;
                cost.DataSource = dt;
                category.DataSource = dt;
                item.ValueMember = "Product_Name";
                category.ValueMember = "Product_Type";
                cost.ValueMember = "Cost";
              
                con.Close();

            }
            catch
            {

            }
        }
            private void sales_Load(object sender, EventArgs e)
        {
            fillCategory();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (cid.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Customer Id !");
                }
                else if (name.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Customer Name ! ");
                }
                else if (mobile.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Customer Contact !");
                }
                else if (seller.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Seller Name !");
                }
                else if (item.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Item Name !");
                }
                else if (category.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Category Of Item !");
                }
                else if (quantity.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter No of quantity !");
                }
                else if (cost.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Cost Per Item !");
                }
                else if(date.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Date !");
                }

                else
                {
                    string query = @"INSERT INTO[dbo].[sales]
                    ([Customer_ID]
            ,[Customer_Name]
            ,[Customer_Contact]
            ,[Seller]
            ,[Item]
            ,[Category]
            ,[Quantity]
            ,[Cost_Per_Item]
            ,[Date])
     VALUES('" + cid.Text + "','" + name.Text + "','" + mobile.Text + "','" + seller.Text + "','" + item.Text + "','" + category.Text + "','" + quantity.Text + "','" + cost.Text + "','" + date.Text + "')";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Inseted Successfully");



                    SqlDataAdapter adapter = new SqlDataAdapter("select * from sales", con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from sales", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (SID > 0)
            {

            
                
                   con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE dbo.sales set Customer_Name=@name,Customer_ID=@cid,Customer_Contact=@mobile,Seller=@seller,Item=@item,Category=@category ,Quantity=@quantity,Cost_Per_Item=@cost,Date=@date where SID=@SID", con);
                    cmd.CommandType = CommandType.Text;
                   cmd.Parameters.AddWithValue("@SID", this.SID);
                    cmd.Parameters.AddWithValue("@cid", cid.Text);
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@mobile", mobile.Text);
                    cmd.Parameters.AddWithValue("@seller", seller.Text) ;
                   cmd.Parameters.AddWithValue("@item", item.Text);
                   cmd.Parameters.AddWithValue("@category", category.Text);
                    cmd.Parameters.AddWithValue("quantity", quantity.Text);
                    cmd.Parameters.AddWithValue("@cost", cost.Text);
                    cmd.Parameters.AddWithValue("@date", date.Text);
                    cmd.ExecuteNonQuery();


                   SqlDataAdapter sda = new SqlDataAdapter("select * from sales", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                MessageBox.Show("data updated");
                con.Close();
 //               string query = @"UPDATE[dbo].[sales]
 //  SET Customer_ID = @cid
 //     ,Customer_Name =@name
 //     ,Customer_Contact =@mobile
 //     ,Seller = @seller
 //     ,Item =@item
 //     ,Category =@category
 //     ,Quantity =@category
 //     ,Cost_Per_Item = @cost
 //     ,Date =@date
 //WHERE SID=@SID";
 //               con.Open();
 //               SqlCommand cmd=new SqlCommand(query, con);
 //               SqlDataAdapter sda = new SqlDataAdapter("select * from sales",con);
 //               DataTable dt = new DataTable();
 //               sda.Fill(dt);
 //               dataGridView1.DataSource = dt;
 //               con.Close();
 //           MessageBox.Show("data updated");
            }
            else
                MessageBox.Show("select sales to update");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (SID > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from sales where SID=@SID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@SID", this.SID);
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter sda = new SqlDataAdapter("select * from sales", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                MessageBox.Show("data deleted");
            }
            else
                MessageBox.Show("select from sales to delete");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                SID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                cid.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                name.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                mobile.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                seller.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                item.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                category.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                quantity.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                cost.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                date.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            }
            catch (System.InvalidCastException ex)
            {

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SID = 0;
            cid.Clear();
            name.Clear();
           mobile.Clear();
            seller.Clear();
            
            date.Clear();
            
          
        }

        private void cost_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void quantity_TextChanged(object sender, EventArgs e)
        {
            long c;          
            if(!long.TryParse(quantity.Text, out c))
            {
                quantity.Text = "";
            }
            else if (quantity.Text.Equals(string.Empty))
            {
                total.Text = "0";
            }
            else
            {
                string a=quantity.Text;
                string b=cost.Text;
                
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
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Welcome to sudur Paschim Enterprises", new Font("Arial", 35, FontStyle.Regular), Brushes.Black, new Point(0, 0));
            e.Graphics.DrawString("Customer_Name : " + name.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 50));
            e.Graphics.DrawString("Seller : " + seller.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 100));
            e.Graphics.DrawString("Item : " + item.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 150));
            e.Graphics.DrawString("Category : " + category.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 200));
            e.Graphics.DrawString("Quantity : " + quantity.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 250));
            e.Graphics.DrawString("Date : " + date.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 300));
            e.Graphics.DrawString("Total_Cost : " + total.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 350));
        }

        private void cid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                name.Focus();
            }
        }

        private void mobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                seller.Focus();
            }
        }

        private void name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mobile.Focus();
            }
        }

        private void seller_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                item.Focus();
            }
        }

        private void category_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                quantity.Focus();
            }
        }

        private void item_KeyDown(object sender, KeyEventArgs e)
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
                date.Focus();
            }
        }

        private void cost_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void date_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rate_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string a = quantity.Text;
            string b = cost.Text;
            string d = rate.Text;

            double t = Convert.ToDouble(a) * Convert.ToDouble(b) * Convert.ToDouble(d);
            total.Text = t.ToString();
        }

        private void seller_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
