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

        string connectionString = "server= NT-27.WWSI.EDU.pl,1601; database=KASETY_404_20; user=Z404_20; password=Z404_20"; // server - hostname 

        private void button2_Click(object sender, EventArgs e) 
        {        

            using (SqlConnection connection= new SqlConnection(connectionString))// nowe połączenie 
            {

                SqlCommand command = new SqlCommand(); // Konstruktor to po słowie NEW! , tworzę obiekt, który tworzy komendy
                SqlDataReader reader; 

                command.CommandText = "SELECT * from  [KASETY_404_20].[Z404_20].[Users];";
                command.CommandType = CommandType.Text; 
                command.Connection = connection; // moja komenda z moją bazą danych (połączenie)

                connection.Open(); // konkretny typ 
                reader = command.ExecuteReader(); // konkretna komenda 
                if (connection.State == ConnectionState.Open)
                {

                    String name;
                    String haslo;
                    while (reader.Read())
                    {
                        name = reader.GetValue(1).ToString();
                        haslo = reader.GetValue(2).ToString();
                        if (this.textBox1.Text == name && this.textBox2.Text == haslo) // Jeśli się zgadza z bazą (przeszukanie)
                        {

                            this.Hide();
                            new Form1().Show();
                        }

                        else
                        {
                            label3.Text = "Bad login or password";
                        }
                    }


                }
            }
        }

        private void Logowanie_Load(object sender, EventArgs e)
        {

        }
    }
}
