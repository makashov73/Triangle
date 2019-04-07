using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace Triangle
{
    class View
    {
        Bitmap pic;

        public void DrawDot(PictureBox map, int x, int y) // метод рисования окружности (точки-середины стороны)
        {
            pic = new Bitmap(map.Width, map.Height);
            Graphics g = Graphics.FromImage(pic);
            Pen p = new Pen(Color.Red, 3);
            var cursorPosition = map.PointToClient(Cursor.Position); // определение координат текущего положения мыши над элементом map (PictureBox1)
            g.DrawEllipse(p, cursorPosition.X-7, cursorPosition.Y-7, 15, 15); // отрисовка окружности (точки-серидины стороны)
            map.Image = pic;
        }

        public void DrawTriangle(PictureBox map, List<Point> newpoints) // метод рисования треугольника
        {
            List<Point> points = new List<Point>();
            points = newpoints;
            Point[] pts = points.ToArray();
            Graphics g = Graphics.FromImage(pic);
            Pen p = new Pen(Color.Black, 2);
            g.DrawLines(p, pts); // метод рисования линий по массиву координат
            map.Image = pic;
            GC.Collect(); // очистка памяти
        }

        
    }
}
