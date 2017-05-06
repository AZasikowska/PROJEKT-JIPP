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

namespace ZASIK
{
    public partial class Logowanie : Form
    {
        public Logowanie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string connectionString = "server= NT-27.WWSI.EDU.pl,1601; database=KASETY_404_20; user=Z404_20; password=Z404_20";
        private void button2_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    label3.Text = "Connection Established!";
                }
                else
                {
                    label3.Text = "Connection Error!";
                }
            }
            
                this.Hide();
            new Form1().Show();

    }

        private void Logowanie_Load(object sender, EventArgs e)
        {

        }
    }
}
