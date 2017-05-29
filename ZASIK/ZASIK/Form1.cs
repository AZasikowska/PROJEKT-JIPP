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
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zdjęcie zdj = new Zdjęcie(); // tworzę nowy obiekt(panel- zdjęcie)
            zdj.homePage = this; // przypisuję form1 do nowo utworzonego obiektu zdjecie
            zdj.Show();
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
          

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void zamknijToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void zalogujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Zdjęcie().Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_click(object sender, EventArgs e)
        {
            this.Hide();
            new Panel().Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Gray, 576, 507, 116, 15);
            e.Graphics.DrawString("Agnieszka Zasikowska", this.Font, Brushes.Black, 576, 507);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Cwiczenia().Show();
            this.Hide();
        }
    }
    }
   
    
   