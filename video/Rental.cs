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
    public partial class Rental : Form
    {
        SqlDataAdapter adap = new SqlDataAdapter();
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        DataSet d = new DataSet();
        public Rental()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            operationclass d = new operationclass();
            con.Close();
            con.ConnectionString = d.connectionstring();
            com.CommandType = CommandType.Text;

            com.CommandText = "insert into RentedMovies (MovieIDFK,CustIDFK,DateRented)values(" + textBox15.Text + "," + textBox16.Text + ",'" + textBox17.Text + "')";

            adap.InsertCommand = com;
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
            
            
            
                MessageBox.Show("Movie Issued");
            
        }

        private void Rental_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet5.RentedMovies' table. You can move, or remove it, as needed.
            this.rentedMoviesTableAdapter.Fill(this.database1DataSet5.RentedMovies);

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];

                textBox14.Text = row.Cells[0].Value.ToString();

                textBox15.Text = row.Cells[1].Value.ToString();
                textBox16.Text = row.Cells[2].Value.ToString();
                textBox17.Text = row.Cells[3].Value.ToString();
                textBox18.Text = row.Cells[4].Value.ToString();


            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            operationclass d = new operationclass();
            con.Close();



            con.ConnectionString = d.connectionstring();
            com.CommandType = CommandType.Text;
            com.CommandText = "update RentedMovies set DateReturned='" + textBox18.Text + "' where RMID=" + textBox14.Text;

            adap.UpdateCommand = com;
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
            
                MessageBox.Show("Movie returned");
            
                }
      private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            operationclass d = new operationclass();
            DataSet f = d.showcurrent();
            dataGridView4.DataSource = f.Tables[0];
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            operationclass d = new operationclass();
            DataSet f1 = d.mostpopular();
            dataGridView4.DataSource = f1.Tables[0];
        }
    }
}
