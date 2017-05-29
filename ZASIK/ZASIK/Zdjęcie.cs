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

            Bitmap sepiaEffect = (Bitmap)pictureBox1.Image.Clone();
            for (int yCoordinate = 0; yCoordinate < sepiaEffect.Height; yCoordinate++)
            {
                for (int xCoordinate = 0; xCoordinate < sepiaEffect.Width; xCoordinate++)
                {
                    Color color = sepiaEffect.GetPixel(xCoordinate, yCoordinate);
                    double grayColor = ((double)(color.R + color.G + color.B)) / 3.0d;
                    Color sepia = Color.FromArgb((byte)grayColor, (byte)(grayColor * 0.95), (byte)(grayColor * 0.82));
                    sepiaEffect.SetPixel(xCoordinate, yCoordinate, sepia);
                }
                pictureBox1.Image = sepiaEffect;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Images | *.jpg; *.png";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image = Image.FromFile(dialog.FileName);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button button1 = (Button)sender;
            Image addedImage = this.pictureBox1.Image;
            this.homePage.pictureBox2.Image = addedImage;
            this.Close();
        }
    }
}
