using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_04
{
    public partial class Form1 : Form
    {
        Methods md = new Methods();

        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            md.loadOriginalImage();
            
            md.convertToGray();
            pictureBox1.ImageLocation = "gray.jpg";

            md.createEmptyPlanes();
            md.SeperateBitPlanes();

            pictureBox2.ImageLocation = "Bit Plane 1.jpg";
            pictureBox3.ImageLocation = "Bit Plane 2.jpg";
            pictureBox4.ImageLocation = "Bit Plane 3.jpg";
            pictureBox5.ImageLocation = "Bit Plane 4.jpg";
            pictureBox6.ImageLocation = "Bit Plane 5.jpg";
            pictureBox7.ImageLocation = "Bit Plane 6.jpg";
            pictureBox8.ImageLocation = "Bit Plane 7.jpg";
            pictureBox9.ImageLocation = "Bit Plane 8.jpg";
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
             md.combinePlanes();
             pictureBox10.ImageLocation = "CombinedImage.jpg";            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
