using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Triangle
{
    public partial class Form1 : Form
    {
        Bitmap main; 

        public Form1()
        {
            InitializeComponent(); // инициализация формы
            main = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        View view = new View(); // создание экземпляра класса View
        Controller ctrl = new Controller(); //создание экземпляра класса Controller

        int getX = -2;
        int getY = -2;

        private void button1_Click(object sender, EventArgs e)
        {
            main = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = null;
            pictureBox1.BackgroundImage = null;
            pictureBox1.Refresh(); // обновление холста
            ctrl.ClearDots(); // выгрузка списков, содержащих координаты точек
        }
        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e) // обработчик клика кнопкой мыши
        {
            getX = e.X;
            getY = e.Y;

            Graphics g = Graphics.FromImage(main); // инициализация работы с графикой
            if (ctrl.SetupDot(getPB, getX, getY)) // проверка на количество добавленных точек на холсте
            {
                g.DrawEllipse(new Pen(new SolidBrush(Color.Red), 4), getX - 7, getY - 7, 15, 15); // отрисовка красных кругов (точек-середин сторон)
                pictureBox1.BackgroundImage = main;
            }
            GC.Collect(); // очистка памяти
        }

        public PictureBox getPB // метод получения элемента холста (PictureBox1)
        {
            get
            {
                return pictureBox1;
            }

        }
    }
}
