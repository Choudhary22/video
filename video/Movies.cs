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
    public partial class Movies : Form
    {
        SqlDataAdapter adap = new SqlDataAdapter();
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        DataSet d = new DataSet();
        public Movies()
        {
            InitializeComponent();
        }

        private void Movies_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet3.Movies' table. You can move, or remove it, as needed.
            this.moviesTableAdapter.Fill(this.database1DataSet3.Movies);

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                    textBox6.Text = row.Cells[0].Value.ToString();
                    textBox7.Text = row.Cells[1].Value.ToString();
                    textBox8.Text = row.Cells[2].Value.ToString();
                    textBox9.Text = row.Cells[3].Value.ToString();
                    textBox10.Text = row.Cells[4].Value.ToString();
                    textBox11.Text = row.Cells[5].Value.ToString();
                    textBox12.Text = row.Cells[6].Value.ToString();
                    textBox13.Text = row.Cells[7].Value.ToString();


                }
            }
            catch (Exception e1)
            {
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            operationclass f = new operationclass();
            con.Close();
            string str = f.connectionstring();
            int year1 = Convert.ToInt16(textBox9.Text);
            string rent = "";
            if (2019 - year1 > 5)
            {
                rent = "2";
            }
            else
            {
                rent = "5";
            }

            con.ConnectionString = str;
            com.CommandType = CommandType.Text;
            com.CommandText = "insert into Movies values('" + textBox7.Text + "','" + textBox8.Text + "','" + year1 + "'," + rent + ",'" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "')";

            adap.InsertCommand = com;
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
            
                MessageBox.Show("New Movie Inserted");
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            operationclass f = new operationclass();
            con.Close();
            string str = f.connectionstring();
            int year1 = Convert.ToInt16(textBox9.Text);
            string rent = "";
            if (2019 - year1 > 5)
            {
                rent = "2";
            }
            else
            {
                rent = "5";
            }

            con.ConnectionString = str;
            com.CommandType = CommandType.Text;

            com.CommandText = "update Movies set Rating='" + textBox7.Text + "',Title='" + textBox8.Text + "',Year='" + year1 + "',Rental_Cost=" + rent + ",Copies='" + textBox11.Text + "',Genre='" + textBox13.Text + "' where MovieID=" + textBox6.Text;

            adap.UpdateCommand = com;
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
           
            MessageBox.Show("Movie Updated");
        }

        private void button5_Click(object sender, EventArgs e)
        {

            operationclass d = new operationclass();
            con.Close();
            string str = d.connectionstring();


           
            com.CommandType = CommandType.Text;
            com.CommandText = "delete Movies where MovieID=" + textBox6.Text;

            adap.DeleteCommand = com;
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
            
          
                MessageBox.Show("Movie Deleted");
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                

                      
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
