using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace video
{

    public partial class Customer : Form
    {
        SqlDataAdapter adap = new SqlDataAdapter();
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        DataSet d = new DataSet();
        public Customer()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox5.Text = row.Cells[0].Value.ToString();

                textBox1.Text = row.Cells[2].Value.ToString();
                textBox2.Text = row.Cells[3].Value.ToString();
                textBox3.Text = row.Cells[4].Value.ToString();
                textBox4.Text = row.Cells[5].Value.ToString();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Close();
            operationclass f = new operationclass();
            string str = f.connectionstring();

            try
            {

                con.ConnectionString = str;
                com.CommandType = CommandType.Text;
                com.CommandText = "insert into Customer (FirstName,LastName,Address,Phone)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";

                adap.InsertCommand = com;
                com.Connection = con;
                con.Open();
                com.ExecuteNonQuery();
                MessageBox.Show("Cutomer Added");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
           
             
                
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Close();
            operationclass f = new operationclass();
            string str = f.connectionstring();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + str + "Database1.mdf" + ";Integrated Security=True";
            com.CommandType = CommandType.Text;
            com.CommandText = "update Customer set FirstName='" + textBox1.Text + "',LastName='" + textBox2.Text + "',Address='" + textBox3.Text + "',Phone='" + textBox4.Text + "' where CustID=" + textBox5.Text;

            adap.UpdateCommand = com;
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
           
             
                MessageBox.Show("Customer Updated");
             
        }

        private void button3_Click(object sender, EventArgs e)
        {
            operationclass f = new operationclass();
            con.Close();
            string str = f.connectionstring();


            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + str + "Database1.mdf" + ";Integrated Security=True";
            com.CommandType = CommandType.Text;
            com.CommandText = "delete from Customer where CustID=" + textBox5.Text;

            adap.DeleteCommand = com;
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
      
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";


            MessageBox.Show("Customer deleted");
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet6.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.database1DataSet6.Customer);

        }
    }
}
