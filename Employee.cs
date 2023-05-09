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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-L780H7UQ;Initial Catalog=Inventory_Management_System;Integrated Security=True");
       public int ID;
        private void Employee_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter adapter=new SqlDataAdapter("select  ID,Name,Designation,Salary,Mobile,Email,Address,Sex,DOB,Father_Name,Citizenship_No,Martial_Status,Type,Username from Employee1",con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource=dt;
            con.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(name.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Name !");
                }
                else if (designation.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Designation ! ");
                }
                else if (salary.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Salary !");
                }
                else if (mobile.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Mobile Number !");
                }
                else if (email.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Email Address !");
                }
                else if (sex.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Sex/Gender !");
                }
                else if (dob.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Date Of Birth(DOB) !");
                }
                else if (fname.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Father's Name !");
                }
                else if (textBox1.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Citizenship Number !");
                }
                else if (marriage.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter Martial status !");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into dbo.employee1 values('" + name.Text + "','" + designation.Text + "','" + salary.Text + "','" + mobile.Text + "','" + email.Text + "','" + address.Text + "','" + sex.Text + "','" + dob.Text + "','" + fname.Text + "','" + textBox1.Text + "','" + marriage.Text + "','" + comboBox1.Text + "','" + username.Text + "','" + password.Text + "' )", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Inserted");

                    SqlDataAdapter adapter = new SqlDataAdapter("select ID,Name,Designation,Salary,Mobile,Email,Address,Sex,DOB,Father_Name,Citizenship_No,Martial_Status,Type,Username from employee1", con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    // print
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
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
            SqlDataAdapter sda = new SqlDataAdapter("select * from employee1", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (ID > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE dbo.employee1 set Name=@name,Designation=@designation,Salary=@salary,Mobile=@mobile,Email=@email,Address=@address ,Sex=@sex,DOB=@dob,Father_Name=@fname,Citizenship_No=@textBox1,Martial_Status=@Marriage,Type=@type,Username=@user,Password=@pass  where ID=@ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.ID);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@designation", designation.Text);
                cmd.Parameters.AddWithValue("@salary", salary.Text);
                cmd.Parameters.AddWithValue("@mobile", mobile.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@address", address.Text);
                cmd.Parameters.AddWithValue("@sex", sex.Text);
                cmd.Parameters.AddWithValue("@dob", dob.Text);
                cmd.Parameters.AddWithValue("@fname", fname.Text);
                cmd.Parameters.AddWithValue("@textBox1", textBox1.Text);
                cmd.Parameters.AddWithValue("@marriage", marriage.Text);
                cmd.Parameters.AddWithValue("@comboBox1", comboBox1.Text);
                cmd.Parameters.AddWithValue("@user", user.Text);
                cmd.Parameters.AddWithValue("@pass", pass.Text);
                cmd.Parameters.AddWithValue("@type", type.Text);

                cmd.ExecuteNonQuery();


                SqlDataAdapter sda = new SqlDataAdapter("select ID,Name,Designation,Salary,Mobile,Email,Address,Sex,DOB,Father_Name,Citizenship_No,Martial_Status,Type,Username from employee1", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();

                MessageBox.Show("data updated");
                
            }
            else
                MessageBox.Show("select employee1 to update");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ID > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from employee1 where ID=@ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.ID);
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter sda = new SqlDataAdapter("select ID,Name,Designation,Salary,Mobile,Email,Address,Sex,DOB,Father_Name,Citizenship_No,Martial_Status,Type,Username from employee1", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                MessageBox.Show("data deleted");
            }
            else
                MessageBox.Show("select employee1 to delete");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ID = 0;
            name.Clear();
            designation.Clear();
            salary.Clear();
            mobile.Clear();
            email.Clear();
            dob.Clear();
            address.Clear();
            textBox1.Clear();
            fname.Clear();

           

           
        }

        private void search_TextChanged(object sender, EventArgs e)
        {

            con.Open();
            string s = search.Text + "%";
            SqlDataAdapter sda = new SqlDataAdapter("select * from employee1 where Name like ('" + s + "')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                designation.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                salary.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                mobile.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                email.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                address.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                sex.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                dob.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                fname.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                marriage.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                username.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
            }
            catch (System.InvalidCastException ex)
            {

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Username : " + username.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 50));
            e.Graphics.DrawString("Type : " + comboBox1.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 100));
            e.Graphics.DrawString("Password : " + password.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 150));
            e.Graphics.DrawString("Please Change Password !", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 250));
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void name_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                designation.Focus();
            }
        }

        private void salary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mobile.Focus();
            }
        }

        private void designation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                salary.Focus();
            }
        }

        private void mobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                email.Focus();
            }
        }

        private void email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                address.Focus();
            }
        }

        private void address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sex.Focus();
            }
        }

        private void sex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dob.Focus();
            }
        }

        private void fname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        private void dob_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void marriage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                marriage.Focus();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                username.Focus();
            }
        }

        private void username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                password.Focus();
            }
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            string suffix = passwordgenerator.GeneratePassword(3);
            username.Text = name.Text + suffix;
            string pw=passwordgenerator.GeneratePassword(8);
            password.Text = pw;
            
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
