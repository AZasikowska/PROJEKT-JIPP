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
    }
}
