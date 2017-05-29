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
            Task.WaitAll();
            this.Close();
        }

        string connectionString = "server= NT-27.WWSI.EDU.pl,1601; database=KASETY_404_20; user=Z404_20; password=Z404_20";  

        private void button2_Click(object sender, EventArgs e) 
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand();
                SqlDataReader reader;

                command.CommandText = "SELECT * from  [KASETY_404_20].[Z404_20].[Users] ;";
                command.CommandType = CommandType.Text;
                command.Connection = connection;

                connection.Open();
                reader = command.ExecuteReader();
                if (connection.State == ConnectionState.Open)
                {

                    String login;
                    String haslo;
                    while (reader.Read())
                    {
                        login = reader.GetValue(1).ToString();
                        haslo = reader.GetValue(2).ToString();

                        if (this.textBox1.Text == login && this.textBox2.Text == haslo)
                        {
                            progressBar1.Visible = true;
                            label4.Text = string.Format("Logowanie..");
                            timer1.Start();
                        }

                        else
                        {
                            label3.Text = "Nieprawidłowy login lub hasło!";
                        }
                    }


                }
            }
        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = Convert.ToInt32(progressBar1.Value) + 15;
            if (Convert.ToInt32(progressBar1.Value) > 85)

            {
                timer1.Stop();
                new Form1().Show();
                this.Hide();
            }


        }


    }
}
