using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace carte_etudiant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Nom";
            dataGridView1.Columns[1].Name = "Prenom";
            dataGridView1.Columns[2].Name = "Classe";
            dataGridView1.Columns[3].Name = "CIN";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            dataGridView1.Rows.Add(textBox1.Text,textBox2.Text,textBox4.Text,textBox3.Text);

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            String barcode = textBox3.Text;
            Bitmap image = new Bitmap(barcode.Length * 200, 1000);
            Graphics g = Graphics.FromImage(image);

            Font fontcode = new Font("Code 128", 50);
            Font font = new Font("Monotype consva", 18);

            PointF point1 = new PointF(20, 220);
            PointF point2 = new PointF(100, 10);
            PointF point23 = new PointF(160, 10);
            PointF point3 = new PointF(100, 40);
            PointF point33 = new PointF(200, 40);
            PointF point4 = new PointF(100, 70);
            PointF point43 = new PointF(200, 70);

            SolidBrush black = new SolidBrush(Color.Black);
            SolidBrush white = new SolidBrush(Color.White);

            g.FillRectangle(white, 0, 0, image.Width, image.Height);
            g.DrawString(barcode, fontcode, black, point1);
            g.DrawString("Nom: ", font, black, point2);
            g.DrawString(textBox1.Text, font, black, point23);
            g.DrawString("Prenom: ", font, black, point3);
            g.DrawString(textBox2.Text, font, black, point33);
            g.DrawString("Classe: ", font, black, point4);
            g.DrawString(textBox4.Text, font, black, point43);


            MemoryStream imageinmemory = new MemoryStream();
            image.Save(imageinmemory, ImageFormat.Jpeg);
            pictureBox1.Image = image;
            
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
           
            OpenFileDialog open = new OpenFileDialog();
            // image filters
           // open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
               
                pictureBox2.Image = new Bitmap(open.FileName);
               

                // image file path
                textBox5.Text = open.FileName;
            }
        }
    }
}
