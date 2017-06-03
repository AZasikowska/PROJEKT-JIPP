﻿using System;
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
            label3.Text = "";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand();


                command.CommandText = "SELECT count(*) from  [KASETY_404_20].[Z404_20].[Users] where login = '" + textBox1.Text + "' AND haslo ='" + textBox2.Text + "';";
                command.CommandType = CommandType.Text;
                command.Connection = connection;

                connection.Open();
                int isCorrect = (int)command.ExecuteScalar();
                connection.Close();
                if (isCorrect == 1)
                {
                    progressBar1.Visible = true;
                    label4.Text = string.Format("Logowanie..");
                    timer1.Start();
                }
                else
                {
                    label3.Text = "Nieprawidłowy login lub hasło!";
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
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
