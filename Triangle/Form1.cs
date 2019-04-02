using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangle
{
    public partial class Form1 : Form
    {
        Bitmap main;

        public Form1()
        {
            InitializeComponent();
            main = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        View view = new View();
        Controller ctrl = new Controller();

        int getX = -2;
        int getY = -2;

        private void button1_Click(object sender, EventArgs e)
        {
            main = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = null;
            pictureBox1.BackgroundImage = null;
            pictureBox1.Refresh();
            ctrl.ClearDots();
        }
        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            getX = e.X;
            getY = e.Y;
            
            Graphics g = Graphics.FromImage(main);
            if (ctrl.SetupDot(getPB, getX, getY))
            {
                g.DrawEllipse(new Pen(new SolidBrush(Color.Red), 4), getX - 7, getY - 7, 15, 15);
                pictureBox1.BackgroundImage = main;
            }
            GC.Collect();
        }

        public PictureBox getPB
        {
            get
            {
                return pictureBox1;
            }

        }
    }
}
