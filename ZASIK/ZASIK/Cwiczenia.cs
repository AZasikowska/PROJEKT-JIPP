using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZASIK
{
    public partial class Cwiczenia : Form
    {
        SqlDataAdapter adapt;
        DataTable dt;

        public Cwiczenia()
        {
            InitializeComponent();
        }

        delegate void Zadanie(DataTable dane);

        private void Aktualizacjadanych(DataTable dt)
        {
            if (dataGridView1.InvokeRequired)
            {
                Zadanie z = Aktualizacjadanych;
                this.Invoke(z, dt);
            }

            else
            {

                dataGridView1.DataSource = dt;
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
         
            string connectionString = "server= NT-27.WWSI.EDU.pl,1601; database=KASETY_404_20; user=Z404_20; password=Z404_20"; 
            SqlConnection connection = new SqlConnection(connectionString);

            adapt = new SqlDataAdapter(@"Select Data, Cwiczenie AS Nazwa_ćwiczenia ,IloscSerii AS Ilość_serii, IloscPowtorzen AS Ilość_powtórzeń, Ciezar AS Ciężar FROM Cwiczenia", connection);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "server= NT-27.WWSI.EDU.pl,1601; database=KASETY_404_20; user=Z404_20; password=Z404_20"; 
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            String query = "INSERT INTO Cwiczenia (Data, Cwiczenie,IloscSerii, IloscPowtorzen, Ciezar) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "' )";
            SqlDataAdapter Adapt = new SqlDataAdapter(query, connection);
            Adapt.SelectCommand.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Zapisano");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
