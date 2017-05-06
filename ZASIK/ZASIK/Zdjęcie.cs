using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZASIK
{
    public partial class Zdjęcie : Form
    {
        private Graphics g;
        private Point p = Point.Empty;
        private Pen pioro;

        public Zdjęcie()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(200, 200);
            g = Graphics.FromImage(pictureBox1.Image);
            pioro = new Pen(Color.Black);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                p = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                g.DrawLine(pioro, p, e.Location);
                p = e.Location;
                pictureBox1.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = button1.BackColor;
            dialog.ShowDialog();
            label1.BackColor = dialog.Color;
            pioro.Color = dialog.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
       
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Images | *.jpg";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image = Image.FromFile(dialog.FileName);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void btn_tarti_zapisz(object sender, EventArgs e)
        {
            // pobierz obrazek
            
            Button button1 = (Button)sender; // rzutowanie, by określić konkretny obiekt "by mieć więcej możliwości"
            Image addedImage = this.pictureBox1.Image;//Tworzę nowy obiekt przypisujący zdjęcie


            //Wrzucam do bazy danych
            //String hostname;
            //String username;
            //String password;
            //string databaseName;
            /*
            Connection conn = mydsqlDatabaseSource(hostname, username, password, databaseName);

            
            ResultSet rs = conn.query("Select * from users");
            Row row;
            while((row = rs.next()) != null)
            {
                row["id"];
                row["name"];
                row["username"];
                row["status"];

            }
            

            conn.query(Insert into databaseName values("id", "name", "username", "status") ("1", "Kamil", "Tarti", "Wolny"));

            conn.close();
            //wyświetl obrazek na Form1
            this.homePage.pictureBox2.Image = addedImage;
            this.Close();
            */
            // zapisz go w bazie danych
            // ukryj lub wylacz ten widok
            // pokaz glowny widok
            // zupdajtuj obrazek
        }
    }
}
