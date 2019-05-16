using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace video
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer cust = new Customer();
            cust.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Movies mov = new Movies();
            mov.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rental rent = new Rental();
            rent.Show();
        }
    }
}
